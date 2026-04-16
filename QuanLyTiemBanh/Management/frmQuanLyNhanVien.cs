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
    public partial class frmQuanLyNhanVien : Form
    {
        // 1. Khởi tạo đối tượng Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        private bool isAdding = false;

        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        // --- HÀM LOAD DỮ LIỆU ---
        private void LoadNhanVienData()
        {
            string sqlQuery = "SELECT MaNhanVien, HoTen, Quyen FROM NhanVien ORDER BY MaNhanVien ASC";

            try
            {
                // Sử dụng hàm laydl để đổ dữ liệu vào GridView
                dgNhanVien.DataSource = db.laydl(sqlQuery);

                // Đổi tên cột
                if (dgNhanVien.Columns.Contains("MaNhanVien")) dgNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                if (dgNhanVien.Columns.Contains("HoTen"))
                {
                    dgNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                    dgNhanVien.Columns["HoTen"].Width = 300;
                }
                if (dgNhanVien.Columns.Contains("Quyen"))
                {
                    dgNhanVien.Columns["Quyen"].HeaderText = "Chức Vụ";
                    dgNhanVien.Columns["Quyen"].Width = 160;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetTrangThaiForm(bool isEditing)
        {
            txtHoTen.Enabled = isEditing;
            txtMatKhau.Enabled = isEditing;
            cbChucVu.Enabled = isEditing;
            txtMaNhanVien.Enabled = isAdding;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;

            if (!isEditing)
            {
                txtMaNhanVien.Text = "";
                txtHoTen.Text = "";
                txtMatKhau.Text = "";
                cbChucVu.SelectedIndex = -1;
                dgNhanVien.ClearSelection();
                dgNhanVien.Enabled = true;
            }
            else
            {
                dgNhanVien.Enabled = false;
            }
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            if (cbChucVu.Items.Count == 0)
            {
                cbChucVu.Items.Add("Admin");
                cbChucVu.Items.Add("NhanVien");
            }

            LoadNhanVienData();
            SetTrangThaiForm(false);

            dgNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgNhanVien.RowHeadersVisible = false;
            dgNhanVien.ReadOnly = true;
            dgNhanVien.MultiSelect = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetTrangThaiForm(true);
            txtMaNhanVien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa từ danh sách!", "Thông báo");
                return;
            }

            isAdding = false;
            SetTrangThaiForm(true);
            txtMaNhanVien.Enabled = false;
            txtMatKhau.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isAdding = false;
            SetTrangThaiForm(false);
        }

        // --- HÀM XÓA ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text)) return;

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên [{txtMaNhanVien.Text}] không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string sqlQuery = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                    SqlCommand cmd = new SqlCommand(sqlQuery);
                    cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNhanVien.Text);

                    // BẮT BUỘC: Gán kết nối cho command trước khi gọi thucthi
                    cmd.Connection = db.cn;

                    db.thucthi(cmd);

                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo");
                    LoadNhanVienData();
                    SetTrangThaiForm(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi");
                }
            }
        }

        // --- HÀM LƯU (THÊM/SỬA) ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(chucVu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã NV, Họ Tên và Chức Vụ.", "Thông báo");
                return;
            }

            if (isAdding && string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Mật khẩu không được để trống khi thêm mới.", "Thông báo");
                return;
            }

            try
            {
                string sqlQuery = "";
                if (isAdding)
                {
                    sqlQuery = "INSERT INTO NhanVien (MaNhanVien, MatKhau, HoTen, Quyen) VALUES (@MaNhanVien, @MatKhau, @HoTen, @Quyen)";
                }
                else
                {
                    if (string.IsNullOrEmpty(matKhau))
                        sqlQuery = "UPDATE NhanVien SET HoTen = @HoTen, Quyen = @Quyen WHERE MaNhanVien = @MaNhanVien";
                    else
                        sqlQuery = "UPDATE NhanVien SET MatKhau = @MatKhau, HoTen = @HoTen, Quyen = @Quyen WHERE MaNhanVien = @MaNhanVien";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery);
                cmd.Connection = db.cn; // Gán kết nối

                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@Quyen", chucVu);
                if (!string.IsNullOrEmpty(matKhau)) cmd.Parameters.AddWithValue("@MatKhau", matKhau);

                // Gọi hàm thucthi của class Database
                db.thucthi(cmd);

                MessageBox.Show(isAdding ? "Thêm mới thành công!" : "Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadNhanVienData();
                SetTrangThaiForm(false);
                isAdding = false;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                    MessageBox.Show($"Mã nhân viên '{maNhanVien}' đã tồn tại!", "Lỗi trùng khóa");
                else
                    MessageBox.Show("Lỗi CSDL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow dr = dgNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = dr.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
                cbChucVu.SelectedItem = dr.Cells["Quyen"].Value.ToString();
                txtMatKhau.Text = "";

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            // Khai báo đúng thứ tự các cột mà hàm Import của bạn đang đọc
            string[] columns = { "MaNhanVien", "HoTen", "Quyen" };
            ExcelHelper.CreateTemplate(columns, "Mau_Nhap_Nhan_Vien.xlsx");
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                // 1. Nhờ Helper đọc file thành DataTable
                DataTable dt = ExcelHelper.Import(open.FileName);

                // 2. Duyệt DataTable đó để lưu vào SQL qua file database.cs
                foreach (DataRow row in dt.Rows)
                {
                    string sql = "Insert into NhanVien (MaNhanVien, HoTen, Quyen) values (@MaNhanVien, @HoTen, @Quyen)";
                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.Connection = db.cn; // Gán kết nối
                    cmd.Parameters.AddWithValue("@MaNhanVien", row[0]);
                    cmd.Parameters.AddWithValue("@HoTen", row[1]);
                    cmd.Parameters.AddWithValue("@Quyen", row[2]);

                    db.thucthi(cmd);
                }
                MessageBox.Show("Đã thành công nhập dữ liệu từ file Excel!", "Thông báo");
                LoadNhanVienData();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Lấy Database từ DGV và gọi Helper
            DataTable dt = (DataTable)dgNhanVien.DataSource;
            ExcelHelper.Export(dt, "DanhSachNhanVien");
        }
    }
}