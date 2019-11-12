﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using Entyti;
using BUS;

namespace Home
{
    public partial class frmThanhToanKhachLe : DevExpress.XtraEditors.XtraForm
    {
        frmHome home;
        ArrayList phuthu = new ArrayList();
        double tienphong = 0, tiendv = 0, tienvat = 0;
        public static string MaThue = string.Empty;
        public static string TenPhong = string.Empty;
        public static string LoaiPhong = string.Empty;
        public static string maNVThanhToan = string.Empty;
        KhachHangBUS khbus = new KhachHangBUS();
        ThuePhongBUS tpbus = new ThuePhongBUS();
        ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();

        public frmThanhToanKhachLe()
        {
            InitializeComponent();
        }

        public frmThanhToanKhachLe(frmHome sql)
        {
            InitializeComponent();
            home = sql;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblMaThue.Text = MaThue;
            lblLoaiPhong.Text = LoaiPhong;
            lblTenPhong.Text = TenPhong;
            loadKhachHang();
            tienPhuThu();
            tinhTienPhong();
            load_list_dichvu();
            txtTongTien.Text = (tienvat + tienphong + tiendv + Convert.ToDouble(phuthu[0])).ToString();
        }

        public DataTable DataTable_DSDV(List<eChiTetDichVu> ds)
        {
            string tienDichVu;
            DichVuBUS dvbus = new DichVuBUS();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên dịch vụ", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(double));
            dt.Columns.Add("Thành tiền", typeof(double));
            foreach (eChiTetDichVu ctdv in ds)
            {
                tiendv += ctdv.SoLuong * dvbus.getDonGia_byID(ctdv.MaDV);
                tienDichVu = (ctdv.SoLuong * dvbus.getDonGia_byID(ctdv.MaDV)).ToString();
                dt.Rows.Add(dvbus.getTenDV_byID(ctdv.MaDV), ctdv.SoLuong, dvbus.getDonGia_byID(ctdv.MaDV), tienDichVu);
            }
            txtDichVu.Text = tiendv.ToString();
            return dt;
        }

        public void load_list_dichvu()
        {
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            dgvCTDV.DataSource = DataTable_DSDV(ctdvbus.getctdv(MaThue,cttpbus.getMaKhach_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong),false)));
        }

        public void loadKhachHang()
        {
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue,pbus.maPhong_byTen(TenPhong)))
            {
                foreach (var kh in khbus.getmaKH(item.MaKhach))
                {
                    txtHoTen.Text = kh.TenKH;
                    txtCMND.Text = kh.SoCMND;
                    txtSDT.Text = kh.SoDT;
                    if (kh.GioiTinh)
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                }
            }
        }

        public double tienPhong(string maLoaiPhong)
        {
            double tienPhong = 0;
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            tienPhong = lpbus.donGia(maLoaiPhong);
            return tienPhong;
        }

        public void tinhTienPhong()
        {
            TimeSpan nhan6h = new TimeSpan(6, 00, 00);
            TimeSpan nhan13h = new TimeSpan(13, 00, 00);
            TimeSpan nhan14h = new TimeSpan(14, 00, 00);
            PhongBUS pbus = new PhongBUS();
            eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue(MaThue))
            {
                lblNhanPhong.Text = item.GioVao + "   " + item.NgayVao.ToShortDateString();
                string gioMacDinh = nhan14h + "  " + item.NgayVao.ToShortDateString();
                lblTraPhong.Text = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                TimeSpan date = Convert.ToDateTime(lblTraPhong.Text) - Convert.ToDateTime(lblNhanPhong.Text);
                int ngay = date.Days;
                int h = date.Hours;
                int m = date.Minutes;
                if (item.NgayVao == DateTime.Now.Date && item.GioVao > nhan13h)
                {
                    tienphong = hdtp.tinhTienPhong(item, tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(gioMacDinh), Convert.ToDateTime(lblTraPhong.Text));
                    txtTienPhong.Text = (tienphong).ToString();
                }
                else
                {
                    tienphong = hdtp.tinhTienPhong(item, tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(lblNhanPhong.Text), Convert.ToDateTime(lblTraPhong.Text));
                    txtTienPhong.Text = (tienphong).ToString();
                }
                if (item.GioVao > nhan6h && item.GioVao < nhan13h)
                {
                    lblGhiChu.Text = "Số tiền khách đến sớm: " + item.GioVao + " " + item.NgayVao.ToShortDateString() + "đến " + nhan14h + " " + item.NgayVao.ToShortDateString() + "là " + phuthu[0].ToString() + " đồng"
                        + "\nSố tiền phòng: " + nhan14h + " " + item.NgayVao.ToShortDateString() + "đến " + lblTraPhong.Text + " là " + tienphong.ToString() + " đồng";
                }
                else
                {
                    lblGhiChu.Text = "\nSố tiền phòng: " + item.GioVao + " " + item.NgayVao.ToShortDateString() + "đến " + lblTraPhong.Text + " là " + tienphong.ToString() + " đồng";
                }
            }
        }

        public void tienPhuThu()
        {
            ArrayList tien = new ArrayList();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            eHoaDonTienPhong pt = new eHoaDonTienPhong();
            PhongBUS pbus = new PhongBUS();
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue(MaThue))
            {
                tien.Add(tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)));
            }
            foreach (double item in tien)
            {
                phuthu = pt.tinhTienPhuThu(cttpbus.getChiTietThuePhong_By_MaThue(MaThue), item);
            }           
            txtPhuThu.Text = phuthu[0].ToString();
        }

        private void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachThanhToan.Text.Equals(""))
            {
                txtTienThua.Text = "";
            }
            else
            {
                txtTienThua.Text = ((Convert.ToDouble(txtKhachThanhToan.Text)) - (tienvat + tienphong + tiendv + Convert.ToDouble(phuthu[0]))).ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtKhachThanhToan.Text.Equals(""))
            {
                MessageBox.Show("Xin hãy nhập số tiền khách thanh toán");
                return;
            }

            TimeSpan gioHienTai = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            ThanhToanHoaDonTienPhongBUS hdtpbus = new ThanhToanHoaDonTienPhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            eHoaDonTienPhong tt_ent = new eHoaDonTienPhong();
            tt_ent.MaThue = lblMaThue.Text.Trim();
            tt_ent.NgayLap = DateTime.Now;
            tt_ent.GioLap = gioHienTai;
            tt_ent.ThueVAT = Convert.ToSingle(10/100);
            tt_ent.KhuyenMai = Convert.ToSingle(txtGiamTru.Text);
            int a = hdtpbus.insertThanhToan(tt_ent);
            if (a == 1)
            {
                //Update lại trạng thái phòng
                PhongBUS pbus = new PhongBUS();
                ePhong phong = new ePhong();
                phong.MaPhong = pbus.maPhong_byTen(TenPhong);
                phong.TinhTrang = false;
                pbus.updateTinhTrangPhong(phong);

                //Update lại trạng thái chi tiết thuê phòng
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
                cttp.MaThue = MaThue;
                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                {
                    cttp.MaKhach = item.MaKhach;
                }
                cttp.TrangThai = true;
                cttp.NgayRa = DateTime.Now.Date;
                cttp.GioRa = gioHienTai;
                cttpbus.updateChiTietThuePhong(cttp);

                //update lại thông tin thuê phòng
                eThuePhong tp = new eThuePhong();
                tp.MaThue = tt_ent.MaThue;
                tp.TrangThai = true;
                tpbus.updateThuePhong(tp);

                MessageBox.Show("Đã thanh toán thành công");

                KhachHangBUS khbus = new KhachHangBUS();
                NhanVienBUS nvbus = new NhanVienBUS();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                HoaDon bc = new HoaDon();
                List<eChiTietBaoCao> listphong = new List<eChiTietBaoCao>();
                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue(tt_ent.MaThue))
                {
                    eChiTietBaoCao ctbc = new eChiTietBaoCao();
                    ctbc.tenPhong = pbus.getTenPhong_ByID(item.MaPhong);
                    ctbc.tenLoaiPhong = lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(item.MaPhong));
                    ctbc.thoiGianNhan = item.GioVao + " " + item.NgayVao.Date.ToShortDateString();
                    ctbc.thoiGianTra = item.GioRa + " " + item.NgayRa.Date.ToShortDateString();
                    ctbc.tienPhong = tienvat + tienphong + tiendv + Convert.ToDouble(phuthu[0]);
                    listphong.Add(ctbc);
                }

                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(tt_ent.MaThue, pbus.maPhong_byTen(TenPhong)))
                {
                    bc.tenNV = nvbus.getenNV_ByID(maNVThanhToan);
                    bc.tenKH = khbus.getenKH_ByID(item.MaKhach);
                    bc.soHD = hdtpbus.gemaHD_BymaThue(tt_ent.MaThue);         //Cần xem xét lại
                    bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                }
                this.Close();
                frmPrintHDTP frmp = new frmPrintHDTP();
                frmp.InHoaDonInTuReport(bc, listphong.ToList());
                frmp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại");
                return;
            }
        }

        private void txtTienPhong_TextChanged(object sender, EventArgs e)
        {
            txtVAT.Text = (Convert.ToDouble(txtTienPhong.Text) * 0.1).ToString();
            tienvat = Convert.ToDouble(txtTienPhong.Text) * 0.1;
        }

        private void frmThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {         
            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            home.cleanGiaoDien();
            home.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }
    }
}