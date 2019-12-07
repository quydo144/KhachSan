using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Entyti;

namespace Home
{
    public partial class InBaoCao_LuongKhach : DevExpress.XtraReports.UI.XtraReport
    {
        public InBaoCao_LuongKhach()
        {
            InitializeComponent();
        }

        public void InBaoCaoDataLuongKhach(string thoiGianInHD, List<eKhachHang> ls)
        {
            thoiGian.Value = thoiGianInHD;
            objectDataSource1.DataSource = ls;
        }
    }
}
