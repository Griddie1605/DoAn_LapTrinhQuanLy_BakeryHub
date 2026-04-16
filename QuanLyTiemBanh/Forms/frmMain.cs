using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Thư viện này dùng để làm chức năng kéo thả cửa sổ không viền
using System.Runtime.InteropServices;

namespace BakeryHub
{
    public partial class frmMain : Form
    {
        // 1. Khai báo biến toàn cục
        private Button currentButton; // Nút đang được chọn
        private Form currentChildForm; // Form con đang mở

        public frmMain()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false; // Tắt các nút mặc định của Windows

            // Bật tính năng DoubleBuffered để giảm giật lag giao diện
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        // --- PHẦN 1: XỬ LÝ MÀU SẮC NÚT BẤM ---

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton(); // Trả màu cũ cho nút trước đó

                    // Lấy nút vừa bấm và đổi màu
                    currentButton = (Button)btnSender;
                    // Màu Nâu Sáng (Active Color): 145, 115, 100
                    currentButton.BackColor = Color.FromArgb(145, 115, 100);
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    // Trả về màu Nâu Đậm gốc: 105, 85, 75
                    previousBtn.BackColor = Color.FromArgb(105, 85, 75);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
                }
            }
        }

        // --- PHẦN 2: HÀM MỞ FORM CON ---

        private void OpenChildForm(Form childForm, object btnSender)
        {
            // Đóng form cũ nếu đang mở
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // Đổi màu nút
            ActivateButton(btnSender);

            currentChildForm = childForm;

            // Thiết lập để nhúng vào Panel
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm vào Panel Chính (panelDesktop)
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;

            // Hiển thị
            childForm.BringToFront();
            childForm.Show();

            // Đổi tiêu đề ở trên cùng
            lblTitle.Text = childForm.Text.ToUpper();
        }

        // --- PHẦN 3: SỰ KIỆN CLICK CÁC NÚT ---

        // 1. Nút Sản Phẩm
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            // Mở form SanPham, truyền nút này vào để đổi màu
            OpenChildForm(new frmSanPham(), sender);
        }

        // 2. Nút Nhân Viên
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmQuanLyNhanVien(), sender);
        }

        // 3. Nút Bán Hàng
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmBanHang_POS_(), sender);
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            // 1. Nếu đang mở form con khác thì đóng lại
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            // 2. Reset lại màu các nút khác (Hàm Reset bạn đã có trong code cũ)
            Reset();

            // 3. Mở form Trang Chủ
            // Quan trọng: Truyền 'btnTrangChu' vào để nó đổi màu sáng lên
            OpenChildForm(new frmTrangChu(), btnMain);
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "TRANG CHỦ";
            currentButton = null;
        }

        // --- PHẦN 4: CÁC NÚT HỆ THỐNG ---
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- PHẦN 5: KÉO THẢ CỬA SỔ KHÔNG VIỀN ---
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 1. Gọi nút Trang chủ mặc định (code cũ)
            btnMain.PerformClick();

            // 2. PHÂN QUYỀN (Code mới)
            PhanQuyen();
        }
        private void PhanQuyen()
        {
            // Kiểm tra quyền từ biến static bên form Login
            if (frmLogin.QuyenTruyCap == "NhanVien")
            {
                // Nếu là Nhân viên bán hàng:
                // CHỈ ĐƯỢC THẤY: Trang chủ, Bán hàng, Đăng xuất
                // PHẢI ẨN: Sản phẩm, Nhân viên, Báo cáo, Nhập kho...

                // Ẩn các nút trên Sidebar
                btnSanPham.Visible = false;   // Nhân viên không được sửa giá/ảnh bánh
                btnNhanVien.Visible = false;  // Nhân viên không được xem bảng nhân viên
                

                // Ẩn các menu trên MenuStrip 
                sảnPhẩmToolStripMenuItem.Visible = false;
                danhMụcSảnPhẩmToolStripMenuItem.Visible = false;
                nhânViênToolStripMenuItem.Visible = false;

                nhậpKhoToolStripMenuItem.Visible = false;
                doanhThuToolStripMenuItem.Visible = false;
                
            }
            else
            {
                // Nếu là Admin: Hiện tất cả
            }
        }


        // --- XỬ LÝ MENU STRIP ---
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin login = new frmLogin();
            login.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmThongKe(), null);
        }

        private void nhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhapkho(), null);
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBanHang.PerformClick();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSanPham.PerformClick();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            // Mở form SanPham, truyền nút này vào để đổi màu
            OpenChildForm(new frmQuanLyHoaDon(), sender);
        }

        private void danhMụcSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form SanPham, truyền nút này vào để đổi màu
            OpenChildForm(new frmDanhMuc(), null);
        }

        private void huỷHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHuyHang(), null);
        }

        private void lịchSửNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuNhapKho(), null);
        }

        private void hoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnBaoCao.PerformClick();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNhanVien.PerformClick();
        }

        private void lịchSửHuỷHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLichSuHuyHang(), null);
        }
    }
}
