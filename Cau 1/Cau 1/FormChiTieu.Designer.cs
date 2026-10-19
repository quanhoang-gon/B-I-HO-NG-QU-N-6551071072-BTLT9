namespace Cau_1
{
    partial class FormChiTieu
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaCT = new System.Windows.Forms.TextBox();
            this.lblMaCT = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.nudSoTien = new System.Windows.Forms.NumericUpDown();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.cboLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblLoaiChi = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.dtpNgayChi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayChi = new System.Windows.Forms.Label();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnXoaLoc = new System.Windows.Forms.Button();
            this.btnLoc = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.chkLocTheoNgay = new System.Windows.Forms.CheckBox();
            this.cboLocLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblLocLoaiChi = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChiTieu = new System.Windows.Forms.DataGridView();
            this.colMaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblTongChi = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).BeginInit();
            this.grpBoLoc.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            this.pnlTop.Controls.Add(this.lblSubTitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblSubTitle.Location = new System.Drawing.Point(16, 38);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(434, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Quản lý chi tiêu hàng ngày | EF Core Database First | Logging & Deployment";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SỔ CHI TIÊU CÁ NHÂN";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.txtMaCT);
            this.grpThongTin.Controls.Add(this.lblMaCT);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.txtGhiChu);
            this.grpThongTin.Controls.Add(this.lblGhiChu);
            this.grpThongTin.Controls.Add(this.nudSoTien);
            this.grpThongTin.Controls.Add(this.lblSoTien);
            this.grpThongTin.Controls.Add(this.cboLoaiChi);
            this.grpThongTin.Controls.Add(this.lblLoaiChi);
            this.grpThongTin.Controls.Add(this.txtNoiDung);
            this.grpThongTin.Controls.Add(this.lblNoiDung);
            this.grpThongTin.Controls.Add(this.dtpNgayChi);
            this.grpThongTin.Controls.Add(this.lblNgayChi);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(12, 75);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(960, 160);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin chi tiêu";
            // 
            // txtMaCT
            // 
            this.txtMaCT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMaCT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaCT.Location = new System.Drawing.Point(90, 26);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.ReadOnly = true;
            this.txtMaCT.Size = new System.Drawing.Size(80, 25);
            this.txtMaCT.TabIndex = 1;
            // 
            // lblMaCT
            // 
            this.lblMaCT.AutoSize = true;
            this.lblMaCT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaCT.Location = new System.Drawing.Point(16, 31);
            this.lblMaCT.Name = "lblMaCT";
            this.lblMaCT.Size = new System.Drawing.Size(46, 15);
            this.lblMaCT.TabIndex = 0;
            this.lblMaCT.Text = "Mã chi:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.Location = new System.Drawing.Point(845, 118);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 32);
            this.btnLamMoi.TabIndex = 15;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(740, 118);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 32);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.BtnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(635, 118);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 32);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.BtnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(530, 118);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 32);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtGhiChu.Location = new System.Drawing.Point(530, 26);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(410, 80);
            this.txtGhiChu.TabIndex = 11;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGhiChu.Location = new System.Drawing.Point(468, 31);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 15);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // nudSoTien
            // 
            this.nudSoTien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudSoTien.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSoTien.Location = new System.Drawing.Point(300, 118);
            this.nudSoTien.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudSoTien.Name = "nudSoTien";
            this.nudSoTien.Size = new System.Drawing.Size(150, 25);
            this.nudSoTien.TabIndex = 9;
            this.nudSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSoTien.ThousandsSeparator = true;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoTien.Location = new System.Drawing.Point(225, 122);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(71, 15);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "Số tiền (đ):*";
            // 
            // cboLoaiChi
            // 
            this.cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboLoaiChi.FormattingEnabled = true;
            this.cboLoaiChi.Items.AddRange(new object[] {
            "Ăn uống",
            "Đi lại",
            "Học tập",
            "Giải trí",
            "Khác"});
            this.cboLoaiChi.Location = new System.Drawing.Point(90, 118);
            this.cboLoaiChi.Name = "cboLoaiChi";
            this.cboLoaiChi.Size = new System.Drawing.Size(125, 25);
            this.cboLoaiChi.TabIndex = 7;
            // 
            // lblLoaiChi
            // 
            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoaiChi.Location = new System.Drawing.Point(16, 122);
            this.lblLoaiChi.Name = "lblLoaiChi";
            this.lblLoaiChi.Size = new System.Drawing.Size(56, 15);
            this.lblLoaiChi.TabIndex = 6;
            this.lblLoaiChi.Text = "Loại chi:*";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNoiDung.Location = new System.Drawing.Point(90, 72);
            this.txtNoiDung.MaxLength = 100;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(360, 25);
            this.txtNoiDung.TabIndex = 5;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoiDung.Location = new System.Drawing.Point(16, 76);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(65, 15);
            this.lblNoiDung.TabIndex = 4;
            this.lblNoiDung.Text = "Nội dung:*";
            // 
            // dtpNgayChi
            // 
            this.dtpNgayChi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayChi.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayChi.Location = new System.Drawing.Point(260, 26);
            this.dtpNgayChi.Name = "dtpNgayChi";
            this.dtpNgayChi.Size = new System.Drawing.Size(190, 25);
            this.dtpNgayChi.TabIndex = 3;
            // 
            // lblNgayChi
            // 
            this.lblNgayChi.AutoSize = true;
            this.lblNgayChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNgayChi.Location = new System.Drawing.Point(195, 31);
            this.lblNgayChi.Name = "lblNgayChi";
            this.lblNgayChi.Size = new System.Drawing.Size(62, 15);
            this.lblNgayChi.TabIndex = 2;
            this.lblNgayChi.Text = "Ngày chi:*";
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnXoaLoc);
            this.grpBoLoc.Controls.Add(this.btnLoc);
            this.grpBoLoc.Controls.Add(this.dtpDenNgay);
            this.grpBoLoc.Controls.Add(this.lblDenNgay);
            this.grpBoLoc.Controls.Add(this.dtpTuNgay);
            this.grpBoLoc.Controls.Add(this.chkLocTheoNgay);
            this.grpBoLoc.Controls.Add(this.cboLocLoaiChi);
            this.grpBoLoc.Controls.Add(this.lblLocLoaiChi);
            this.grpBoLoc.Controls.Add(this.txtTimKiem);
            this.grpBoLoc.Controls.Add(this.lblTimKiem);
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpBoLoc.Location = new System.Drawing.Point(12, 241);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(960, 75);
            this.grpBoLoc.TabIndex = 2;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Tìm kiếm và Lọc dữ liệu";
            // 
            // btnXoaLoc
            // 
            this.btnXoaLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnXoaLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnXoaLoc.Location = new System.Drawing.Point(860, 27);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(80, 30);
            this.btnXoaLoc.TabIndex = 9;
            this.btnXoaLoc.Text = "Bỏ lọc";
            this.btnXoaLoc.UseVisualStyleBackColor = false;
            this.btnXoaLoc.Click += new System.EventHandler(this.BtnXoaLoc_Click);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(75)))), ((int)(((byte)(140)))));
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(775, 27);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(80, 30);
            this.btnLoc.TabIndex = 8;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.BtnLoc_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Enabled = false;
            this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(650, 30);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 23);
            this.dtpDenNgay.TabIndex = 7;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDenNgay.Location = new System.Drawing.Point(618, 34);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(30, 15);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "đến:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Enabled = false;
            this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(505, 30);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 23);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // chkLocTheoNgay
            // 
            this.chkLocTheoNgay.AutoSize = true;
            this.chkLocTheoNgay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkLocTheoNgay.Location = new System.Drawing.Point(435, 33);
            this.chkLocTheoNgay.Name = "chkLocTheoNgay";
            this.chkLocTheoNgay.Size = new System.Drawing.Size(68, 19);
            this.chkLocTheoNgay.TabIndex = 4;
            this.chkLocTheoNgay.Text = "Từ ngày:";
            this.chkLocTheoNgay.UseVisualStyleBackColor = true;
            this.chkLocTheoNgay.CheckedChanged += new System.EventHandler(this.ChkLocTheoNgay_CheckedChanged);
            // 
            // cboLocLoaiChi
            // 
            this.cboLocLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboLocLoaiChi.FormattingEnabled = true;
            this.cboLocLoaiChi.Items.AddRange(new object[] {
            "-- Tất cả --",
            "Ăn uống",
            "Đi lại",
            "Học tập",
            "Giải trí",
            "Khác"});
            this.cboLocLoaiChi.Location = new System.Drawing.Point(310, 30);
            this.cboLocLoaiChi.Name = "cboLocLoaiChi";
            this.cboLocLoaiChi.Size = new System.Drawing.Size(110, 23);
            this.cboLocLoaiChi.TabIndex = 3;
            this.cboLocLoaiChi.SelectedIndexChanged += new System.EventHandler(this.CboLocLoaiChi_SelectedIndexChanged);
            // 
            // lblLocLoaiChi
            // 
            this.lblLocLoaiChi.AutoSize = true;
            this.lblLocLoaiChi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocLoaiChi.Location = new System.Drawing.Point(255, 34);
            this.lblLocLoaiChi.Name = "lblLocLoaiChi";
            this.lblLocLoaiChi.Size = new System.Drawing.Size(51, 15);
            this.lblLocLoaiChi.TabIndex = 2;
            this.lblLocLoaiChi.Text = "Loại chi:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTimKiem.Location = new System.Drawing.Point(85, 30);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập nội dung tìm...";
            this.txtTimKiem.Size = new System.Drawing.Size(160, 23);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTimKiem_KeyDown);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimKiem.Location = new System.Drawing.Point(16, 34);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(63, 15);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Nội dung:";
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.dgvChiTieu);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpDanhSach.Location = new System.Drawing.Point(12, 322);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(960, 275);
            this.grpDanhSach.TabIndex = 3;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách chi tiêu";
            // 
            // dgvChiTieu
            // 
            this.dgvChiTieu.AllowUserToAddRows = false;
            this.dgvChiTieu.AllowUserToDeleteRows = false;
            this.dgvChiTieu.AllowUserToResizeRows = false;
            this.dgvChiTieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTieu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTieu.ColumnHeadersHeight = 32;
            this.dgvChiTieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaCT,
            this.colNgayChi,
            this.colNoiDung,
            this.colLoaiChi,
            this.colSoTien,
            this.colGhiChu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(225)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTieu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTieu.EnableHeadersVisualStyles = false;
            this.dgvChiTieu.Location = new System.Drawing.Point(3, 21);
            this.dgvChiTieu.MultiSelect = false;
            this.dgvChiTieu.Name = "dgvChiTieu";
            this.dgvChiTieu.ReadOnly = true;
            this.dgvChiTieu.RowHeadersVisible = false;
            this.dgvChiTieu.RowTemplate.Height = 28;
            this.dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTieu.Size = new System.Drawing.Size(954, 251);
            this.dgvChiTieu.TabIndex = 0;
            this.dgvChiTieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvChiTieu_CellClick);
            this.dgvChiTieu.SelectionChanged += new System.EventHandler(this.DgvChiTieu_SelectionChanged);
            // 
            // colMaCT
            // 
            this.colMaCT.DataPropertyName = "MaCt";
            this.colMaCT.HeaderText = "Mã";
            this.colMaCT.Name = "colMaCT";
            this.colMaCT.ReadOnly = true;
            this.colMaCT.Width = 60;
            // 
            // colNgayChi
            // 
            this.colNgayChi.DataPropertyName = "NgayChiFormat";
            this.colNgayChi.HeaderText = "Ngày chi";
            this.colNgayChi.Name = "colNgayChi";
            this.colNgayChi.ReadOnly = true;
            this.colNgayChi.Width = 100;
            // 
            // colNoiDung
            // 
            this.colNoiDung.DataPropertyName = "NoiDung";
            this.colNoiDung.HeaderText = "Nội dung chi";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.ReadOnly = true;
            this.colNoiDung.Width = 230;
            // 
            // colLoaiChi
            // 
            this.colLoaiChi.DataPropertyName = "LoaiChi";
            this.colLoaiChi.HeaderText = "Loại chi";
            this.colLoaiChi.Name = "colLoaiChi";
            this.colLoaiChi.ReadOnly = true;
            this.colLoaiChi.Width = 110;
            // 
            // colSoTien
            // 
            this.colSoTien.DataPropertyName = "SoTienFormat";
            this.colSoTien.HeaderText = "Số tiền (đ)";
            this.colSoTien.Name = "colSoTien";
            this.colSoTien.ReadOnly = true;
            this.colSoTien.Width = 130;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(248)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblTrangThai);
            this.pnlBottom.Controls.Add(this.lblTongChi);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 605);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(984, 45);
            this.pnlBottom.TabIndex = 4;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTrangThai.ForeColor = System.Drawing.Color.DimGray;
            this.lblTrangThai.Location = new System.Drawing.Point(12, 14);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(46, 15);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Sẵn sàng";
            // 
            // lblTongChi
            // 
            this.lblTongChi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblTongChi.Location = new System.Drawing.Point(450, 8);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.Size = new System.Drawing.Size(520, 28);
            this.lblTongChi.TabIndex = 1;
            this.lblTongChi.Text = "Tổng chi: 0 đ";
            this.lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(984, 650);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FormChiTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ chi tiêu cá nhân - QL_ChiTieu";
            this.Load += new System.EventHandler(this.FormChiTieu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).EndInit();
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaCT;
        private System.Windows.Forms.Label lblMaCT;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.NumericUpDown nudSoTien;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.ComboBox cboLoaiChi;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.DateTimePicker dtpNgayChi;
        private System.Windows.Forms.Label lblNgayChi;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.Button btnXoaLoc;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.CheckBox chkLocTheoNgay;
        private System.Windows.Forms.ComboBox cboLocLoaiChi;
        private System.Windows.Forms.Label lblLocLoaiChi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTongChi;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
