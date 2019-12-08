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
using System.Threading;
using Entyti;
using BUS;

namespace Home
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {

        public frmDangNhap()
        {
            InitializeComponent();
        }

        public void open_frmMain()
        {
            Application.Run(new frmHome());
        }

        public void DangNhap()
        {
            frmDatPhong.emailNV = txtEmail.Text.Trim();
            NhanVienBUS nvbus = new NhanVienBUS();
            frmTraKhachLe.maNVThanhToan = nvbus.getmaNV_byEmail(txtEmail.Text.Trim());
            frmTraKhachDoan.maNVThanhToan = nvbus.getmaNV_byEmail(txtEmail.Text.Trim());
            frmDatKhachDoan.emailNV = txtEmail.Text.Trim();
            frmDoiMK.tenDangNhap = txtEmail.Text.Trim();
            if (nvbus.GetTKQL(txtEmail.Text.Trim(), txtPass.Text.Trim()))
            {
                Thread th = new Thread(new ThreadStart(open_frmMain));
                //#pragma warning disable CS0618 // Type or member is obsolete
                //                th.ApartmentState = ApartmentState.STA;
                //#pragma warning restore CS0618 // Type or member is obsolete
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPass.UseSystemPasswordChar)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }
    }
}