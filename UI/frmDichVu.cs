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

        List<eDichVu> listDV;
        DichVuBUS dvBUS;
        eDichVu dv = new eDichVu();
        public frmDichVu()
        {
            InitializeComponent();
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
            //dv = dvBUS.tangma();
            //if (Convert.ToInt32(dv.MaDV.Substring(5)) > 10)
            //{
            //    txtMaDV.Text = "DV000" + (Convert.ToInt32(dv.MaDV.Substring(5)) + 1).ToString();
            //}
            //else if (Convert.ToInt32(dv.MaDV.Substring(4, 5)) < 100)
            //{
            //    txtMaDV.Text = "DV00" + (Convert.ToInt32(dv.MaDV.Substring(4, 5)) + 1).ToString();
            //}
            //else if (Convert.ToInt32(dv.MaDV.Substring(3, 4)) < 1000)
            //{
            //    txtMaDV.Text = "DV0" + (Convert.ToInt32(dv.MaDV.Substring(3, 5)) + 1).ToString();
            //}
            //else
            //{
            //    txtMaDV.Text = "DV" + (Convert.ToInt32(dv.MaDV.Substring(2, 5)) + 1).ToString();
            //}
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
    }
}