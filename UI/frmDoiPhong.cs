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
    public partial class frmDoiPhong : DevExpress.XtraEditors.XtraForm
    {
        frmHome frm;
        public static string TenPhong = string.Empty;

        public frmDoiPhong()
        {
            InitializeComponent();
        }

        public frmDoiPhong(frmHome sql)
        {
            InitializeComponent();
            frm = sql;
        }

        private void frmDoiPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            frm.AnflowLayoutPanel();
            frm.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        private void frmDoiPhong_Load(object sender, EventArgs e)
        {
            lblTenPhong.Text = TenPhong;
            PhongBUS pbus = new PhongBUS();
            cboPhongTrong.ValueMember = "MaPhong";
            cboPhongTrong.DisplayMember = "TenPhong";
            cboPhongTrong.DataSource = pbus.gettinhtrangp(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void cboPhongTrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            eChiTietThuePhong cttp = new eChiTietThuePhong();
            eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
            cttp = cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false);
            double tienPhongCu = hdtp.tinhTienPhong(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(TenPhong))), Convert.ToDateTime(cttp.GioVao + "   " + cttp.NgayVao.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString()));
            double tienPhongMoi = hdtp.tinhTienPhong(cttp, lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(cboPhongTrong.Text.Trim()))), Convert.ToDateTime(cttp.GioVao + "   " + cttp.NgayVao.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString()));
            if (!(lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(TenPhong))) > lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(cboPhongTrong.Text.Trim())))))
            {
                lblTienKhac.Text = (tienPhongMoi - tienPhongCu).ToString();
            }
            else if (lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(TenPhong))) == lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(cboPhongTrong.Text.Trim()))))
            {
                lblTienKhac.Text = "0";
            }
            else
            {
                lblTienKhac.Text = (tienPhongCu - tienPhongMoi).ToString();
            }          
        }
    }
}