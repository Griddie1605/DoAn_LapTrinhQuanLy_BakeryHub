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
    public partial class frmNhapkho : Form
    {
        // 1. Khởi tạo class Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // 2. Bảng tạm chứa giỏ hàng nhập
        private DataTable dtHangNhap = new DataTable();

        public frmNhapkho()
        {
            InitializeComponent();
        }

        private void frmNhapkho_Load(object sender, EventArgs e)
        {
            KhoiTaoLuoi();
            LoadSanPhamVaoCombo();

            dtpNgayNhap.Value = DateTime.Now;
            dtpHanSuDung.Value = DateTime.Now.AddDays(7);
            txtNhanVien.Text = frmLogin.MaNhanVien;
        }

        private void KhoiTaoLuoi()
        {
            dtHangNhap = new DataTable();
            dtHangNhap.Columns.Add("MaSanPham", typeof(string));
            dtHangNhap.Columns.Add("TenSanPham", typeof(string));
            dtHangNhap.Columns.Add("SoLuong", typeof(int));
            dtHangNhap.Columns.Add("DonGia", typeof(decimal));
            dtHangNhap.Columns.Add("ThanhTien", typeof(decimal));
            dtHangNhap.Columns.Add("HanSuDung", typeof(DateTime));

            dgvChiTietNhap.DataSource = dtHangNhap;

            if (dgvChiTietNhap.Columns.Contains("MaSanPham")) dgvChiTietNhap.Columns["MaSanPham"].Visible = false;
            dgvChiTietNhap.Columns["TenSanPham"].HeaderText = "Tên Bánh";
            dgvChiTietNhap.Columns["SoLuong"].HeaderText = "SL";
            dgvChiTietNhap.Columns["DonGia"].HeaderText = "Giá Nhập";
            dgvChiTietNhap.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgvChiTietNhap.Columns["HanSuDung"].HeaderText = "Hạn Dùng";

            dgvChiTietNhap.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietNhap.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTietNhap.Columns["HanSuDung"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvChiTietNhap.Columns["TenSanPham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void LoadSanPhamVaoCombo()
        {
            try
            {
                // Thay thế SqlDataAdapter thủ công bằng hàm laydl
                string sql = "SELECT MaSanPham, TenSanPham FROM SanPham WHERE TrangThai = 1";
                cboSanPham.DataSource = db.laydl(sql);
                cboSanPham.DisplayMember = "TenSanPham";
                cboSanPham.ValueMember = "MaSanPham";
                cboSanPham.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi load sản phẩm: " + ex.Message); }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1) { MessageBox.Show("Chưa chọn bánh!"); return; }
            if (string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtDonGia.Text)) { MessageBox.Show("Nhập thiếu số lượng hoặc giá!"); return; }

            if (dtpHanSuDung.Value.Date <= dtpNgayNhap.Value.Date)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày nhập!", "Lỗi Date");
                return;
            }

            try
            {
                string maSP = cboSanPham.SelectedValue.ToString();
                string tenSP = cboSanPham.Text;
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal donGia = decimal.Parse(txtDonGia.Text);
                decimal thanhTien = soLuong * donGia;
                DateTime hanDung = dtpHanSuDung.Value.Date;

                bool daCo = false;
                foreach (DataRow dr in dtHangNhap.Rows)
                {
                    if (dr["MaSanPham"].ToString() == maSP && Convert.ToDateTime(dr["HanSuDung"]) == hanDung)
                    {
                        dr["SoLuong"] = int.Parse(dr["SoLuong"].ToString()) + soLuong;
                        dr["ThanhTien"] = decimal.Parse(dr["SoLuong"].ToString()) * donGia;
                        daCo = true;
                        break;
                    }
                }

                if (!daCo)
                {
                    dtHangNhap.Rows.Add(maSP, tenSP, soLuong, donGia, thanhTien, hanDung);
                }

                TinhTongTien();
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                cboSanPham.Focus();
            }
            catch { MessageBox.Show("Số lượng phải là số nguyên, đơn giá là số!"); }
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow dr in dtHangNhap.Rows)
            {
                tong += decimal.Parse(dr["ThanhTien"].ToString());
            }
            lblTongTien.Text = string.Format("Tổng tiền: {0:N0} đ", tong);
        }

        // --- PHẦN 3: LƯU VÀO CSDL (SỬ DỤNG TRANSACTION) ---
        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtHangNhap.Rows.Count == 0) return;

            // Mở kết nối thông qua db.cn
            if (db.cn.State == ConnectionState.Closed) db.cn.Open();
            SqlTransaction transaction = db.cn.BeginTransaction();

            try
            {
                // 1. INSERT PhieuNhapKho
                string sqlPhieu = @"INSERT INTO PhieuNhapKho (NgayNhap, NhaCungCap, MaNhanVien) 
                                    VALUES (@Ngay, @NCC, @MaNV);
                                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, db.cn, transaction);
                cmdPhieu.Parameters.AddWithValue("@Ngay", dtpNgayNhap.Value);
                cmdPhieu.Parameters.AddWithValue("@NCC", txtNhaCungCap.Text);
                cmdPhieu.Parameters.AddWithValue("@MaNV", frmLogin.MaNhanVien);

                int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                // 2. Duyệt từng dòng trong giỏ hàng
                foreach (DataRow dr in dtHangNhap.Rows)
                {
                    string maSP = dr["MaSanPham"].ToString();
                    int sl = Convert.ToInt32(dr["SoLuong"]);
                    decimal gia = Convert.ToDecimal(dr["DonGia"]);
                    DateTime hsd = Convert.ToDateTime(dr["HanSuDung"]);

                    // A. Lưu Chi tiết phiếu nhập
                    string sqlChiTiet = @"INSERT INTO ChiTietPhieuNhapKho (MaPhieuNhapKho, MaSanPham, SoLuong, DonGiaNhap) 
                                          VALUES (@MaPhieu, @MaSP, @SL, @Gia)";
                    SqlCommand cmdCT = new SqlCommand(sqlChiTiet, db.cn, transaction);
                    cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdCT.Parameters.AddWithValue("@MaSP", maSP);
                    cmdCT.Parameters.AddWithValue("@SL", sl);
                    cmdCT.Parameters.AddWithValue("@Gia", gia);
                    cmdCT.ExecuteNonQuery();

                    // B. Lưu vào bảng Lô hàng
                    string sqlLoHang = @"INSERT INTO LoHang (MaSanPham, NgayNhap, HanSuDung, SoLuongNhap, SoLuongHienTai)
                                         VALUES (@MaSP, @NgayNhap, @HSD, @SL, @SL)";
                    SqlCommand cmdLo = new SqlCommand(sqlLoHang, db.cn, transaction);
                    cmdLo.Parameters.AddWithValue("@MaSP", maSP);
                    cmdLo.Parameters.AddWithValue("@NgayNhap", dtpNgayNhap.Value);
                    cmdLo.Parameters.AddWithValue("@HSD", hsd);
                    cmdLo.Parameters.AddWithValue("@SL", sl);
                    cmdLo.ExecuteNonQuery();

                    // C. Cập nhật tồn kho tổng
                    string sqlCapNhatKho = @"UPDATE SanPham 
                                             SET SoLuongTon = ISNULL(SoLuongTon, 0) + @SLNhap,
                                                 GiaNhap = @GiaNhap
                                             WHERE MaSanPham = @MaSPKho";
                    SqlCommand cmdKho = new SqlCommand(sqlCapNhatKho, db.cn, transaction);
                    cmdKho.Parameters.AddWithValue("@SLNhap", sl);
                    cmdKho.Parameters.AddWithValue("@GiaNhap", gia);
                    cmdKho.Parameters.AddWithValue("@MaSPKho", maSP);
                    cmdKho.ExecuteNonQuery();
                }

                transaction.Commit();
                MessageBox.Show("Nhập kho thành công! Đã cập nhật Lô hàng và Tồn kho.");

                dtHangNhap.Clear();
                txtNhaCungCap.Text = "";
                lblTongTien.Text = "Tổng tiền: 0 đ";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Lỗi nhập kho: " + ex.Message);
            }
            finally
            {
                db.cn.Close(); // Luôn đóng kết nối
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvChiTietNhap.SelectedRows)
                {
                    if (!row.IsNewRow) dtHangNhap.Rows.RemoveAt(row.Index);
                }
                TinhTongTien();
            }
        }

        // Các hàm chặn ký tự (Giữ nguyên)
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}