using BakeryHub.Crystal_Report.Hoa_Don;
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
    public partial class FrmBanHang_POS_ : Form
    {
        // 1. Sử dụng class Database dùng chung
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        // 2. Giỏ hàng ảo (DataTable)
        private DataTable dtGioHang = new DataTable();

        // Lấy tên người đăng nhập 
        string NhanVienBanHang = frmLogin.MaNhanVien;

        public FrmBanHang_POS_()
        {
            InitializeComponent();
        }

        private void FrmBanHang_POS__Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NhanVienBanHang)) NhanVienBanHang = "admin";

            KhoiTaoGioHang();
            LoadThucDon();
            LoadComboBoxDanhMuc();
        }

        // --- PHẦN 1: KHỞI TẠO VÀ LOAD DỮ LIỆU ---

        private void KhoiTaoGioHang()
        {
            dtGioHang.Columns.Add("MaSanPham", typeof(string));
            dtGioHang.Columns.Add("TenSanPham", typeof(string));
            dtGioHang.Columns.Add("SoLuong", typeof(int));
            dtGioHang.Columns.Add("DonGia", typeof(decimal));
            dtGioHang.Columns.Add("ThanhTien", typeof(decimal));

            dgvGioHang.DataSource = dtGioHang;

            if (dgvGioHang.Columns.Contains("MaSanPham")) dgvGioHang.Columns["MaSanPham"].Visible = false;

            dgvGioHang.Columns["TenSanPham"].HeaderText = "Tên Bánh";
            dgvGioHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvGioHang.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvGioHang.Columns["TenSanPham"].ReadOnly = true;
            dgvGioHang.Columns["ThanhTien"].ReadOnly = true;
            dgvGioHang.Columns["DonGia"].ReadOnly = true;
        }

        private void LoadThucDon()
        {
            string sql = @"SELECT s.MaSanPham, s.TenSanPham, d.TenDanhMuc, s.DonGia, s.SoLuongTon 
                           FROM SanPham s 
                           JOIN DanhMuc d ON s.MaDanhMuc = d.MaDanhMuc 
                           WHERE s.SoLuongTon > 0 AND s.TrangThai = 1";

            try
            {
                // Thay thế bằng hàm laydl
                dgvThucDon.DataSource = db.laydl(sql);

                if (dgvThucDon.Columns.Contains("MaSanPham")) dgvThucDon.Columns["MaSanPham"].Visible = false;
                dgvThucDon.Columns["TenSanPham"].HeaderText = "Tên Bánh";
                dgvThucDon.Columns["TenSanPham"].Width = 200;
                dgvThucDon.Columns["TenDanhMuc"].HeaderText = "Loại";
                dgvThucDon.Columns["SoLuongTon"].HeaderText = "Tồn Kho";
                dgvThucDon.Columns["DonGia"].HeaderText = "Giá Tiền";
                dgvThucDon.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi menu: " + ex.Message); }
        }

        private void LoadComboBoxDanhMuc()
        {
            try
            {
                // Thay thế bằng hàm laydl
                DataTable dt = db.laydl("SELECT TenDanhMuc FROM DanhMuc");

                DataRow dr = dt.NewRow();
                dr["TenDanhMuc"] = "Tất cả";
                dt.Rows.InsertAt(dr, 0);

                cboLocLoai.DataSource = dt;
                cboLocLoai.DisplayMember = "TenDanhMuc";
            }
            catch { }
        }

        // --- PHẦN 2: THAO TÁC GIỎ HÀNG ---

        private void dgvThucDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThucDon.Rows[e.RowIndex];
                string maSP = row.Cells["MaSanPham"].Value.ToString();
                string tenSP = row.Cells["TenSanPham"].Value.ToString();
                decimal donGia = decimal.Parse(row.Cells["DonGia"].Value.ToString());
                int tonKhoThucTe = int.Parse(row.Cells["SoLuongTon"].Value.ToString());

                ThemVaoGioHang(maSP, tenSP, donGia, tonKhoThucTe);
            }
        }

        private void ThemVaoGioHang(string maSP, string tenSP, decimal donGiaGoc, int tonKho)
        {
            // 1. Lấy mức giảm giá từ lô hàng sắp hết hạn nhất của sản phẩm này
            int phanTramGiam = 0;
            try
            {
                string sqlCheckGiamGia = $@"SELECT TOP 1 MucGiamGia FROM LoHang 
                                    WHERE MaSanPham = '{maSP}' AND SoLuongHienTai > 0 
                                    ORDER BY HanSuDung ASC";
                DataTable dtSale = db.laydl(sqlCheckGiamGia);
                if (dtSale.Rows.Count > 0 && dtSale.Rows[0]["MucGiamGia"] != DBNull.Value)
                {
                    phanTramGiam = Convert.ToInt32(dtSale.Rows[0]["MucGiamGia"]);
                }
            }
            catch { phanTramGiam = 0; }

            // 2. Tính toán đơn giá bán thực tế sau khi giảm
            decimal donGiaBan = donGiaGoc * (100 - phanTramGiam) / 100;

            // 3. Cập nhật tên hiển thị nếu có giảm giá để nhân viên dễ nhận biết
            string tenHienThi = phanTramGiam > 0 ? $"{tenSP} (-{phanTramGiam}%)" : tenSP;

            // 4. Kiểm tra xem sản phẩm đã có trong giỏ hàng chưa
            DataRow foundRow = null;
            foreach (DataRow dr in dtGioHang.Rows)
            {
                // Kiểm tra mã sản phẩm
                if (dr["MaSanPham"].ToString() == maSP)
                {
                    foundRow = dr;
                    break;
                }
            }

            if (foundRow != null)
            {
                // Đã có trong giỏ -> Tăng số lượng
                int soLuongHienTai = int.Parse(foundRow["SoLuong"].ToString());
                if (soLuongHienTai + 1 > tonKho)
                {
                    MessageBox.Show($"Chỉ còn {tonKho} cái trong kho!", "Hết hàng");
                    return;
                }
                foundRow["SoLuong"] = soLuongHienTai + 1;
                // Tính tiền dựa trên đơn giá đã giảm
                foundRow["ThanhTien"] = (soLuongHienTai + 1) * donGiaBan;
            }
            else
            {
                // Chưa có -> Thêm dòng mới
                if (1 > tonKho)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!", "Thông báo");
                    return;
                }
                // Thêm vào DataTable giỏ hàng với đơn giá bán thực tế
                dtGioHang.Rows.Add(maSP, tenHienThi, 1, donGiaBan, donGiaBan);
            }

            TinhTongTien();
        }

        private void TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow dr in dtGioHang.Rows)
            {
                tong += decimal.Parse(dr["ThanhTien"].ToString());
            }
            lblTongTien.Text = string.Format("{0:N0} đ", tong);
            lblTongTien.Tag = tong;
            XuLyTienThua();
        }

        private void txtKhachDua_TextChanged(object sender, EventArgs e) => XuLyTienThua();

        private void XuLyTienThua()
        {
            try
            {
                if (lblTongTien.Tag == null) return;
                decimal tongTien = Convert.ToDecimal(lblTongTien.Tag);
                decimal khachDua = 0;
                if (!string.IsNullOrEmpty(txtKhachDua.Text))
                    decimal.TryParse(txtKhachDua.Text, out khachDua);

                decimal tienThua = khachDua - tongTien;
                lblTienThua.Text = (tienThua < 0) ? "Thiếu tiền" : string.Format("{0:N0} đ", tienThua);
            }
            catch { }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) => LocThucDon();
        private void cboLocLoai_SelectedIndexChanged(object sender, EventArgs e) => LocThucDon();

        private void LocThucDon()
        {
            DataTable dt = (DataTable)dgvThucDon.DataSource;
            if (dt != null)
            {
                string filter = $"TenSanPham LIKE '%{txtTimKiem.Text}%'";
                if (cboLocLoai.Text != "Tất cả" && !string.IsNullOrEmpty(cboLocLoai.Text))
                {
                    filter += $" AND TenDanhMuc = '{cboLocLoai.Text}'";
                }
                dt.DefaultView.RowFilter = filter;
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvGioHang.SelectedRows)
                {
                    if (!row.IsNewRow) dgvGioHang.Rows.Remove(row);
                }
                TinhTongTien();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtGioHang.Clear();
            TinhTongTien();
            txtKhachDua.Text = "";
            lblTienThua.Text = "0 đ";
            LoadThucDon();
        }

        // --- PHẦN 3: THANH TOÁN (SỬ DỤNG TRANSACTION) ---
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dtGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo");
                return;
            }

            decimal tongTien = Convert.ToDecimal(lblTongTien.Tag);
            decimal khachDua = 0;

            if (string.IsNullOrWhiteSpace(txtKhachDua.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền khách đưa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhachDua.Focus();
                return;
            }

            // Mở kết nối qua db.cn
            if (db.cn.State == ConnectionState.Closed) db.cn.Open();
            SqlTransaction transaction = db.cn.BeginTransaction();

            try
            {
                // 1. Lưu Hóa Đơn
                string sqlHoaDon = @"INSERT INTO HoaDon (NgayBan, TongTien, MaNhanVien) 
                                     VALUES (GETDATE(), @TongTien, @MaNhanVien);
                                     SELECT SCOPE_IDENTITY();";

                SqlCommand cmdHD = new SqlCommand(sqlHoaDon, db.cn, transaction);
                cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                cmdHD.Parameters.AddWithValue("@MaNhanVien", NhanVienBanHang);

                int maHDMoi = Convert.ToInt32(cmdHD.ExecuteScalar());

                // 2. Duyệt từng món trong giỏ hàng
                foreach (DataRow dr in dtGioHang.Rows)
                {
                    string maSP = dr["MaSanPham"].ToString();
                    int soLuongBan = Convert.ToInt32(dr["SoLuong"]);
                    decimal donGia = Convert.ToDecimal(dr["DonGia"]);

                    // a. Insert ChiTietHoaDon (Giữ nguyên)
                    string sqlChiTiet = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuong, DonGia) 
                          VALUES (@MaHoaDon, @MaSanPham, @SoLuong, @DonGia)";
                    SqlCommand cmdCT = new SqlCommand(sqlChiTiet, db.cn, transaction);
                    cmdCT.Parameters.AddWithValue("@MaHoaDon", maHDMoi);
                    cmdCT.Parameters.AddWithValue("@MaSanPham", maSP);
                    cmdCT.Parameters.AddWithValue("@SoLuong", soLuongBan);
                    cmdCT.Parameters.AddWithValue("@DonGia", donGia);
                    cmdCT.ExecuteNonQuery();

                   

                    // c. [MỚI] TRỪ KHO THEO LÔ (FIFO - Lô nào hạn gần nhất trừ trước)
                    int soLuongCanTru = soLuongBan;

                    // Truy vấn các lô hàng còn hàng của sản phẩm này, ưu tiên hạn dùng gần nhất
                    string sqlGetLo = @"SELECT MaLo, SoLuongHienTai FROM LoHang 
                        WHERE MaSanPham = @Ma AND SoLuongHienTai > 0 
                        ORDER BY HanSuDung ASC";

                    SqlCommand cmdGetLo = new SqlCommand(sqlGetLo, db.cn, transaction);
                    cmdGetLo.Parameters.AddWithValue("@Ma", maSP);

                    // Dùng DataTable để đọc dữ liệu lô hàng tạm thời trong transaction
                    DataTable dtLo = new DataTable();
                    using (SqlDataReader reader = cmdGetLo.ExecuteReader())
                    {
                        dtLo.Load(reader);
                    }

                    foreach (DataRow rowLo in dtLo.Rows)
                    {
                        if (soLuongCanTru <= 0) break;

                        int maLo = Convert.ToInt32(rowLo["MaLo"]);
                        int tonTrongLo = Convert.ToInt32(rowLo["SoLuongHienTai"]);
                        int thucTru = Math.Min(soLuongCanTru, tonTrongLo);

                        // Cập nhật trừ trong bảng LoHang
                        string sqlUpdateLo = "UPDATE LoHang SET SoLuongHienTai = SoLuongHienTai - @SL WHERE MaLo = @MaLo";
                        SqlCommand cmdUpdateLo = new SqlCommand(sqlUpdateLo, db.cn, transaction);
                        cmdUpdateLo.Parameters.AddWithValue("@SL", thucTru);
                        cmdUpdateLo.Parameters.AddWithValue("@MaLo", maLo);
                        cmdUpdateLo.ExecuteNonQuery();

                        soLuongCanTru -= thucTru;
                    }
                }
                transaction.Commit();

                int maHDVuaTao = maHDMoi; // Lưu lại mã hóa đơn vừa tạo để truyền sang form in hóa đơn

                MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHDMoi}",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form in hóa đơn và truyền mã hóa đơn mới tạo


                // --- CODE IN HÓA ĐƠN ---
                // Giả sử 'maHDMoi' là ID của hóa đơn vừa tạo
                string sqlHD = $@"SELECT h.MaHoaDon, h.NgayBan, nv.HoTen, s.TenSanPham, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien
                  FROM HoaDon h
                  JOIN ChiTietHoaDon c ON h.MaHoaDon = c.MaHoaDon
                  JOIN SanPham s ON c.MaSanPham = s.MaSanPham
                  JOIN NhanVien nv ON h.MaNhanVien = nv.MaNhanVien
                  WHERE h.MaHoaDon = {maHDMoi}";

                DataTable dtHD = db.laydl(sqlHD);
                frmInHoaDon fHD = new frmInHoaDon();
                fHD.HienThiBaoCao(dtHD, new rptHoaDon()); // Nạp cuộn phim Hóa đơn
                fHD.ShowDialog();


                btnLamMoi.PerformClick(); // Xóa giỏ hàng, load lại thực đơn
                // =================================
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
            finally
            {
                db.cn.Close(); // Luôn giải phóng kết nối
            }
        }

        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }
    }
}