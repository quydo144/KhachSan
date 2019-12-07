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
    public partial class frmBC_TienDichVu : DevExpress.XtraEditors.XtraForm
    {
        public frmBC_TienDichVu()
        {
            InitializeComponent();
        }

        private void frmBC_TienDichVu_Load(object sender, EventArgs e)
        {
            ArrayList NV = new ArrayList();
            NhanVienBUS nvbus = new NhanVienBUS();
            foreach (var item in nvbus.getallnv())
            {
                NV.Add(item);
            }
            NV.Add("All");
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.DataSource = NV;
            cboNhanVien.SelectedIndex = 0;
            cboNgayThang.SelectedIndex = 3;
        }

        public DataTable DataTable_DSTDV(ArrayList ds)
        {
            DichVuBUS dvbus = new DichVuBUS();
            PhongBUS pbus = new PhongBUS();
            KhachHangBUS khbus = new KhachHangBUS();
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
            eHoaDonDichVu hddv = new eHoaDonDichVu();//
            DataTable dt = new DataTable();
            dt.Columns.Add("Phòng", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Tiền DV", typeof(double));
            dt.Columns.Add("Ngày Lập", typeof(string));
            for (int i = 0; i < ds.Count; i++)
            {
                for (int j = 1; j < ds.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (ds[i].Equals(ds[j]))
                    { 
                        ds.RemoveAt(i);
                    }
                }
            }
            double tongTienDV = 0;
            foreach (string item in ds)
            {
                foreach (var ctdv in ctdvbus.getctdv_byMaThue(item))
                {
                    double tienDV = 0;
                    foreach (var ctdv1 in ctdvbus.getctdv_byMaThue(ctdv.MaThue))
                    {
                        tienDV += ctdv1.SoLuong * dvbus.getDonGia_byID(ctdv1.MaDV);
                    }
                    dt.Rows.Add(pbus.getTenPhong_ByID(ctdv.MaPhong), khbus.getenKH_ByID(ctdv.MaKhach), tienDV,hddvbus.getNgay_byMaThue(ctdv.MaThue).ToShortDateString());
                    tongTienDV += tienDV;
                    break;
                }
            }
            lblTongTien.Text = string.Format("{0:#,##0 vnđ}", tongTienDV).ToString();
            return dt;
        }
        public void TheoNgay(DateTime date, string maNV)
        {
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            gdvBC_TienDV.DataSource = DataTable_DSTDV(hddvbus.getMaThue_byNgay(date, maNV));
        }
        public void TheoNgay_All(DateTime date)
        {
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            gdvBC_TienDV.DataSource = DataTable_DSTDV(hddvbus.getMaThue_byNgay_All(date));
        }
        public void TrongKhoangNgayToNgay(DateTime dateS, DateTime dateE, string maNV)
        {
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            gdvBC_TienDV.DataSource = DataTable_DSTDV(hddvbus.getMaThue_byNgay_to_Ngay(dateS, dateE, maNV));
        }
        public void TrongKhoangNgayToNgay_All(DateTime dateS, DateTime dateE)
        {
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            gdvBC_TienDV.DataSource = DataTable_DSTDV(hddvbus.getMaThue_byNgay_to_Ngay_All(dateS, dateE));
        }

        public DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff + 1).Date;
        }

        public DateTime LastDayOfWeek(DateTime dt)
        {
            return FirstDayOfWeek(dt).AddDays(6);
        }

        public DateTime FirstDayOfMonth(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public DateTime LastDayOfMonth(DateTime dt)
        {
            return FirstDayOfMonth(dt).AddMonths(1).AddDays(-1);
        }

        public DateTime FirstDayOfYear(DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }

        public DateTime LastDayOfYear(DateTime dt)
        {
            return FirstDayOfYear(dt).AddYears(1).AddMonths(0).AddDays(-1);
        }


        private void cboNgayThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNgayThang.SelectedIndex == 0)
            {
                TheoNgay(DateTime.Now.Date, cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 1)
            {
                TrongKhoangNgayToNgay(FirstDayOfWeek(DateTime.Now.Date), LastDayOfWeek(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 2)
            {
                TrongKhoangNgayToNgay(FirstDayOfMonth(DateTime.Now.Date), LastDayOfMonth(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 3)
            {
                TrongKhoangNgayToNgay(FirstDayOfYear(DateTime.Now.Date), LastDayOfYear(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 4)
            {
                TrongKhoangNgayToNgay(Convert.ToDateTime("1/1/1975"), DateTime.Now.Date, cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 5)
            {
                TrongKhoangNgayToNgay(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNhanVien.SelectedItem.ToString().Equals("All"))
            {
                if (cboNgayThang.SelectedIndex == 0)
                {
                    TheoNgay_All(DateTime.Now.Date);
                }
                if (cboNgayThang.SelectedIndex == 1)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfWeek(DateTime.Now.Date), LastDayOfWeek(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 2)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfMonth(DateTime.Now.Date), LastDayOfMonth(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 3)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfYear(DateTime.Now.Date), LastDayOfYear(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 4)
                {
                    TrongKhoangNgayToNgay_All(Convert.ToDateTime("1/1/1975"), DateTime.Now.Date);
                }
                if (cboNgayThang.SelectedIndex == 5)
                {
                    TrongKhoangNgayToNgay_All(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text));
                }
            }
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNgayThang.SelectedIndex == 0)
            {
                TheoNgay(DateTime.Now.Date, cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 1)
            {
                TrongKhoangNgayToNgay(FirstDayOfWeek(DateTime.Now.Date), LastDayOfWeek(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 2)
            {
                TrongKhoangNgayToNgay(FirstDayOfMonth(DateTime.Now.Date), LastDayOfMonth(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 3)
            {
                TrongKhoangNgayToNgay(FirstDayOfYear(DateTime.Now.Date), LastDayOfYear(DateTime.Now.Date), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 4)
            {
                TrongKhoangNgayToNgay(Convert.ToDateTime("1/1/1975"), DateTime.Now.Date, cboNhanVien.SelectedValue.ToString());
            }
            if (cboNgayThang.SelectedIndex == 5)
            {
                TrongKhoangNgayToNgay(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text), cboNhanVien.SelectedValue.ToString());
            }
            if (cboNhanVien.SelectedItem.ToString().Equals("All"))
            {
                if (cboNgayThang.SelectedIndex == 0)
                {
                    TheoNgay_All(DateTime.Now.Date);
                }
                if (cboNgayThang.SelectedIndex == 1)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfWeek(DateTime.Now.Date), LastDayOfWeek(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 2)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfMonth(DateTime.Now.Date), LastDayOfMonth(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 3)
                {
                    TrongKhoangNgayToNgay_All(FirstDayOfYear(DateTime.Now.Date), LastDayOfYear(DateTime.Now.Date));
                }
                if (cboNgayThang.SelectedIndex == 4)
                {
                    TrongKhoangNgayToNgay_All(Convert.ToDateTime("1/1/1975"), DateTime.Now.Date);
                }
                if (cboNgayThang.SelectedIndex == 5)
                {
                    TrongKhoangNgayToNgay_All(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text));
                }
            }
        }
        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            cboNgayThang.SelectedIndex = 5;
            TrongKhoangNgayToNgay(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text), cboNhanVien.SelectedValue.ToString());
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            cboNgayThang.SelectedIndex = 5;
            TrongKhoangNgayToNgay(Convert.ToDateTime(dtpStart.Text), Convert.ToDateTime(dtpEnd.Text), cboNhanVien.SelectedValue.ToString());
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            HoaDon bc = new HoaDon();
            List<eBC_DoanhThuDV> listbcdv = new List<eBC_DoanhThuDV>();

            for (int i = 0; i < gridViewTienDV.RowCount; i++)
            {
                eBC_DoanhThuDV bcdv = new eBC_DoanhThuDV();
                bcdv.TenPhong = gridViewTienDV.GetRowCellValue(i, gridViewTienDV.Columns[0]).ToString();
                bcdv.TenKH = gridViewTienDV.GetRowCellValue(i, gridViewTienDV.Columns[1]).ToString();
                bcdv.TienDV = Convert.ToDouble(gridViewTienDV.GetRowCellValue(i, gridViewTienDV.Columns[2]));
                bcdv.NgayLap = Convert.ToDateTime(gridViewTienDV.GetRowCellValue(i, gridViewTienDV.Columns[3]));
                listbcdv.Add(bcdv);
            }

            bc.loai = cboNgayThang.Text;
            bc.thoiGianInHD= DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
            frmPrint frmInBCDV = new frmPrint();
            frmInBCDV.InBaoCaoInDichVuTuReport(bc, listbcdv.ToList());
            frmInBCDV.ShowDialog();
            this.Close();
        }
    }
}