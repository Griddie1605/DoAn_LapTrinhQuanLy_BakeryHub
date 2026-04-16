using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmSanPham : Form
    {
        // 1. Sử dụng class Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // Biến trạng thái
        private bool isAdding = false;

        string folderAnh = Path.Combine(Application.StartupPath, "Images");

        public frmSanPham()
        {
            InitializeComponent();
            // Tạo thư mục lưu ảnh nếu chưa tồn tại
            if (!Directory.Exists(folderAnh)) Directory.CreateDirectory(folderAnh);
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            LoadDanhMucCombobox();
            LoadSanPhamData();
            SetFormState(false);

            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.ReadOnly = true;
            dgvSanPham.MultiSelect = false;
        }

        // --- PHẦN 1: LOAD DỮ LIỆU ---
        private void LoadDanhMucCombobox()
        {
            try
            {

                string sql = "SELECT MaDanhMuc, TenDanhMuc FROM DanhMuc";
                cboDanhMuc.DataSource = db.laydl(sql);
                cboDanhMuc.DisplayMember = "TenDanhMuc";
                cboDanhMuc.ValueMember = "MaDanhMuc";
                cboDanhMuc.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi danh mục: " + ex.Message); }
        }

        private void LoadSanPhamData()
        {
            string query = @"SELECT s.MaSanPham, s.TenSanPham, s.DonGia, s.HinhAnh, s.SoLuongTon, s.MaDanhMuc, d.TenDanhMuc 
                             FROM SanPham s 
                             JOIN DanhMuc d ON s.MaDanhMuc = d.MaDanhMuc
                             WHERE s.TrangThai = 1";

            try
            {
                dgvSanPham.DataSource = db.laydl(query);

                if (dgvSanPham.Columns.Contains("MaSanPham")) dgvSanPham.Columns["MaSanPham"].HeaderText = "Mã SP";
                if (dgvSanPham.Columns.Contains("TenSanPham")) dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Bánh";
                if (dgvSanPham.Columns.Contains("SoLuongTon"))
                {
                    dgvSanPham.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                    dgvSanPham.Columns["SoLuongTon"].Width = 70;
                }

                if (dgvSanPham.Columns.Contains("DonGia"))
                {
                    dgvSanPham.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvSanPham.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dgvSanPham.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvSanPham.Columns.Contains("HinhAnh")) dgvSanPham.Columns["HinhAnh"].Visible = false;
                if (dgvSanPham.Columns.Contains("MaDanhMuc")) dgvSanPham.Columns["MaDanhMuc"].Visible = false;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message); }
        }

        // --- PHẦN 2: TRẠNG THÁI FORM ---
        private void SetFormState(bool editMode)
        {
            txtMaSP.Enabled = editMode && isAdding;
            txtTenSP.Enabled = editMode;
            txtDonGia.Enabled = editMode;
            cboDanhMuc.Enabled = editMode;
            btnChonAnh.Enabled = editMode;

            btnThem.Enabled = !editMode;
            btnSua.Enabled = !editMode;
            btnXoa.Enabled = !editMode;
            btnLuu.Enabled = editMode;
            btnHuy.Enabled = editMode;

            dgvSanPham.Enabled = !editMode;

            if (!editMode)
            {
                txtMaSP.Clear();
                txtTenSP.Clear();
                txtDonGia.Clear();
                txtHinhAnh.Clear();
                if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
                cboDanhMuc.SelectedIndex = -1;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // Chỉ hiển thị ảnh lên PictureBox để xem trước
                using (FileStream fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read))
                {
                    if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                    picHinhAnh.Image = Image.FromStream(fs);
                }
                // Lưu tạm đường dẫn gốc vào Tag để tí nữa Copy
                txtHinhAnh.Text = open.FileName;
            }
        }

        private void LoadImageSafe(string tenFileAnh)
        {
            if (string.IsNullOrEmpty(tenFileAnh))
            {
                if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                picHinhAnh.Image = null;
                return;
            }

            string pathFull = Path.Combine(folderAnh, tenFileAnh);
            if (File.Exists(pathFull))
            {
                try
                {
                    using (FileStream fs = new FileStream(pathFull, FileMode.Open, FileAccess.Read))
                    {
                        if (picHinhAnh.Image != null) picHinhAnh.Image.Dispose();
                        picHinhAnh.Image = Image.FromStream(fs);
                    }
                }
                catch { picHinhAnh.Image = null; }
            }
            else { picHinhAnh.Image = null; }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetFormState(true);
            txtMaSP.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!");
                return;
            }
            isAdding = false;
            SetFormState(true);
        }

        // --- PHẦN 4: XÓA (ẨN) SẢN PHẨM ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "") return;

            if (MessageBox.Show($"Bạn muốn ngừng kinh doanh sản phẩm {txtTenSP.Text}?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string sql = "UPDATE SanPham SET TrangThai = 0 WHERE MaSanPham = @MaSP";
                    SqlCommand cmd = new SqlCommand(sql);

                    // Điểm thay đổi số 2: Gán Connection cho Command
                    cmd.Connection = db.cn;
                    cmd.Parameters.AddWithValue("@MaSP", txtMaSP.Text);

                    db.thucthi(cmd); // Gọi hàm thực thi

                    MessageBox.Show("Đã ẩn sản phẩm thành công!");
                    LoadSanPhamData();
                    SetFormState(false);
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }

        // --- PHẦN 5: LƯU DỮ LIỆU ---
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text == "" || txtTenSP.Text == "" || txtDonGia.Text == "") return;

            string maSP = txtMaSP.Text.Trim();
            string tenFileAnh = "";

            // Xử lý Copy ảnh vào thư mục nội bộ
            if (!string.IsNullOrEmpty(txtHinhAnh.Text) && File.Exists(txtHinhAnh.Text))
            {
                tenFileAnh = Path.GetFileName(txtHinhAnh.Text);
                string pathDich = Path.Combine(folderAnh, tenFileAnh);

                // Nếu ảnh chọn khác với ảnh đã có trong thư mục nội bộ thì mới Copy
                if (txtHinhAnh.Text != pathDich)
                {
                    File.Copy(txtHinhAnh.Text, pathDich, true);
                }
            }

            try
            {
                string sql = isAdding
                    ? "INSERT INTO SanPham (MaSanPham, TenSanPham, DonGia, HinhAnh, MaDanhMuc, TrangThai) VALUES (@Ma, @Ten, @Gia, @Anh, @DM, 1)"
                    : "UPDATE SanPham SET TenSanPham=@Ten, DonGia=@Gia, HinhAnh=@Anh, MaDanhMuc=@DM WHERE MaSanPham=@Ma";

                SqlCommand cmd = new SqlCommand(sql);
                cmd.Connection = db.cn;
                cmd.Parameters.AddWithValue("@Ma", maSP);
                cmd.Parameters.AddWithValue("@Ten", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@Gia", decimal.Parse(txtDonGia.Text));
                cmd.Parameters.AddWithValue("@Anh", string.IsNullOrEmpty(tenFileAnh) ? (object)DBNull.Value : tenFileAnh);
                cmd.Parameters.AddWithValue("@DM", cboDanhMuc.SelectedValue);

                db.thucthi(cmd);
                MessageBox.Show("Lưu thành công!");
                LoadSanPhamData();
                SetFormState(false);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi lưu: " + ex.Message); }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells["MaSanPham"].Value.ToString();
                txtTenSP.Text = row.Cells["TenSanPham"].Value.ToString();
                txtDonGia.Text = string.Format("{0:0}", row.Cells["DonGia"].Value);
                cboDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;

                string path = row.Cells["HinhAnh"].Value?.ToString();
                txtHinhAnh.Text = path;
                LoadImageSafe(path);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // 1. Chuyển cờ isAdding về false (dừng trạng thái thêm mới)
            isAdding = false;

            // 2. Gọi hàm SetFormState với tham số false để:
            //    - Khóa các ô nhập liệu
            //    - Hiện lại các nút chức năng
            //    - Xóa trắng các ô TextBox và ảnh trên giao diện
            SetFormState(false);

            // 3. (Tùy chọn) Nếu muốn khi Hủy, nó hiện lại thông tin của dòng đang chọn trên Grid
            if (dgvSanPham.CurrentRow != null)
            {
                dgvSanPham_CellClick(null, null); // Gọi lại sự kiện click để đổ lại dữ liệu cũ
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable dt = ExcelHelper.Import(open.FileName);
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row[0] == null || string.IsNullOrWhiteSpace(row[0].ToString())) continue;

                        string sql = "INSERT INTO SanPham (MaSanPham, TenSanPham, DonGia, HinhAnh, MaDanhMuc, TrangThai) VALUES (@Ma, @Ten, @Gia, @Anh, @DM, 1)";
                        SqlCommand cmd = new SqlCommand(sql, db.cn);
                        cmd.Parameters.AddWithValue("@Ma", row[0]);
                        cmd.Parameters.AddWithValue("@Ten", row[1]);
                        cmd.Parameters.AddWithValue("@Gia", row[2]);
                        cmd.Parameters.AddWithValue("@Anh", row[3]);
                        cmd.Parameters.AddWithValue("@DM", row[4]);
                        db.thucthi(cmd);
                    }
                    MessageBox.Show("Nhập Excel thành công!");
                    LoadSanPhamData();
                }
                catch (Exception ex) { MessageBox.Show("Lỗi nhập Excel: " + ex.Message); }
            }
        }
            

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Lấy DataTable từ DataGridView và gọi Helper
            DataTable dt = (DataTable)dgvSanPham.DataSource;
            ExcelHelper.Export(dt, "DanhSachSanPham");
        }

        private void btnTaiFileMau_Click(object sender, EventArgs e)
        {
            // Khai báo đúng thứ tự các cột mà hàm Import của bạn đang đọc
            string[] columns = { "MaSanPham", "TenSanPham", "DonGia", "HinhAnh", "MaDanhMuc", "TrangThai" };
            ExcelHelper.CreateTemplate(columns, "Mau_Nhap_San_Pham.xlsx");
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            // 1. Truy vấn dữ liệu từ SQL
            string sql = @"SELECT s.TenSanPham, l.SoLuongHienTai, l.HanSuDung, l.MucGiamGia 
                   FROM LoHang l 
                   JOIN SanPham s ON l.MaSanPham = s.MaSanPham 
                   WHERE l.SoLuongHienTai > 0 
                   ORDER BY l.HanSuDung ASC"; // Sắp xếp theo hạn dùng

            DataTable dt = db.laydl(sql);

            // 2. Gọi máy in
            if (dt.Rows.Count > 0)
            {
                frmInHoaDon fKho = new frmInHoaDon();
                fKho.HienThiBaoCao(dt, new Crystal_Report.Ton_Kho.rptTonKho()); // Nạp cuộn phim Tồn kho
                fKho.ShowDialog();
            }
            else { MessageBox.Show("Kho hàng đang trống!"); }
        }
    }
}