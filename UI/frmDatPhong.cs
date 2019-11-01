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
        eSuDungDichVu sddv;
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
        public static string maNV = string.Empty;
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
            autoCompleteSource();
            lblTenPhong.Text = TenPhong;
            lblLoaiPhong.Text = TenLoaiPhong;
        }

        private void autoCompleteSource()
        {
            txtSeachKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSeachKH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            KhachHangBUS khbus = new KhachHangBUS();
            txtSeachKH.AutoCompleteCustomSource.Clear();
            foreach (eKhachHang item in khbus.get())
            {
                txtSeachKH.AutoCompleteCustomSource.Add(item.SoCMND);
            }
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
            eDichVu dvtemp = new eDichVu(maDV, tenDV, Convert.ToDecimal(donGia), Convert.ToInt32(soLuongDV));
            mangDichVu.Add(dvtemp);
            eCTDV dv = new eCTDV();
            dv.MaDV = maDV;
            dv.TenDV = tenDV;
            dv.DonGia = Convert.ToDecimal(donGia);
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

        string tangMaSDDV()
        {
            string maSuDungDichVu;
            sddvbus = new SuDungDichVuBUS();
            sddv = new eSuDungDichVu();
            sddv = sddvbus.tangma();
            if (Convert.ToInt32(sddv.MaSDDV.Substring(3, 7)) < 10000000 && Convert.ToInt32(sddv.MaSDDV.Substring(3, 7)) >= 1000000)
            {
                maSuDungDichVu = "PDV" + (Convert.ToInt32(sddv.MaSDDV.Substring(3, 7)) + 1).ToString();
            }
            else if (Convert.ToInt32(sddv.MaSDDV.Substring(4, 6)) < 1000000 && Convert.ToInt32(sddv.MaSDDV.Substring(4, 6)) >= 100000)
            {
                maSuDungDichVu = "PDV0" + (Convert.ToInt32(sddv.MaSDDV.Substring(4, 6)) + 1).ToString();
            }
            else if (Convert.ToInt32(sddv.MaSDDV.Substring(5, 5)) < 100000 && Convert.ToInt32(sddv.MaSDDV.Substring(5, 5)) >= 10000)
            {
                maSuDungDichVu = "PDV00" + (Convert.ToInt32(sddv.MaSDDV.Substring(5, 5)) + 1).ToString();
            }
            else if (Convert.ToInt32(sddv.MaSDDV.Substring(6, 4)) < 10000 && Convert.ToInt32(sddv.MaSDDV.Substring(6, 4)) >= 1000)
            {
                maSuDungDichVu = "PDV000" + (Convert.ToInt32(sddv.MaSDDV.Substring(6, 4)) + 1).ToString();
            }
            else if (Convert.ToInt32(sddv.MaSDDV.Substring(7, 3)) < 1000 && Convert.ToInt32(sddv.MaSDDV.Substring(7, 3)) >= 100)
            {
                maSuDungDichVu = "PDV0000" + (Convert.ToInt32(sddv.MaSDDV.Substring(7, 2)) + 1).ToString();
            }
            else if (Convert.ToInt32(sddv.MaSDDV.Substring(8, 2)) < 100 && Convert.ToInt32(sddv.MaSDDV.Substring(8, 2)) >= 10)
            {
                maSuDungDichVu = "PDV00000" + (Convert.ToInt32(sddv.MaSDDV.Substring(8, 2)) + 1).ToString();
            }
            else
            {
                maSuDungDichVu = "PDV000000" + (Convert.ToInt32(sddv.MaSDDV.Substring(9, 1)) + 1).ToString();
            }
            return maSuDungDichVu;
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
            frmTTKhachHang frm = new frmTTKhachHang();
            frm.ShowDialog();
            txtSeachKH.Text = CMND;
        }

        private void txtSeachKH_TextChanged(object sender, EventArgs e)
        {
            string s = txtSeachKH.Text;
            lskh = khbus.getcmnd(s);
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

        string maThuePhong()
        {
            string maDatPhong;
            tp = new eThuePhong();
            tp = tpbus.tangma();
            if (Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) < 10000000 && Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) > 1000000)
            {
                maDatPhong = "TP" + (Convert.ToInt32(tp.MaThuePhong.Substring(2, 7)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) < 1000000 && Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) > 100000)
            {
                maDatPhong = "TP0" + (Convert.ToInt32(tp.MaThuePhong.Substring(3, 6)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) < 100000 && Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) > 10000)
            {
                maDatPhong = "TP00" + (Convert.ToInt32(tp.MaThuePhong.Substring(4, 5)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) < 10000 && Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) > 1000)
            {
                maDatPhong = "TP000" + (Convert.ToInt32(tp.MaThuePhong.Substring(5, 4)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) < 1000 && Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) > 100)
            {
                maDatPhong = "TP0000" + (Convert.ToInt32(tp.MaThuePhong.Substring(6, 3)) + 1).ToString();
            }
            else if (Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) < 100 && Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) > 10)
            {
                maDatPhong = "TP00000" + (Convert.ToInt32(tp.MaThuePhong.Substring(7, 2)) + 1).ToString();
            }
            else
            {
                maDatPhong = "TP000000" + (Convert.ToInt32(tp.MaThuePhong.Substring(8, 1)) + 1).ToString();
            }
            return maDatPhong;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thêm mã thuê phòng
            eThuePhong tp = new eThuePhong();
            PhongBUS pbus = new PhongBUS();
            tp.MaPhong = pbus.maPhong(TenPhong);
            tp.MaThuePhong = maThuePhong();
            tp.MaKH = maKH;
            tp.NgayVao = DateTime.Now.Date;
            tp.NgayRa = Convert.ToDateTime(dtmNgayRa.Text);
            tp.MaNV = maNV;
            tp.TrangThai = 0;
            TimeSpan gioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            tp.GioVao = gioVao;
            TimeSpan gioRa = new TimeSpan(12, 00, 00);
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
                    sddv.MaThue = tp.MaThuePhong;
                    sddv.MaSDDV = tangMaSDDV();
                    sddv.MaDV = gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString();
                    sddv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());

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

                    sddv.NgaySD = DateTime.Now.Date;
                    sddv.GioSD = gioVao;
                    int s = sddvbus.InsertSDDV(sddv);
                }
            }
            maThue = maThuePhong();
        }

        private void dtmNgayRa_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan date = dtmNgayRa.Value - DateTime.Now.Date;
            if (date.Days <= 0)
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