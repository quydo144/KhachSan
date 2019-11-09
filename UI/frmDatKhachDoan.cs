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
    public partial class frmDatKhachDoan : DevExpress.XtraEditors.XtraForm
    {
        List<eLoaiPhong> lsLP = new List<eLoaiPhong>();
        List<eKhachHang> ls = new List<eKhachHang>();
        int stt = 0;
        public static string CMND = string.Empty;
        public static string TenKH = string.Empty;
        public static string SDT = string.Empty;
        public static string emailNV = string.Empty;

        public frmDatKhachDoan()
        {
            InitializeComponent();
        }

        private void frmDatKhachDoan_Load(object sender, EventArgs e)
        {
            //PhongBUS pbus = new PhongBUS();
            autoCompleteSource();
            LoadPhongTrong();
            lblTongSoPhong.Text = stt.ToString();
        }

        public void autoCompleteSource()
        {
            txtTKcmnd.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTKcmnd.AutoCompleteSource = AutoCompleteSource.CustomSource;
            KhachHangBUS khbus = new KhachHangBUS();
            txtTKcmnd.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in khbus.get())
            {
                txtTKcmnd.AutoCompleteCustomSource.Add(item.SoCMND);
            }
        }

        public void LoadPhongTrong()
        {
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getall())
            {
                eLoaiPhong lp = new eLoaiPhong();
                int s = 0;
                foreach (var p in pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false))
                {
                    s++;
                }
                lp.TenLoaiPhong = item.TenLoaiPhong;
                lp.SoPhongTrong = s;
                lp.SoNguoi = 0;
                lsLP.Add(lp);
            }
            dgvLoaiPhong.DataSource = lsLP.ToList();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmTTKhachHang frm = new frmTTKhachHang();
            frm.ShowDialog();
            txtSDT.Text = SDT;
            txtTenDoan.Text = TenKH;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //eThuePhong tp = new eThuePhong();
            //ThuePhongBUS tpbus = new ThuePhongBUS();
            //PhongBUS pbus = new PhongBUS();
            //LoaiPhongBUS lpbus = new LoaiPhongBUS();
            //NhanVienBUS nvbus = new NhanVienBUS();
            //KhachHangBUS khbus = new KhachHangBUS();
            //tp.MaPhong = pbus.maPhong_byTen(TenPhong);
            //tp.MaKH = khbus.gemaKH_ByCMND(txtCMND.Text.Trim());
            //tp.NgayVao = DateTime.Now.Date;
            //tp.NgayRa = Convert.ToDateTime(dtmNgayRa.Text);
            //tp.MaNV = nvbus.getmaNV_byEmail(emailNV);
            //tp.TrangThai = 0;
            //TimeSpan gioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            //tp.GioVao = gioVao;
            //TimeSpan gioRa = new TimeSpan(14, 00, 00);
            //tp.GioRa = gioRa;
            //int a = tpbus.insertThuePhong(tp);
            //if (a == 1)
            //{
            //    //Đổi tình trạng phòng thành phòng có khách khi đặt phòng thành công
            //    ePhong p = new ePhong();
            //    p.MaPhong = pbus.maPhong_byTen(TenPhong);
            //    p.TinhTrang = true;
            //    pbus.updateTinhTrangPhong(p);
            //    MessageBox.Show("Đặt phòng thành công");
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Không thành công");
            //    return;
            //}
        }

        private void btnKhToView_Click(object sender, EventArgs e)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            foreach (var item in khbus.getcmnd(txtTKcmnd.Text))
            {
                eKhachHang kh = new eKhachHang();
                kh = item;
                ls.Add(kh);
            }
            dgvDsKH.DataSource = ls.ToList();
        }

    }
}