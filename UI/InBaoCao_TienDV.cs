using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Entyti;

namespace Home
{
    public partial class InBaoCao_TienDV : DevExpress.XtraReports.UI.XtraReport
    {
        public InBaoCao_TienDV()
        {
            InitializeComponent();
        }
        public void InBaoCaoDataDichVu(string loai, string thoiGianInHD, List<eBC_DoanhThuDV> ls)
        {
            tgianbc.Value = thoiGianInHD;
            loaiBC.Value = loai;
            objectDataSource1.DataSource = ls;
        }
    }
}
