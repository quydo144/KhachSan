using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;
using Entyti;

namespace Home
{
    public partial class frmDoiMK : DevExpress.XtraEditors.XtraForm
    {
        public static string tenDangNhap = string.Empty;

        public frmDoiMK()
        {
            InitializeComponent();
        }

        private void chkDMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDMK.Checked == true)
            {
                panel.Enabled = true;
            }
            else
            {
                panel.Enabled = false;
            }
        }

        private void frmDoiMK_Load(object sender, EventArgs e)
        {
            NhanVienBUS nvbus = new NhanVienBUS();
            txtMail.Text = tenDangNhap.Trim();
            txtHoTen.Text = nvbus.getTenNV_byEmail(tenDangNhap.Trim());
            panel.Enabled = false;
        }

        private void cbxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassCu.UseSystemPasswordChar && txtKTPassMoi.UseSystemPasswordChar && txtPassMoi.UseSystemPasswordChar)
            {
                txtPassCu.UseSystemPasswordChar = false;
                txtKTPassMoi.UseSystemPasswordChar = false;
                txtPassMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassCu.UseSystemPasswordChar = true;
                txtKTPassMoi.UseSystemPasswordChar = true;
                txtPassMoi.UseSystemPasswordChar = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!txtPassMoi.Text.Trim().Equals(txtKTPassMoi.Text.Trim()))
            {
                MessageBox.Show("Mật khẩu không giống nhau", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}