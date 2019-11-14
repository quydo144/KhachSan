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
    public partial class frmTextKhachHang : DevExpress.XtraEditors.XtraForm
    {
        frmKhachHang frm;
        KhachHangBUS khBus;
        string cmnd, tenkh, sdt, giotinh;
        int kq = 0;
        string maKhachHang;
        int kieuForm;

        public frmTextKhachHang()
        {
            InitializeComponent();
        }

        public frmTextKhachHang(frmKhachHang sql)
        {
            InitializeComponent();
            kieuForm = 1;
            frm = sql;
        }

        public frmTextKhachHang(frmKhachHang sql, string idKH)
        {
            InitializeComponent();
            kieuForm = 2;
            frm = sql;
            maKhachHang = idKH;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kieuForm == 1)
            {
                ThemKH();
            }
            if (kieuForm == 2)
            {
                SuaKH();
            }
        }

        private void frmTextKhachHang_Load(object sender, EventArgs e)
        {
            if (kieuForm == 2)
            {
                KhachHangBUS khbus = new KhachHangBUS();
                eKhachHang kh = new eKhachHang();
                kh = khbus.getmaKH(maKhachHang);
                txtTenKhach.Text = kh.TenKH;
                txtSDT.Text = kh.SoDT;
                txtCMND.Text = kh.SoDT;
                if (kh.GioiTinh)
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
            }
        }

        void ThemKH()
        {
            eKhachHang newkh = new eKhachHang();
            newkh.TenKH = txtTenKhach.Text;
            newkh.SoCMND = txtCMND.Text;
            newkh.SoDT = txtSDT.Text;
            if (radNam.Checked == true) newkh.GioiTinh = true;
            else newkh.GioiTinh = false;
            khBus = new KhachHangBUS();
            kq = khBus.InsertKH(newkh);
            if (kq == 1)
            {
                MessageBox.Show("Thêm thành công!!!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bị trùng mã, nhập lại");
            }
        }

        void SuaKH()
        {
            eKhachHang kh = new eKhachHang();
            KhachHangBUS khbus = new KhachHangBUS();
            kh.MaKH = maKhachHang;
            kh.TenKH = txtTenKhach.Text;
            kh.SoCMND = txtCMND.Text;
            kh.SoDT = txtSDT.Text;
            if (radNam.Checked == true) kh.GioiTinh = true;
            else kh.GioiTinh = false;
            khbus.updateKH(kh);
            this.Close();
        }

        private void frmTTKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kieuForm == 1 || kieuForm == 2)
            {
                frm.LoadKHDangThuePhong();
            }
            else
            {
                if (kq != 1)
                {
                    return;
                }
                else
                {
                    frmDatPhong.CMND = cmnd;
                    frmDatPhong.TenKH = tenkh;
                    frmDatPhong.SDT = sdt;
                    frmDatPhong.GioiTinh = giotinh;

                    frmDatKhachDoan.CMND = cmnd;
                    frmDatKhachDoan.TenKH = tenkh;
                    frmDatKhachDoan.SDT = sdt;
                }
            }        
        }
    }
}