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
    public partial class frmTraKhachDoan : DevExpress.XtraEditors.XtraForm
    {
        frmHome form;
        string maDoan;
        public static string maNVThanhToan = string.Empty;

        public frmTraKhachDoan()
        {
            InitializeComponent();
        }

        public frmTraKhachDoan(frmHome sql)
        {
            InitializeComponent();
            form = sql;
        }

        public frmTraKhachDoan(frmHome sql, string maD)
        {
            InitializeComponent();
            form = sql;
            maDoan = maD;
        }

        private void frmTraKhachDoan_Load(object sender, EventArgs e)
        {
            autoCompleteSource();
            if (maDoan != null)
            {
                DoanBUS dbus = new DoanBUS();
                eDoan doan = new eDoan();
                doan = dbus.getdoan_ID(maDoan);
                txtSdt.Text = doan.Sdt;
                txtTruongDoan.Text = doan.MaTruongDoan;
                txtTenDoan.Text = doan.TenDoan;
                loadThuePhong_Doan();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DoanBUS dbus = new DoanBUS();
            eDoan doan = new eDoan();
            doan = dbus.getdoan_sdt(txtSdt.Text.Trim());
            txtTruongDoan.Text = doan.MaTruongDoan;
            txtTenDoan.Text = doan.TenDoan;
            loadThuePhong_Doan();
        }
        public void autoCompleteSource()
        {
            txtTenDoan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenDoan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            DoanBUS dbus = new DoanBUS();
            txtTenDoan.AutoCompleteCustomSource.Clear();
            foreach (eDoan item in dbus.getdoans())
            {
                txtTenDoan.AutoCompleteCustomSource.Add(item.TenDoan);
            }
        }

        public void loadThuePhong_Doan()
        {
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            DoanBUS dbus = new DoanBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            PhongBUS pbus = new PhongBUS();
            ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
            DichVuBUS dvbus = new DichVuBUS();
            List<eChiTietThuePhong> list_ect = new List<eChiTietThuePhong>();
            list_ect = cttpbus.getChiTietThuePhong_By_MaThue_TrangThai(tpbus.getMaThue_ByMaDoan(dbus.getId_ByTenDoan(txtTenDoan.Text), 0), 0);

            for (int i = 0; i < list_ect.Count; i++)
            {
                for (int j = 1; j < list_ect.Count; j++)
                {
                    if (i == j)
                    {
                        list_ect.RemoveAt(i);
                        continue;
                    }
                    if (list_ect[i].MaPhong.Equals(list_ect[j].MaPhong))
                    {
                        list_ect.RemoveAt(i);
                    }
                }
            }

            List<eThuePhong_Doan> lstp_d = new List<eThuePhong_Doan>();
            foreach (eChiTietThuePhong item in list_ect)
            {
                eThuePhong_Doan etpd = new eThuePhong_Doan();
                eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
                eHoaDonDichVu hddv = new eHoaDonDichVu();
                double tienPhong = Convert.ToDouble(hdtp.tinhTienPhong(item, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(item.GioVao + "   " + item.NgayVao.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString())));
                double tienPhuThu = 0;
                if (item.GhiChu.Equals(""))
                {               
                    tienPhuThu += Convert.ToDouble(hdtp.tinhTienPhuThu(item, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong))));
                }
                else
                {
                    tienPhuThu += Convert.ToDouble(hdtp.tinhTienPhuThu(item, lpbus.donGia(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(item.GhiChu.Substring(0, 8))))));
                }
                etpd.Tenphong = pbus.getTenPhong_ByID(item.MaPhong);
                etpd.TienPhong = tienPhong + tienPhuThu;
                double tienDV = 0;
                foreach (eChiTetDichVu ctdv in ctdvbus.getctdv_MaThue_MaPhong(item.MaThue, item.MaPhong))
                {
                    tienDV += hddv.tinhDichVu(dvbus.getDonGia_byID(ctdv.MaDV), ctdv.SoLuong);
                }
                etpd.TienDV = tienDV;
                etpd.TienKhac = item.TienKhac;
                etpd.GhiChu = item.GhiChu;
                lstp_d.Add(etpd);
            }
            dgvDsThuePhong.DataSource = lstp_d.ToList();
            double tongTienPhong = 0;
            for (int i = 0; i < gridViewDsThuePhong.RowCount; i++)
            {
                tongTienPhong += Convert.ToDouble(gridViewDsThuePhong.GetRowCellValue(i, gridViewDsThuePhong.Columns[1]));
            }
            txtTongTienPhong.Text = string.Format("{0:#,##0}", tongTienPhong).ToString();
            txtThueVAT.Text = string.Format("{0:#,##0}", tongTienPhong * 0.1).ToString();
            txtKhuyenMai.Text = string.Format("{0:#,##0}", tongTienPhong * 0.2).ToString();
            txtTienThanhToan.Text = string.Format("{0:#,##0}", tongTienPhong + tongTienPhong * 0.1 - tongTienPhong * 0.2).ToString();
        }

        private void frmTraKhachDoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            form.cleanGiaoDien();
            form.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            txtTienThua.Text = (Convert.ToDouble(txtTienThanhToan.Text) - Convert.ToDouble(txtTienKhachDua.Text)).ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            DoanBUS dbus = new DoanBUS();
            PhongBUS pbus = new PhongBUS();
            HoaDonTienPhongBUS hdtpbus = new HoaDonTienPhongBUS();
            TimeSpan gioHienTai = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            eHoaDonTienPhong tt_ent = new eHoaDonTienPhong();
            tt_ent.MaThue = tpbus.getMaThue_ByMaDoan(dbus.getId_ByTenDoan(txtTenDoan.Text), 0);
            tt_ent.NgayLap = DateTime.Now;
            tt_ent.GioLap = gioHienTai;
            tt_ent.ThueVAT = Convert.ToSingle(txtThueVAT.Text);
            tt_ent.KhuyenMai = Convert.ToSingle(txtKhuyenMai.Text);
            int a = hdtpbus.insertThanhToan(tt_ent);
            if (a == 1)
            {
                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue(tpbus.getMaThue_ByMaDoan(dbus.getId_ByTenDoan(txtTenDoan.Text), 0)))
                {
                    eChiTietThuePhong ectOld = new eChiTietThuePhong();
                    ectOld.MaThue = tpbus.getMaThue_ByMaDoan(dbus.getId_ByTenDoan(txtTenDoan.Text), 0);
                    ectOld.MaPhong = item.MaPhong;
                    ectOld.MaKhach = item.MaKhach;
                    ectOld.NgayRa = DateTime.Now.Date;
                    ectOld.GioRa = gioHienTai;
                    ectOld.TrangThai = true;
                    cttpbus.updateChiTietThuePhong(ectOld);

                    ePhong newp = new ePhong();
                    newp.MaPhong = item.MaPhong;
                    newp.TinhTrang = false;
                    newp.SoNgHienTai = 0;
                    pbus.updateTinhTrangPhong(newp);
                }

                eThuePhong tp = new eThuePhong();
                tp.MaThue = tpbus.getMaThue_ByMaDoan(dbus.getId_ByTenDoan(txtTenDoan.Text), 0);
                tp.TrangThai = true;
                tpbus.updateThuePhong(tp);

                MessageBox.Show("Thanh toán thành công");

                NhanVienBUS nvbus = new NhanVienBUS();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                HoaDon bc = new HoaDon();
                List<eChiTietBaoCao> listphong = new List<eChiTietBaoCao>();
                foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_TrangThai(tp.MaThue, 1))
                {
                    eChiTietBaoCao ctbc = new eChiTietBaoCao();
                    ctbc.tenPhong = pbus.getTenPhong_ByID(item.MaPhong);
                    ctbc.tenLoaiPhong = lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(item.MaPhong));
                    ctbc.thoiGianNhan = item.GioVao + " " + item.NgayVao.Date.ToShortDateString();
                    ctbc.thoiGianTra = item.GioRa + " " + item.NgayRa.Date.ToShortDateString();
                    eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
                    double tienPhong = Convert.ToDouble(hdtp.tinhTienPhong(item, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(item.GioVao + "   " + item.NgayVao.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString())));
                    double tienPhuThu = Convert.ToDouble(hdtp.tinhTienPhuThu(item, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong))));
                    ctbc.tienPhong = tienPhong + tienPhuThu;
                    listphong.Add(ctbc);
                }

                for (int i = 0; i < listphong.Count; i++)
                {
                    for (int j = 1; j < listphong.Count; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        if (listphong[i].tenPhong.Equals(listphong[j].tenPhong))
                        {
                            listphong.RemoveAt(i);
                        }
                    }
                }

                foreach (var item in tpbus.getMaThue(tp.MaThue))
                {
                    bc.tenNV = nvbus.getenNV_ByID(maNVThanhToan);
                    bc.tenKH = dbus.getTen_ById(item.MaDoan);
                    bc.soHD = hdtpbus.gemaHD_BymaThue(tp.MaThue);         //Cần xem xét lại
                    bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                }
                this.Close();
                frmPrint frmp = new frmPrint();
                frmp.InHoaDonInTuReport(bc, listphong.ToList());
                frmp.ShowDialog();

                ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
                HoaDonDichVuBUS hddvbus = new HoaDonDichVuBUS();
                DichVuBUS dvbus = new DichVuBUS();               
                KhachHangBUS khbus = new KhachHangBUS();
                if (ctdvbus.getctdv_byMaThue(tt_ent.MaThue) != null)
                {
                    foreach (var item in ctdvbus.getctdv_byMaThue(tt_ent.MaThue))
                    {
                        if (hddvbus.kiemTraTonTai(item.MaThue,item.MaPhong) == false)
                        {
                            eHoaDonDichVu hddv = new eHoaDonDichVu();
                            hddv.MaHDDV = (DateTime.Now.Day).ToString() + (DateTime.Now.Month).ToString() + (DateTime.Now.Year).ToString() + item.MaThue + item.MaKhach + item.MaPhong;
                            hddv.MaThue = item.MaThue;
                            hddv.MaKH = item.MaKhach;
                            hddv.MaPhong = item.MaPhong;
                            hddv.NgayLap = DateTime.Now.Date;
                            hddv.GioLap = gioHienTai;
                            hddvbus.insertThanhToanDV(hddv);
                            List<eCTDV> lsctdv = new List<eCTDV>();
                            foreach (eChiTetDichVu dv in ctdvbus.getctdv_MaThue_MaPhong(item.MaThue,item.MaPhong))
                            {
                                eCTDV ctdv = new eCTDV();
                                ctdv.TenDV = dvbus.getTenDV_byID(dv.MaDV);
                                ctdv.SoLuong = dv.SoLuong;
                                ctdv.DonGia = dvbus.getDonGia_byID(dv.MaDV);
                                lsctdv.Add(ctdv);
                            }

                            bc.tenNV = nvbus.getenNV_ByID(maNVThanhToan);
                            bc.tenKH = khbus.getenKH_ByID(item.MaKhach);
                            bc.soHD = hddvbus.gemaHD_BymaThue_maPhong(item.MaThue, item.MaPhong);
                            bc.thoiGianInHD = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                            bc.tenPhong = pbus.getTenPhong_ByID(item.MaPhong);

                            frmPrint frmInDV = new frmPrint();
                            frmInDV.InHoaDonInDichVuTuReport(bc, lsctdv.ToList());
                            frmInDV.ShowDialog();
                            this.Close();
                        }
                    }
                }               
            }
        }
    }
}