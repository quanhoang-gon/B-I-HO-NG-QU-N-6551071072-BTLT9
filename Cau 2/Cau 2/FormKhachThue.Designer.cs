namespace Cau_2
{
    partial class FormKhachThue
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
            this.btnGayLoiThu = new System.Windows.Forms.Button();
            this.chkTamTru = new System.Windows.Forms.CheckBox();
            this.cboPhuongXa = new System.Windows.Forms.ComboBox();
            this.lblPhuongXa = new System.Windows.Forms.Label();
            this.cboTinhThanh = new System.Windows.Forms.ComboBox();
            this.lblTinhThanh = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.grpGioiTinh = new System.Windows.Forms.GroupBox();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtMaKhach = new System.Windows.Forms.TextBox();
            this.lblMaKhach = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.grpBoLoc = new System.Windows.Forms.GroupBox();
            this.btnBoLoc = new System.Windows.Forms.Button();
            this.cboLocTinh = new System.Windows.Forms.ComboBox();
            this.lblLocTinh = new System.Windows.Forms.Label();
            this.cboLocPhong = new System.Windows.Forms.ComboBox();
            this.lblLocPhong = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvKhachThue = new System.Windows.Forms.DataGridView();
            this.colMaKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaThue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQueQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTamTru = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTongKet = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpGioiTinh.SuspendLayout();
            this.grpBoLoc.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.pnlTop.Controls.Add(this.lblSubTitle);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1024, 65);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.lblSubTitle.Location = new System.Drawing.Point(16, 38);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(490, 17);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Hệ thống quản lý phòng trọ & khách thuê | Tích hợp API hành chính VN | Chịu lỗi mạng";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(14, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(418, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ NHÀ TRỌ - CÔ LAN (QL_NhaTro)";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.btnGayLoiThu);
            this.grpThongTin.Controls.Add(this.chkTamTru);
            this.grpThongTin.Controls.Add(this.cboPhuongXa);
            this.grpThongTin.Controls.Add(this.lblPhuongXa);
            this.grpThongTin.Controls.Add(this.cboTinhThanh);
            this.grpThongTin.Controls.Add(this.lblTinhThanh);
            this.grpThongTin.Controls.Add(this.cboPhong);
            this.grpThongTin.Controls.Add(this.lblPhong);
            this.grpThongTin.Controls.Add(this.txtSoDienThoai);
            this.grpThongTin.Controls.Add(this.lblSoDienThoai);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.grpGioiTinh);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtMaKhach);
            this.grpThongTin.Controls.Add(this.lblMaKhach);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpThongTin.Location = new System.Drawing.Point(12, 73);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(1000, 185);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khách thuê";
            // 
            // btnGayLoiThu
            // 
            this.btnGayLoiThu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.btnGayLoiThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGayLoiThu.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGayLoiThu.ForeColor = System.Drawing.Color.DarkRed;
            this.btnGayLoiThu.Location = new System.Drawing.Point(885, 142);
            this.btnGayLoiThu.Name = "btnGayLoiThu";
            this.btnGayLoiThu.Size = new System.Drawing.Size(100, 32);
            this.btnGayLoiThu.TabIndex = 20;
            this.btnGayLoiThu.Text = "⚡ Gây lỗi thử";
            this.btnGayLoiThu.UseVisualStyleBackColor = false;
            this.btnGayLoiThu.Click += new System.EventHandler(this.BtnGayLoiThu_Click);
            // 
            // chkTamTru
            // 
            this.chkTamTru.AutoSize = true;
            this.chkTamTru.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkTamTru.ForeColor = System.Drawing.Color.DarkBlue;
            this.chkTamTru.Location = new System.Drawing.Point(740, 102);
            this.chkTamTru.Name = "chkTamTru";
            this.chkTamTru.Size = new System.Drawing.Size(147, 19);
            this.chkTamTru.TabIndex = 15;
            this.chkTamTru.Text = "Đã đăng ký tạm trú";
            this.chkTamTru.UseVisualStyleBackColor = true;
            // 
            // cboPhuongXa
            // 
            this.cboPhuongXa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboPhuongXa.FormattingEnabled = true;
            this.cboPhuongXa.Location = new System.Drawing.Point(440, 99);
            this.cboPhuongXa.Name = "cboPhuongXa";
            this.cboPhuongXa.Size = new System.Drawing.Size(275, 25);
            this.cboPhuongXa.TabIndex = 14;
            // 
            // lblPhuongXa
            // 
            this.lblPhuongXa.AutoSize = true;
            this.lblPhuongXa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhuongXa.Location = new System.Drawing.Point(365, 104);
            this.lblPhuongXa.Name = "lblPhuongXa";
            this.lblPhuongXa.Size = new System.Drawing.Size(72, 15);
            this.lblPhuongXa.TabIndex = 13;
            this.lblPhuongXa.Text = "Phường/Xã:*";
            // 
            // cboTinhThanh
            // 
            this.cboTinhThanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhThanh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboTinhThanh.FormattingEnabled = true;
            this.cboTinhThanh.Location = new System.Drawing.Point(90, 99);
            this.cboTinhThanh.Name = "cboTinhThanh";
            this.cboTinhThanh.Size = new System.Drawing.Size(255, 25);
            this.cboTinhThanh.TabIndex = 12;
            this.cboTinhThanh.SelectedIndexChanged += new System.EventHandler(this.CboTinhThanh_SelectedIndexChanged);
            // 
            // lblTinhThanh
            // 
            this.lblTinhThanh.AutoSize = true;
            this.lblTinhThanh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTinhThanh.Location = new System.Drawing.Point(14, 104);
            this.lblTinhThanh.Name = "lblTinhThanh";
            this.lblTinhThanh.Size = new System.Drawing.Size(73, 15);
            this.lblTinhThanh.TabIndex = 11;
            this.lblTinhThanh.Text = "Tỉnh/Thành:*";
            // 
            // cboPhong
            // 
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboPhong.FormattingEnabled = true;
            this.cboPhong.Location = new System.Drawing.Point(740, 62);
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.Size = new System.Drawing.Size(245, 25);
            this.cboPhong.TabIndex = 10;
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPhong.Location = new System.Drawing.Point(670, 66);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(65, 15);
            this.lblPhong.TabIndex = 9;
            this.lblPhong.Text = "Phòng trọ:*";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSoDienThoai.Location = new System.Drawing.Point(440, 62);
            this.txtSoDienThoai.MaxLength = 15;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(200, 25);
            this.txtSoDienThoai.TabIndex = 8;
            // 
            // lblSoDienThoai
            // 
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoDienThoai.Location = new System.Drawing.Point(365, 66);
            this.lblSoDienThoai.Name = "lblSoDienThoai";
            this.lblSoDienThoai.Size = new System.Drawing.Size(43, 15);
            this.lblSoDienThoai.TabIndex = 7;
            this.lblSoDienThoai.Text = "Số ĐT:*";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new System.Drawing.Point(90, 62);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(255, 25);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNgaySinh.Location = new System.Drawing.Point(14, 66);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(67, 15);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh:*";
            // 
            // grpGioiTinh
            // 
            this.grpGioiTinh.Controls.Add(this.rdoNu);
            this.grpGioiTinh.Controls.Add(this.rdoNam);
            this.grpGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.grpGioiTinh.Location = new System.Drawing.Point(670, 16);
            this.grpGioiTinh.Name = "grpGioiTinh";
            this.grpGioiTinh.Size = new System.Drawing.Size(180, 42);
            this.grpGioiTinh.TabIndex = 4;
            this.grpGioiTinh.TabStop = false;
            this.grpGioiTinh.Text = "Giới tính:*";
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(100, 18);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(41, 19);
            this.rdoNu.TabIndex = 1;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Checked = true;
            this.rdoNam.Location = new System.Drawing.Point(25, 18);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(51, 19);
            this.rdoNam.TabIndex = 0;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHoTen.Location = new System.Drawing.Point(260, 26);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(380, 25);
            this.txtHoTen.TabIndex = 3;
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoTen.Location = new System.Drawing.Point(195, 31);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(51, 15);
            this.lblHoTen.TabIndex = 2;
            this.lblHoTen.Text = "Họ tên:*";
            // 
            // txtMaKhach
            // 
            this.txtMaKhach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtMaKhach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMaKhach.Location = new System.Drawing.Point(90, 26);
            this.txtMaKhach.Name = "txtMaKhach";
            this.txtMaKhach.ReadOnly = true;
            this.txtMaKhach.Size = new System.Drawing.Size(80, 25);
            this.txtMaKhach.TabIndex = 1;
            // 
            // lblMaKhach
            // 
            this.lblMaKhach.AutoSize = true;
            this.lblMaKhach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMaKhach.Location = new System.Drawing.Point(14, 31);
            this.lblMaKhach.Name = "lblMaKhach";
            this.lblMaKhach.Size = new System.Drawing.Size(61, 15);
            this.lblMaKhach.TabIndex = 0;
            this.lblMaKhach.Text = "Mã khách:";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLamMoi.Location = new System.Drawing.Point(340, 142);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 32);
            this.btnLamMoi.TabIndex = 19;
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
            this.btnXoa.Location = new System.Drawing.Point(235, 142);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 32);
            this.btnXoa.TabIndex = 18;
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
            this.btnSua.Location = new System.Drawing.Point(130, 142);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 32);
            this.btnSua.TabIndex = 17;
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
            this.btnThem.Location = new System.Drawing.Point(25, 142);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 32);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // grpBoLoc
            // 
            this.grpBoLoc.Controls.Add(this.btnBoLoc);
            this.grpBoLoc.Controls.Add(this.cboLocTinh);
            this.grpBoLoc.Controls.Add(this.lblLocTinh);
            this.grpBoLoc.Controls.Add(this.cboLocPhong);
            this.grpBoLoc.Controls.Add(this.lblLocPhong);
            this.grpBoLoc.Controls.Add(this.txtTimKiem);
            this.grpBoLoc.Controls.Add(this.lblTimKiem);
            this.grpBoLoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpBoLoc.Location = new System.Drawing.Point(12, 264);
            this.grpBoLoc.Name = "grpBoLoc";
            this.grpBoLoc.Size = new System.Drawing.Size(1000, 68);
            this.grpBoLoc.TabIndex = 2;
            this.grpBoLoc.TabStop = false;
            this.grpBoLoc.Text = "Tìm kiếm & Lọc dữ liệu";
            // 
            // btnBoLoc
            // 
            this.btnBoLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBoLoc.Location = new System.Drawing.Point(885, 24);
            this.btnBoLoc.Name = "btnBoLoc";
            this.btnBoLoc.Size = new System.Drawing.Size(95, 30);
            this.btnBoLoc.TabIndex = 6;
            this.btnBoLoc.Text = "Bỏ lọc";
            this.btnBoLoc.UseVisualStyleBackColor = false;
            this.btnBoLoc.Click += new System.EventHandler(this.BtnBoLoc_Click);
            // 
            // cboLocTinh
            // 
            this.cboLocTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboLocTinh.FormattingEnabled = true;
            this.cboLocTinh.Location = new System.Drawing.Point(645, 28);
            this.cboLocTinh.Name = "cboLocTinh";
            this.cboLocTinh.Size = new System.Drawing.Size(220, 23);
            this.cboLocTinh.TabIndex = 5;
            this.cboLocTinh.SelectedIndexChanged += new System.EventHandler(this.CboLocTinh_SelectedIndexChanged);
            // 
            // lblLocTinh
            // 
            this.lblLocTinh.AutoSize = true;
            this.lblLocTinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocTinh.Location = new System.Drawing.Point(585, 32);
            this.lblLocTinh.Name = "lblLocTinh";
            this.lblLocTinh.Size = new System.Drawing.Size(56, 15);
            this.lblLocTinh.TabIndex = 4;
            this.lblLocTinh.Text = "Lọc Tỉnh:";
            // 
            // cboLocPhong
            // 
            this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cboLocPhong.FormattingEnabled = true;
            this.cboLocPhong.Location = new System.Drawing.Point(395, 28);
            this.cboLocPhong.Name = "cboLocPhong";
            this.cboLocPhong.Size = new System.Drawing.Size(170, 23);
            this.cboLocPhong.TabIndex = 3;
            this.cboLocPhong.SelectedIndexChanged += new System.EventHandler(this.CboLocPhong_SelectedIndexChanged);
            // 
            // lblLocPhong
            // 
            this.lblLocPhong.AutoSize = true;
            this.lblLocPhong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLocPhong.Location = new System.Drawing.Point(325, 32);
            this.lblLocPhong.Name = "lblLocPhong";
            this.lblLocPhong.Size = new System.Drawing.Size(68, 15);
            this.lblLocPhong.TabIndex = 2;
            this.lblLocPhong.Text = "Lọc Phòng:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTimKiem.Location = new System.Drawing.Point(100, 28);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.PlaceholderText = "Nhập tên hoặc số ĐT...";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 23);
            this.txtTimKiem.TabIndex = 1;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.TxtTimKiem_TextChanged);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTimKiem.Location = new System.Drawing.Point(14, 32);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(79, 15);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm ĐT:";
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDanhSach.Controls.Add(this.dgvKhachThue);
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grpDanhSach.Location = new System.Drawing.Point(12, 338);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(1000, 280);
            this.grpDanhSach.TabIndex = 3;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách khách thuê phòng trọ";
            // 
            // dgvKhachThue
            // 
            this.dgvKhachThue.AllowUserToAddRows = false;
            this.dgvKhachThue.AllowUserToDeleteRows = false;
            this.dgvKhachThue.AllowUserToResizeRows = false;
            this.dgvKhachThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhachThue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachThue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachThue.ColumnHeadersHeight = 32;
            this.dgvKhachThue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKhach,
            this.colHoTen,
            this.colGioiTinh,
            this.colNgaySinh,
            this.colSoDienThoai,
            this.colTenPhong,
            this.colGiaThue,
            this.colQueQuan,
            this.colTamTru});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhachThue.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhachThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachThue.EnableHeadersVisualStyles = false;
            this.dgvKhachThue.Location = new System.Drawing.Point(3, 21);
            this.dgvKhachThue.MultiSelect = false;
            this.dgvKhachThue.Name = "dgvKhachThue";
            this.dgvKhachThue.ReadOnly = true;
            this.dgvKhachThue.RowHeadersVisible = false;
            this.dgvKhachThue.RowTemplate.Height = 28;
            this.dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachThue.Size = new System.Drawing.Size(994, 256);
            this.dgvKhachThue.TabIndex = 0;
            this.dgvKhachThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvKhachThue_CellClick);
            this.dgvKhachThue.SelectionChanged += new System.EventHandler(this.DgvKhachThue_SelectionChanged);
            // 
            // colMaKhach
            // 
            this.colMaKhach.DataPropertyName = "MaKhach";
            this.colMaKhach.HeaderText = "Mã";
            this.colMaKhach.Name = "colMaKhach";
            this.colMaKhach.ReadOnly = true;
            this.colMaKhach.Width = 50;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            this.colHoTen.Width = 160;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            this.colGioiTinh.Width = 75;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.DataPropertyName = "NgaySinhFormat";
            this.colNgaySinh.HeaderText = "Ngày sinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.ReadOnly = true;
            this.colNgaySinh.Width = 95;
            // 
            // colSoDienThoai
            // 
            this.colSoDienThoai.DataPropertyName = "SoDienThoai";
            this.colSoDienThoai.HeaderText = "SĐT";
            this.colSoDienThoai.Name = "colSoDienThoai";
            this.colSoDienThoai.ReadOnly = true;
            this.colSoDienThoai.Width = 100;
            // 
            // colTenPhong
            // 
            this.colTenPhong.DataPropertyName = "TenPhong";
            this.colTenPhong.HeaderText = "Tên phòng";
            this.colTenPhong.Name = "colTenPhong";
            this.colTenPhong.ReadOnly = true;
            this.colTenPhong.Width = 100;
            // 
            // colGiaThue
            // 
            this.colGiaThue.DataPropertyName = "GiaThueFormat";
            this.colGiaThue.HeaderText = "Giá thuê (đ)";
            this.colGiaThue.Name = "colGiaThue";
            this.colGiaThue.ReadOnly = true;
            this.colGiaThue.Width = 110;
            // 
            // colQueQuan
            // 
            this.colQueQuan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQueQuan.DataPropertyName = "QueQuan";
            this.colQueQuan.HeaderText = "Quê quán (Phường/Xã – Tỉnh/Thành)";
            this.colQueQuan.Name = "colQueQuan";
            this.colQueQuan.ReadOnly = true;
            // 
            // colTamTru
            // 
            this.colTamTru.DataPropertyName = "DaDangKyTamTru";
            this.colTamTru.HeaderText = "Tạm trú";
            this.colTamTru.Name = "colTamTru";
            this.colTamTru.ReadOnly = true;
            this.colTamTru.Width = 70;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.lblTongKet);
            this.pnlBottom.Controls.Add(this.lblTrangThai);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 624);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1024, 40);
            this.pnlBottom.TabIndex = 4;
            // 
            // lblTongKet
            // 
            this.lblTongKet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongKet.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongKet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(80)))), ((int)(((byte)(120)))));
            this.lblTongKet.Location = new System.Drawing.Point(500, 8);
            this.lblTongKet.Name = "lblTongKet";
            this.lblTongKet.Size = new System.Drawing.Size(510, 22);
            this.lblTongKet.TabIndex = 1;
            this.lblTongKet.Text = "Tổng: 0 khách | Đang thuê: 0 phòng | Trống: 0 phòng";
            this.lblTongKet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.lblTrangThai.ForeColor = System.Drawing.Color.DimGray;
            this.lblTrangThai.Location = new System.Drawing.Point(12, 11);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(53, 15);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Sẵn sàng";
            // 
            // FormKhachThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1024, 664);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpBoLoc);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormKhachThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà trọ - QL_NhaTro";
            this.Load += new System.EventHandler(this.FormKhachThue_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpGioiTinh.ResumeLayout(false);
            this.grpGioiTinh.PerformLayout();
            this.grpBoLoc.ResumeLayout(false);
            this.grpBoLoc.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.TextBox txtMaKhach;
        private System.Windows.Forms.Label lblMaKhach;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.GroupBox grpGioiTinh;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboTinhThanh;
        private System.Windows.Forms.Label lblTinhThanh;
        private System.Windows.Forms.ComboBox cboPhuongXa;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.CheckBox chkTamTru;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnGayLoiThu;
        private System.Windows.Forms.GroupBox grpBoLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocTinh;
        private System.Windows.Forms.Label lblLocTinh;
        private System.Windows.Forms.Button btnBoLoc;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvKhachThue;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblTongKet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKhach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaThue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQueQuan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTamTru;
    }
}
