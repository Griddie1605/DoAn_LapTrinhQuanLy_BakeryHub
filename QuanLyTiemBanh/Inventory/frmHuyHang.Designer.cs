namespace BakeryHub
{
    partial class frmHuyHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.txtNhanVien = new System.Windows.Forms.TextBox();
            this.dtpNgayHuy = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvHuyHang = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLuuHuy = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnXuatDSHuyHang = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuyHang)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.txtLyDo);
            this.panel1.Controls.Add(this.txtNhanVien);
            this.panel1.Controls.Add(this.dtpNgayHuy);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 120);
            this.panel1.TabIndex = 0;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyDo.Location = new System.Drawing.Point(669, 69);
            this.txtLyDo.Multiline = true;
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(221, 23);
            this.txtLyDo.TabIndex = 3;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVien.Location = new System.Drawing.Point(408, 69);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(177, 23);
            this.txtNhanVien.TabIndex = 3;
            // 
            // dtpNgayHuy
            // 
            this.dtpNgayHuy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHuy.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayHuy.Location = new System.Drawing.Point(79, 69);
            this.dtpNgayHuy.Name = "dtpNgayHuy";
            this.dtpNgayHuy.Size = new System.Drawing.Size(200, 23);
            this.dtpNgayHuy.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lý do huỷ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(310, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Người lập phiếu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày huỷ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHIẾU HỦY HÀNG / HẾT HẠN";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.cboSanPham);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 120);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(954, 70);
            this.panel2.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(801, 10);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 43);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(131, 24);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(186, 23);
            this.cboSanPham.TabIndex = 0;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(429, 21);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(88, 23);
            this.txtSoLuong.TabIndex = 3;
            this.txtSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoLuong_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Chọn bánh cần huỷ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số lượng huỷ";
            // 
            // dgvHuyHang
            // 
            this.dgvHuyHang.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(180)))), ((int)(((byte)(150)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHuyHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHuyHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHuyHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHuyHang.Location = new System.Drawing.Point(0, 190);
            this.dgvHuyHang.Name = "dgvHuyHang";
            this.dgvHuyHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHuyHang.Size = new System.Drawing.Size(954, 427);
            this.dgvHuyHang.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.panel3.Controls.Add(this.btnXuatDSHuyHang);
            this.panel3.Controls.Add(this.btnLuuHuy);
            this.panel3.Controls.Add(this.btnXoaDong);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 547);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 70);
            this.panel3.TabIndex = 3;
            // 
            // btnLuuHuy
            // 
            this.btnLuuHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            this.btnLuuHuy.FlatAppearance.BorderSize = 0;
            this.btnLuuHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuHuy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuHuy.ForeColor = System.Drawing.Color.White;
            this.btnLuuHuy.Location = new System.Drawing.Point(685, 15);
            this.btnLuuHuy.Name = "btnLuuHuy";
            this.btnLuuHuy.Size = new System.Drawing.Size(242, 40);
            this.btnLuuHuy.TabIndex = 6;
            this.btnLuuHuy.Text = "XÁC NHẬN HUỶ HÀNG";
            this.btnLuuHuy.UseVisualStyleBackColor = false;
            this.btnLuuHuy.Click += new System.EventHandler(this.btnLuuHuy_Click);
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.Gray;
            this.btnXoaDong.FlatAppearance.BorderSize = 0;
            this.btnXoaDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaDong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDong.ForeColor = System.Drawing.Color.White;
            this.btnXoaDong.Location = new System.Drawing.Point(27, 15);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(88, 43);
            this.btnXoaDong.TabIndex = 5;
            this.btnXoaDong.Text = "Xoá";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnXuatDSHuyHang
            // 
            this.btnXuatDSHuyHang.BackColor = System.Drawing.Color.OliveDrab;
            this.btnXuatDSHuyHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatDSHuyHang.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatDSHuyHang.ForeColor = System.Drawing.Color.White;
            this.btnXuatDSHuyHang.Location = new System.Drawing.Point(475, 15);
            this.btnXuatDSHuyHang.Name = "btnXuatDSHuyHang";
            this.btnXuatDSHuyHang.Size = new System.Drawing.Size(110, 43);
            this.btnXuatDSHuyHang.TabIndex = 20;
            this.btnXuatDSHuyHang.Text = "Xuất...";
            this.btnXuatDSHuyHang.UseVisualStyleBackColor = false;
            this.btnXuatDSHuyHang.Click += new System.EventHandler(this.btnXuatDSHoaDon_Click);
            // 
            // frmHuyHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 617);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvHuyHang);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHuyHang";
            this.Text = "Huỷ Hàng";
            this.Load += new System.EventHandler(this.frmHuyHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHuyHang)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNhanVien;
        private System.Windows.Forms.DateTimePicker dtpNgayHuy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvHuyHang;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnLuuHuy;
        private System.Windows.Forms.Button btnXuatDSHuyHang;
    }
}