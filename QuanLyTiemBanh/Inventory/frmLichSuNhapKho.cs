using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmLichSuNhapKho : Form
    {
        // 1. Khởi tạo đối tượng Database (Dùng chung tên DB là BakeryHub như các form trước)
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        public frmLichSuNhapKho()
        {
            InitializeComponent();
        }

        private void frmLichSuNhapKho_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            btnXem.PerformClick();
        }

        // 1. TẢI DANH SÁCH PHIẾU NHẬP (BẢNG CHA)
        private void btnXem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị ngày và định dạng lại để truyền vào chuỗi SQL
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd");

            try
            {
                // Truy vấn kết hợp lấy tên nhân viên
                string sql = "SELECT p.MaPhieuNhapKho, p.NgayNhap, p.NhaCungCap, nv.HoTen AS NguoiNhap " +
                             "FROM PhieuNhapKho p " +
                             "LEFT JOIN NhanVien nv ON p.MaNhanVien = nv.MaNhanVien " +
                             "WHERE p.NgayNhap >= '" + tuNgay + "' AND p.NgayNhap < '" + denNgay + "' " +
                             "ORDER BY p.NgayNhap DESC";

                // Sử dụng hàm laydl để lấy dữ liệu về DataTable
                DataTable dt = db.laydl(sql);

                dgvPhieuNhap.DataSource = dt;
                FormatLuoiPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phiếu nhập: " + ex.Message);
            }
        }

        // 2. KHI BẤM VÀO 1 PHIẾU -> HIỆN CHI TIẾT (BẢNG CON)
        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Lấy Mã phiếu từ dòng được chọn
                    int maPhieu = Convert.ToInt32(dgvPhieuNhap.Rows[e.RowIndex].Cells["MaPhieuNhapKho"].Value);
                    LoadChiTiet(maPhieu);
                }
                catch { }
            }
        }

        private void LoadChiTiet(int maPhieu)
        {
            try
            {
                // Lấy tên bánh, số lượng, giá từ bảng chi tiết JOIN với bảng SanPham
                string sql = "SELECT sp.TenSanPham, ct.SoLuong, ct.DonGiaNhap, (ct.SoLuong * ct.DonGiaNhap) AS ThanhTien " +
                             "FROM ChiTietPhieuNhapKho ct " +
                             "JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham " +
                             "WHERE ct.MaPhieuNhapKho = " + maPhieu;

                // Sử dụng hàm laydl
                DataTable dt = db.laydl(sql);

                dgvChiTiet.DataSource = dt;
                FormatLuoiChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }

        // --- CÁC HÀM FORMAT (Giữ nguyên logic của bạn) ---
        private void FormatLuoiPhieu()
        {
            if (dgvPhieuNhap.Columns.Contains("MaPhieuNhapKho")) dgvPhieuNhap.Columns["MaPhieuNhapKho"].HeaderText = "Mã Phiếu";
            if (dgvPhieuNhap.Columns.Contains("NgayNhap"))
            {
                dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                dgvPhieuNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvPhieuNhap.Columns.Contains("NhaCungCap")) dgvPhieuNhap.Columns["NhaCungCap"].HeaderText = "Nhà Cung Cấp";
            if (dgvPhieuNhap.Columns.Contains("NguoiNhap")) dgvPhieuNhap.Columns["NguoiNhap"].HeaderText = "Người Nhập";

            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuNhap.MultiSelect = false;
            dgvPhieuNhap.RowHeadersVisible = false;
        }

        private void FormatLuoiChiTiet()
        {
            if (dgvChiTiet.Columns.Contains("TenSanPham"))
            {
                dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Hàng";
                dgvChiTiet.Columns["TenSanPham"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            if (dgvChiTiet.Columns.Contains("SoLuong")) dgvChiTiet.Columns["SoLuong"].HeaderText = "SL";
            if (dgvChiTiet.Columns.Contains("DonGiaNhap"))
            {
                dgvChiTiet.Columns["DonGiaNhap"].HeaderText = "Giá Nhập";
                dgvChiTiet.Columns["DonGiaNhap"].DefaultCellStyle.Format = "N0";
            }
            if (dgvChiTiet.Columns.Contains("ThanhTien"))
            {
                dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            dgvChiTiet.RowHeadersVisible = false;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnXuatChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow == null) return;

            // Lấy mã hóa đơn để đặt tên file 
            string maHD = dgvPhieuNhap.CurrentRow.Cells["MaPhieuNhapKho"].Value.ToString();
            DataTable dt = (DataTable)dgvChiTiet.DataSource;

            if (dt != null)
            {
                ExcelHelper.Export(dt, "Chi_Tiet_Nhap_Kho" + maHD);
            }
        }

        private void btnXuatDSNhapKho_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvPhieuNhap.DataSource;
            if (dt != null)
            {
                ExcelHelper.Export(dt, "Danh_Sach_Nhap_Kho");
            }
        }
    }
}