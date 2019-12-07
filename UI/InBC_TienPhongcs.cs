using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Entyti;
namespace Home
{
    public partial class InBC_TienPhongcs : DevExpress.XtraReports.UI.XtraReport
    {
        public InBC_TienPhongcs()
        {
            InitializeComponent();
        }
        public void InBaoCaoDataTienPhong(string loai, string nv, string thoiGianInHD, List<eBC_TienPhong> ls)
        {
            thoigianIn.Value = thoiGianInHD;
            loaiBC.Value = loai;
            tenNV.Value = nv;
            objectDataSource1.DataSource = ls;
        }
    }
}
