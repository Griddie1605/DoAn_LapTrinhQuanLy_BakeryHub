namespace BakeryHub
{
    partial class frmNhapkho
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.txtNhaCungCap = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHanSuDung = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.dgvChiTietNhap = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.dtpNgayNhap);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNhanVien);
            this.panel1.Controls.Add(this.txtNhaCungCap);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 100);
            this.panel1.TabIndex = 0;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhap.Location = new System.Drawing.Point(316, 65);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(185, 23);
            this.dtpNgayNhap.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHIẾU NHẬP KHO";
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhanVien.Enabled = false;
            this.txtNhanVien.Location = new System.Drawing.Point(703, 65);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(227, 23);
            this.txtNhanVien.TabIndex = 2;
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNhaCungCap.Location = new System.Drawing.Point(23, 65);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Size = new System.Drawing.Size(270, 23);
            this.txtNhaCungCap.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhà cung cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(700, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Người nhập";
            // 
            // dtpHanSuDung
            // 
            this.dtpHanSuDung.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHanSuDung.Location = new System.Drawing.Point(495, 31);
            this.dtpHanSuDung.Name = "dtpHanSuDung";
            this.dtpHanSuDung.Size = new System.Drawing.Size(163, 23);
            this.dtpHanSuDung.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(492, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "Hạn sử dụng";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dtpHanSuDung);
            this.panel2.Controls.Add(this.btnXoaDong);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.txtDonGia);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboSanPham);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 80);
            this.panel2.TabIndex = 1;
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.Gray;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(725, 13);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(88, 43);
            this.btnXoaDong.TabIndex = 4;
            this.btnXoaDong.Text = "Xoá";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(841, 13);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 43);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(315, 31);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(167, 23);
            this.txtDonGia.TabIndex = 3;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(227, 31);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(75, 23);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Giá nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Số lượng";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(24, 33);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(181, 23);
            this.cboSanPham.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sản Phẩm";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnLuuPhieu);
            this.panel3.Controls.Add(this.lblTongTien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 547);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 70);
            this.panel3.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "TỔNG TIỀN:";
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnLuuPhieu.FlatAppearance.BorderSize = 0;
            this.btnLuuPhieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(666, 13);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(242, 40);
            this.btnLuuPhieu.TabIndex = 1;
            this.btnLuuPhieu.Text = "LƯU PHIẾU VÀ NHẬP KHO";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTongTien.Location = new System.Drawing.Point(158, 18);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(42, 30);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "0 đ";
            // 
            // dgvChiTietNhap
            // 
            this.dgvChiTietNhap.AllowUserToAddRows = false;
            this.dgvChiTietNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChiTietNhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Peru;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietNhap.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvChiTietNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietNhap.EnableHeadersVisualStyles = false;
            this.dgvChiTietNhap.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvChiTietNhap.Location = new System.Drawing.Point(0, 180);
            this.dgvChiTietNhap.Name = "dgvChiTietNhap";
            this.dgvChiTietNhap.RowHeadersVisible = false;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            this.dgvChiTietNhap.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvChiTietNhap.RowTemplate.Height = 40;
            this.dgvChiTietNhap.RowTemplate.ReadOnly = true;
            this.dgvChiTietNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietNhap.Size = new System.Drawing.Size(954, 367);
            this.dgvChiTietNhap.TabIndex = 4;
            // 
            // frmNhapkho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 617);
            this.Controls.Add(this.dgvChiTietNhap);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmNhapkho";
            this.Text = "Nhập Kho";
            this.Load += new System.EventHandler(this.frmNhapkho_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNhaCungCap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.DateTimePicker dtpHanSuDung;
        private System.Windows.Forms.Label label9;
    }
}