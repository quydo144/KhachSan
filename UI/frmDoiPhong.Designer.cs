namespace Home
{
    partial class frmDoiPhong
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTienKhac = new System.Windows.Forms.Label();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.cboPhongTrong = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phòng cũ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phòng chuyển đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiền chênh lệch";
            // 
            // lblTienKhac
            // 
            this.lblTienKhac.BackColor = System.Drawing.Color.White;
            this.lblTienKhac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTienKhac.Location = new System.Drawing.Point(376, 88);
            this.lblTienKhac.Name = "lblTienKhac";
            this.lblTienKhac.Size = new System.Drawing.Size(156, 29);
            this.lblTienKhac.TabIndex = 3;
            this.lblTienKhac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.BackColor = System.Drawing.Color.White;
            this.lblTenPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenPhong.Location = new System.Drawing.Point(134, 21);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(156, 29);
            this.lblTenPhong.TabIndex = 4;
            this.lblTenPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboPhongTrong
            // 
            this.cboPhongTrong.FormattingEnabled = true;
            this.cboPhongTrong.Location = new System.Drawing.Point(578, 20);
            this.cboPhongTrong.Name = "cboPhongTrong";
            this.cboPhongTrong.Size = new System.Drawing.Size(183, 32);
            this.cboPhongTrong.TabIndex = 5;
            this.cboPhongTrong.SelectedIndexChanged += new System.EventHandler(this.cboPhongTrong_SelectedIndexChanged);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(179, 151);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(128, 49);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(453, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmDoiPhong
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(773, 220);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboPhongTrong);
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.lblTienKhac);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDoiPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi phòng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDoiPhong_FormClosing);
            this.Load += new System.EventHandler(this.frmDoiPhong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTienKhac;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.ComboBox cboPhongTrong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button button2;
    }
}