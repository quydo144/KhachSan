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
using Entyti;
using BUS;


namespace Home
{
    public partial class frmTTKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHangBUS khBus;
        eKhachHang kh = new eKhachHang();       

        public frmTTKhachHang()
        {
            InitializeComponent();
        }
              
        private void btnThem_Click(object sender, EventArgs e)
        {
            eKhachHang newkh = new eKhachHang();
            newkh.MaKH = txtMaKhach.Text.Trim();
            newkh.TenKH = txtTenKhach.Text;
            newkh.SoCMND = txtCMND.Text;
            newkh.SoDT = txtSDT.Text;           
            if (radNam.Checked == true) newkh.GioiTinh = true;
            else newkh.GioiTinh = false;
            khBus = new KhachHangBUS();
            int kq = khBus.InsertKH(newkh);
            if (kq == 1)
            {
                MessageBox.Show("Thêm thành công!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bị trùng mã, nhập lại");
                txtMaKhach.Focus();
            }          
        }

        private void frmTTKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmDatPhong.CMND = txtCMND.Text;
        }

        private void frmTTKhachHang_Load(object sender, EventArgs e)
        {
                 
        }
    }
}