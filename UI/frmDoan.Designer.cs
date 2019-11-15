namespace Home
{
    partial class frmDoan
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.maDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tenDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maTruongDoan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.diaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSuaDoan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.gridControl1.Location = new System.Drawing.Point(26, 155);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(896, 403);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.maDoan,
            this.tenDoan,
            this.maTruongDoan,
            this.diaChi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // maDoan
            // 
            this.maDoan.Caption = "Mã Đoàn";
            this.maDoan.MinWidth = 25;
            this.maDoan.Name = "maDoan";
            this.maDoan.Visible = true;
            this.maDoan.VisibleIndex = 0;
            this.maDoan.Width = 94;
            // 
            // tenDoan
            // 
            this.tenDoan.Caption = "Tên đoàn";
            this.tenDoan.MinWidth = 25;
            this.tenDoan.Name = "tenDoan";
            this.tenDoan.Visible = true;
            this.tenDoan.VisibleIndex = 1;
            this.tenDoan.Width = 94;
            // 
            // maTruongDoan
            // 
            this.maTruongDoan.Caption = "Trưởng đoàn";
            this.maTruongDoan.MinWidth = 25;
            this.maTruongDoan.Name = "maTruongDoan";
            this.maTruongDoan.Visible = true;
            this.maTruongDoan.VisibleIndex = 2;
            this.maTruongDoan.Width = 94;
            // 
            // diaChi
            // 
            this.diaChi.Caption = "Địa chỉ";
            this.diaChi.MinWidth = 25;
            this.diaChi.Name = "diaChi";
            this.diaChi.Visible = true;
            this.diaChi.VisibleIndex = 3;
            this.diaChi.Width = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên đoàn";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(418, 32);
            this.textBox1.TabIndex = 2;
            // 
            // btnSuaDoan
            // 
            this.btnSuaDoan.Location = new System.Drawing.Point(760, 52);
            this.btnSuaDoan.Name = "btnSuaDoan";
            this.btnSuaDoan.Size = new System.Drawing.Size(144, 64);
            this.btnSuaDoan.TabIndex = 3;
            this.btnSuaDoan.Text = "Sửa Đoàn";
            this.btnSuaDoan.UseVisualStyleBackColor = true;
            // 
            // frmDoan
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 593);
            this.Controls.Add(this.btnSuaDoan);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControl1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDoan";
            this.Text = "frmDoan";
            this.Load += new System.EventHandler(this.frmDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn maDoan;
        private DevExpress.XtraGrid.Columns.GridColumn tenDoan;
        private DevExpress.XtraGrid.Columns.GridColumn maTruongDoan;
        private DevExpress.XtraGrid.Columns.GridColumn diaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSuaDoan;
    }
}