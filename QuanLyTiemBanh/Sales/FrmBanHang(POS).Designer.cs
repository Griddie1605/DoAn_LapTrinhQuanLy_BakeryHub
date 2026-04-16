namespace BakeryHub
{
    partial class FrmBanHang_POS_
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.dgvThucDon = new System.Windows.Forms.DataGridView();
            this.panelTimKiem = new System.Windows.Forms.Panel();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.cboLocLoai = new System.Windows.Forms.ComboBox();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panelTinhTien = new System.Windows.Forms.Panel();
            this.lblTienThua = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtKhachDua = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).BeginInit();
            this.panelTimKiem.SuspendLayout();
            this.panelOrder.SuspendLayout();
            this.panelTinhTien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMenu.Controls.Add(this.dgvThucDon);
            this.panelMenu.Controls.Add(this.panelTimKiem);
            this.panelMenu.Controls.Add(this.panelOrder);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(954, 617);
            this.panelMenu.TabIndex = 0;
            // 
            // dgvThucDon
            // 
            this.dgvThucDon.AllowUserToAddRows = false;
            this.dgvThucDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThucDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThucDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvThucDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThucDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvThucDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThucDon.EnableHeadersVisualStyles = false;
            this.dgvThucDon.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvThucDon.Location = new System.Drawing.Point(0, 60);
            this.dgvThucDon.Name = "dgvThucDon";
            this.dgvThucDon.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgvThucDon.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvThucDon.RowTemplate.Height = 40;
            this.dgvThucDon.RowTemplate.ReadOnly = true;
            this.dgvThucDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThucDon.Size = new System.Drawing.Size(554, 557);
            this.dgvThucDon.TabIndex = 2;
            this.dgvThucDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThucDon_CellClick);
            // 
            // panelTimKiem
            // 
            this.panelTimKiem.BackColor = System.Drawing.Color.White;
            this.panelTimKiem.Controls.Add(this.btnTim);
            this.panelTimKiem.Controls.Add(this.txtTimKiem);
            this.panelTimKiem.Controls.Add(this.cboLocLoai);
            this.panelTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTimKiem.Location = new System.Drawing.Point(0, 0);
            this.panelTimKiem.Name = "panelTimKiem";
            this.panelTimKiem.Size = new System.Drawing.Size(554, 60);
            this.panelTimKiem.TabIndex = 1;
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(465, 12);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(41, 32);
            this.btnTim.TabIndex = 2;
            this.btnTim.Text = "🔍";
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(247, 13);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(198, 27);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // cboLocLoai
            // 
            this.cboLocLoai.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocLoai.FormattingEnabled = true;
            this.cboLocLoai.Location = new System.Drawing.Point(3, 13);
            this.cboLocLoai.Name = "cboLocLoai";
            this.cboLocLoai.Size = new System.Drawing.Size(238, 28);
            this.cboLocLoai.TabIndex = 0;
            this.cboLocLoai.Text = "Tất cả loại bánh";
            this.cboLocLoai.SelectedIndexChanged += new System.EventHandler(this.cboLocLoai_SelectedIndexChanged);
            // 
            // panelOrder
            // 
            this.panelOrder.BackColor = System.Drawing.Color.White;
            this.panelOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOrder.Controls.Add(this.btnLamMoi);
            this.panelOrder.Controls.Add(this.btnXoaMon);
            this.panelOrder.Controls.Add(this.btnThanhToan);
            this.panelOrder.Controls.Add(this.panelTinhTien);
            this.panelOrder.Controls.Add(this.dgvGioHang);
            this.panelOrder.Controls.Add(this.panel2);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOrder.Location = new System.Drawing.Point(554, 0);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(400, 617);
            this.panelOrder.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.ForeColor = System.Drawing.Color.DimGray;
            this.btnLamMoi.Location = new System.Drawing.Point(211, 472);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(164, 34);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.BackColor = System.Drawing.Color.Silver;
            this.btnXoaMon.FlatAppearance.BorderSize = 0;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaMon.ForeColor = System.Drawing.Color.DimGray;
            this.btnXoaMon.Location = new System.Drawing.Point(17, 472);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(163, 34);
            this.btnXoaMon.TabIndex = 4;
            this.btnXoaMon.Text = "Xoá món";
            this.btnXoaMon.UseVisualStyleBackColor = false;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnThanhToan.FlatAppearance.BorderSize = 0;
            this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Location = new System.Drawing.Point(17, 534);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(342, 60);
            this.btnThanhToan.TabIndex = 3;
            this.btnThanhToan.Text = "THANH TOÁN";
            this.btnThanhToan.UseVisualStyleBackColor = false;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panelTinhTien
            // 
            this.panelTinhTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panelTinhTien.Controls.Add(this.lblTienThua);
            this.panelTinhTien.Controls.Add(this.lblTongTien);
            this.panelTinhTien.Controls.Add(this.txtKhachDua);
            this.panelTinhTien.Controls.Add(this.label4);
            this.panelTinhTien.Controls.Add(this.label3);
            this.panelTinhTien.Controls.Add(this.label2);
            this.panelTinhTien.Location = new System.Drawing.Point(3, 310);
            this.panelTinhTien.Name = "panelTinhTien";
            this.panelTinhTien.Size = new System.Drawing.Size(396, 156);
            this.panelTinhTien.TabIndex = 2;
            // 
            // lblTienThua
            // 
            this.lblTienThua.AutoSize = true;
            this.lblTienThua.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienThua.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblTienThua.Location = new System.Drawing.Point(266, 110);
            this.lblTienThua.Name = "lblTienThua";
            this.lblTienThua.Size = new System.Drawing.Size(35, 25);
            this.lblTienThua.TabIndex = 2;
            this.lblTienThua.Text = "0đ";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblTongTien.Location = new System.Drawing.Point(282, 19);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(35, 25);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "0đ";
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKhachDua.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhachDua.Location = new System.Drawing.Point(236, 69);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(148, 29);
            this.txtKhachDua.TabIndex = 1;
            this.txtKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKhachDua.TextChanged += new System.EventHandler(this.txtKhachDua_TextChanged);
            this.txtKhachDua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKhachDua_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tiền thừa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Khách đưa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng tiền hàng:";
            // 
            // dgvGioHang
            // 
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvGioHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGioHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGioHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGioHang.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvGioHang.EnableHeadersVisualStyles = false;
            this.dgvGioHang.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvGioHang.Location = new System.Drawing.Point(5, 59);
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.RowHeadersVisible = false;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvGioHang.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvGioHang.RowTemplate.Height = 35;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(382, 245);
            this.dgvGioHang.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 50);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(141, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GIỎ HÀNG";
            // 
            // FrmBanHang_POS_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 617);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmBanHang_POS_";
            this.Text = "BÁN HÀNG - POS";
            this.Load += new System.EventHandler(this.FrmBanHang_POS__Load);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDon)).EndInit();
            this.panelTimKiem.ResumeLayout(false);
            this.panelTimKiem.PerformLayout();
            this.panelOrder.ResumeLayout(false);
            this.panelTinhTien.ResumeLayout(false);
            this.panelTinhTien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTinhTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTienThua;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Panel panelTimKiem;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboLocLoai;
        private System.Windows.Forms.DataGridView dgvThucDon;
    }
}