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
    public partial class frmDatKhachDoan : DevExpress.XtraEditors.XtraForm
    {
        List<eKhachHang> ls = new List<eKhachHang>();
        int stt = 0;
        public static string CMND = string.Empty;
        public static string TenKH = string.Empty;
        public static string SDT = string.Empty;
        public static string emailNV = string.Empty;

        public frmDatKhachDoan()
        {
            InitializeComponent();
        }

        private void frmDatKhachDoan_Load(object sender, EventArgs e)
        {
            autoCompleteSource();
            LoadPhongTrong();
            lblTongSoPhong.Text = stt.ToString();
        }

        public void autoCompleteSource()
        {
            txtTKcmnd.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTKcmnd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            KhachHangBUS khbus = new KhachHangBUS();
            txtTKcmnd.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in khbus.get())
            {
                txtTKcmnd.AutoCompleteCustomSource.Add(item.SoCMND);
            }
        }

        public void LoadPhongTrong()
        {
            int sl = 0;
            DataTable dt = new DataTable();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            dt.Columns.Add("Tên loại phòng", typeof(string));
            dt.Columns.Add("Số phòng trống", typeof(int));
            dt.Columns.Add("Số lượng phòng", typeof(int));
            foreach (var item in lpbus.getall())
            {
                int s = 0;
                foreach (var p in pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false))
                {
                    s++;
                }
                dt.Rows.Add(item.TenLoaiPhong, s, sl);
            }
            dgvLoaiPhong.DataSource = dt;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmTTKhachHang frm = new frmTTKhachHang();
            frm.ShowDialog();
            txtSDT.Text = SDT;
            txtTenDoan.Text = TenKH;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnKhToView_Click(object sender, EventArgs e)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            foreach (var item in khbus.getcmnd(txtTKcmnd.Text))
            {
                eKhachHang kh = new eKhachHang();
                kh = item;
                ls.Add(kh);
            }
            dgvDsKH.DataSource = ls.ToList();
        }

        private void gridViewLoaiPhong_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //eDichVu dv = new eDichVu();
            //for (int i = 0; i < gridViewCTDV.RowCount; i++)
            //{
            //    foreach (eDichVu item in mangDichVu)
            //    {
            //        if (gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString() == item.MaDV && item.SoLuong < Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])))
            //        {
            //            ls.RemoveAt(i);
            //            gridViewCTDV.DeleteRow(i);
            //            DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng dịch vụ " + item.TenDV.ToLower() + " đã hết");
            //            return;
            //        }
            //        if (Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])) == 0)
            //        {
            //            DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng dịch vụ phải lớn hơn 0");
            //            return;
            //        }
            //    }
            //}
        }
    }
}