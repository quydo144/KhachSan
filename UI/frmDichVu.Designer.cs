namespace Home
{
    partial class frmDichVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDichVu));
            this.btnThoat = new System.Windows.Forms.Button();
            this.grdTenDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdMaDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdDonGiaDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btnSuaDV = new System.Windows.Forms.Button();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.btnXoaDV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(669, 232);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(106, 45);
            this.btnThoat.TabIndex = 51;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            // 
            // grdTenDV
            // 
            this.grdTenDV.Caption = "Tên dịch vụ";
            this.grdTenDV.FieldName = "ten dich vu";
            this.grdTenDV.MinWidth = 31;
            this.grdTenDV.Name = "grdTenDV";
            this.grdTenDV.OptionsColumn.FixedWidth = true;
            this.grdTenDV.Visible = true;
            this.grdTenDV.VisibleIndex = 1;
            this.grdTenDV.Width = 118;
            // 
            // grdMaDV
            // 
            this.grdMaDV.Caption = "Mã dịch vụ";
            this.grdMaDV.FieldName = "ma dich vu";
            this.grdMaDV.MinWidth = 31;
            this.grdMaDV.Name = "grdMaDV";
            this.grdMaDV.OptionsColumn.FixedWidth = true;
            this.grdMaDV.Visible = true;
            this.grdMaDV.VisibleIndex = 0;
            this.grdMaDV.Width = 118;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdMaDV,
            this.grdTenDV,
            this.grdDonGiaDV});
            this.gridView1.DetailHeight = 481;
            this.gridView1.FixedLineWidth = 3;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // grdDonGiaDV
            // 
            this.grdDonGiaDV.Caption = "Đơn giá";
            this.grdDonGiaDV.FieldName = "don gia";
            this.grdDonGiaDV.MinWidth = 31;
            this.grdDonGiaDV.Name = "grdDonGiaDV";
            this.grdDonGiaDV.OptionsColumn.FixedWidth = true;
            this.grdDonGiaDV.Visible = true;
            this.grdDonGiaDV.VisibleIndex = 2;
            this.grdDonGiaDV.Width = 118;
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gridControl1.Location = new System.Drawing.Point(-3, 287);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(849, 229);
            this.gridControl1.TabIndex = 50;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // btnSuaDV
            // 
            this.btnSuaDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnSuaDV.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaDV.Image")));
            this.btnSuaDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaDV.Location = new System.Drawing.Point(247, 232);
            this.btnSuaDV.Margin = new System.Windows.Forms.Padding(6);
            this.btnSuaDV.Name = "btnSuaDV";
            this.btnSuaDV.Size = new System.Drawing.Size(126, 45);
            this.btnSuaDV.TabIndex = 48;
            this.btnSuaDV.Text = "Cập nhật";
            this.btnSuaDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaDV.UseVisualStyleBackColor = false;
            // 
            // btnThemDV
            // 
            this.btnThemDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnThemDV.Image = global::Home.Properties.Resources.add_icon;
            this.btnThemDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDV.Location = new System.Drawing.Point(64, 232);
            this.btnThemDV.Margin = new System.Windows.Forms.Padding(6);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(102, 45);
            this.btnThemDV.TabIndex = 49;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemDV.UseVisualStyleBackColor = false;
            // 
            // btnXoaDV
            // 
            this.btnXoaDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnXoaDV.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDV.Image")));
            this.btnXoaDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaDV.Location = new System.Drawing.Point(472, 232);
            this.btnXoaDV.Margin = new System.Windows.Forms.Padding(6);
            this.btnXoaDV.Name = "btnXoaDV";
            this.btnXoaDV.Size = new System.Drawing.Size(104, 45);
            this.btnXoaDV.TabIndex = 34;
            this.btnXoaDV.Text = "Xóa";
            this.btnXoaDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaDV.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(93, 95);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 45);
            this.button1.TabIndex = 36;
            this.button1.Text = "Tìm Kiếm";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(55, 50);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(197, 30);
            this.txtTimKiem.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.txtTenDV);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMaDV);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(555, 215);
            this.panel1.TabIndex = 52;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(169, 151);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(6);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(350, 30);
            this.txtDonGia.TabIndex = 49;
            this.txtDonGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTenDV
            // 
            this.txtTenDV.Location = new System.Drawing.Point(169, 83);
            this.txtTenDV.Margin = new System.Windows.Forms.Padding(6);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(350, 30);
            this.txtTenDV.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 22);
            this.label3.TabIndex = 46;
            this.label3.Text = "Đơn giá";
            // 
            // txtMaDV
            // 
            this.txtMaDV.Enabled = false;
            this.txtMaDV.Location = new System.Drawing.Point(169, 23);
            this.txtMaDV.Margin = new System.Windows.Forms.Padding(6);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(350, 30);
            this.txtMaDV.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 45;
            this.label2.Text = "Tên dịch vụ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 44;
            this.label1.Text = "Mã dịch vụ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(551, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(295, 215);
            this.panel2.TabIndex = 53;
            // 
            // frmDichVu
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(844, 514);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnSuaDV);
            this.Controls.Add(this.btnThemDV);
            this.Controls.Add(this.btnXoaDV);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dịch vụ";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraGrid.Columns.GridColumn grdTenDV;
        private DevExpress.XtraGrid.Columns.GridColumn grdMaDV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grdDonGiaDV;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Button btnSuaDV;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.Button btnXoaDV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
    }
}