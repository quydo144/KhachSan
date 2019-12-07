using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using Entyti;
using BUS;

namespace Home
{
    public partial class frmBC_TienPhong : DevExpress.XtraEditors.XtraForm
    {
        public frmBC_TienPhong()
        {       
            InitializeComponent();
        }

        private void frmBC_TienPhong_Load(object sender, EventArgs e)
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
            cboNgayThang.SelectedIndex = 0;
        }
        public DataTable DataTable_DSTP(ArrayList ds)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            PhongBUS pbus = new PhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            DoanBUS dbus = new DoanBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên khách hàng", typeof(string));
            dt.Columns.Add("Tiền phòng", typeof(double));
            dt.Columns.Add("Thời gian vào", typeof(string));
            dt.Columns.Add("Thời gian ra", typeof(string));
            foreach (string item in ds)
            {
                double tienPhong = 0;            
                foreach (var cttp in cttpbus.getChiTietThuePhong_By_MaThue(item))
                {
                    tienPhong += hdtp.tinhTienPhong(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(cttp.MaPhong)), Convert.ToDateTime(cttp.GioVao + " " + cttp.NgayVao.ToShortDateString()), Convert.ToDateTime(cttp.GioRa + " " + cttp.NgayRa.ToShortDateString())) + hdtp.tinhTienPhuThu(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(cttp.MaPhong))) + cttp.TienKhac;
                }
                if (tpbus.getMaDoan_ByMaThue(item) == null)
                {
                    foreach (var cttp in cttpbus.getChiTietThuePhong_By_MaThue(item))
                    {
                        dt.Rows.Add(khbus.getenKH_ByID(cttp.MaKhach), tienPhong, cttp.GioVao + " " + cttp.NgayVao.ToShortDateString(), cttp.GioRa + " " + cttp.NgayRa.ToShortDateString());
                    }
                }
                else
                {
                    foreach (var cttp in cttpbus.getChiTietThuePhong_By_MaThue(item))
                    {
                        dt.Rows.Add(dbus.getTen_ById(tpbus.getMaDoan_ByMaThue(item)), tienPhong, cttp.GioVao + " " + cttp.NgayVao.ToShortDateString(), cttp.GioRa + " " + cttp.NgayRa.ToShortDateString());
                        break;
                    }
                }
            }
            return dt;
        }

        public void TheoNgay(DateTime date, string maNV)
        {
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            gdvBCDoanhThu.DataSource = DataTable_DSTP(hdtpbus.getMaThue_byNgay(date,maNV));
        }

        public void TrongKhoangNgayToNgay(DateTime dateS, DateTime dateE, string maNV)
        {
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            gdvBCDoanhThu.DataSource = DataTable_DSTP(hdtpbus.getMaThue_byNgay_to_Ngay(dateS,dateE,maNV));
        }

        public void TheoNgay_All(DateTime date)
        {
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            gdvBCDoanhThu.DataSource = DataTable_DSTP(hdtpbus.getMaThue_byNgay_All(date));
        }

        public void TrongKhoangNgayToNgay_All(DateTime dateS, DateTime dateE)
        {
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            gdvBCDoanhThu.DataSource = DataTable_DSTP(hdtpbus.getMaThue_byNgay_to_Ngay_All(dateS, dateE));
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

        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNgayThang.SelectedIndex == 0)
            {               
                TheoNgay(DateTime.Now.Date,cboNhanVien.SelectedValue.ToString());
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
            List<eBC_TienPhong> listbctp = new List<eBC_TienPhong>();

            for (int i = 0; i < gridViewTienPhong.RowCount; i++)
            {
                eBC_TienPhong bctp = new eBC_TienPhong();
                bctp.TenKH = gridViewTienPhong.GetRowCellValue(i, gridViewTienPhong.Columns[0]).ToString();
                bctp.TienPhong = Convert.ToDouble(gridViewTienPhong.GetRowCellValue(i, gridViewTienPhong.Columns[1]));
                bctp.TgianVao = Convert.ToDateTime(gridViewTienPhong.GetRowCellValue(i, gridViewTienPhong.Columns[2]));
                bctp.TgianRa = Convert.ToDateTime(gridViewTienPhong.GetRowCellValue(i, gridViewTienPhong.Columns[3]));
                listbctp.Add(bctp);
            }

            bc.loai = cboNgayThang.Text;
            bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
            bc.tenNV = cboNhanVien.Text;
            frmPrint frmInBCDV = new frmPrint();
            frmInBCDV.InBaoCaoInTienPhongTuReport(bc, listbctp.ToList());
            frmInBCDV.ShowDialog();
            this.Close();
        }
    }
}