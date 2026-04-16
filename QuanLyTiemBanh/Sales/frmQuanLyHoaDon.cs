using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmQuanLyHoaDon : Form
    {
        // 1. Khởi tạo đối tượng Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // Placeholder text
        private string placeHolder = "Tìm kiếm theo mã đơn";

        public frmQuanLyHoaDon()
        {
            InitializeComponent();
            // Gán sự kiện
            this.Load += frmQuanLyHoaDon_Load;
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
        }

        // --- PHẦN 1: XỬ LÝ GIAO DIỆN PLACEHOLDER ---
        private void TxtMaHoaDon_Enter(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == placeHolder)
            {
                txtMaHoaDon.Text = "";
                txtMaHoaDon.ForeColor = Color.Black;
            }
        }

        private void TxtMaHoaDon_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text))
            {
                txtMaHoaDon.Text = placeHolder;
                txtMaHoaDon.ForeColor = Color.Gray;
            }
        }

        // --- PHẦN 2: TẢI DỮ LIỆU ---
        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            LoadDanhSachHoaDon();
        }

        private void LoadDanhSachHoaDon()
        {
            string maHoaDon = txtMaHoaDon.Text.Trim();
            // Định dạng ngày thành chuỗi yyyy-MM-dd để truyền vào hàm laydl
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd");

            try
            {
                // Xây dựng câu lệnh SQL
                string sql = $@"SELECT MaHoaDon, NgayBan, TongTien, MaNhanVien 
                               FROM HoaDon 
                               WHERE NgayBan >= '{tuNgay}' AND NgayBan < '{denNgay}'";

                // Nếu có nhập mã hóa đơn hợp lệ thì lọc thêm theo mã
                if (!string.IsNullOrEmpty(maHoaDon) && maHoaDon != placeHolder && int.TryParse(maHoaDon, out _))
                {
                    sql += $" AND MaHoaDon = {maHoaDon}";
                }

                sql += " ORDER BY NgayBan DESC";

                // Sử dụng hàm laydl (Tự động mở/đóng kết nối bên trong)
                DataTable dt = db.laydl(sql);

                dgvHoaDon.DataSource = dt;

                // Tính tổng doanh thu và định dạng lưới
                TinhTongDoanhThu(dt);
                FormatLuoiHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hóa đơn: " + ex.Message);
            }
        }

        // Hàm tính tổng tiền dựa trên DataTable đang có
        private void TinhTongDoanhThu(DataTable dt)
        {
            decimal tongTien = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["TongTien"] != DBNull.Value)
                    {
                        tongTien += Convert.ToDecimal(row["TongTien"]);
                    }
                }
            }

            if (lblTongDoanhThu != null)
            {
                lblTongDoanhThu.Text = $"TỔNG DOANH THU: {tongTien:N0} VNĐ";
                lblTongDoanhThu.ForeColor = Color.Red;
                lblTongDoanhThu.Font = new Font(lblTongDoanhThu.Font, FontStyle.Bold);
            }
        }

        // Load chi tiết hóa đơn (Bảng con) khi chọn 1 hóa đơn ở bảng cha
        private void LoadChiTietHoaDon(int maHoaDon)
        {
            try
            {
                string sql = $@"SELECT sp.MaSanPham, sp.TenSanPham, cthd.SoLuong, cthd.DonGia, 
                                      (cthd.SoLuong * cthd.DonGia) AS ThanhTien
                               FROM ChiTietHoaDon cthd
                               JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
                               WHERE cthd.MaHoaDon = {maHoaDon}";

                // Sử dụng hàm laydl
                DataTable dt = db.laydl(sql);

                dgvChiTiet.DataSource = dt;
                FormatLuoiChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem chi tiết: " + ex.Message);
            }
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value != DBNull.Value)
            {
                try
                {
                    int maHD = Convert.ToInt32(dgvHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);
                    LoadChiTietHoaDon(maHD);
                }
                catch { }
            }
        }

        // --- PHẦN 3: FORMAT GIAO DIỆN ---
        private void FormatLuoiHoaDon()
        {
            if (dgvHoaDon.Columns.Contains("MaHoaDon")) dgvHoaDon.Columns["MaHoaDon"].HeaderText = "Mã HĐ";
            if (dgvHoaDon.Columns.Contains("NgayBan"))
            {
                dgvHoaDon.Columns["NgayBan"].HeaderText = "Ngày Bán";
                dgvHoaDon.Columns["NgayBan"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvHoaDon.Columns.Contains("TongTien"))
            {
                dgvHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgvHoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvHoaDon.Columns.Contains("MaNhanVien")) dgvHoaDon.Columns["MaNhanVien"].HeaderText = "Nhân Viên";

            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormatLuoiChiTiet()
        {
            if (dgvChiTiet.Columns.Contains("MaSanPham")) dgvChiTiet.Columns["MaSanPham"].Visible = false;
            if (dgvChiTiet.Columns.Contains("TenSanPham"))
            {
                dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Bánh";
                dgvChiTiet.Columns["TenSanPham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvChiTiet.Columns.Contains("SoLuong")) dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChiTiet.Columns.Contains("DonGia"))
            {
                dgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgvChiTiet.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTiet.Columns.Contains("ThanhTien"))
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            txtMaHoaDon.Text = placeHolder;
            txtMaHoaDon.ForeColor = Color.Gray;
            txtMaHoaDon.Enter += TxtMaHoaDon_Enter;
            txtMaHoaDon.Leave += TxtMaHoaDon_Leave;

            DateTime today = DateTime.Now;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;

            btnXemDuLieu.PerformClick();
        }

        private void btnXuatDSHoaDon_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvHoaDon.DataSource;
            if (dt != null)
            {
                ExcelHelper.Export(dt, "Danh_Sach_Hoa_Don");
            }
        }

        private void btnXuatChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow == null) return;

            // Lấy mã hóa đơn để đặt tên file 
            string maHD = dgvHoaDon.CurrentRow.Cells["MaHoaDon"].Value.ToString();
            DataTable dt = (DataTable)dgvChiTiet.DataSource;

            if (dt != null)
            {
                ExcelHelper.Export(dt, "Chi_Tiet_Hoa_Don_" + maHD);
            }
        }
    }
}