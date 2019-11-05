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

        private void open_frmMain()
        {
            Application.Run(new frmHome());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDatPhong.emailNV = txtEmail.Text;
            NhanVienBUS nvbus = new NhanVienBUS();
            frmThanhToan.maNVThanhToan = nvbus.getmaNV_byEmail(txtEmail.Text.Trim());
            if (nvbus.GetTKQL(txtEmail.Text.Trim(),txtPass.Text.Trim()))
            {
                Thread th = new Thread(open_frmMain);
                th.Start();
                this.Close();
            }
        }
    }
}