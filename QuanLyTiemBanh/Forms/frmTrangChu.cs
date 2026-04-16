using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmTrangChu : Form
    {
        // Giữ nguyên chuỗi kết nối của bạn
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        private int NguongHetHang = 10;
        private int NguongHetHan = 7;

        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            LoadThongKeHomNay();
            LoadCanhBao();
        }

        // 1. Thống kê nhanh tình hình hôm nay
        private void LoadThongKeHomNay()
        {
            try
            {
                // --- ĐẾM SỐ ĐƠN ---
                string sqlDon = "SELECT COUNT(*) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)";
                // Sử dụng hàm laydl của file Database.cs
                DataTable dtDon = db.laydl(sqlDon);
                int soDon = 0;
                if (dtDon.Rows.Count > 0)
                {
                    soDon = Convert.ToInt32(dtDon.Rows[0][0]);
                }
                lblTongDon.Text = soDon.ToString() + " đơn";

                // --- TÍNH DOANH THU ---
                string sqlTien = "SELECT SUM(TongTien) FROM HoaDon WHERE CAST(NgayBan AS DATE) = CAST(GETDATE() AS DATE)";
                DataTable dtTien = db.laydl(sqlTien);
                decimal doanhThu = 0;
                if (dtTien.Rows.Count > 0 && dtTien.Rows[0][0] != DBNull.Value)
                {
                    doanhThu = Convert.ToDecimal(dtTien.Rows[0][0]);
                }
                lblDoanhThu.Text = doanhThu.ToString("N0") + " đ";
            }
            catch (Exception ex)
            {
                lblTongDon.Text = "0 đơn";
                lblDoanhThu.Text = "0 đ";
            }
        }

        // 2. HÀM CẢNH BÁO (TỒN KHO & HẠN DÙNG)
        private void LoadCanhBao()
        {
            try
            {
                // --- PHẦN A: CẢNH BÁO SẮP HẾT HÀNG ---
                // Vì hàm laydl chỉ nhận chuỗi string, ta sẽ truyền biến trực tiếp vào chuỗi
                string sqlHetHang = @"SELECT 0 AS MaLo, TenSanPham, SoLuongTon, N'Sắp hết hàng' AS TrangThai 
                                      FROM SanPham 
                                      WHERE SoLuongTon <= " + NguongHetHang + " AND TrangThai = 1";

                // --- PHẦN B: CẢNH BÁO SẮP HẾT HẠN ---
                string sqlHetHan = @"SELECT l.MaLo, s.TenSanPham, l.SoLuongHienTai AS SoLuongTon, 
                                            N'Sắp hết hạn (' + CONVERT(varchar, l.HanSuDung, 103) + ')' AS TrangThai
                                     FROM LoHang l
                                     JOIN SanPham s ON l.MaSanPham = s.MaSanPham
                                     WHERE DATEDIFF(day, GETDATE(), l.HanSuDung) <= " + NguongHetHan + @" 
                                     AND DATEDIFF(day, GETDATE(), l.HanSuDung) >= 0
                                     AND l.SoLuongHienTai > 0
                                     AND s.TrangThai = 1";

                // Gộp 2 cảnh báo
                string sqlTongHop = sqlHetHang + " UNION ALL " + sqlHetHan;

                // Dùng laydl để lấy toàn bộ dữ liệu cảnh báo
                DataTable dt = db.laydl(sqlTongHop);

                // Gán dữ liệu lên lưới
                dgvCanhBao.DataSource = dt;

                // Format giao diện (Giữ nguyên logic của bạn)
                dgvCanhBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvCanhBao.Columns.Contains("MaLo")) dgvCanhBao.Columns["MaLo"].Visible = false;
                if (dgvCanhBao.Columns.Contains("TenSanPham")) dgvCanhBao.Columns["TenSanPham"].HeaderText = "Tên Bánh";
                if (dgvCanhBao.Columns.Contains("SoLuongTon")) dgvCanhBao.Columns["SoLuongTon"].HeaderText = "SL Tồn";
                if (dgvCanhBao.Columns.Contains("TrangThai")) dgvCanhBao.Columns["TrangThai"].HeaderText = "Cảnh Báo";

                dgvCanhBao.DefaultCellStyle.ForeColor = Color.Red;
                dgvCanhBao.DefaultCellStyle.SelectionForeColor = Color.Yellow;
                dgvCanhBao.RowHeadersVisible = false;

                if (lblCanhBaoSL != null)
                    lblCanhBaoSL.Text = dt.Rows.Count.ToString() + " mục";
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi hiển thị
            }
        }

        private void btnKichHoatGiamGia_Click(object sender, EventArgs e)
        {
            if (dgvCanhBao.CurrentRow == null) return;

            // Lấy MaLo từ dòng đang chọn (Lúc này cột MaLo đã tồn tại trên lưới nên sẽ hết lỗi)
            int maLo = Convert.ToInt32(dgvCanhBao.CurrentRow.Cells["MaLo"].Value);

            // Kiểm tra nếu là cảnh báo Hết hàng (MaLo = 0) thì không áp dụng giảm giá lô được
            if (maLo == 0)
            {
                MessageBox.Show("Đây là cảnh báo hết số lượng tồn. Chương trình 'Giờ Vàng' chỉ áp dụng cho các lô hàng cụ thể sắp hết hạn!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tenSP = dgvCanhBao.CurrentRow.Cells["TenSanPham"].Value.ToString();

            if (MessageBox.Show($"Xác nhận giảm giá 50% cho lô hàng {tenSP}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Cập nhật mức giảm giá vào đúng lô hàng đó
                    string sql = $"UPDATE LoHang SET MucGiamGia = 50 WHERE MaLo = {maLo}";
                    SqlCommand cmd = new SqlCommand(sql) { Connection = db.cn };
                    db.thucthi(cmd);

                    MessageBox.Show("Đã kích hoạt chương trình Giờ Vàng (Giảm 50%) thành công!");
                    LoadCanhBao(); // Tải lại để cập nhật
                }
                catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
            }
        }
    }
}