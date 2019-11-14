namespace Home
{
    partial class frmKhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhachHang));
            this.gridControlDsKH = new DevExpress.XtraGrid.GridControl();
            this.gridViewDsKh = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.maKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tenKH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sdt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnThemKH = new System.Windows.Forms.Button();
            this.cboTKKH = new System.Windows.Forms.ComboBox();
            this.txtTK = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDsKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsKh)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlDsKH
            // 
            this.gridControlDsKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDsKH.Location = new System.Drawing.Point(-4, 127);
            this.gridControlDsKH.MainView = this.gridViewDsKh;
            this.gridControlDsKH.Name = "gridControlDsKH";
            this.gridControlDsKH.Size = new System.Drawing.Size(1469, 614);
            this.gridControlDsKH.TabIndex = 0;
            this.gridControlDsKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDsKh});
            // 
            // gridViewDsKh
            // 
            this.gridViewDsKh.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.maKH,
            this.tenKH,
            this.gioiTinh,
            this.cmnd,
            this.sdt});
            this.gridViewDsKh.GridControl = this.gridControlDsKH;
            this.gridViewDsKh.Name = "gridViewDsKh";
            this.gridViewDsKh.OptionsView.ShowGroupPanel = false;
            // 
            // maKH
            // 
            this.maKH.Caption = "Mã khách hàng";
            this.maKH.FieldName = "MaKH";
            this.maKH.MinWidth = 25;
            this.maKH.Name = "maKH";
            this.maKH.Visible = true;
            this.maKH.VisibleIndex = 0;
            this.maKH.Width = 150;
            // 
            // tenKH
            // 
            this.tenKH.Caption = "Tên khách hàng";
            this.tenKH.FieldName = "TenKH";
            this.tenKH.MinWidth = 25;
            this.tenKH.Name = "tenKH";
            this.tenKH.Visible = true;
            this.tenKH.VisibleIndex = 1;
            this.tenKH.Width = 147;
            // 
            // gioiTinh
            // 
            this.gioiTinh.Caption = "Giới tính";
            this.gioiTinh.FieldName = "GioiTinh";
            this.gioiTinh.MinWidth = 25;
            this.gioiTinh.Name = "gioiTinh";
            this.gioiTinh.Visible = true;
            this.gioiTinh.VisibleIndex = 2;
            this.gioiTinh.Width = 147;
            // 
            // cmnd
            // 
            this.cmnd.Caption = "Số CMND";
            this.cmnd.FieldName = "SoCMND";
            this.cmnd.MinWidth = 25;
            this.cmnd.Name = "cmnd";
            this.cmnd.Visible = true;
            this.cmnd.VisibleIndex = 3;
            this.cmnd.Width = 147;
            // 
            // sdt
            // 
            this.sdt.Caption = "Số điện thoại";
            this.sdt.FieldName = "SoDT";
            this.sdt.MinWidth = 25;
            this.sdt.Name = "sdt";
            this.sdt.Visible = true;
            this.sdt.VisibleIndex = 4;
            this.sdt.Width = 152;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1467, 55);
            this.label7.TabIndex = 11;
            this.label7.Text = "Quản lý khách hàng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.btnThemKH);
            this.groupBox2.Controls.Add(this.cboTKKH);
            this.groupBox2.Controls.Add(this.txtTK);
            this.groupBox2.Location = new System.Drawing.Point(12, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1400, 84);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnCapNhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhat.Image")));
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(1157, 24);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(123, 43);
            this.btnCapNhat.TabIndex = 15;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(353, 29);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 38);
            this.button4.TabIndex = 17;
            this.button4.Text = "Tìm kiếm";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btnThemKH
            // 
            this.btnThemKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnThemKH.Image = global::Home.Properties.Resources.add_icon;
            this.btnThemKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemKH.Location = new System.Drawing.Point(976, 24);
            this.btnThemKH.Name = "btnThemKH";
            this.btnThemKH.Size = new System.Drawing.Size(123, 43);
            this.btnThemKH.TabIndex = 16;
            this.btnThemKH.Text = "Thêm";
            this.btnThemKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemKH.UseVisualStyleBackColor = false;
            this.btnThemKH.Click += new System.EventHandler(this.btnThemKH_Click);
            // 
            // cboTKKH
            // 
            this.cboTKKH.FormattingEnabled = true;
            this.cboTKKH.Location = new System.Drawing.Point(629, 31);
            this.cboTKKH.Name = "cboTKKH";
            this.cboTKKH.Size = new System.Drawing.Size(191, 30);
            this.cboTKKH.TabIndex = 13;
            // 
            // txtTK
            // 
            this.txtTK.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTK.ForeColor = System.Drawing.Color.DarkGray;
            this.txtTK.Location = new System.Drawing.Point(9, 31);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(314, 30);
            this.txtTK.TabIndex = 11;
            this.txtTK.Text = "Tìm kiếm Số CMND";
            this.txtTK.Enter += new System.EventHandler(this.txtTK_Enter);
            // 
            // frmKhachHang
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1464, 741);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gridControlDsKH);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKhachHang_FormClosing);
            this.Load += new System.EventHandler(this.frmKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDsKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDsKh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDsKH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDsKh;
        private DevExpress.XtraGrid.Columns.GridColumn maKH;
        private DevExpress.XtraGrid.Columns.GridColumn tenKH;
        private DevExpress.XtraGrid.Columns.GridColumn gioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn cmnd;
        private DevExpress.XtraGrid.Columns.GridColumn sdt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboTKKH;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThemKH;
        private System.Windows.Forms.Button button4;
    }
}