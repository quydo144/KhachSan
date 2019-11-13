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
using System.Collections;
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
            dt.Columns.Add("Giá phòng", typeof(double));
            dt.Columns.Add("Số phòng trống", typeof(int));
            dt.Columns.Add("Số lượng phòng", typeof(int));
            foreach (var item in lpbus.getall())
            {
                int s = 0;
                foreach (var p in pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false))
                {
                    s++;
                }
                dt.Rows.Add(item.TenLoaiPhong, item.DonGia, s, sl);
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

        private void btnKhToView_Click(object sender, EventArgs e)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            foreach (var khachhang in khbus.getcmnd(txtTKcmnd.Text))
            {
                eKhachHang kh = new eKhachHang();
                kh = khachhang;
                ls.Add(kh);
            }
            for (int i = 0; i < ls.Count - 1; i++)
            {
                if (ls.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < ls.Count; j++)
                {
                    if (ls[i].MaKH.Equals(ls[j].MaKH))
                    {
                        ls.RemoveAt(i);
                    }
                }
            }
            dgvDsKH.DataSource = ls.ToList();
        }

        private void txtTKcmnd_Enter(object sender, EventArgs e)
        {
            txtTKcmnd.Clear();
        }

        public void auToloadKhachHanhToDSPhong()
        {
            ArrayList dsTenPhong = new ArrayList();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
                {
                    dsTenPhong.Add(item.TenPhong);
                }
            }
            for (int i = 0; i < dsTenPhong.Count; i++)
            {
                if (dsTenPhong.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < dsTenPhong.Count; j++)
                {
                    if (dsTenPhong[i].Equals(dsTenPhong[j]))
                    {
                        dsTenPhong.RemoveAt(i);
                    }
                }
            }
            int s = 0;
            for (int i = s; i < dsTenPhong.Count; i++)
            {
                int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
                for (int j = 0; j < soNguoiToiDa; j++)
                {
                    gridViewDsKH.SetRowCellValue(s, gridViewDsKH.Columns[3], dsTenPhong[i]);
                    s++;

                }
            }
            cboPhong.DataSource = dsTenPhong;

        }

        private void btnAddKhAutoPhong_Click(object sender, EventArgs e)
        {
            auToloadKhachHanhToDSPhong();
        }

        private void cboPhong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ArrayList dsTenPhong = new ArrayList();
            ArrayList dsPhongO = new ArrayList();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
                {
                    dsTenPhong.Add(item.TenPhong);
                }
            }
            for (int i = 0; i < dsTenPhong.Count; i++)
            {
                if (dsTenPhong.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < dsTenPhong.Count; j++)
                {
                    if (dsTenPhong[i].Equals(dsTenPhong[j]))
                    {
                        dsTenPhong.RemoveAt(i);
                    }
                }
            }
            cboPhong.DataSource = dsTenPhong;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void gridViewLoaiPhong_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[2])) < Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3])))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng phòng " + gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString() + " lớn hơn yêu cầu");
                    return;
                }
            }
        }

        private void btnAddCoSanPhong_Click(object sender, EventArgs e)
        {
            //ArrayList dsTenPhong = new ArrayList();
            //ArrayList dsPhongO = new ArrayList();
            //PhongBUS pbus = new PhongBUS();
            //LoaiPhongBUS lpbus = new LoaiPhongBUS();
            //for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            //{
            //    foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
            //    {
            //        dsTenPhong.Add(item.TenPhong);
            //    }
            //}
            //for (int i = 0; i < dsTenPhong.Count; i++)
            //{
            //    if (dsTenPhong.Count == 1)
            //    {
            //        break;
            //    }
            //    for (int j = i + 1; j < dsTenPhong.Count; j++)
            //    {
            //        if (dsTenPhong[i].Equals(dsTenPhong[j]))
            //        {
            //            dsTenPhong.RemoveAt(i);
            //        }
            //    }
            //}

            //for (int a = 0; a < gridViewDsKH.RowCount; a++) 
            //{
            //    eKhachHang kh = new eKhachHang();
            //    kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //    int x = 0;
            //    if (kh.SoPhong == null)
            //    {
            //        continue;
            //    }
            //    for (int i = 0; i < dsTenPhong.Count; i++)
            //    {
            //        if (kh.SoPhong.Equals(dsTenPhong[i]))
            //        {
            //            dsTenPhong.RemoveAt(i);
            //            x--;
            //        }
            //    }
            //    x++;
            //}

            //int y = 0;
            //for (int a = y; a < gridViewDsKH.RowCount; a++)
            //{
            //    eKhachHang kh = new eKhachHang();
            //    kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //    for (int i = 0; i < dsTenPhong.Count; i++)
            //    {
            //        int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
            //        for (int j = 0; j < soNguoiToiDa; j++)
            //        {
            //            if (kh.SoPhong != null)
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                gridViewDsKH.SetRowCellValue(a, gridViewDsKH.Columns[3], dsTenPhong[i]);                   
            //            }
            //        }
            //        y++;
            //    }
            //}

            //for (int i = 0; i < dsTenPhong.Count; i++)
            //{
            //    for (int a = y; a < gridViewDsKH.RowCount; a++)
            //    {
            //        eKhachHang kh = new eKhachHang();
            //        kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //        int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
            //        for (int j = 0; j < soNguoiToiDa; j++)
            //        {
            //            if (kh.SoPhong != null)
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                gridViewDsKH.SetRowCellValue(a, gridViewDsKH.Columns[3], dsTenPhong[i]);
            //            }
            //        }
            //        y++;
            //    }
            //}
            //cboPhong.DataSource = dsTenPhong;
        }
    }
}