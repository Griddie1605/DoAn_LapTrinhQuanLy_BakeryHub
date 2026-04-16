namespace BakeryHub
{
    partial class frmSanPham
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTaiFileMau = new System.Windows.Forms.Label();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnInBaoCao = new System.Windows.Forms.Button();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.Tomato;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(231, 325);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.Turquoise;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(365, 324);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 35);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Gold;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(137, 325);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 35);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Silver;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.White;
            this.btnHuy.Location = new System.Drawing.Point(446, 324);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 35);
            this.btnHuy.TabIndex = 2;
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Orange;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(48, 325);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 35);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // grpThongTin
            // 
            this.grpThongTin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpThongTin.Controls.Add(this.txtHinhAnh);
            this.grpThongTin.Controls.Add(this.cboDanhMuc);
            this.grpThongTin.Controls.Add(this.btnChonAnh);
            this.grpThongTin.Controls.Add(this.picHinhAnh);
            this.grpThongTin.Controls.Add(this.txtDonGia);
            this.grpThongTin.Controls.Add(this.label5);
            this.grpThongTin.Controls.Add(this.label4);
            this.grpThongTin.Controls.Add(this.txtTenSP);
            this.grpThongTin.Controls.Add(this.label3);
            this.grpThongTin.Controls.Add(this.txtMaSP);
            this.grpThongTin.Controls.Add(this.label2);
            this.grpThongTin.Location = new System.Drawing.Point(15, 59);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(891, 260);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin chi tiết";
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(698, 212);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHinhAnh.Size = new System.Drawing.Size(100, 25);
            this.txtHinhAnh.TabIndex = 4;
            this.txtHinhAnh.Visible = false;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(45, 159);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(346, 25);
            this.cboDanhMuc.TabIndex = 3;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnChonAnh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonAnh.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonAnh.ForeColor = System.Drawing.Color.White;
            this.btnChonAnh.Location = new System.Drawing.Point(560, 96);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(82, 42);
            this.btnChonAnh.TabIndex = 2;
            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.UseVisualStyleBackColor = false;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Location = new System.Drawing.Point(663, 24);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(180, 180);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 1;
            this.picHinhAnh.TabStop = false;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(45, 212);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(346, 25);
            this.txtDonGia.TabIndex = 0;
            this.txtDonGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGia_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Danh mục";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(45, 105);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(346, 25);
            this.txtTenSP.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên Bánh";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(45, 53);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(346, 25);
            this.txtMaSP.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Sản phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label1.Location = new System.Drawing.Point(337, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.OliveDrab;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(575, 325);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 35);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(32, 365);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(874, 206);
            this.dgvSanPham.TabIndex = 3;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnInBaoCao);
            this.panel1.Controls.Add(this.btnTaiFileMau);
            this.panel1.Controls.Add(this.dgvSanPham);
            this.panel1.Controls.Add(this.btnXuat);
            this.panel1.Controls.Add(this.btnNhap);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.grpThongTin);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 617);
            this.panel1.TabIndex = 4;
            // 
            // btnTaiFileMau
            // 
            this.btnTaiFileMau.AutoSize = true;
            this.btnTaiFileMau.Location = new System.Drawing.Point(858, 333);
            this.btnTaiFileMau.Name = "btnTaiFileMau";
            this.btnTaiFileMau.Size = new System.Drawing.Size(75, 17);
            this.btnTaiFileMau.TabIndex = 4;
            this.btnTaiFileMau.Text = "Tải file mẫu";
            this.btnTaiFileMau.Click += new System.EventHandler(this.btnTaiFileMau_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.BackColor = System.Drawing.Color.OliveDrab;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(777, 325);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(75, 35);
            this.btnXuat.TabIndex = 2;
            this.btnXuat.Text = "Xuất...";
            this.btnXuat.UseVisualStyleBackColor = false;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnNhap
            // 
            this.btnNhap.BackColor = System.Drawing.Color.OliveDrab;
            this.btnNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhap.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhap.ForeColor = System.Drawing.Color.White;
            this.btnNhap.Location = new System.Drawing.Point(696, 325);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 35);
            this.btnNhap.TabIndex = 2;
            this.btnNhap.Text = "Nhập...";
            this.btnNhap.UseVisualStyleBackColor = false;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // btnInBaoCao
            // 
            this.btnInBaoCao.BackColor = System.Drawing.Color.OliveDrab;
            this.btnInBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBaoCao.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnInBaoCao.Location = new System.Drawing.Point(815, 577);
            this.btnInBaoCao.Name = "btnInBaoCao";
            this.btnInBaoCao.Size = new System.Drawing.Size(75, 35);
            this.btnInBaoCao.TabIndex = 5;
            this.btnInBaoCao.Text = "In Báo Cáo";
            this.btnInBaoCao.UseVisualStyleBackColor = false;
            this.btnInBaoCao.Click += new System.EventHandler(this.btnInBaoCao_Click);
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(954, 617);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSanPham";
            this.Text = "Quản Lý Sản Phẩm";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Label btnTaiFileMau;
        private System.Windows.Forms.Button btnInBaoCao;
    }
}