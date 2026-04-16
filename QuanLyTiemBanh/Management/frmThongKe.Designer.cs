namespace BakeryHub
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnXem = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoDonHang = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMonBanChay = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTongLoiNhuan = new System.Windows.Forms.Label();
            this.btnInDoanhThu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(864, 12);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(65, 37);
            this.btnXem.TabIndex = 2;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(696, 29);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(113, 25);
            this.dtpDenNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(567, 29);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(117, 25);
            this.dtpTuNgay.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(693, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(564, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bảng Tin Tiệm Bánh Sweet Bakery";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.Location = new System.Drawing.Point(18, 47);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(28, 32);
            this.lblTongDoanhThu.TabIndex = 0;
            this.lblTongDoanhThu.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TỔNG DOANH THU";
            // 
            // lblSoDonHang
            // 
            this.lblSoDonHang.AutoSize = true;
            this.lblSoDonHang.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDonHang.Location = new System.Drawing.Point(20, 47);
            this.lblSoDonHang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoDonHang.Name = "lblSoDonHang";
            this.lblSoDonHang.Size = new System.Drawing.Size(28, 32);
            this.lblSoDonHang.TabIndex = 0;
            this.lblSoDonHang.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(23, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "SỐ ĐƠN HÀNG";
            // 
            // lblMonBanChay
            // 
            this.lblMonBanChay.AutoSize = true;
            this.lblMonBanChay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonBanChay.Location = new System.Drawing.Point(17, 47);
            this.lblMonBanChay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonBanChay.Name = "lblMonBanChay";
            this.lblMonBanChay.Size = new System.Drawing.Size(44, 32);
            this.lblMonBanChay.TabIndex = 0;
            this.lblMonBanChay.Text = "---";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "MÓN BÁN CHẠY NHẤT";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend1);
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 254);
            this.chartDoanhThu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu.Series.Add(series1);
            this.chartDoanhThu.Size = new System.Drawing.Size(954, 363);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "chart1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 210);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "Biểu Đồ Doanh Thu Theo Ngày";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpTuNgay);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpDenNgay);
            this.panel1.Controls.Add(this.btnXem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 60);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblTongDoanhThu);
            this.panel2.Location = new System.Drawing.Point(12, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(192, 114);
            this.panel2.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LimeGreen;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(192, 5);
            this.panel5.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblSoDonHang);
            this.panel3.Location = new System.Drawing.Point(421, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(141, 114);
            this.panel3.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Orange;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(141, 5);
            this.panel6.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.lblMonBanChay);
            this.panel4.Location = new System.Drawing.Point(579, 78);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(350, 114);
            this.panel4.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Pink;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(350, 5);
            this.panel7.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Controls.Add(this.lblTongLoiNhuan);
            this.panel8.Location = new System.Drawing.Point(210, 78);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(192, 114);
            this.panel8.TabIndex = 4;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.LimeGreen;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(192, 5);
            this.panel9.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "TỔNG LỢI NHUẬN";
            // 
            // lblTongLoiNhuan
            // 
            this.lblTongLoiNhuan.AutoSize = true;
            this.lblTongLoiNhuan.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongLoiNhuan.Location = new System.Drawing.Point(18, 47);
            this.lblTongLoiNhuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongLoiNhuan.Name = "lblTongLoiNhuan";
            this.lblTongLoiNhuan.Size = new System.Drawing.Size(28, 32);
            this.lblTongLoiNhuan.TabIndex = 0;
            this.lblTongLoiNhuan.Text = "0";
            // 
            // btnInDoanhThu
            // 
            this.btnInDoanhThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(85)))), ((int)(((byte)(75)))));
            this.btnInDoanhThu.FlatAppearance.BorderSize = 0;
            this.btnInDoanhThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDoanhThu.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInDoanhThu.ForeColor = System.Drawing.Color.White;
            this.btnInDoanhThu.Location = new System.Drawing.Point(839, 205);
            this.btnInDoanhThu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnInDoanhThu.Name = "btnInDoanhThu";
            this.btnInDoanhThu.Size = new System.Drawing.Size(90, 37);
            this.btnInDoanhThu.TabIndex = 3;
            this.btnInDoanhThu.Text = "In Thống Kê";
            this.btnInDoanhThu.UseVisualStyleBackColor = false;
            this.btnInDoanhThu.Click += new System.EventHandler(this.btnInDoanhThu_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(954, 617);
            this.Controls.Add(this.btnInDoanhThu);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chartDoanhThu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmThongKe";
            this.Text = "Thống Kê";
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoDonHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblMonBanChay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTongLoiNhuan;
        private System.Windows.Forms.Button btnInDoanhThu;
    }
}