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
    public partial class frmDichVu : DevExpress.XtraEditors.XtraForm
    {
        frmHome frm;
        List<eDichVu> listDV;
        DichVuBUS dvBUS;
        eDichVu dv = new eDichVu();
        public frmDichVu()
        {
            InitializeComponent();
        }

        public frmDichVu(frmHome home)
        {
            InitializeComponent();
            frm = home;
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {
            dvBUS = new DichVuBUS();
            listDV = new List<eDichVu>();
            listDV = dvBUS.getalldv();
            gridControlDV.DataSource = listDV;
            cboTKDV.Items.Add("Tìm theo mã");
            cboTKDV.Items.Add("Tìm theo tên");
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            eDichVu newdv = new eDichVu();
            newdv.MaDV = txtMaDV.Text.Trim();
            newdv.TenDV = txtTenDV.Text;
            newdv.DonGia = Convert.ToInt32(txtDonGia.Text);
            newdv.SoLuong = Convert.ToInt32(txtSL.Text);
            int kq = dvBUS.InsertDichVu(newdv);
            if (kq == 1)
                MessageBox.Show("Thêm thành công!!!");
            List<eDichVu> listDichVu = dvBUS.getalldv();
            gridControlDV.DataSource = listDichVu;
        }

        private void frmDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            if (frm.ExitAllForm())
            {
                frm.AnflowLayoutPanel();
                frm.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
            }
        }
    }
}