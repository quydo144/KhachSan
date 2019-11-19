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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmDatPhong.emailNV = txtEmail.Text.Trim();
            NhanVienBUS nvbus = new NhanVienBUS();
            frmTraKhachLe.maNVThanhToan = nvbus.getmaNV_byEmail(txtEmail.Text.Trim());
            frmTraKhachDoan.maNVThanhToan = nvbus.getmaNV_byEmail(txtEmail.Text.Trim());
            frmDatKhachDoan.emailNV = txtEmail.Text.Trim();
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
    }
}