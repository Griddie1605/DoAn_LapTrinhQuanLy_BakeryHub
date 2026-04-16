using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmHuyHang : Form
    {
        // 1. Sử dụng class Database thay vì chuỗi connectionString rời rạc
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // 2. Bảng tạm chứa danh sách hàng hủy
        private DataTable dtHangHuy = new DataTable();

        public frmHuyHang()
        {
            InitializeComponent();
        }

        private void frmHuyHang_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            LoadSanPhamVaoCombo();

            dtpNgayHuy.Value = DateTime.Now;
            txtNhanVien.Text = frmLogin.MaNhanVien;
        }

        private void KhoiTaoLuoi()
        {
            dtHangHuy.Columns.Add("MaSanPham", typeof(string));
            dtHangHuy.Columns.Add("TenSanPham", typeof(string));
            dtHangHuy.Columns.Add("SoLuong", typeof(int));

            dgvHuyHang.DataSource = dtHangHuy;

            if (dgvHuyHang.Columns.Contains("MaSanPham")) dgvHuyHang.Columns["MaSanPham"].Visible = false;
            dgvHuyHang.Columns["TenSanPham"].HeaderText = "Tên Bánh";
            dgvHuyHang.Columns["TenSanPham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvHuyHang.Columns["SoLuong"].HeaderText = "SL Hủy";
            dgvHuyHang.Columns["SoLuong"].Width = 80;
            dgvHuyHang.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void LoadSanPhamVaoCombo()
        {
            try
            {
                // Thay thế SqlDataAdapter thủ công bằng hàm laydl của class Database
                string sql = "SELECT MaSanPham, TenSanPham FROM SanPham";
                DataTable dt = db.laydl(sql);

                cboSanPham.DataSource = dt;
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";
                cboSanPham.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load sản phẩm: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1 || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bánh và nhập số lượng hủy!");
                return;
            }

            try
            {
                string maSP = cboSanPham.SelectedValue.ToString();
                string tenSP = cboSanPham.Text;
                int soLuong = int.Parse(txtSoLuong.Text);

                if (soLuong <= 0) { MessageBox.Show("Số lượng phải lớn hơn 0"); return; }

                bool daCo = false;
                foreach (DataRow dr in dtHangHuy.Rows)
                {
                    if (dr["MaSanPham"].ToString() == maSP)
                    {
                        dr["SoLuong"] = int.Parse(dr["SoLuong"].ToString()) + soLuong;
                        daCo = true;
                        break;
                    }
                }

                if (!daCo)
                {
                    dtHangHuy.Rows.Add(maSP, tenSP, soLuong);
                }

                txtSoLuong.Text = "";
                cboSanPham.Focus();
            }
            catch { MessageBox.Show("Số lượng phải là số nguyên!"); }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvHuyHang.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvHuyHang.SelectedRows)
                {
                    if (!row.IsNewRow) dtHangHuy.Rows.RemoveAt(row.Index);
                }
            }
        }

        // --- BƯỚC 3: LƯU VÀO CSDL (SỬ DỤNG TRANSACTION QUA DB.CN) ---
        private void btnLuuHuy_Click(object sender, EventArgs e)
        {
            if (dtHangHuy.Rows.Count == 0)
            {
                MessageBox.Show("Danh sách hủy đang trống!");
                return;
            }
            if (string.IsNullOrEmpty(txtLyDo.Text))
            {
                MessageBox.Show("Vui lòng ghi rõ Lý do hủy hàng!");
                txtLyDo.Focus();
                return;
            }

            // Mở kết nối thông qua đối tượng db
            if (db.cn.State == ConnectionState.Closed) db.cn.Open();
            SqlTransaction transaction = db.cn.BeginTransaction();

            try
            {
                // A. Tạo Phiếu Hủy
                string sqlPhieu = @"INSERT INTO PhieuHuy (NgayHuy, LyDo, MaNhanVien) 
                                    VALUES (GETDATE(), @LyDo, @MaNV); 
                                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, db.cn, transaction);
                cmdPhieu.Parameters.AddWithValue("@LyDo", txtLyDo.Text);
                cmdPhieu.Parameters.AddWithValue("@MaNV", txtNhanVien.Text);

                int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                // B. Lưu Chi Tiết & TRỪ KHO
                foreach (DataRow dr in dtHangHuy.Rows)
                {
                    // 1. Lưu chi tiết hủy
                    string sqlChiTiet = @"INSERT INTO ChiTietPhieuHuy (MaPhieuHuy, MaSanPham, SoLuongHuy) 
                                          VALUES (@MaPhieu, @MaSP, @SL)";

                    SqlCommand cmdCT = new SqlCommand(sqlChiTiet, db.cn, transaction);
                    cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdCT.Parameters.AddWithValue("@MaSP", dr["MaSanPham"]);
                    cmdCT.Parameters.AddWithValue("@SL", dr["SoLuong"]);
                    cmdCT.ExecuteNonQuery();

                    // 2. TRỪ TỒN KHO
                    string sqlTruKho = @"UPDATE SanPham 
                                         SET SoLuongTon = SoLuongTon - @SLHuy 
                                         WHERE MaSanPham = @MaSP";

                    SqlCommand cmdKho = new SqlCommand(sqlTruKho, db.cn, transaction);
                    cmdKho.Parameters.AddWithValue("@SLHuy", dr["SoLuong"]);
                    cmdKho.Parameters.AddWithValue("@MaSP", dr["MaSanPham"]);
                    cmdKho.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Đã hủy hàng thành công! Kho đã được cập nhật.");

                dtHangHuy.Clear();
                txtLyDo.Text = "";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Lỗi khi hủy hàng: " + ex.Message);
            }
            finally
            {
                db.cn.Close(); // Đảm bảo đóng kết nối sau khi xong Transaction
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXuatDSHoaDon_Click(object sender, EventArgs e)
        {

        }
    }
}