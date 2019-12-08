namespace Home
{
    partial class frmTraKhachDoan
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
            this.dgvDsThuePhong = new DevExpress.XtraGrid.GridControl();
            this.gridViewDsThuePhong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tenPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tienPhong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tienDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.thueVat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.khuyenMai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tienKhac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ghiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPhong = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenDoan = new System.Windows.Forms.TextBox();
            this.txtTruongDoan = new System.Windows.Forms.TextBox();
            this.panelThanhToanDoan = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.txtTienThanhToan = new System.Windows.Forms.TextBox();
            this.txtKhuyenMai = new System.Windows.Forms.TextBox();
            this.txtThueVAT = new System.Windows.Forms.TextBox();
            this.txtTongTienPhong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsThuePhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsThuePhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhong)).BeginInit();
            this.panelThanhToanDoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDsThuePhong
            // 
            this.dgvDsThuePhong.Location = new System.Drawing.Point(1, 150);
            this.dgvDsThuePhong.MainView = this.gridViewDsThuePhong;
            this.dgvDsThuePhong.Name = "dgvDsThuePhong";
            this.dgvDsThuePhong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnPhong});
            this.dgvDsThuePhong.Size = new System.Drawing.Size(928, 351);
            this.dgvDsThuePhong.TabIndex = 0;
            this.dgvDsThuePhong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDsThuePhong});
            // 
            // gridViewDsThuePhong
            // 
            this.gridViewDsThuePhong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tenPhong,
            this.tienPhong,
            this.tienDV,
            this.thueVat,
            this.khuyenMai,
            this.tienKhac,
            this.ghiChu});
            this.gridViewDsThuePhong.GridControl = this.dgvDsThuePhong;
            this.gridViewDsThuePhong.Name = "gridViewDsThuePhong";
            this.gridViewDsThuePhong.OptionsView.ShowGroupPanel = false;
            // 
            // tenPhong
            // 
            this.tenPhong.Caption = "Tên phòng";
            this.tenPhong.FieldName = "Tenphong";
            this.tenPhong.MinWidth = 25;
            this.tenPhong.Name = "tenPhong";
            this.tenPhong.OptionsColumn.AllowEdit = false;
            this.tenPhong.OptionsColumn.AllowFocus = false;
            this.tenPhong.Visible = true;
            this.tenPhong.VisibleIndex = 0;
            this.tenPhong.Width = 94;
            // 
            // tienPhong
            // 
            this.tienPhong.Caption = "Tiền phòng";
            this.tienPhong.DisplayFormat.FormatString = "{0:#,##0}";
            this.tienPhong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tienPhong.FieldName = "TienPhong";
            this.tienPhong.MinWidth = 25;
            this.tienPhong.Name = "tienPhong";
            this.tienPhong.OptionsColumn.AllowEdit = false;
            this.tienPhong.OptionsColumn.AllowFocus = false;
            this.tienPhong.Visible = true;
            this.tienPhong.VisibleIndex = 1;
            this.tienPhong.Width = 94;
            // 
            // tienDV
            // 
            this.tienDV.Caption = "Tiền dịch vụ";
            this.tienDV.DisplayFormat.FormatString = "{0:#,##0 vnđ}";
            this.tienDV.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tienDV.FieldName = "TienDV";
            this.tienDV.MinWidth = 25;
            this.tienDV.Name = "tienDV";
            this.tienDV.OptionsColumn.AllowEdit = false;
            this.tienDV.OptionsColumn.AllowFocus = false;
            this.tienDV.Visible = true;
            this.tienDV.VisibleIndex = 2;
            this.tienDV.Width = 94;
            // 
            // thueVat
            // 
            this.thueVat.Caption = "Thuế VAT";
            this.thueVat.DisplayFormat.FormatString = "{0:#,##0 vnđ}";
            this.thueVat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.thueVat.FieldName = "TienVat";
            this.thueVat.MinWidth = 25;
            this.thueVat.Name = "thueVat";
            this.thueVat.OptionsColumn.AllowEdit = false;
            this.thueVat.OptionsColumn.AllowFocus = false;
            this.thueVat.Visible = true;
            this.thueVat.VisibleIndex = 3;
            this.thueVat.Width = 94;
            // 
            // khuyenMai
            // 
            this.khuyenMai.Caption = "Khuyến mãi";
            this.khuyenMai.DisplayFormat.FormatString = "{0:#,##0 vnđ}";
            this.khuyenMai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.khuyenMai.FieldName = "TienKM";
            this.khuyenMai.MinWidth = 25;
            this.khuyenMai.Name = "khuyenMai";
            this.khuyenMai.OptionsColumn.AllowEdit = false;
            this.khuyenMai.OptionsColumn.AllowFocus = false;
            this.khuyenMai.Visible = true;
            this.khuyenMai.VisibleIndex = 4;
            this.khuyenMai.Width = 94;
            // 
            // tienKhac
            // 
            this.tienKhac.Caption = "Tiền Khác";
            this.tienKhac.DisplayFormat.FormatString = "{0:#,##0 vnđ}";
            this.tienKhac.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tienKhac.FieldName = "TienKhac";
            this.tienKhac.MinWidth = 25;
            this.tienKhac.Name = "tienKhac";
            this.tienKhac.OptionsColumn.AllowEdit = false;
            this.tienKhac.OptionsColumn.AllowFocus = false;
            this.tienKhac.Visible = true;
            this.tienKhac.VisibleIndex = 5;
            this.tienKhac.Width = 94;
            // 
            // ghiChu
            // 
            this.ghiChu.Caption = "Ghi chú";
            this.ghiChu.FieldName = "GhiChu";
            this.ghiChu.MinWidth = 25;
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.OptionsColumn.AllowEdit = false;
            this.ghiChu.OptionsColumn.AllowFocus = false;
            this.ghiChu.Visible = true;
            this.ghiChu.VisibleIndex = 6;
            this.ghiChu.Width = 94;
            // 
            // btnPhong
            // 
            this.btnPhong.AutoHeight = false;
            this.btnPhong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đoàn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên trưởng đoàn";
            // 
            // txtTenDoan
            // 
            this.txtTenDoan.Location = new System.Drawing.Point(265, 63);
            this.txtTenDoan.Name = "txtTenDoan";
            this.txtTenDoan.Size = new System.Drawing.Size(368, 32);
            this.txtTenDoan.TabIndex = 3;
            // 
            // txtTruongDoan
            // 
            this.txtTruongDoan.Location = new System.Drawing.Point(265, 101);
            this.txtTruongDoan.Name = "txtTruongDoan";
            this.txtTruongDoan.Size = new System.Drawing.Size(368, 32);
            this.txtTruongDoan.TabIndex = 3;
            // 
            // panelThanhToanDoan
            // 
            this.panelThanhToanDoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelThanhToanDoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThanhToanDoan.Controls.Add(this.btnThoat);
            this.panelThanhToanDoan.Controls.Add(this.btnThanhToan);
            this.panelThanhToanDoan.Controls.Add(this.txtTienThua);
            this.panelThanhToanDoan.Controls.Add(this.txtTienKhachDua);
            this.panelThanhToanDoan.Controls.Add(this.txtTienThanhToan);
            this.panelThanhToanDoan.Controls.Add(this.txtKhuyenMai);
            this.panelThanhToanDoan.Controls.Add(this.txtThueVAT);
            this.panelThanhToanDoan.Controls.Add(this.txtTongTienPhong);
            this.panelThanhToanDoan.Controls.Add(this.label10);
            this.panelThanhToanDoan.Controls.Add(this.label9);
            this.panelThanhToanDoan.Controls.Add(this.label8);
            this.panelThanhToanDoan.Controls.Add(this.label6);
            this.panelThanhToanDoan.Controls.Add(this.label5);
            this.panelThanhToanDoan.Controls.Add(this.label4);
            this.panelThanhToanDoan.Location = new System.Drawing.Point(930, 1);
            this.panelThanhToanDoan.Name = "panelThanhToanDoan";
            this.panelThanhToanDoan.Size = new System.Drawing.Size(393, 500);
            this.panelThanhToanDoan.TabIndex = 4;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(228, 393);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 37);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(34, 393);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(133, 37);
            this.btnThanhToan.TabIndex = 2;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // txtTienThua
            // 
            this.txtTienThua.Enabled = false;
            this.txtTienThua.Location = new System.Drawing.Point(185, 308);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.Size = new System.Drawing.Size(187, 32);
            this.txtTienThua.TabIndex = 1;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Location = new System.Drawing.Point(185, 239);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(187, 32);
            this.txtTienKhachDua.TabIndex = 1;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged);
            // 
            // txtTienThanhToan
            // 
            this.txtTienThanhToan.Enabled = false;
            this.txtTienThanhToan.Location = new System.Drawing.Point(185, 180);
            this.txtTienThanhToan.Name = "txtTienThanhToan";
            this.txtTienThanhToan.Size = new System.Drawing.Size(187, 32);
            this.txtTienThanhToan.TabIndex = 1;
            // 
            // txtKhuyenMai
            // 
            this.txtKhuyenMai.Enabled = false;
            this.txtKhuyenMai.Location = new System.Drawing.Point(185, 119);
            this.txtKhuyenMai.Name = "txtKhuyenMai";
            this.txtKhuyenMai.Size = new System.Drawing.Size(187, 32);
            this.txtKhuyenMai.TabIndex = 1;
            // 
            // txtThueVAT
            // 
            this.txtThueVAT.Enabled = false;
            this.txtThueVAT.Location = new System.Drawing.Point(185, 66);
            this.txtThueVAT.Name = "txtThueVAT";
            this.txtThueVAT.Size = new System.Drawing.Size(187, 32);
            this.txtThueVAT.TabIndex = 1;
            // 
            // txtTongTienPhong
            // 
            this.txtTongTienPhong.Enabled = false;
            this.txtTongTienPhong.Location = new System.Drawing.Point(185, 4);
            this.txtTongTienPhong.Name = "txtTongTienPhong";
            this.txtTongTienPhong.Size = new System.Drawing.Size(187, 32);
            this.txtTongTienPhong.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 316);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "Tiền trả khách";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tiền khách đưa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tiền thanh toán";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tiền khuyến mãi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thuế VAT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tổng tiền phòng";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(732, 20);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(133, 37);
            this.btnTim.TabIndex = 5;
            this.btnTim.Text = "Tìm đoàn";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(265, 25);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(368, 32);
            this.txtSdt.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số điện thoại";
            // 
            // frmTraKhachDoan
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1322, 498);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.panelThanhToanDoan);
            this.Controls.Add(this.txtTruongDoan);
            this.Controls.Add(this.txtTenDoan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDsThuePhong);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTraKhachDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trả khách đoàn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTraKhachDoan_FormClosing);
            this.Load += new System.EventHandler(this.frmTraKhachDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDsThuePhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsThuePhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhong)).EndInit();
            this.panelThanhToanDoan.ResumeLayout(false);
            this.panelThanhToanDoan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvDsThuePhong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDsThuePhong;
        private DevExpress.XtraGrid.Columns.GridColumn tenPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tienPhong;
        private DevExpress.XtraGrid.Columns.GridColumn tienDV;
        private DevExpress.XtraGrid.Columns.GridColumn thueVat;
        private DevExpress.XtraGrid.Columns.GridColumn khuyenMai;
        private DevExpress.XtraGrid.Columns.GridColumn tienKhac;
        private DevExpress.XtraGrid.Columns.GridColumn ghiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenDoan;
        private System.Windows.Forms.TextBox txtTruongDoan;
        private System.Windows.Forms.Panel panelThanhToanDoan;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.TextBox txtTienKhachDua;
        private System.Windows.Forms.TextBox txtTienThanhToan;
        private System.Windows.Forms.TextBox txtKhuyenMai;
        private System.Windows.Forms.TextBox txtThueVAT;
        private System.Windows.Forms.TextBox txtTongTienPhong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTim;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnPhong;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.Label label1;
    }
}