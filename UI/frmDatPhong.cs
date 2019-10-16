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
        DichVuBUS listdv = new DichVuBUS();

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
            dgvDichVu.DataSource = listdv.getdv();
            gridViewDV.ShowFindPanel();
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
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //int index = gridViewCTDV.FocusedRowHandle;
            //ls.RemoveAt(index);
            //dgvCTDV.DataSource = ls;
        }

        private void txtSeachDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void cboSoLuong_Leave(object sender, EventArgs e)
        {
            string s;
            s = gridViewCTDV.Columns[1].ColumnEdit.IsLoading.ToString();
            
            MessageBox.Show(s);
            gridViewCTDV.SetFocusedRowCellValue(gridViewCTDV.Columns[3], 5);
        }
    }
}