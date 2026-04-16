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
    public partial class frmLogin : Form
    {
        // 1. BIẾN TOÀN CỤC
        public static string QuyenTruyCap = "";
        public static string MaNhanVien = "";

        // 2. Kết nối SQL (Giữ nguyên chuỗi kết nối của bạn)
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- SỬA CÁCH GỌI HÀM DATABASE Ở ĐÂY ---

            // Vì hàm laydl trong Database.cs chỉ nhận vào 1 chuỗi string, 
            // nên mình sẽ truyền câu truy vấn trực tiếp vào đó.
            string sQueryDangNhap = "SELECT Quyen FROM NhanVien WHERE MaNhanVien = '" + username + "' AND MatKhau = '" + password + "'";

            try
            {
                // Gọi hàm laydl để lấy dữ liệu về dưới dạng DataTable
                DataTable dt = db.laydl(sQueryDangNhap);

                // Kiểm tra xem DataTable có dòng nào không (nếu có tức là đăng nhập đúng)
                if (dt.Rows.Count > 0)
                {
                    // Lấy giá trị Quyền từ dòng đầu tiên, cột "Quyen"
                    QuyenTruyCap = dt.Rows[0]["Quyen"].ToString();
                    MaNhanVien = username;

                    MessageBox.Show("Đăng nhập thành công! Chức vụ: " + QuyenTruyCap);

                    frmMain fMain = new frmMain();
                    fMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}