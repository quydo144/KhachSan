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
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        frmHome frmHome;
        public static string MaThue = string.Empty;
        public static string TenPhong = string.Empty;
        public static string LoaiPhong = string.Empty;
        SuDungDichVuBUS sddvbus = new SuDungDichVuBUS();
        KhachHangBUS khbus = new KhachHangBUS();
        ThuePhongBUS tpbus = new ThuePhongBUS();

        public frmThanhToan()
        {
            InitializeComponent();
        }

        public frmThanhToan(frmHome sql)
        {
            InitializeComponent();
            frmHome = sql;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblMaThue.Text = MaThue;
            lblLoaiPhong.Text = LoaiPhong;
            lblTenPhong.Text = TenPhong;
            loadKhachHang();
            tinhTienPhong();
            load_list_dichvu();
            tienPhuThu();
        }

        public DataTable DataTable_DSDV(List<eSuDungDichVu> ds)
        {
            string tienDichVu;
            DichVuBUS dvbus = new DichVuBUS();
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên dịch vụ", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Đơn giá", typeof(double));
            dt.Columns.Add("Thành tiền", typeof(double));
            foreach (eSuDungDichVu sddv in ds)
            {
                tienDichVu = (sddv.SoLuong * dvbus.getDonGia_byID(sddv.MaDV)).ToString();
                dt.Rows.Add(dvbus.getTenDV_byID(sddv.MaDV), sddv.SoLuong, dvbus.getDonGia_byID(sddv.MaDV), tienDichVu);
                txtDichVu.Text = tienDichVu;
            }
            return dt;
        }

        public void load_list_dichvu()
        {
            SuDungDichVuBUS sddvbus = new SuDungDichVuBUS();
            dgvCTDV.DataSource = DataTable_DSDV(sddvbus.getctdv(MaThue.Trim()));
        }

        public void loadKhachHang()
        {
            foreach (var item in tpbus.getMaThuePhong(lblMaThue.Text))
            {
                foreach (var kh in khbus.getmaKH(item.MaKH))
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
            //foreach (var item in lpbus.getall())
            //{
            //    if (item.MaLoaiPhong.Trim().Equals(maLoaiPhong))
            //    {
            //        tienPhong = item.DonGia;
            //    }
            //}
            return tienPhong;
        }

        public void tinhTienPhong()
        {
            TimeSpan nhan13h = new TimeSpan(13, 00, 00);
            TimeSpan nhan14h = new TimeSpan(14, 00, 00);
            PhongBUS pbus = new PhongBUS();
            eThanhToan tt = new eThanhToan();
            foreach (var item in tpbus.getMaThuePhong(lblMaThue.Text))
            {
                lblNhanPhong.Text = item.GioVao + "   " + item.NgayVao.ToShortDateString();
                string gioMacDinh = nhan14h + "  " + item.NgayVao.ToShortDateString();
                lblTraPhong.Text = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                TimeSpan date = Convert.ToDateTime(lblTraPhong.Text) - Convert.ToDateTime(lblNhanPhong.Text);
                int ngay = date.Days;
                int h = date.Hours;
                int m = date.Minutes;
                lblGhiChu.Text = "\nThời gian sử dụng phòng là: " + ngay + " ngày " + h + " giờ " + m + " phút ";
                if (item.GioVao < nhan13h)
                {
                    txtTienPhong.Text = (tt.tinhTienPhong(item, tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(gioMacDinh), Convert.ToDateTime(lblTraPhong.Text))).ToString();
                }
                else
                {
                    txtTienPhong.Text = (tt.tinhTienPhong(item, tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)), Convert.ToDateTime(lblNhanPhong.Text), Convert.ToDateTime(lblTraPhong.Text))).ToString();
                }
            }
        }

        public void tienPhuThu()
        {
            double tienphong = 0;
            ThuePhongBUS tpbus = new ThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            eThanhToan tt = new eThanhToan();
            List<eThuePhong> ls = new List<eThuePhong>();
            ls = tpbus.getMaThuePhong(MaThue.Trim());
            foreach (var item in ls)
            {
                tienphong = tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong));
            }
            double tienPhuThu = tt.tinhTienPhuThu(ls, tienphong);
            txtPhuThu.Text = tienPhuThu.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            TimeSpan gioHienTai = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            ThanhToanBUS ttbus = new ThanhToanBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            eThanhToan tt_ent = new eThanhToan();
            tt_ent.MaThuePhong = lblMaThue.Text.Trim();
            tt_ent.NgayLap = DateTime.Now;
            tt_ent.GioLap = gioHienTai;
            tt_ent.ThueVAT = Convert.ToSingle(10/100);
            tt_ent.GiamGia = Convert.ToSingle(txtGiamTru.Text);
            int a = ttbus.insertThanhToan(tt_ent);
            if (a == 1)
            {
                //Update lại trạng thái phòng
                PhongBUS pbus = new PhongBUS();
                ePhong phong = new ePhong();
                phong.MaPhong = tpbus.getMaPhong_ByMaThueTrangThai(tt_ent.MaThuePhong, 0);
                phong.TinhTrang = false;
                pbus.updateTinhTrangPhong(phong);

                //update lại thông tin thuê phòng
                eThuePhong tp = new eThuePhong();
                tp.MaThuePhong = tt_ent.MaThuePhong;
                tp.NgayRa = DateTime.Now.Date;
                tp.TrangThai = 1;
                tp.GioRa = gioHienTai;
                tpbus.updateThuePhong(tp);

                MessageBox.Show("Đã thanh toán thành công");
                this.Close();
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
        }

        private void frmThanhToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            frmHome.textPhongCoKhach(joinbus.GetPhong_ThuePhong(true, 0));
            //frmHome.loadphong(pbus.getallp());
        }
    }
}