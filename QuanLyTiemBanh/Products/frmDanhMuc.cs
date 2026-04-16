using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BakeryHub
{
    public partial class frmDanhMuc : Form
    {
        // 1. Khởi tạo đối tượng Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // 2. Biến trạng thái
        private bool isAdding = false;

        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDuLieuDanhMuc();
            SetTrangThai(false);
        }

        // --- HÀM TẢI DỮ LIỆU ---
        private void LoadDuLieuDanhMuc()
        {
            try
            {
                string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";

                // Dùng laydl để lấy bảng dữ liệu (Không cần gán Connection vì hàm tự lo)
                dgvDanhMuc.DataSource = db.laydl(sql);

                // Định dạng cột
                if (dgvDanhMuc.Columns.Contains("MaDanhMuc"))
                {
                    dgvDanhMuc.Columns["MaDanhMuc"].HeaderText = "Mã DM";
                    dgvDanhMuc.Columns["MaDanhMuc"].Width = 100;
                }
                if (dgvDanhMuc.Columns.Contains("TenDanhMuc"))
                {
                    dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên Danh Mục";
                    dgvDanhMuc.Columns["TenDanhMuc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        private void SetTrangThai(bool dangThaoTac)
        {
            txtTenDanhMuc.Enabled = dangThaoTac;
            txtMaDanhMuc.Enabled = false;

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            btnLuu.Enabled = dangThaoTac;
            btnHuy.Enabled = dangThaoTac;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetTrangThai(true);
            txtMaDanhMuc.Text = "Tự động";
            txtTenDanhMuc.Text = "";
            txtTenDanhMuc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text) || txtMaDanhMuc.Text == "Tự động")
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo");
                return;
            }

            isAdding = false;
            SetTrangThai(true);
            txtTenDanhMuc.Focus();
        }

        // --- HÀM XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaDanhMuc.Text) || txtMaDanhMuc.Text == "Tự động")
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            string maXoa = txtMaDanhMuc.Text;

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa danh mục {maXoa}?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "DELETE FROM DanhMuc WHERE MaDanhMuc = @Ma";
                    SqlCommand cmd = new SqlCommand(sql);

                    // BẮT BUỘC: Gán kết nối từ file Database sang cho Command này
                    cmd.Connection = db.cn;
                    cmd.Parameters.AddWithValue("@Ma", maXoa);

                    // Gọi hàm thực thi
                    db.thucthi(cmd);

                    MessageBox.Show("Xóa thành công!");
                    LoadDuLieuDanhMuc();
                    txtMaDanhMuc.Text = "";
                    txtTenDanhMuc.Text = "";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                        MessageBox.Show("Không thể xóa vì đang có sản phẩm thuộc danh mục này!", "Lỗi ràng buộc");
                    else
                        MessageBox.Show("Lỗi xóa: " + ex.Message);
                }
            }
        }

        // --- HÀM LƯU (THÊM/SỬA) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Tên danh mục không được để trống!");
                txtTenDanhMuc.Focus();
                return;
            }

            try
            {
                string sql = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = db.cn; // Gán kết nối ngay từ đầu

                if (isAdding)
                {
                    sql = "INSERT INTO DanhMuc (TenDanhMuc) VALUES (@Ten)";
                }
                else
                {
                    sql = "UPDATE DanhMuc SET TenDanhMuc = @Ten WHERE MaDanhMuc = @Ma";
                    cmd.Parameters.AddWithValue("@Ma", txtMaDanhMuc.Text);
                }

                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Ten", txtTenDanhMuc.Text.Trim());

                // Thực thi lệnh thông qua file Database.cs
                db.thucthi(cmd);

                MessageBox.Show(isAdding ? "Thêm mới thành công!" : "Cập nhật thành công!");
                LoadDuLieuDanhMuc();
                SetTrangThai(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Lưu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetTrangThai(false);
            if (dgvDanhMuc.CurrentRow != null)
            {
                txtMaDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = dgvDanhMuc.CurrentRow.Cells["TenDanhMuc"].Value.ToString();
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];
                txtMaDanhMuc.Text = row.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
            }
        }
    }
}