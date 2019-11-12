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
using Entyti;
using BUS;

namespace Home
{
    public partial class frmPrintHDTP : DevExpress.XtraEditors.XtraForm
    {
        public frmPrintHDTP()
        {
            InitializeComponent();
        }

        public void InHoaDonInTuReport(HoaDon bc, List<eChiTietBaoCao> ls)
        {
            InHoaDonTienPhong report = new InHoaDonTienPhong();
            foreach (DevExpress.XtraReports.Parameters.Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.InHoaDonInData(bc.tenNV, bc.tenKH, bc.soHD, bc.thoiGianInHD, ls.ToList());
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}