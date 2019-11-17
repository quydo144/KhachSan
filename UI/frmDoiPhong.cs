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
        public static string maThue = string.Empty;

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
            ThuePhongBUS tpbus = new ThuePhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            int s = 0;
            foreach (eThuePhong item in tpbus.getMaThue(maThue))
            {
                eThuePhong etp = new eThuePhong();
                etp.MaNV = item.MaNV;
                etp.MaDoan = item.MaDoan;
                etp.SoLuongPhong = item.SoLuongPhong;
                etp.TrangThai = false;
                s = tpbus.insertThuePhong(etp);
            }
            if (s == 1)
            {

                foreach (eChiTietThuePhong item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(maThue, pbus.maPhong_byTen(TenPhong)))
                {
                    eChiTietThuePhong ect = new eChiTietThuePhong();
                    ect.GioRa = item.GioRa;
                    ect.GioVao = item.GioVao;
                    ect.MaKhach = item.MaKhach;
                    ect.MaPhong = cboPhongTrong.SelectedValue.ToString();
                    ect.NgayRa = item.NgayRa;
                    ect.NgayVao = item.NgayVao;
                    ect.TienKhac = Convert.ToDouble(lblTienKhac.Text);
                    ect.MaThue = tpbus.getMaThueCuoi();
                    ect.TrangThai = false;
                    if (cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false).GhiChu == null)
                    {
                        ect.GhiChu = cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false).GhiChu + "Đổi phòng từ " + lblTenPhong.Text + " (" + item.GioVao + " " + item.NgayVao.ToShortDateString() + ")" + "đến " + cboPhongTrong.Text + " (" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString() + ")";
                    }
                    else
                    {
                        ect.GhiChu = "Đổi phòng từ " + lblTenPhong.Text + " (" + item.GioVao + " " + item.NgayVao.ToShortDateString() + ")" + "đến " + cboPhongTrong.Text + " (" + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString() + ")";
                    }
                    cttpbus.insertCTTP(ect);

                    eChiTietThuePhong ectOld = new eChiTietThuePhong();
                    ectOld.MaThue = maThue;
                    ectOld.MaThue = pbus.maPhong_byTen(TenPhong);
                    ectOld.GhiChu = "Đổi phòng";

                }
                foreach (eChiTietThuePhong item in cttpbus.getChiTietThuePhong_By_MaThue_TrangThai(maThue, 0))
                {
                    if (!item.MaPhong.Equals(pbus.maPhong_byTen(TenPhong)))
                    {
                        eChiTietThuePhong ect = new eChiTietThuePhong();
                        ect.GioRa = item.GioRa;
                        ect.GioVao = item.GioVao;
                        ect.MaKhach = item.MaKhach;
                        ect.MaPhong = item.MaPhong;
                        ect.NgayRa = item.NgayRa;
                        ect.NgayVao = item.NgayVao;
                        ect.MaThue = tpbus.getMaThueCuoi();
                        ect.TrangThai = false;
                        cttpbus.insertCTTP(ect);
                    }
                }
                foreach (eChiTietThuePhong item in cttpbus.getChiTietThuePhong_By_MaThue_TrangThai(maThue, 1))
                {
                    eChiTietThuePhong ect = new eChiTietThuePhong();
                    ect.GioRa = item.GioRa;
                    ect.GioVao = item.GioVao;
                    ect.MaKhach = item.MaKhach;
                    ect.MaPhong = item.MaPhong;
                    ect.NgayRa = item.NgayRa;
                    ect.NgayVao = item.NgayVao;
                    ect.MaThue = tpbus.getMaThueCuoi();
                    ect.TrangThai = true;
                    cttpbus.insertCTTP(ect);
                }
                ePhong ep = new ePhong();
                ep.MaPhong = pbus.maPhong_byTen(TenPhong);
                ep.TinhTrang = false;
                pbus.updateTinhTrangPhong(ep);

                ePhong newp = new ePhong();
                newp.MaPhong = cboPhongTrong.SelectedValue.ToString();
                newp.TinhTrang = true;
                newp.SoNgHienTai = pbus.getEPhong_byID(pbus.maPhong_byTen(TenPhong)).SoNgHienTai;
                pbus.updateTinhTrangPhong(newp);

                //eChiTietThuePhong ecttp = new eChiTietThuePhong();
                //ecttp.MaThue = maThue;
                //ecttp.MaPhong = pbus.maPhong_byTen(TenPhong);
                //ecttp.GhiChu = "Đổi phòng";
                //cttpbus.updateChiTietThuePhong(ecttp);

                MessageBox.Show("Thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
                return;
            }
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