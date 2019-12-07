namespace Home
{
    partial class frmBC_TienDichVu
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.cboNgayThang = new System.Windows.Forms.ComboBox();
            this.gdvBC_TienDV = new DevExpress.XtraGrid.GridControl();
            this.gridViewTienDV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tenKhach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tienDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ngayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gdvBC_TienDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienDV)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Chọn nhân viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lựa chọn";
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(234, 12);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(299, 27);
            this.cboNhanVien.TabIndex = 9;
            this.cboNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboNhanVien_SelectedIndexChanged);
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
            this.cboNgayThang.Location = new System.Drawing.Point(733, 12);
            this.cboNgayThang.Name = "cboNgayThang";
            this.cboNgayThang.Size = new System.Drawing.Size(159, 27);
            this.cboNgayThang.TabIndex = 8;
            this.cboNgayThang.SelectedIndexChanged += new System.EventHandler(this.cboNgayThang_SelectedIndexChanged);
            // 
            // gdvBC_TienDV
            // 
            this.gdvBC_TienDV.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1);
            this.gdvBC_TienDV.Location = new System.Drawing.Point(6, 60);
            this.gdvBC_TienDV.MainView = this.gridViewTienDV;
            this.gdvBC_TienDV.Name = "gdvBC_TienDV";
            this.gdvBC_TienDV.Size = new System.Drawing.Size(746, 365);
            this.gdvBC_TienDV.TabIndex = 12;
            this.gdvBC_TienDV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTienDV});
            // 
            // gridViewTienDV
            // 
            this.gridViewTienDV.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tenPhong,
            this.tenKhach,
            this.tienDV,
            this.ngayLap});
            this.gridViewTienDV.GridControl = this.gdvBC_TienDV;
            this.gridViewTienDV.Name = "gridViewTienDV";
            this.gridViewTienDV.OptionsView.ShowGroupPanel = false;
            // 
            // tenPhong
            // 
            this.tenPhong.Caption = "Phòng";
            this.tenPhong.FieldName = "Phòng";
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.OptionsColumn.AllowEdit = false;
            this.tenPhong.OptionsColumn.AllowFocus = false;
            this.tenPhong.Visible = true;
            this.tenPhong.VisibleIndex = 0;
            // 
            // tenKhach
            // 
            this.tenKhach.Caption = "Khách hàng";
            this.tenKhach.FieldName = "Khách hàng";
            this.tenKhach.Name = "tenKhach";
            this.tenKhach.OptionsColumn.AllowEdit = false;
            this.tenKhach.OptionsColumn.AllowFocus = false;
            this.tenKhach.Visible = true;
            this.tenKhach.VisibleIndex = 1;
            // 
            // tienDV
            // 
            this.tienDV.Caption = "Tiền DV";
            this.tienDV.DisplayFormat.FormatString = "{0:#,##0}";
            this.tienDV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tienDV.FieldName = "Tiền DV";
            this.tienDV.Name = "tienDV";
            this.tienDV.OptionsColumn.AllowEdit = false;
            this.tienDV.OptionsColumn.AllowFocus = false;
            this.tienDV.Visible = true;
            this.tienDV.VisibleIndex = 2;
            // 
            // ngayLap
            // 
            this.ngayLap.Caption = "Ngày Lập";
            this.ngayLap.FieldName = "Ngày Lập";
            this.ngayLap.Name = "ngayLap";
            this.ngayLap.OptionsColumn.AllowEdit = false;
            this.ngayLap.OptionsColumn.AllowFocus = false;
            this.ngayLap.Visible = true;
            this.ngayLap.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Từ ngày";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "dd/MM/yyyy";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(937, 74);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(180, 27);
            this.dtpStart.TabIndex = 14;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(773, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đến ngày";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "dd/MM/yyyy";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(937, 120);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(180, 27);
            this.dtpEnd.TabIndex = 16;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(497, 444);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tổng tiền";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTongTien.Location = new System.Drawing.Point(619, 444);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(79, 21);
            this.lblTongTien.TabIndex = 17;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(937, 179);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(143, 40);
            this.btnIn.TabIndex = 18;
            this.btnIn.Text = "In báo cáo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmBC_TienDichVu
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 472);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gdvBC_TienDV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNhanVien);
            this.Controls.Add(this.cboNgayThang);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBC_TienDichVu";
            this.Text = "Báo cáo tiền dịch vụ";
            this.Load += new System.EventHandler(this.frmBC_TienDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvBC_TienDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.ComboBox cboNgayThang;
        private DevExpress.XtraGrid.GridControl gdvBC_TienDV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTienDV;
        private DevExpress.XtraGrid.Columns.GridColumn tenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tenKhach;
        private DevExpress.XtraGrid.Columns.GridColumn tienDV;
        private DevExpress.XtraGrid.Columns.GridColumn ngayLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnIn;
    }
}