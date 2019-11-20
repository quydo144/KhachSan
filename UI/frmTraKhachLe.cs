using System;
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
    public partial class frmTraKhachLe : DevExpress.XtraEditors.XtraForm
    {
        frmHome home;
        string doan;
        double phuthu = 0;
        double tienphong = 0, tiendv = 0, tienvat = 0;
        public static string MaThue = string.Empty;
        public static string TenPhong = string.Empty;
        public static string LoaiPhong = string.Empty;
        public static string maNVThanhToan = string.Empty;
        KhachHangBUS khbus = new KhachHangBUS();
        ThuePhongBUS tpbus = new ThuePhongBUS();
        ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();

        public frmTraKhachLe()
        {
            InitializeComponent();
        }

        public frmTraKhachLe(frmHome sql)
        {
            InitializeComponent();
            home = sql;
            btnTraDoan.Visible = false;
        }

        public frmTraKhachLe(frmHome sql, string maDoan)
        {
            InitializeComponent();
            home = sql;
            doan = maDoan;
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
            txtTongTien.Text = (tienvat + tienphong + tiendv + Convert.ToDouble(phuthu) + Convert.ToDouble(txtTienKhac.Text)).ToString();
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
            dgvCTDV.DataSource = DataTable_DSDV(ctdvbus.getctdv(MaThue, cttpbus.getMaKhach_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false)));
        }

        public void loadKhachHang()
        {
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
            {
                eKhachHang kh = new eKhachHang();
                kh = khbus.getmaKH(item.MaKhach);
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
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
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
                    lblGhiChu.Text = item.GhiChu + "Số tiền khách đến sớm: " + item.GioVao + " " + item.NgayVao.ToShortDateString() + "đến " + nhan14h + " " + item.NgayVao.ToShortDateString() + "là " + phuthu.ToString() + " đồng"
                        + "\nSố tiền phòng: " + nhan14h + " " + item.NgayVao.ToShortDateString() + "đến " + lblTraPhong.Text + " là " + tienphong.ToString() + " đồng";
                }
                else
                {
                    lblGhiChu.Text = item.GhiChu + "\nSố tiền phòng: " + item.GioVao + " " + item.NgayVao.ToShortDateString() + "đến " + lblTraPhong.Text + " là " + tienphong.ToString() + " đồng";
                }
                txtTienKhac.Text = item.TienKhac.ToString();
            }
        }

        public void tienPhuThu()
        {
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            eHoaDonTienPhong pt = new eHoaDonTienPhong();
            phuthu = pt.tinhTienPhuThu(cttpbus.getCTTP_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false), tienPhong(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(TenPhong))));
            txtPhuThu.Text = phuthu.ToString();
        }

        private void txtKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachThanhToan.Text.Equals(""))
            {
                txtTienThua.Text = "";
            }
            else
            {
                txtTienThua.Text = ((Convert.ToDouble(txtKhachThanhToan.Text)) - (tienvat + tienphong + tiendv + Convert.ToDouble(phuthu))).ToString();
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
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
            PhongBUS pbus = new PhongBUS();

            int a = 0;
            int b = 0;
            if (cttpbus.getChiTietThuePhong_By_MaThue(MaThue).Count < 2)
            {
                eHoaDonTienPhong tt_ent = new eHoaDonTienPhong();
                tt_ent.MaThue = lblMaThue.Text.Trim();
                tt_ent.NgayLap = DateTime.Now;
                tt_ent.GioLap = gioHienTai;
                tt_ent.ThueVAT = Convert.ToSingle(10 / 100);
                tt_ent.KhuyenMai = Convert.ToSingle(txtGiamTru.Text);
                a = hdtpbus.insertThanhToan(tt_ent);
            }

            if (tpbus.getMaDoan_ByMaThue(MaThue) != null || ctdvbus.getctdv_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)).Count != 0)
            {
                b++;
            }

            /* Với a = 1 thanh toán khách lẻ 
                Với b = 1 thanh toán khách đoàn */

            //Update lại trạng thái phòng
            ePhong phong = new ePhong();
            phong.MaPhong = pbus.maPhong_byTen(TenPhong);
            phong.TinhTrang = false;
            pbus.updateTinhTrangPhong(phong);

            //Update lại trạng thái chi tiết thuê phòng
            eChiTietThuePhong cttp = new eChiTietThuePhong();
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
            {
                cttp.MaThue = MaThue;
                cttp.MaKhach = item.MaKhach;
                cttp.MaPhong = item.MaPhong;
                cttp.TrangThai = true;
                cttpbus.updateTrangThaiChiTietThuePhong(cttp);
            }

            //update lại thông tin thuê phòng
            eThuePhong tp = new eThuePhong();
            tp.MaThue = MaThue;
            tp.TrangThai = true;
            tpbus.updateThuePhong(tp);

            if (a == 1)
            {

                MessageBox.Show("Đã thanh toán thành công");

                KhachHangBUS khbus = new KhachHangBUS();
                NhanVienBUS nvbus = new NhanVienBUS();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                HoaDon bc = new HoaDon();
                List<eChiTietBaoCao> listphong = new List<eChiTietBaoCao>();
                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                {
                    eChiTietBaoCao ctbc = new eChiTietBaoCao();
                    ctbc.tenPhong = pbus.getTenPhong_ByID(item.MaPhong);
                    ctbc.tenLoaiPhong = lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(item.MaPhong));
                    ctbc.thoiGianNhan = item.GioVao + " " + item.NgayVao.Date.ToShortDateString();
                    ctbc.thoiGianTra = item.GioRa + " " + item.NgayRa.Date.ToShortDateString();
                    ctbc.tienPhong = tienvat + tienphong + tiendv + Convert.ToDouble(phuthu);
                    listphong.Add(ctbc);
                    break;
                }

                if (cttpbus.getChiTietThuePhong_By_MaThue(MaThue).Count < 2)
                {
                    foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                    {
                        bc.tenNV = nvbus.getenNV_ByID(maNVThanhToan);
                        bc.tenKH = khbus.getenKH_ByID(item.MaKhach);
                        bc.soHD = hdtpbus.gemaHD_BymaThue(MaThue);         //Cần xem xét lại
                        bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                    }
                }

                this.Close();
                frmPrint frmp = new frmPrint();
                frmp.InHoaDonInTuReport(bc, listphong.ToList());
                frmp.ShowDialog();
            }

            if (b == 1)
            {
                List<eCTDV> lsctdv = new List<eCTDV>();
                DichVuBUS dvbus = new DichVuBUS();
                KhachHangBUS khbus = new KhachHangBUS();
                NhanVienBUS nvbus = new NhanVienBUS();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                HoaDon bc = new HoaDon();

                if (ctdvbus.getctdv_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)) != null)
                {
                    foreach (var item in ctdvbus.getctdv_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                    {
                        eHoaDonDichVu hddv = new eHoaDonDichVu();
                        hddv.MaHDDV = (DateTime.Now.Day).ToString() + (DateTime.Now.Month).ToString() + (DateTime.Now.Year).ToString() + item.MaThue + item.MaKhach + item.MaPhong;
                        hddv.MaThue = MaThue;
                        hddv.MaKH = item.MaKhach;
                        hddv.MaPhong = item.MaPhong;
                        hddvbus.insertThanhToanDV(hddv);
                        break;
                    }
                }

                foreach (var item in ctdvbus.getctdv_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                {
                    eCTDV ctdv = new eCTDV();
                    ctdv.TenDV = dvbus.getTenDV_byID(item.MaDV);
                    ctdv.SoLuong = item.SoLuong;
                    ctdv.DonGia = dvbus.getDonGia_byID(item.MaDV);
                    lsctdv.Add(ctdv);
                }

                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(MaThue, pbus.maPhong_byTen(TenPhong)))
                {
                    if (item.MaPhong.Equals(pbus.maPhong_byTen(TenPhong)))
                    {
                        bc.tenNV = nvbus.getenNV_ByID(maNVThanhToan);
                        bc.tenKH = khbus.getenKH_ByID(item.MaKhach);
                        bc.soHD = hddvbus.gemaHD_BymaThue_maPhong(MaThue, item.MaPhong);
                        bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                        bc.tenPhong = pbus.getTenPhong_ByID(item.MaPhong);
                    }
                }

                frmPrint frmInDV = new frmPrint();
                frmInDV.InHoaDonInDichVuTuReport(bc, lsctdv.ToList());
                frmInDV.ShowDialog();
                this.Close();
            }
        }

        private void btnTraDoan_Click(object sender, EventArgs e)
        {
            this.Close();
            ThuePhongBUS tpbus = new ThuePhongBUS();           
            frmTraKhachDoan frm = new frmTraKhachDoan(home, tpbus.getMaDoan_ByMaThue(MaThue));
            frm.ShowDialog();
        }

        private void txtTienPhong_TextChanged(object sender, EventArgs e)
        {
            txtVAT.Text = (Convert.ToDouble(txtTienPhong.Text) * 0.1).ToString();
            tienvat = Convert.ToDouble(txtTienPhong.Text) * 0.1;
        }

        private void frmThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            home.cleanGiaoDien();
            home.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }
    }
}