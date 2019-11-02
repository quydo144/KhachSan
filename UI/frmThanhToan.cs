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
        int ngay = 0;
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

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblMaThue.Text = MaThue;
            lblLoaiPhong.Text = LoaiPhong;
            lblTenPhong.Text = TenPhong;
            loadKhachHang();
            thoiGianThuePhong();
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
                dt.Rows.Add(dvbus.getTenDV_byID(sddv.MaDV), sddv.SoLuong, dvbus.getDonGia_byID(sddv.MaDV), sddv.SoLuong * dvbus.getDonGia_byID(sddv.MaDV));
                tienDichVu = (sddv.SoLuong * dvbus.getDonGia_byID(sddv.MaDV)).ToString();
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

        public void thoiGianThuePhong()
        {
            PhongBUS pbus = new PhongBUS();
            foreach (var item in tpbus.getMaThuePhong(lblMaThue.Text))
            {
                lblNhanPhong.Text = item.GioVao +"   "+ item.NgayVao.ToShortDateString();
                if (item.NgayRa > DateTime.Now)         //Trả phòng trước dự tính
                {
                    lblTraPhong.Text = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                    TimeSpan date = Convert.ToDateTime(lblTraPhong.Text) - Convert.ToDateTime(lblNhanPhong.Text);
                    int ngay = date.Days;
                    int h = date.Hours;
                    int m = date.Minutes;
                    lblGhiChu.Text = "\n\nThời gian sử dụng phòng là: " + ngay + " ngày " + h + " giờ " + m + " phút ";
                    if (ngay  == 0 &&  m > 0 && m < 59)
                    {
                        txtTienPhong.Text = (0.2 * Convert.ToDouble(tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)))).ToString();
                    }
                    if (ngay == 0 && h == 1 && m > 0 && m < 59)
                    {
                        txtTienPhong.Text = (0.3 * Convert.ToDouble(tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)))).ToString();
                    }
                    //txtTienPhong.Text = (ngay * tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong))).ToString();
                }
                if (item.NgayRa == DateTime.Now)
                {
                    lblTraPhong.Text = DateTime.Now.ToLongTimeString() + "   " + DateTime.Now.ToShortDateString();
                    TimeSpan date = Convert.ToDateTime(lblTraPhong.Text) - Convert.ToDateTime(lblNhanPhong.Text);
                    int s = date.Days + 1;
                    lblGhiChu.Text = "\n " + lblNhanPhong.Text + " đến " + lblTraPhong.Text + " là " + s + " ngày";
                }
                //else
                //{
                //    dtpTraPhong.Text = item.NgayRa.ToString();
                //    TimeSpan date = item.NgayRa - item.NgayVao;
                //    int s = date.Days + 1;
                //    lblGhiChu.Text = "\n\n " + dtpNhanPhong.Text + " đến " + dtpTraPhong.Text + " là " + s + " ngày";
                //}
            }                     
        }

        public double tienPhong(string maLoaiPhong)
        {
            double tienPhong = 0;
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getall())
            {
                if (item.MaLoaiPhong.Trim().Equals(maLoaiPhong))
                {
                    tienPhong = item.DonGia;
                }
            }
            return tienPhong;           
        }



        public void tienPhuThu()    //nhận phòng sớm
        {
            TimeSpan nhan13h = new TimeSpan(13, 00, 00);
            TimeSpan nhan11h = new TimeSpan(11, 00, 00);
            TimeSpan nhan8h = new TimeSpan(8, 00, 00);
            TimeSpan nhan6h = new TimeSpan(6, 00, 00);
            ThuePhongBUS tpbus = new ThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            foreach (var item in tpbus.getMaThuePhong(MaThue.Trim()))
            {
                if (item.GioVao <= nhan13h && item.GioVao > nhan11h)
                {
                    txtPhuThu.Text = (0.3 * Convert.ToDouble(tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)))).ToString();
                }
                else if (item.GioVao <= nhan11h && item.GioVao > nhan8h)
                {
                    txtPhuThu.Text = (0.5 * Convert.ToDouble(tienPhong(pbus.getLoaiPhong_ByID(item.MaPhong)))).ToString();
                }
                else if (item.GioVao < nhan6h)
                {
                    txtPhuThu.Text = "0";
                    ngay++;
                }
                else if (item.GioVao >= nhan13h)
                {
                    txtPhuThu.Text = "0";
                }
            }
        }
    }
}