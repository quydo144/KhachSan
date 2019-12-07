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
            int nam = DateTime.Now.Year - 9;
            for (int i = nam ; i <= nam + 9; i++)
            {
                cboNam.Items.Add(i);
            }
            cboNam.SelectedIndex = 9;
        }

        private void cboLuaChon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLuaChon.SelectedIndex == 0)
            {
                cboNam.Visible = true;
                eThongKeDoanhThuBindingSource.Clear();
                XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
                diagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
                HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
                for (int i = 1; i < 13; i++)
                {
                    eThongKeDoanhThu tk = new eThongKeDoanhThu();
                    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byThang_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byThang_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TongTien = tk.TienDichVu + tk.TienPhong;
                    tk.donVi = Convert.ToInt32(i);
                    eThongKeDoanhThuBindingSource.Add(tk);
                }
            }
            if (cboLuaChon.SelectedIndex == 1)
            {
                cboNam.Visible = true;
                eThongKeDoanhThuBindingSource.Clear();
                XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
                diagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Quarter;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Quarter;
                HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
                for (int i = 1; i <= 4; i++)
                {
                    eThongKeDoanhThu tk = new eThongKeDoanhThu();
                    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byQui_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byQui_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TongTien = tk.TienDichVu + tk.TienPhong;
                    tk.donVi = i;
                    eThongKeDoanhThuBindingSource.Add(tk);
                }
            }
            if (cboLuaChon.SelectedIndex == 2)
            {
                cboNam.Visible = false;
                eThongKeDoanhThuBindingSource.Clear();                
                XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
                diagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Year;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Year;
                DateTime dt = DateTime.Now.AddYears(-10);
                HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
                for (int i = 1; i < 11; i++)
                {
                    eThongKeDoanhThu tk = new eThongKeDoanhThu();
                    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byNam(FirstDayOfYear(dt).AddYears(i).Year));
                    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byNam(FirstDayOfYear(dt).AddYears(i).Year));
                    tk.TongTien = tk.TienDichVu + tk.TienPhong;
                    tk.donVi = (FirstDayOfYear(dt).AddYears(i).Year);
                    eThongKeDoanhThuBindingSource.Add(tk);
                }
            }
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLuaChon.SelectedIndex == 0)
            {
                cboNam.Visible = true;
                eThongKeDoanhThuBindingSource.Clear();
                XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
                diagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Month;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Month;
                HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
                for (int i = 1; i < 13; i++)
                {
                    eThongKeDoanhThu tk = new eThongKeDoanhThu();
                    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byThang_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byThang_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TongTien = tk.TienDichVu + tk.TienPhong;
                    tk.donVi = Convert.ToInt32(i);
                    eThongKeDoanhThuBindingSource.Add(tk);
                }
            }
            if (cboLuaChon.SelectedIndex == 1)
            {
                cboNam.Visible = true;
                eThongKeDoanhThuBindingSource.Clear();
                XYDiagram diagram = (XYDiagram)chartDoanhThu.Diagram;
                diagram.AxisX.DateTimeScaleOptions.AutoGrid = true;
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Quarter;
                diagram.AxisX.DateTimeScaleOptions.GridAlignment = DateTimeGridAlignment.Quarter;
                HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
                for (int i = 1; i <= 4; i++)
                {
                    eThongKeDoanhThu tk = new eThongKeDoanhThu();
                    tk.TienDichVu = tienDV(hdtpbus.getMaThue_byQui_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TienPhong = tienPhong(hdtpbus.getMaThue_byQui_Nam(i, Convert.ToInt32(cboNam.SelectedItem)));
                    tk.TongTien = tk.TienDichVu + tk.TienPhong;
                    tk.donVi = i;
                    eThongKeDoanhThuBindingSource.Add(tk);
                }
            }
        }
    }
}