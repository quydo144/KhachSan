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
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        public frmPrint()
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

        public void InHoaDonInDichVuTuReport(HoaDon bc, List<eCTDV> ls)
        {
            InHoaDonDichVu report = new InHoaDonDichVu();
            foreach (DevExpress.XtraReports.Parameters.Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.InHoaDonDataDichVu(bc.tenNV, bc.tenKH, bc.soHD, bc.thoiGianInHD, bc.tenPhong, ls.ToList());
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        public void InBaoCaoInDichVuTuReport(HoaDon bc, List<eBC_DoanhThuDV> ls)
        {
            InBaoCao_TienDV report = new InBaoCao_TienDV();
            foreach (DevExpress.XtraReports.Parameters.Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.InBaoCaoDataDichVu(bc.loai, bc.thoiGianInHD, ls.ToList());
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public void InBaoCaoInTienPhongTuReport(HoaDon bc, List<eBC_TienPhong> ls)
        {
            InBC_TienPhongcs report = new InBC_TienPhongcs();
            foreach (DevExpress.XtraReports.Parameters.Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.InBaoCaoDataTienPhong(bc.loai, bc.tenNV, bc.thoiGianInHD, ls.ToList());
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
      
        public void InBaoCaoInLuongKhachTuReport(HoaDon bc, List<eKhachHang> ls)
        {
            InBaoCao_LuongKhach report = new InBaoCao_LuongKhach();
            foreach (DevExpress.XtraReports.Parameters.Parameter item in report.Parameters)
            {
                item.Visible = false;
            }
            report.InBaoCaoDataLuongKhach(bc.thoiGianInHD, ls.ToList());
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
    }
}