using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Entyti;

namespace Home
{
    public partial class InHoaDonDichVu : DevExpress.XtraReports.UI.XtraReport
    {
        public InHoaDonDichVu()
        {
            InitializeComponent();
        }

        public void InHoaDonDataDichVu(string tenNV, string tenKH, string soHD, string thoiGianInHD, string phong,List<eCTDV> ls)
        {
            maHoaDon.Value = soHD;
            thoiGianInHoaDon.Value = thoiGianInHD;
            tenKhachHang.Value = tenKH;
            tenNhanVien.Value = tenNV;
            tenPhong.Value = phong;
            objectDataSource1.DataSource = ls;
        }

    }
}
