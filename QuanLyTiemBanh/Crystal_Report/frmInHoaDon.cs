using BakeryHub.Crystal_Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace BakeryHub
{
    public partial class frmInHoaDon : Form
    {
        Database db = new Database(@"DESKTOP-RV61JR2\BINHTRONG", "BakeryHub");

        public frmInHoaDon()
        {
            InitializeComponent();
        }

        // HÀM VẠN NĂNG: Nhận dữ liệu (dt) và mẫu thiết kế (rptFile)
        public void HienThiBaoCao(DataTable dt, object rptFile)
        {
            try
            {
                // Ép kiểu rptFile về ReportDocument để dùng chung cho mọi file .rpt
                ReportDocument rpt = (ReportDocument)rptFile;

                // Đổ dữ liệu vào
                rpt.SetDataSource(dt);

                // Hiển thị lên Viewer
                crvViewer.ReportSource = rpt;
                crvViewer.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị báo cáo: " + ex.Message);
            }
        }
    }
}

