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
        
        string tangMaKH()
        {
            string ma;
            khBus = new KhachHangBUS();
            kh = khBus.maTangTD();
            if (Convert.ToInt32(kh.MaKH.Substring(2, 6)) < 1000000 && Convert.ToInt32(kh.MaKH.Substring(2, 6)) >= 100000)
            {
                ma = "KH" + (Convert.ToInt32(kh.MaKH.Substring(2, 6)) + 1).ToString();
            }
            else if (Convert.ToInt32(kh.MaKH.Substring(3, 5)) < 100000 && Convert.ToInt32(kh.MaKH.Substring(3, 5)) >= 10000)
            {
                ma = "KH0" + (Convert.ToInt32(kh.MaKH.Substring(3, 5)) + 1).ToString();
            }
            else if (Convert.ToInt32(kh.MaKH.Substring(4, 4)) < 10000 && Convert.ToInt32(kh.MaKH.Substring(4, 4)) >= 1000)
            {
                ma = "KH00" + (Convert.ToInt32(kh.MaKH.Substring(4, 4)) + 1).ToString();
            }
            else if (Convert.ToInt32(kh.MaKH.Substring(5, 3)) < 1000 && Convert.ToInt32(kh.MaKH.Substring(5, 3)) >= 100)
            {
                ma = "KH000" + (Convert.ToInt32(kh.MaKH.Substring(5, 3)) + 1).ToString();
            }
            else if (Convert.ToInt32(kh.MaKH.Substring(6, 2)) < 100 && Convert.ToInt32(kh.MaKH.Substring(6, 2)) >= 10)
            {
                ma = "KH0000" + (Convert.ToInt32(kh.MaKH.Substring(6, 2)) + 1).ToString();
            }
            else
            {
                ma = "KH00000" + (Convert.ToInt32(kh.MaKH.Substring(7, 1)) + 1).ToString();
            }
            return ma;
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
            txtMaKhach.Text = tangMaKH();
        }
    }
}