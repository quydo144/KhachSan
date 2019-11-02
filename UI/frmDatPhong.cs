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
using System.Collections;
using Entyti;
using BUS;

namespace Home
{
    public partial class frmDatPhong : DevExpress.XtraEditors.XtraForm
    {

        frmHome frmHome;
        string maKH;
        List<eCTDV> ls = new List<eCTDV>();
        List<eKhachHang> lskh;
        List<eSuDungDichVu> lssddv = new List<eSuDungDichVu>();
        eThuePhong tp;
        SuDungDichVuBUS sddvbus = new SuDungDichVuBUS();
        ThuePhongBUS tpbus = new ThuePhongBUS();
        DichVuBUS dvbus = new DichVuBUS();
        KhachHangBUS khbus = new KhachHangBUS();
        ArrayList mangDichVu = new ArrayList();

        public static string TenPhong = string.Empty;
        public static string TenLoaiPhong = string.Empty;
        public static string CMND = string.Empty;
        public static string TenKH = string.Empty;
        public static string SDT = string.Empty;
        public static string GioiTinh = string.Empty;
        public static string emailNV = string.Empty;
        public static string maThue = string.Empty;

        public frmDatPhong()
        {
            InitializeComponent();
        }

        public frmDatPhong(frmHome sql)
        {
            InitializeComponent();
            frmHome = sql;
        }

        private void btnLuu_MouseHover(object sender, EventArgs e)
        {
            btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(217)))), ((int)(((byte)(89)))));
        }

        private void btnLuu_MouseLeave(object sender, EventArgs e)
        {
            btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(210)))), ((int)(((byte)(242)))));
        }

        private void btnThoat_MouseHover(object sender, EventArgs e)
        {
            btnThoat.BackColor = Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(217)))), ((int)(((byte)(89)))));
        }

        private void frmDatPhong_Load(object sender, EventArgs e)
        {
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            dgvDichVu.DataSource = dvbus.getalldv();
            lblTenPhong.Text = TenPhong;
            lblLoaiPhong.Text = TenLoaiPhong;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 31; i++)
            {
                cboSL.Items.Add(i);
            }
            string maDV = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[0]).ToString();
            string tenDV = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[1]).ToString();
            string donGia = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[2]).ToString();
            string soLuongDV = gridViewDV.GetRowCellValue(gridViewDV.FocusedRowHandle, gridViewDV.Columns[4]).ToString();
            eDichVu dvtemp = new eDichVu(maDV, tenDV, Convert.ToDouble(donGia), Convert.ToInt32(soLuongDV));
            mangDichVu.Add(dvtemp);
            eCTDV dv = new eCTDV();
            dv.MaDV = maDV;
            dv.TenDV = tenDV;
            dv.DonGia = Convert.ToDouble(donGia);
            dv.SoLuong = 1;
            foreach (var item in ls.ToList())
            {
                if (item.TenDV.Equals(tenDV))
                {
                    ls.Remove(item);
                }
            }
            ls.Add(dv);
            int index = gridViewDV.FocusedRowHandle;
            gridViewDV.DeleteRow(index);
            dgvCTDV.DataSource = ls.ToList();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = gridViewCTDV.FocusedRowHandle;
            ls.RemoveAt(index);
            gridViewCTDV.DeleteRow(index);
        }

        private void txtSeachDV_TextChanged(object sender, EventArgs e)
        {
            if (txtSeachDV.Text == "")
            {
                dgvDichVu.DataSource = dvbus.getalldv();
            }
            else
            {
                dgvDichVu.DataSource = dvbus.getallTenDV(txtSeachDV.Text);
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            lskh = new List<eKhachHang>();
            string s = txtSeachKH.Text.Trim();
            lskh = khbus.getcmnd(s);
            if (lskh.Count == 0)
            {
                DialogResult ds = MessageBox.Show("Không có khách hàng. Hãy nhập thông tin khách hàng", "Thêm khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ds == DialogResult.OK)
                {
                    frmTTKhachHang frm = new frmTTKhachHang();
                    frm.ShowDialog();
                    txtCMND.Text = CMND;
                    txtSDT.Text = SDT;
                    txtHT.Text = TenKH;
                    if (GioiTinh.Equals("Nam"))
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                }
            }
            else
            {
                foreach (var item in lskh)
                {
                    maKH = item.MaKH;
                    txtHT.Text = item.TenKH;
                    txtCMND.Text = item.SoCMND;
                    txtSDT.Text = item.SoDT;
                    if (item.GioiTinh)
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thêm mã thuê phòng
            eThuePhong tp = new eThuePhong();
            PhongBUS pbus = new PhongBUS();
            NhanVienBUS nvbus = new NhanVienBUS();
            tp.MaPhong = pbus.maPhong(TenPhong);
            tp.MaKH = maKH;
            tp.NgayVao = DateTime.Now.Date;
            tp.NgayRa = Convert.ToDateTime(dtmNgayRa.Text);
            tp.MaNV = nvbus.getmaNV_byEmail(emailNV);
            tp.TrangThai = 0;
            TimeSpan gioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            tp.GioVao = gioVao;
            TimeSpan gioRa = new TimeSpan(14, 00, 00);
            tp.GioRa = gioRa;
            int a = tpbus.insertThuePhong(tp);
            if (a == 1)
            {
                //Đổi tình trạng phòng
                ePhong p = new ePhong();
                p.MaPhong = pbus.maPhong(TenPhong);
                p.TinhTrang = true;
                pbus.updateTinhTrangPhong(p);
                MessageBox.Show("Đặt phòng thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
            }

            DichVuBUS dvbus = new DichVuBUS();
            eDichVu dv = new eDichVu();

            //Thêm chi tiết dịch vụ
            if (gridViewCTDV.RowCount > 0)
            {
                eSuDungDichVu sddv = new eSuDungDichVu();
                for (int i = 0; i < gridViewCTDV.RowCount; i++)
                {
                    sddv.MaThue = tpbus.getMaThue_ByMaPhongTrangThai(tp.MaPhong, 0);
                    sddv.MaDV = gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString();
                    sddv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());
                    sddv.NgaySD = DateTime.Now.Date;
                    sddv.GioSD = gioVao;
                    int s = sddvbus.InsertSDDV(sddv);
                    foreach (eDichVu item in mangDichVu)
                    {
                        //Cập nhật số lượng trong bảng dịch vụ
                        if (gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString() == item.MaDV)
                        {
                            dv.MaDV = item.MaDV;
                            dv.TenDV = item.TenDV;
                            dv.DonGia = item.DonGia;
                            dv.SoLuong = (item.SoLuong - Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])));
                            dvbus.SuaDV(dv);
                        }
                    }
                }
            }
        }

        private void dtmNgayRa_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan date = dtmNgayRa.Value - DateTime.Now.Date;
            if (date.Days < 0)
            {
                MessageBox.Show("Nhập ngày lớn hơn ngày hiện tại");
                dtmNgayRa.Focus();
            }
        }

        private void frmDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            frmHome.textPhong(joinbus.GetPhong_ThuePhong(true, 0));
        }

        private void gridViewCTDV_Click(object sender, EventArgs e)
        {
            eDichVu dv = new eDichVu();
            for (int i = 0; i < gridViewCTDV.RowCount; i++)
            {
                foreach (eDichVu item in mangDichVu)
                {
                    if (gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString() == item.MaDV && item.SoLuong < Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng dịch vụ " +item.TenDV+  " đã hết");
                    }
                }
            }
        }
    }
}