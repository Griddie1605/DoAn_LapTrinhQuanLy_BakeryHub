using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryHub
{
    public partial class frmLichSuHuyHang : Form
    {
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");
        public frmLichSuHuyHang()
        {
            InitializeComponent();
        }

        private void frmLichSuHuyHang_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpTuNgay.Value = now;

            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.AddDays(1).ToString("yyyy-MM-dd");

            try
            {
                string sql = "SELECT p.MaPhieuHuy, p.NgayHuy, p.LyDo, n.HoTen AS NguoiThucHien" +
                    "                   FROM PhieuHuy p" +
                    "                   JOIN NhanVien n ON p.MaNhanVien = n.MaNhanVien" +
                    "                   WHERE p.NgayHuy >= '" + tuNgay + "' AND p.NgayHuy < '" + denNgay + "' " +
                    "                   ORDER BY p.NgayHuy DESC";

                DataTable dt = db.laydl(sql);

                dgvPhieuHuy.DataSource = dt;
                FormatLuoiPhieu();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải phiếu hủy: " + ex.Message);
            }
        }

        private void dgvPhieuHuy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                try
                {
                    int maPhieu = Convert.ToInt32(dgvPhieuHuy.Rows[e.RowIndex].Cells["MaPhieuHuy"].Value);
                    LoadChiTiet(maPhieu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải chi tiết phiếu hủy: " + ex.Message);
                }
            }
        }

        private void LoadChiTiet(int maPhieu)
        {
            try
            {
                // Lấy thông tin các sản phẩm bị hủy trong phiếu đó
                string sql = "SELECT sp.TenSanPham, ct.SoLuongHuy " +
                             "FROM ChiTietPhieuHuy ct " +
                             "JOIN SanPham sp ON ct.MaSanPham = sp.MaSanPham " +
                             "WHERE ct.MaPhieuHuy = " + maPhieu;

                DataTable dt = db.laydl(sql);
                dgvChiTiet.DataSource = dt;
                FormatLuoiChiTiet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hủy: " + ex.Message);
            }
        }

        // --- PHẦN 3: ĐỊNH DẠNG GIAO DIỆN LƯỚI ---
        private void FormatLuoiPhieu()
        {
            if (dgvPhieuHuy.Columns.Contains("MaPhieuHuy")) dgvPhieuHuy.Columns["MaPhieuHuy"].HeaderText = "Mã Phiếu";
            if (dgvPhieuHuy.Columns.Contains("NgayHuy"))
            {
                dgvPhieuHuy.Columns["NgayHuy"].HeaderText = "Ngày Hủy";
                dgvPhieuHuy.Columns["NgayHuy"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvPhieuHuy.Columns.Contains("LyDo")) dgvPhieuHuy.Columns["LyDo"].HeaderText = "Lý Do";
            if (dgvPhieuHuy.Columns.Contains("NguoiHuy")) dgvPhieuHuy.Columns["NguoiHuy"].HeaderText = "Nhân Viên";

            dgvPhieuHuy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuHuy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuHuy.RowHeadersVisible = false;
        }

        private void FormatLuoiChiTiet()
        {
            if (dgvChiTiet.Columns.Contains("TenSanPham")) dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Bánh";
            if (dgvChiTiet.Columns.Contains("SoLuongHuy")) dgvChiTiet.Columns["SoLuongHuy"].HeaderText = "SL Hủy";

            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.RowHeadersVisible = false;
        }

        private void btnXuatDSHuyHang_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvPhieuHuy.DataSource;
            if(dt != null)
            {
                ExcelHelper.Export(dt, "Danh_Sach_Huy_Hang");
            }
        }

        private void btnXuatChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvPhieuHuy.CurrentRow == null) return;

            string maPhieuHuy = dgvPhieuHuy.CurrentRow.Cells["MaPhieuHuy"].Value.ToString();
            DataTable dt = (DataTable)dgvChiTiet.DataSource;

            if (dt != null)
            {
                ExcelHelper.Export(dt, "Chi_Tiet_Huy_Hang_" + maPhieuHuy);
            }
        }
    }

}
