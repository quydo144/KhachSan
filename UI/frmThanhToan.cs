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
            foreach (var item in tpbus.getMaThuePhong(lblMaThue.Text))
            {
                dtpNhanPhong.Text = item.NgayVao.ToString();
                if (item.NgayRa < DateTime.Now)
                {
                    if (item.NgayRa.DayOfYear == DateTime.Now.DayOfYear)
                    {
                        int gio = item.NgayVao.Hour - DateTime.Now.Hour;;
                    }
                    dtpTraPhong.Text = DateTime.Now.ToString();
                    TimeSpan date = DateTime.Now - item.NgayVao;
                    int s = date.Days + 1;
                    lblGhiChu.Text = "Ghi chú " + s;
                }
                else
                {
                    dtpTraPhong.Text = item.NgayRa.ToString();
                    TimeSpan date = item.NgayRa - item.NgayVao;
                    int s = date.Days + 1;
                    lblGhiChu.Text = "Ghi chú \n\n\n " + dtpNhanPhong.Text + " đến " + dtpTraPhong.Text + " là " + s + " ngày";
                }
            }           
            
        }
    }
}