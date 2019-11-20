namespace Home
{
    partial class frmDatKhachDoan
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatKhachDoan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTimDoan = new System.Windows.Forms.Button();
            this.txtSdtDoan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTruongDoan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTongSoPhong = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTKcmnd = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnKhToView = new System.Windows.Forms.Button();
            this.dgvDsKH = new DevExpress.XtraGrid.GridControl();
            this.gridViewDsKH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboPhong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.dtmNgayRa = new System.Windows.Forms.DateTimePicker();
            this.dgvLoaiPhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewLoaiPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tenLoaiPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.giaPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.phongTrong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.soLuongPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bteSoLuong = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.toolTipKH = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddKhAutoPhong = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimDoan);
            this.groupBox1.Controls.Add(this.txtSdtDoan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTruongDoan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTenDoan);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(-4, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 177);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đoàn";
            // 
            // btnTimDoan
            // 
            this.btnTimDoan.Location = new System.Drawing.Point(525, 27);
            this.btnTimDoan.Name = "btnTimDoan";
            this.btnTimDoan.Size = new System.Drawing.Size(47, 32);
            this.btnTimDoan.TabIndex = 17;
            this.btnTimDoan.Text = "TK";
            this.btnTimDoan.UseVisualStyleBackColor = true;
            this.btnTimDoan.Click += new System.EventHandler(this.btnTimDoan_Click);
            // 
            // txtSdtDoan
            // 
            this.txtSdtDoan.Location = new System.Drawing.Point(200, 30);
            this.txtSdtDoan.Multiline = true;
            this.txtSdtDoan.Name = "txtSdtDoan";
            this.txtSdtDoan.Size = new System.Drawing.Size(319, 29);
            this.txtSdtDoan.TabIndex = 15;
            this.txtSdtDoan.Text = "123456789";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Số điện thoại";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTruongDoan
            // 
            this.txtTruongDoan.Location = new System.Drawing.Point(200, 142);
            this.txtTruongDoan.Multiline = true;
            this.txtTruongDoan.Name = "txtTruongDoan";
            this.txtTruongDoan.Size = new System.Drawing.Size(372, 29);
            this.txtTruongDoan.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên trưởng đoàn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTenDoan
            // 
            this.txtTenDoan.Location = new System.Drawing.Point(200, 71);
            this.txtTenDoan.Multiline = true;
            this.txtTenDoan.Name = "txtTenDoan";
            this.txtTenDoan.Size = new System.Drawing.Size(372, 29);
            this.txtTenDoan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên đoàn";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(200, 106);
            this.txtDiaChi.Multiline = true;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(372, 29);
            this.txtDiaChi.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Địa chỉ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.btnThemKH.Image = global::Home.Properties.Resources.add_icon;
            this.btnThemKH.Location = new System.Drawing.Point(1018, 94);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(39, 37);
            this.btnThemKH.TabIndex = 21;
            this.btnThemKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTipKH.SetToolTip(this.btnThemKH, "Thêm khách hàng");
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTongSoPhong);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Location = new System.Drawing.Point(-4, 790);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 46);
            this.panel1.TabIndex = 17;
            // 
            // lblTongSoPhong
            // 
            this.lblTongSoPhong.AutoSize = true;
            this.lblTongSoPhong.Location = new System.Drawing.Point(196, 11);
            this.lblTongSoPhong.Name = "lblTongSoPhong";
            this.lblTongSoPhong.Size = new System.Drawing.Size(21, 24);
            this.lblTongSoPhong.TabIndex = 5;
            this.lblTongSoPhong.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng số phòng: ";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(945, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(105, 47);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(760, 0);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(109, 47);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTKcmnd
            // 
            this.txtTKcmnd.Location = new System.Drawing.Point(39, 27);
            this.txtTKcmnd.Name = "txtTKcmnd";
            this.txtTKcmnd.Size = new System.Drawing.Size(293, 32);
            this.txtTKcmnd.TabIndex = 20;
            this.txtTKcmnd.Enter += new System.EventHandler(this.txtTKcmnd_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnKhToView);
            this.groupBox3.Controls.Add(this.txtTKcmnd);
            this.groupBox3.Location = new System.Drawing.Point(618, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 75);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnKhToView
            // 
            this.btnKhToView.Location = new System.Drawing.Point(350, 29);
            this.btnKhToView.Name = "btnKhToView";
            this.btnKhToView.Size = new System.Drawing.Size(103, 30);
            this.btnKhToView.TabIndex = 22;
            this.btnKhToView.Text = "Add KH";
            this.btnKhToView.UseVisualStyleBackColor = true;
            this.btnKhToView.Click += new System.EventHandler(this.btnKhToView_Click);
            // 
            // dgvDsKH
            // 
            this.dgvDsKH.Location = new System.Drawing.Point(-4, 439);
            this.dgvDsKH.MainView = this.gridViewDsKH;
            this.dgvDsKH.Name = "dgvDsKH";
            this.dgvDsKH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboPhong});
            this.dgvDsKH.Size = new System.Drawing.Size(1112, 351);
            this.dgvDsKH.TabIndex = 22;
            this.dgvDsKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDsKH});
            // 
            // gridViewDsKH
            // 
            this.gridViewDsKH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridViewDsKH.GridControl = this.dgvDsKH;
            this.gridViewDsKH.Name = "gridViewDsKH";
            this.gridViewDsKH.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên khách hàng";
            this.gridColumn1.FieldName = "TenKH";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 246;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Số CMND";
            this.gridColumn4.FieldName = "SoCMND";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 245;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Số điện thoại";
            this.gridColumn5.FieldName = "SoDT";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 258;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Số phòng";
            this.gridColumn6.ColumnEdit = this.cboPhong;
            this.gridColumn6.FieldName = "SoPhong";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 212;
            // 
            // cboPhong
            // 
            this.cboPhong.AutoHeight = false;
            this.cboPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhong.Name = "cboPhong";
            this.cboPhong.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.cboPhong_ButtonClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(-4, 403);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(859, 30);
            this.labelControl3.TabIndex = 23;
            this.labelControl3.Text = "Danh sách khách hàng theo đoàn";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(-4, 184);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(1112, 30);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Danh sách loại phòng trống";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13F);
            this.label6.Location = new System.Drawing.Point(627, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 37);
            this.label6.TabIndex = 27;
            this.label6.Text = "Ngày trả phòng";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtmNgayRa
            // 
            this.dtmNgayRa.CustomFormat = "dd/MM/yyyy";
            this.dtmNgayRa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmNgayRa.Location = new System.Drawing.Point(783, 96);
            this.dtmNgayRa.Name = "dtmNgayRa";
            this.dtmNgayRa.Size = new System.Drawing.Size(190, 32);
            this.dtmNgayRa.TabIndex = 26;
            this.dtmNgayRa.ValueChanged += new System.EventHandler(this.dtmNgayRa_ValueChanged);
            // 
            // dgvLoaiPhong
            // 
            this.dgvLoaiPhong.Location = new System.Drawing.Point(-4, 220);
            this.dgvLoaiPhong.MainView = this.gridViewLoaiPhong;
            this.dgvLoaiPhong.Name = "dgvLoaiPhong";
            this.dgvLoaiPhong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.bteSoLuong});
            this.dgvLoaiPhong.Size = new System.Drawing.Size(1112, 177);
            this.dgvLoaiPhong.TabIndex = 28;
            this.dgvLoaiPhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewLoaiPhong});
            // 
            // gridViewLoaiPhong
            // 
            this.gridViewLoaiPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tenLoaiPhong,
            this.giaPhong,
            this.phongTrong,
            this.soLuongPhong});
            this.gridViewLoaiPhong.GridControl = this.dgvLoaiPhong;
            this.gridViewLoaiPhong.Name = "gridViewLoaiPhong";
            this.gridViewLoaiPhong.OptionsView.ShowGroupPanel = false;
            this.gridViewLoaiPhong.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewLoaiPhong_RowCellClick);
            // 
            // tenLoaiPhong
            // 
            this.tenLoaiPhong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tenLoaiPhong.AppearanceCell.Options.UseFont = true;
            this.tenLoaiPhong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tenLoaiPhong.AppearanceHeader.Options.UseFont = true;
            this.tenLoaiPhong.Caption = "Tên loại phòng";
            this.tenLoaiPhong.FieldName = "Tên loại phòng";
            this.tenLoaiPhong.MinWidth = 25;
            this.tenLoaiPhong.Name = "tenLoaiPhong";
            this.tenLoaiPhong.OptionsColumn.AllowEdit = false;
            this.tenLoaiPhong.OptionsColumn.AllowFocus = false;
            this.tenLoaiPhong.Visible = true;
            this.tenLoaiPhong.VisibleIndex = 0;
            this.tenLoaiPhong.Width = 94;
            // 
            // giaPhong
            // 
            this.giaPhong.Caption = "Giá phòng";
            this.giaPhong.FieldName = "Giá phòng";
            this.giaPhong.MinWidth = 25;
            this.giaPhong.Name = "giaPhong";
            this.giaPhong.OptionsColumn.AllowEdit = false;
            this.giaPhong.OptionsColumn.AllowFocus = false;
            this.giaPhong.Visible = true;
            this.giaPhong.VisibleIndex = 1;
            this.giaPhong.Width = 94;
            // 
            // phongTrong
            // 
            this.phongTrong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.phongTrong.AppearanceCell.Options.UseFont = true;
            this.phongTrong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F);
            this.phongTrong.AppearanceHeader.Options.UseFont = true;
            this.phongTrong.Caption = "Số phòng trống";
            this.phongTrong.FieldName = "Số phòng trống";
            this.phongTrong.MinWidth = 25;
            this.phongTrong.Name = "phongTrong";
            this.phongTrong.OptionsColumn.AllowEdit = false;
            this.phongTrong.OptionsColumn.AllowFocus = false;
            this.phongTrong.Visible = true;
            this.phongTrong.VisibleIndex = 2;
            this.phongTrong.Width = 94;
            // 
            // soLuongPhong
            // 
            this.soLuongPhong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F);
            this.soLuongPhong.AppearanceCell.Options.UseFont = true;
            this.soLuongPhong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F);
            this.soLuongPhong.AppearanceHeader.Options.UseFont = true;
            this.soLuongPhong.Caption = "Số lượng phòng";
            this.soLuongPhong.ColumnEdit = this.bteSoLuong;
            this.soLuongPhong.FieldName = "Số lượng phòng";
            this.soLuongPhong.MinWidth = 25;
            this.soLuongPhong.Name = "soLuongPhong";
            this.soLuongPhong.Visible = true;
            this.soLuongPhong.VisibleIndex = 3;
            this.soLuongPhong.Width = 94;
            // 
            // bteSoLuong
            // 
            this.bteSoLuong.AutoHeight = false;
            this.bteSoLuong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bteSoLuong.MaxLength = 1;
            this.bteSoLuong.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.bteSoLuong.Name = "bteSoLuong";
            // 
            // btnAddKhAutoPhong
            // 
            this.btnAddKhAutoPhong.Location = new System.Drawing.Point(1016, 403);
            this.btnAddKhAutoPhong.Name = "btnAddKhAutoPhong";
            this.btnAddKhAutoPhong.Size = new System.Drawing.Size(92, 30);
            this.btnAddKhAutoPhong.TabIndex = 30;
            this.btnAddKhAutoPhong.Text = "Add";
            this.btnAddKhAutoPhong.UseVisualStyleBackColor = true;
            this.btnAddKhAutoPhong.Click += new System.EventHandler(this.btnAddKhAutoPhong_Click);
            // 
            // frmDatKhachDoan
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1107, 834);
            this.Controls.Add(this.btnAddKhAutoPhong);
            this.Controls.Add(this.dgvLoaiPhong);
            this.Controls.Add(this.btnThemKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtmNgayRa);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.dgvDsKH);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatKhachDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách đoàn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDatKhachDoan_FormClosing);
            this.Load += new System.EventHandler(this.frmDatKhachDoan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewLoaiPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bteSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenDoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.Label lblTongSoPhong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTKcmnd;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraGrid.GridControl dgvDsKH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDsKH;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtmNgayRa;
        private System.Windows.Forms.Button btnKhToView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboPhong;
        private DevExpress.XtraGrid.GridControl dgvLoaiPhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewLoaiPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tenLoaiPhong;
        private DevExpress.XtraGrid.Columns.GridColumn phongTrong;
        private DevExpress.XtraGrid.Columns.GridColumn soLuongPhong;
        private System.Windows.Forms.ToolTip toolTipKH;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit bteSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn giaPhong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.TextBox txtTruongDoan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddKhAutoPhong;
        private System.Windows.Forms.TextBox txtSdtDoan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimDoan;
    }
}