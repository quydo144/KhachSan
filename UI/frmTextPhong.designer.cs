namespace Home
{
    partial class frmTextPhong
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
            this.label3 = new System.Windows.Forms.Label();
            this.cbxLoaiPhong = new System.Windows.Forms.ComboBox();
            this.bteTang = new DevExpress.XtraEditors.SpinEdit();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bteTang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-3, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 38);
            this.label3.TabIndex = 45;
            this.label3.Text = "Tầng";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxLoaiPhong
            // 
            this.cbxLoaiPhong.FormattingEnabled = true;
            this.cbxLoaiPhong.Items.AddRange(new object[] {
            "Normal",
            "Double",
            "Triple",
            "Family",
            "Vip",
            "Deluxe"});
            this.cbxLoaiPhong.Location = new System.Drawing.Point(126, 187);
            this.cbxLoaiPhong.Name = "cbxLoaiPhong";
            this.cbxLoaiPhong.Size = new System.Drawing.Size(319, 32);
            this.cbxLoaiPhong.TabIndex = 49;
            // 
            // bteTang
            // 
            this.bteTang.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.bteTang.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bteTang.Location = new System.Drawing.Point(126, 133);
            this.bteTang.Name = "bteTang";
            this.bteTang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.bteTang.Properties.Appearance.Options.UseFont = true;
            this.bteTang.Properties.AutoHeight = false;
            this.bteTang.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.bteTang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bteTang.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.bteTang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.bteTang.Properties.MaxValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.bteTang.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bteTang.Size = new System.Drawing.Size(319, 30);
            this.bteTang.TabIndex = 50;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(126, 242);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(319, 107);
            this.txtGhiChu.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-3, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 38);
            this.label5.TabIndex = 43;
            this.label5.Text = "Loại phòng";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-13, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 38);
            this.label4.TabIndex = 44;
            this.label4.Text = "Ghi chú";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoEllipsis = true;
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lbTieuDe.Location = new System.Drawing.Point(97, 9);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(283, 33);
            this.lbTieuDe.TabIndex = 51;
            this.lbTieuDe.Text = "THÔNG TIN PHÒNG";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(145, 381);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(142, 49);
            this.btnLuu.TabIndex = 52;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Enabled = false;
            this.txtTenPhong.Location = new System.Drawing.Point(126, 85);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(319, 32);
            this.txtTenPhong.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 38);
            this.label2.TabIndex = 46;
            this.label2.Text = "Tên phòng";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTextPhong
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(470, 441);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.lbTieuDe);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxLoaiPhong);
            this.Controls.Add(this.bteTang);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTextPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin phòng";
            this.Load += new System.EventHandler(this.frmTextPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bteTang.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxLoaiPhong;
        private DevExpress.XtraEditors.SpinEdit bteTang;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.Label label2;
    }
}