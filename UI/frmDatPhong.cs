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
    public partial class frmDatPhong : DevExpress.XtraEditors.XtraForm
    {
        List<eCTDV> ls = new List<eCTDV>();
        List<eKhachHang> lskh;
        eSuDungDichVu sddv;
        eThuePhong tp;
        SuDungDichVuBUS sddvbus;
        ThuePhongBUS tpbus = new ThuePhongBUS();
        DichVuBUS dvbus = new DichVuBUS();
        KhachHangBUS khbus = new KhachHangBUS();

        public frmDatPhong()
        {
            InitializeComponent();
        }

        private void btnLuu_MouseHover(object sender, EventArgs e)
        {
            btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(217)))), ((int)(((byte)(89)))));
        }

        private void btnLuu_MouseLeave(object sender, EventArgs e)
        {
            btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(217)))), ((int)(((byte)(89)))));
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            dgvDichVu.DataSource = dvbus.getdv();
            autoCompleteSource();
        }

        private void autoCompleteSource()
        {
            txtSeachKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSeachKH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            KhachHangBUS khbus = new KhachHangBUS();
            txtSeachKH.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in khbus.get())
            {
                txtSeachKH.AutoCompleteCustomSource.Add(item.SoCMND);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 31; i++)
            {
                cboSL.Items.Add(i);
            }
            string tenDV = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[1]).ToString();
            string donGia = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[2]).ToString();
            eCTDV dv = new eCTDV();
            dv.TenDV = tenDV;
            dv.DonGia = Convert.ToDecimal(donGia);
            dv.SoLuong = 1;
            dv.ThanhTien = dv.DonGia;
            foreach (var item in ls.ToList())
            {
                if (item.TenDV.Equals(tenDV))
                {
                    ls.Remove(item);
                }
            }
            ls.Add(dv);
  
            dgvCTDV.DataSource = ls.ToList();
            eSuDungDichVu sddvnew = new eSuDungDichVu();
            sddvnew.MaSDDV = maThuePhong();
            sddvnew.MaDV = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[0]).ToString();
            //sddvnew.MaThue = maThuePhong();
            sddvnew.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(gridViewCTDV.FocusedRowHandle, gridViewCTDV.Columns[2]).ToString());
            sddvnew.ThoiGianSd = Convert.ToDateTime(DateTime.Now);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = gridViewCTDV.FocusedRowHandle;
            ls.RemoveAt(index);
            dgvCTDV.DataSource = ls;
        }

        private void txtSeachDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void txtSeachKH_TextChanged(object sender, EventArgs e)
        {
            string s = txtSeachKH.Text;
            lskh = khbus.getcmnd(s);
            foreach (var item in lskh)
            {
                txtHT.Text = item.TenKH;
                txtCMND.Text = item.SoCMND;
                txtSDT.Text = item.SoDT;
                if (item.GioiTinh)
                {
                    radNam.Checked = true;
                }
                else
                {
                    radNu.Checked = true;
                }
            }
        }

        string maThuePhong()
        {
            string maDatPhong;
            tp = new eThuePhong();
            tp = tpbus.tangma();
            if (Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) < 10000000 && Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) > 1000000)
            {
                maDatPhong = "TP" + (Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) < 1000000 && Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) > 100000)
            {
                maDatPhong = "TP0" + (Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) < 100000 && Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) > 10000)
            {
                maDatPhong = "TP00" + (Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) < 10000 && Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) > 1000)
            {
                maDatPhong = "TP000" + (Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) < 1000 && Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) > 100)
            {
                maDatPhong = "TP0000" + (Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) < 100 && Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) > 10)
            {
                maDatPhong = "TP00000" + (Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) + 1).ToString();
            }
            else
            {
                maDatPhong = "TP000000" + (Convert.ToInt32(tp.MaThuePhong.Substring(8, 1)) + 1).ToString();
            }
            return maDatPhong;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            eThuePhong tp = new eThuePhong();
            tp.MaThuePhong = maThuePhong();

        }
    }
}