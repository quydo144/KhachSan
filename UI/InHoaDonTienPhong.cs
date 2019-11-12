using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Entyti;

namespace Home
{
    public partial class InHoaDonTienPhong : XtraReport
    {
        public InHoaDonTienPhong()
        {
            InitializeComponent();
        }

        public void InHoaDonInData(string tenNV, string tenKH, string soHD, string thoiGianInHD,  List<eChiTietBaoCao> ls)
        {
            soHoaDon.Value = soHD;
            tgianInHoaDon.Value = thoiGianInHD;
            tenKhach.Value = tenKH;
            tenNhanVien.Value = tenNV;
            objectDataSource1.DataSource = ls;
        }

    }
}
