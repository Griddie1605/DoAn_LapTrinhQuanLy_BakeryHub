using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BakeryHub
{
    public partial class frmThongKe : Form
    {
        // 1. Sử dụng class Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        public frmThongKe()
        {
            InitializeComponent();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // Chuyển ngày sang dạng chuỗi yyyy-MM-dd để SQL hiểu đúng
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd");

            try
            {
                // --- 1. TÍNH TỔNG DOANH THU & LỢI NHUẬN ---
                string queryTaiChinh = $@"
                    SELECT 
                        SUM(cthd.SoLuong * cthd.DonGia) AS DoanhThu,
                        SUM(cthd.SoLuong * (cthd.DonGia - ISNULL(sp.GiaNhap, 0))) AS LoiNhuan
                    FROM ChiTietHoaDon cthd
                    JOIN HoaDon hd ON cthd.MaHoaDon = hd.MaHoaDon
                    JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
                    WHERE hd.NgayBan >= '{tuNgay}' AND hd.NgayBan < '{denNgay}'";

                DataTable dtTaiChinh = db.laydl(queryTaiChinh);
                decimal tongDoanhThu = 0;
                decimal tongLoiNhuan = 0;

                if (dtTaiChinh.Rows.Count > 0)
                {
                    tongDoanhThu = dtTaiChinh.Rows[0]["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(dtTaiChinh.Rows[0]["DoanhThu"]) : 0;
                    tongLoiNhuan = dtTaiChinh.Rows[0]["LoiNhuan"] != DBNull.Value ? Convert.ToDecimal(dtTaiChinh.Rows[0]["LoiNhuan"]) : 0;
                }

                // --- 2. TÍNH SỐ ĐƠN HÀNG ---
                string querySoDon = $"SELECT COUNT(*) FROM HoaDon WHERE NgayBan >= '{tuNgay}' AND NgayBan < '{denNgay}'";
                DataTable dtSoDon = db.laydl(querySoDon);
                int soDonHang = Convert.ToInt32(dtSoDon.Rows[0][0]);

                // --- 3. MÓN BÁN CHẠY NHẤT ---
                string queryBanChay = $@"
                    SELECT TOP 1 sp.TenSanPham, SUM(cthd.SoLuong) AS SL
                    FROM ChiTietHoaDon cthd
                    JOIN HoaDon hd ON cthd.MaHoaDon = hd.MaHoaDon
                    JOIN SanPham sp ON cthd.MaSanPham = sp.MaSanPham
                    WHERE hd.NgayBan >= '{tuNgay}' AND hd.NgayBan < '{denNgay}'
                    GROUP BY sp.TenSanPham
                    ORDER BY SL DESC";

                DataTable dtBanChay = db.laydl(queryBanChay);
                string monBanChay = "Không có dữ liệu";
                if (dtBanChay.Rows.Count > 0)
                {
                    monBanChay = $"{dtBanChay.Rows[0][0]} ({dtBanChay.Rows[0][1]} cái)";
                }

                // --- 4. VẼ BIỂU ĐỒ ---
                string queryChart = $@"
                    SELECT CONVERT(date, NgayBan) AS Ngay, SUM(TongTien) AS DoanhThu
                    FROM HoaDon
                    WHERE NgayBan >= '{tuNgay}' AND NgayBan < '{denNgay}'
                    GROUP BY CONVERT(date, NgayBan)
                    ORDER BY Ngay";

                DataTable dtChart = db.laydl(queryChart);

                chartDoanhThu.Series.Clear();
                Series series = new Series("Doanh Thu");
                series.ChartType = SeriesChartType.Column;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "N0";

                foreach (DataRow row in dtChart.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    decimal dThu = Convert.ToDecimal(row["DoanhThu"]);
                    series.Points.AddXY(ngay.ToString("dd/MM"), dThu);
                }
                chartDoanhThu.Series.Add(series);

                // --- 5. HIỂN THỊ KẾT QUẢ ---
                lblTongDoanhThu.Text = tongDoanhThu.ToString("N0") + " VNĐ";
                if (lblTongLoiNhuan != null) lblTongLoiNhuan.Text = tongLoiNhuan.ToString("N0") + " VNĐ";
                lblSoDonHang.Text = soDonHang + " đơn";
                lblMonBanChay.Text = monBanChay;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thống kê: " + ex.Message);
            }
        }

        private void btnInDoanhThu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy ngày và dùng logic +1 ngày để không mất dữ liệu giờ giấc
                string tu = dtpTuNgay.Value.ToString("yyyy-MM-dd");
                string den = dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd");

                // 2. Câu SQL lấy dữ liệu: Phải có 3 cột giống hệt dtDoanhThu trong Dataset
                // CAST(NgayBan AS DATE) giúp gộp các hóa đơn cùng ngày lại thành 1 dòng trên báo cáo
                string sql = $@"SELECT CAST(NgayBan AS DATE) AS Ngay, 
                               COUNT(MaHoaDon) AS SoLuongDon, 
                               SUM(TongTien) AS TongDoanhThu 
                        FROM HoaDon 
                        WHERE NgayBan >= '{tu}' AND NgayBan < '{den}' 
                        GROUP BY CAST(NgayBan AS DATE)
                        ORDER BY Ngay ASC";

                DataTable dt = db.laydl(sql);

                // 3. Gọi máy in vạn năng frmInHoaDon
                if (dt != null && dt.Rows.Count > 0)
                {
                    frmInHoaDon fDT = new frmInHoaDon();

                    // Thư kiểm tra kỹ dòng này xem tên file rpt có đúng không nhé
                    fDT.HienThiBaoCao(dt, new Crystal_Report.Doanh_Thu.rptDoanhThu());

                    fDT.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian từ " + tu + " đến " + dtpDenNgay.Value.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in thống kê: " + ex.Message);
            }
        }
    }
}