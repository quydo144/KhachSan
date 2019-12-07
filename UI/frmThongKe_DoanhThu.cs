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
using DevExpress.XtraCharts;
using Entyti;
using BUS;

namespace Home
{
    public partial class frmThongKe_DoanhThu : DevExpress.XtraEditors.XtraForm
    {

        public frmThongKe_DoanhThu()
        {
            InitializeComponent();
        }

        public void DinhDangX(DateTimeGridAlignment x, DateTimeMeasureUnit y)
        {
            XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
            diagram.AxisX.DateTimeScaleOptions.AutoGrid = false;
            diagram.AxisX.DateTimeScaleOptions.GridAlignment = x;
            diagram.AxisX.DateTimeScaleOptions.MeasureUnit = y;
        }

        public double tienPhong(ArrayList ds)
        {
            double tienPhong = 0;
            PhongBUS pbus = new PhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
            foreach (string item in ds)
            {
                foreach (var cttp in cttpbus.getChiTietThuePhong_By_MaThue(item))
                {
                    tienPhong += hdtp.tinhTienPhong(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(cttp.MaPhong)), Convert.ToDateTime(cttp.GioVao + " " + cttp.NgayVao.ToShortDateString()), Convert.ToDateTime(cttp.GioRa + " " + cttp.NgayRa.ToShortDateString())) + hdtp.tinhTienPhuThu(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(cttp.MaPhong))) + cttp.TienKhac;
                }
            }
            return tienPhong;
        }

        public double tienDV(ArrayList ds)
        {
            double tongTienDV = 0;
            DichVuBUS dvbus = new DichVuBUS();
            PhongBUS pbus = new PhongBUS();
            KhachHangBUS khbus = new KhachHangBUS();
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
            eHoaDonDichVu hddv = new eHoaDonDichVu();
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
            foreach (string item in ds)
            {
                foreach (var ctdv in ctdvbus.getctdv_byMaThue(item))
                {
                    double tienDV = 0;
                    foreach (var ctdv1 in ctdvbus.getctdv_byMaThue(ctdv.MaThue))
                    {
                        tienDV += ctdv1.SoLuong * dvbus.getDonGia_byID(ctdv1.MaDV);
                    }
                    tongTienDV += tienDV;
                    break;
                }
            }
            return tongTienDV;
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

        private void frmThongKe_DoanhThu_Load(object sender, EventArgs e)
        {
            cboLuaChon.SelectedIndex = 0;

            DinhDangX(DateTimeGridAlignment.Month, DateTimeMeasureUnit.Month);
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            for (int i = 1; i < 13; i++)
            {
                eThongKeDoanhThu tk = new eThongKeDoanhThu();
                tk.TienDichVu = tienDV(hdtpbus.getMaThue_byThang_Nam(i, DateTime.Now.Year));
                tk.TienPhong = tienPhong(hdtpbus.getMaThue_byThang_Nam(i, DateTime.Now.Year));
                tk.TongTien = tk.TienDichVu + tk.TienPhong;
                tk.donVi = i.ToString();
                eThongKeDoanhThuBindingSource.Add(tk);
            }

            //DateTime dt = DateTime.Now.AddYears(-10);
            //DinhDangX(DateTimeGridAlignment.Year, DateTimeMeasureUnit.Year);
            //HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            //for (int i = 1; i < 11; i++)
            //{
            //    eThongKeDoanhThu tk = new eThongKeDoanhThu();
            //    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byNam(FirstDayOfYear(dt).AddYears(i).Year));
            //    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byNam(FirstDayOfYear(dt).AddYears(i).Year));
            //    tk.TongTien = tk.TienDichVu + tk.TienPhong;
            //    tk.donVi = (FirstDayOfYear(dt).AddYears(i).Year).ToString();
            //    eThongKeDoanhThuBindingSource.Add(tk);
            //}

            //DinhDangX(DateTimeGridAlignment.Quarter, DateTimeMeasureUnit.Quarter);
            //HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            //for (int i = 1; i <= 4; i++)
            //{
            //    eThongKeDoanhThu tk = new eThongKeDoanhThu();
            //    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byQui_Nam(i, DateTime.Now.Year));
            //    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byQui_Nam(i, DateTime.Now.Year));
            //    tk.TongTien = tk.TienDichVu + tk.TienPhong;
            //    tk.donVi = i.ToString();
            //    eThongKeDoanhThuBindingSource.Add(tk);
            //}

        }
    }
}