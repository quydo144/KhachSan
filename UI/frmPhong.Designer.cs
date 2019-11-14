namespace Home
{
    partial class frmPhong
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
            this.gclDSP = new DevExpress.XtraGrid.GridControl();
            this.gridViewPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.maPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tinhTrang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loaiPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_LocTheoTang = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gclDSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gclDSP
            // 
            this.gclDSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gclDSP.Location = new System.Drawing.Point(0, 124);
            this.gclDSP.MainView = this.gridViewPhong;
            this.gclDSP.Name = "gclDSP";
            this.gclDSP.Size = new System.Drawing.Size(1279, 626);
            this.gclDSP.TabIndex = 1;
            this.gclDSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPhong});
            // 
            // gridViewPhong
            // 
            this.gridViewPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.maPhong,
            this.tenPhong,
            this.tang,
            this.tinhTrang,
            this.loaiPhong});
            this.gridViewPhong.GridControl = this.gclDSP;
            this.gridViewPhong.Name = "gridViewPhong";
            this.gridViewPhong.OptionsView.ShowGroupPanel = false;
            // 
            // maPhong
            // 
            this.maPhong.Caption = "Mã phòng";
            this.maPhong.FieldName = "MaPhong";
            this.maPhong.MinWidth = 25;
            this.maPhong.Name = "maPhong";
            this.maPhong.Visible = true;
            this.maPhong.VisibleIndex = 0;
            this.maPhong.Width = 94;
            // 
            // tenPhong
            // 
            this.tenPhong.Caption = "Tên phòng";
            this.tenPhong.FieldName = "TenPhong";
            this.tenPhong.MinWidth = 25;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.Visible = true;
            this.tenPhong.VisibleIndex = 1;
            this.tenPhong.Width = 94;
            // 
            // tang
            // 
            this.tang.Caption = "Tầng";
            this.tang.FieldName = "Tang";
            this.tang.MinWidth = 25;
            this.tang.Name = "tang";
            this.tang.Visible = true;
            this.tang.VisibleIndex = 2;
            this.tang.Width = 94;
            // 
            // tinhTrang
            // 
            this.tinhTrang.Caption = "Tình trạng";
            this.tinhTrang.FieldName = "TinhTrang";
            this.tinhTrang.MinWidth = 25;
            this.tinhTrang.Name = "tinhTrang";
            this.tinhTrang.Visible = true;
            this.tinhTrang.VisibleIndex = 3;
            this.tinhTrang.Width = 94;
            // 
            // loaiPhong
            // 
            this.loaiPhong.Caption = "Loại phòng";
            this.loaiPhong.FieldName = "MaLoaiPhong";
            this.loaiPhong.MinWidth = 25;
            this.loaiPhong.Name = "loaiPhong";
            this.loaiPhong.Visible = true;
            this.loaiPhong.VisibleIndex = 4;
            this.loaiPhong.Width = 94;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-1, -2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1284, 42);
            this.label7.TabIndex = 42;
            this.label7.Text = "Quản lý phòng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbo_LocTheoTang);
            this.groupBox2.Location = new System.Drawing.Point(12, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 69);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lọc tìm kiếm";
            // 
            // cbo_LocTheoTang
            // 
            this.cbo_LocTheoTang.FormattingEnabled = true;
            this.cbo_LocTheoTang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbo_LocTheoTang.Location = new System.Drawing.Point(55, 29);
            this.cbo_LocTheoTang.Name = "cbo_LocTheoTang";
            this.cbo_LocTheoTang.Size = new System.Drawing.Size(238, 30);
            this.cbo_LocTheoTang.TabIndex = 0;
            this.cbo_LocTheoTang.Text = "Lọc theo tầng";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(772, 65);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(134, 37);
            this.btnThem.TabIndex = 45;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1133, 65);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(134, 37);
            this.btnSua.TabIndex = 46;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(946, 65);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(134, 37);
            this.btnXoa.TabIndex = 47;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmPhong
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1279, 750);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gclDSP);
            this.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPhong_FormClosing);
            this.Load += new System.EventHandler(this.frmPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gclDSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPhong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gclDSP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPhong;
        private DevExpress.XtraGrid.Columns.GridColumn maPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tang;
        private DevExpress.XtraGrid.Columns.GridColumn tinhTrang;
        private DevExpress.XtraGrid.Columns.GridColumn loaiPhong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_LocTheoTang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
    }
}