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
using BUS;
using Entyti;

namespace Home
{
    public partial class frmBC_SoLuongKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmBC_SoLuongKhachHang()
        {
            InitializeComponent();
        }

        private void frmBC_SoLuongKhachHang_Load(object sender, EventArgs e)
        {
            cboNgayThang.SelectedIndex = 0;
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            gdvBC_LuongKhach.DataSource = DataTable_DSTP(cttpbus.getAllKHDangO());
        }

        public DataTable DataTable_DSTP(List<eChiTietThuePhong> ds)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            PhongBUS pbus = new PhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            DoanBUS dbus = new DoanBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên phòng", typeof(string));
            dt.Columns.Add("Tên khách hàng", typeof(string));
            dt.Columns.Add("Số CMND", typeof(string));
            dt.Columns.Add("Số điện thoại", typeof(string));
            dt.Columns.Add("Thời gian nhận phòng", typeof(string));
            foreach (eChiTietThuePhong item in ds)
            {
                eKhachHang kh = new eKhachHang();
                kh = khbus.getmaKH(item.MaKhach);
                dt.Rows.Add(pbus.getTenPhong_ByID(item.MaPhong), kh.TenKH, kh.SoCMND, kh.SoDT, item.GioVao + "  " + item.NgayVao.ToShortDateString());
            }
            return dt;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            HoaDon bc = new HoaDon();
            List<eKhachHang> listkh = new List<eKhachHang>();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            for (int i = 0; i < gridViewLuongKhach.RowCount; i++)
            {
                eKhachHang kh = new eKhachHang();
                kh.SoPhong = gridViewLuongKhach.GetRowCellValue(i, gridViewLuongKhach.Columns[0]).ToString();
                kh.TenKH = gridViewLuongKhach.GetRowCellValue(i, gridViewLuongKhach.Columns[1]).ToString();
                kh.SoCMND = gridViewLuongKhach.GetRowCellValue(i, gridViewLuongKhach.Columns[2]).ToString();
                kh.SoDT = gridViewLuongKhach.GetRowCellValue(i, gridViewLuongKhach.Columns[3]).ToString();
                string tgian = cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(kh.SoPhong), false).GioVao + "  " + cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(kh.SoPhong), false).NgayVao.ToShortDateString();
                kh.ThoiGianNhanPhong = tgian;
                listkh.Add(kh);
            }
            bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
            frmPrint frmInBCDV = new frmPrint();
            frmInBCDV.InBaoCaoInLuongKhachTuReport(bc, listkh.ToList());
            frmInBCDV.ShowDialog();
            this.Close();
        }
    }
}