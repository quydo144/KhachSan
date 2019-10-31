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

        private void button1_Click(object sender, EventArgs e)
        {
            frmDatPhong.maNV = txtID.Text;
            NhanVienBUS nvbus = new NhanVienBUS();
            if (nvbus.GetTKQL(txtID.Text.Trim(),txtPass.Text.Trim()))
            {
                frmHome frm = new frmHome(this);
                frm.ShowDialog();               
            }
            this.Visible = false;
        }
    }
}