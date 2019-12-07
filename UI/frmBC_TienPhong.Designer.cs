namespace Home
{
    partial class frmBC_TienPhong
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
            this.gdvBCDoanhThu = new DevExpress.XtraGrid.GridControl();
            this.gridViewTienPhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tienPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tgianVao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tgianRa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.cboNgayThang = new System.Windows.Forms.ComboBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBCDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvBCDoanhThu
            // 
            this.gdvBCDoanhThu.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gdvBCDoanhThu.Location = new System.Drawing.Point(10, 72);
            this.gdvBCDoanhThu.MainView = this.gridViewTienPhong;
            this.gdvBCDoanhThu.Name = "gdvBCDoanhThu";
            this.gdvBCDoanhThu.Size = new System.Drawing.Size(945, 585);
            this.gdvBCDoanhThu.TabIndex = 0;
            this.gdvBCDoanhThu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTienPhong});
            // 
            // gridViewTienPhong
            // 
            this.gridViewTienPhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tenKH,
            this.tienPhong,
            this.tgianVao,
            this.tgianRa});
            this.gridViewTienPhong.GridControl = this.gdvBCDoanhThu;
            this.gridViewTienPhong.Name = "gridViewTienPhong";
            this.gridViewTienPhong.OptionsView.ShowGroupPanel = false;
            // 
            // tenKH
            // 
            this.tenKH.Caption = "Khách hàng";
            this.tenKH.FieldName = "Tên khách hàng";
            this.tenKH.MinWidth = 25;
            this.tenKH.Name = "tenKH";
            this.tenKH.OptionsColumn.AllowEdit = false;
            this.tenKH.OptionsColumn.AllowFocus = false;
            this.tenKH.Visible = true;
            this.tenKH.VisibleIndex = 0;
            this.tenKH.Width = 94;
            // 
            // tienPhong
            // 
            this.tienPhong.Caption = "Tiền phòng";
            this.tienPhong.DisplayFormat.FormatString = "{0:#,##0 vnd}";
            this.tienPhong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tienPhong.FieldName = "Tiền phòng";
            this.tienPhong.MinWidth = 25;
            this.tienPhong.Name = "tienPhong";
            this.tienPhong.OptionsColumn.AllowEdit = false;
            this.tienPhong.OptionsColumn.AllowFocus = false;
            this.tienPhong.Visible = true;
            this.tienPhong.VisibleIndex = 1;
            this.tienPhong.Width = 94;
            // 
            // tgianVao
            // 
            this.tgianVao.Caption = "Thời gian vào";
            this.tgianVao.FieldName = "Thời gian vào";
            this.tgianVao.MinWidth = 25;
            this.tgianVao.Name = "tgianVao";
            this.tgianVao.OptionsColumn.AllowEdit = false;
            this.tgianVao.OptionsColumn.AllowFocus = false;
            this.tgianVao.Visible = true;
            this.tgianVao.VisibleIndex = 2;
            this.tgianVao.Width = 94;
            // 
            // tgianRa
            // 
            this.tgianRa.Caption = "Thời gian ra";
            this.tgianRa.FieldName = "Thời gian ra";
            this.tgianRa.MinWidth = 25;
            this.tgianRa.Name = "tgianRa";
            this.tgianRa.OptionsColumn.AllowEdit = false;
            this.tgianRa.OptionsColumn.AllowFocus = false;
            this.tgianRa.Visible = true;
            this.tgianRa.VisibleIndex = 3;
            this.tgianRa.Width = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(787, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Từ ngày";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(876, 3);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(149, 32);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1031, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến ngày";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(1132, 3);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(149, 32);
            this.dtpEnd.TabIndex = 3;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // cboNgayThang
            // 
            this.cboNgayThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNgayThang.FormattingEnabled = true;
            this.cboNgayThang.Items.AddRange(new object[] {
            "Trong ngày",
            "Trong tuần",
            "Trong tháng",
            "Trong năm",
            "Tất cả",
            "Tuỳ chọn"});
            this.cboNgayThang.Location = new System.Drawing.Point(574, 6);
            this.cboNgayThang.Name = "cboNgayThang";
            this.cboNgayThang.Size = new System.Drawing.Size(194, 32);
            this.cboNgayThang.TabIndex = 4;
            this.cboNgayThang.SelectedIndexChanged += new System.EventHandler(this.cboLuaChon_SelectedIndexChanged);
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(160, 6);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(286, 32);
            this.cboNhanVien.TabIndex = 5;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lựa chọn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chọn nhân viên";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(1035, 98);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(122, 41);
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "In hoá đơn";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmBC_TienPhong
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1294, 669);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.cboNgayThang);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdvBCDoanhThu);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmBC_TienPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiền phòng";
            this.Load += new System.EventHandler(this.frmBC_TienPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvBCDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdvBCDoanhThu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTienPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cboNgayThang;
        private DevExpress.XtraGrid.Columns.GridColumn tenKH;
        private DevExpress.XtraGrid.Columns.GridColumn tienPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tgianVao;
        private DevExpress.XtraGrid.Columns.GridColumn tgianRa;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIn;
    }
}