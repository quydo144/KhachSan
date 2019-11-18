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
        public frmTraKhachDoan()
        {
            InitializeComponent();
        }

        public frmTraKhachDoan(frmHome sql)
        {
            InitializeComponent();
            form = sql;
        }

        private void frmTraKhachDoan_Load(object sender, EventArgs e)
        {
            autoCompleteSource();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmDoan frm = new frmDoan();
            frm.ShowDialog();
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
            List<eThuePhong_Doan> lstp_d = new List<eThuePhong_Doan>(); 
            foreach (eChiTietThuePhong item in list_ect)
            {
                eThuePhong_Doan etpd = new eThuePhong_Doan();
                eHoaDonTienPhong hdtp = new eHoaDonTienPhong();
                eHoaDonDichVu hddv = new eHoaDonDichVu();
                double tienPhong = Convert.ToDouble(hdtp.tinhTienPhong(item, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(item.GioVao + "   " + item.NgayVao.ToShortDateString()), Convert.ToDateTime(DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString())));
                double tienPhuThu = Convert.ToDouble(hdtp.tinhTienPhuThu(list_ect, lpbus.donGia(pbus.getLoaiPhong_ByID(item.MaPhong))));
                etpd.Tenphong = pbus.getTenPhong_ByID(item.MaPhong);
                etpd.TienPhong = tienPhong + tienPhuThu;
                double tienDV = 0;
                foreach (eChiTetDichVu ctdv in ctdvbus.getctdv_MaThue_MaPhong(item.MaThue,item.MaPhong))
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
            txtTongTienPhong.Text = tongTienPhong.ToString();
            txtThueVAT.Text = "10%";
            txtKhuyenMai.Text = "20%";
            txtTienThanhToan.Text = (tongTienPhong + tongTienPhong * 0.1 - tongTienPhong * 0.2).ToString();
        }

        private void txtTenDoan_TextChanged(object sender, EventArgs e)
        {
            DoanBUS dbus = new DoanBUS();
            txtTruongDoan.Text = dbus.getTD_ByTenDoan(txtTenDoan.Text.Trim());
        }

        private void frmTraKhachDoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            form.cleanGiaoDien();
            form.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadThuePhong_Doan();
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            txtTienThua.Text = (Convert.ToDouble(txtTienThanhToan.Text) - Convert.ToDouble(txtTienKhachDua.Text)).ToString();
        }
    }
}