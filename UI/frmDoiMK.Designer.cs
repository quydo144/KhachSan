namespace Home
{
    partial class frmDoiMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoiMK));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.txtKTPassMoi = new System.Windows.Forms.TextBox();
            this.txtPassMoi = new System.Windows.Forms.TextBox();
            this.txtPassCu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkDMK = new System.Windows.Forms.CheckBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxHienMK = new System.Windows.Forms.CheckBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMail
            // 
            this.txtMail.Enabled = false;
            this.txtMail.Location = new System.Drawing.Point(193, 17);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(228, 30);
            this.txtMail.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Họ tên ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Enabled = false;
            this.txtHoTen.Location = new System.Drawing.Point(193, 53);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(228, 30);
            this.txtHoTen.TabIndex = 1;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.cbxHienMK);
            this.panel.Controls.Add(this.txtKTPassMoi);
            this.panel.Controls.Add(this.txtPassMoi);
            this.panel.Controls.Add(this.txtPassCu);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label3);
            this.panel.Location = new System.Drawing.Point(12, 121);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(431, 176);
            this.panel.TabIndex = 2;
            // 
            // txtKTPassMoi
            // 
            this.txtKTPassMoi.Location = new System.Drawing.Point(180, 98);
            this.txtKTPassMoi.Name = "txtKTPassMoi";
            this.txtKTPassMoi.Size = new System.Drawing.Size(228, 30);
            this.txtKTPassMoi.TabIndex = 3;
            this.txtKTPassMoi.UseSystemPasswordChar = true;
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Location = new System.Drawing.Point(180, 53);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.Size = new System.Drawing.Size(228, 30);
            this.txtPassMoi.TabIndex = 3;
            this.txtPassMoi.UseSystemPasswordChar = true;
            // 
            // txtPassCu
            // 
            this.txtPassCu.Location = new System.Drawing.Point(180, 10);
            this.txtPassCu.Name = "txtPassCu";
            this.txtPassCu.Size = new System.Drawing.Size(228, 30);
            this.txtPassCu.TabIndex = 3;
            this.txtPassCu.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nhập lại";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mật khẩu mới";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu cũ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkDMK
            // 
            this.chkDMK.AutoSize = true;
            this.chkDMK.Location = new System.Drawing.Point(12, 89);
            this.chkDMK.Name = "chkDMK";
            this.chkDMK.Size = new System.Drawing.Size(136, 26);
            this.chkDMK.TabIndex = 3;
            this.chkDMK.Text = "Đổi mật khẩu";
            this.chkDMK.UseVisualStyleBackColor = true;
            this.chkDMK.CheckedChanged += new System.EventHandler(this.chkDMK_CheckedChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(73, 303);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(105, 44);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(251, 303);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "Thoát";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cbxHienMK
            // 
            this.cbxHienMK.AutoSize = true;
            this.cbxHienMK.Location = new System.Drawing.Point(264, 145);
            this.cbxHienMK.Name = "cbxHienMK";
            this.cbxHienMK.Size = new System.Drawing.Size(144, 26);
            this.cbxHienMK.TabIndex = 5;
            this.cbxHienMK.Text = "Hiện mật khẩu";
            this.cbxHienMK.UseVisualStyleBackColor = true;
            this.cbxHienMK.CheckedChanged += new System.EventHandler(this.cbxHienMK_CheckedChanged);
            // 
            // frmDoiMK
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(209)))), ((int)(((byte)(237)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(455, 355);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.chkDMK);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin tài khoản";
            this.Load += new System.EventHandler(this.frmDoiMK_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox txtKTPassMoi;
        private System.Windows.Forms.TextBox txtPassMoi;
        private System.Windows.Forms.TextBox txtPassCu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkDMK;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbxHienMK;
    }
}