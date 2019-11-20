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
    public partial class frmDatKhachDoan : DevExpress.XtraEditors.XtraForm
    {
        frmHome frm;
        List<eKhachHang> ls = new List<eKhachHang>();
        public static string CMND = string.Empty;
        public static string TenKH = string.Empty;
        public static string SDT = string.Empty;
        public static string emailNV = string.Empty;

        public frmDatKhachDoan()
        {
            InitializeComponent();
        }

        public frmDatKhachDoan(frmHome sql)
        {
            InitializeComponent();
            frm = sql;
        }

        private void frmDatKhachDoan_Load(object sender, EventArgs e)
        {         
            LoadPhongTrong();
            autoCompleteSourceCMND();
        }

        public void autoCompleteSourceCMND()
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
            int sl = 0;
            DataTable dt = new DataTable();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            dt.Columns.Add("Tên loại phòng", typeof(string));
            dt.Columns.Add("Giá phòng", typeof(double));
            dt.Columns.Add("Số phòng trống", typeof(int));
            dt.Columns.Add("Số lượng phòng", typeof(int));
            foreach (var item in lpbus.getall())
            {
                int s = 0;
                foreach (var p in pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false))
                {
                    s++;
                }
                dt.Rows.Add(item.TenLoaiPhong, item.DonGia, s, sl);               
            }
            dgvLoaiPhong.DataSource = dt;

        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmTextKhachHang frm = new frmTextKhachHang();
            frm.ShowDialog();           
        }

        private void btnKhToView_Click(object sender, EventArgs e)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            foreach (var khachhang in khbus.getcmnd(txtTKcmnd.Text))
            {
                eKhachHang kh = new eKhachHang();
                kh = khachhang;
                ls.Add(kh);
            }
            for (int i = 0; i < ls.Count - 1; i++)
            {
                if (ls.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < ls.Count; j++)
                {
                    if (ls[i].MaKH.Equals(ls[j].MaKH))
                    {
                        ls.RemoveAt(i);
                    }
                }
            }
            dgvDsKH.DataSource = ls.ToList();
        }

        private void txtTKcmnd_Enter(object sender, EventArgs e)
        {
            txtTKcmnd.Clear();
        }

        public void auToloadKhachHanhToDSPhong()
        {
            ArrayList dsTenPhong = new ArrayList();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
                {
                    dsTenPhong.Add(item.TenPhong);
                }
            }
            for (int i = 0; i < dsTenPhong.Count; i++)
            {
                if (dsTenPhong.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < dsTenPhong.Count; j++)
                {
                    if (dsTenPhong[i].Equals(dsTenPhong[j]))
                    {
                        dsTenPhong.RemoveAt(i);
                    }
                }
            }
            int s = 0;
            for (int i = s; i < dsTenPhong.Count; i++)
            {
                int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
                for (int j = 0; j < soNguoiToiDa; j++)
                {
                    gridViewDsKH.SetRowCellValue(s, gridViewDsKH.Columns[3], dsTenPhong[i]);
                    s++;

                }
            }
            cboPhong.DataSource = dsTenPhong;

        }

        private void btnAddKhAutoPhong_Click(object sender, EventArgs e)
        {
            auToloadKhachHanhToDSPhong();
        }

        private void cboPhong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ArrayList dsTenPhong = new ArrayList();
            ArrayList dsPhongO = new ArrayList();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
                {
                    dsTenPhong.Add(item.TenPhong);
                }
            }
            for (int i = 0; i < dsTenPhong.Count; i++)
            {
                if (dsTenPhong.Count == 1)
                {
                    break;
                }
                for (int j = i + 1; j < dsTenPhong.Count; j++)
                {
                    if (dsTenPhong[i].Equals(dsTenPhong[j]))
                    {
                        dsTenPhong.RemoveAt(i);
                    }
                }
            }
            cboPhong.DataSource = dsTenPhong;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            ThuePhongBUS tpbus = new ThuePhongBUS();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            eThuePhong tp = new eThuePhong();
            NhanVienBUS nvbus = new NhanVienBUS();
            DoanBUS dbus = new DoanBUS();
            //Tao Doan
            eDoan doan = new eDoan();
            doan.DiaChi = txtDiaChi.Text.Trim();
            doan.MaTruongDoan = txtTruongDoan.Text.Trim();
            doan.TenDoan = txtTenDoan.Text.Trim();
            doan.Sdt = txtSdtDoan.Text.Trim();
            if (dbus.getdoan_sdt(txtSdtDoan.Text.Trim()) == null)
            {
                int kqTaoDoan = dbus.insertDoan(doan);
            }
            tp.MaNV = nvbus.getmaNV_byEmail(emailNV);
            tp.MaDoan = dbus.getId_ByTenDoan(txtTenDoan.Text.Trim()); //ma doan
            int soLuongP = 0;
            for (int i = 0; i < gridViewLoaiPhong.RowCount ; i++)
            {
                soLuongP += Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]));
            }

            tp.SoLuongPhong = soLuongP;
            tp.TrangThai = false;
            TimeSpan gioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            TimeSpan gioRa = new TimeSpan(14, 00, 00);
            int a = tpbus.insertThuePhong(tp);
            eChiTietThuePhong cttp = new eChiTietThuePhong();
            if (a == 1)
            {
                ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
                foreach (eKhachHang item in ls)
                {
                    cttp.MaThue = tpbus.getMaThueCuoi();
                    cttp.MaKhach = item.MaKH;
                    cttp.MaPhong = pbus.maPhong_byTen(item.SoPhong);
                    cttp.NgayRa = Convert.ToDateTime(dtmNgayRa.Text).Date;
                    cttp.NgayVao = DateTime.Now.Date;
                    cttp.GioRa = gioRa;
                    cttp.GioVao = gioVao;
                    cttp.TrangThai = false;
                    cttpbus.insertCTTP(cttp);
                    ePhong p = new ePhong();
                    p.MaPhong = pbus.maPhong_byTen(item.SoPhong);
                    p.TinhTrang = true;
                    int soPhong = 0;
                    foreach (var kh in ls)
                    {
                        if (kh.SoPhong.Equals(item.SoPhong))
                        {
                            soPhong++;
                        }
                    }
                    p.SoNgHienTai = soPhong;
                    pbus.updateTinhTrangPhong(p);
                }
                MessageBox.Show("Đặt phòng thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thành công");
                return;
            }
        }

        private void gridViewLoaiPhong_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[2])) < Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3])))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng phòng " + gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString() + " lớn hơn yêu cầu");
                    return;
                }
            }
        }

        /*private void btnAddCoSanPhong_Click(object sender, EventArgs e)
        {
            //ArrayList dsTenPhong = new ArrayList();
            //ArrayList dsPhongO = new ArrayList();
            //PhongBUS pbus = new PhongBUS();
            //LoaiPhongBUS lpbus = new LoaiPhongBUS();
            //for (int i = 0; i < gridViewLoaiPhong.RowCount; i++)
            //{
            //    foreach (var item in pbus.getLoaiPhong_Trong_soLuong(lpbus.getma_ByTen(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[0]).ToString()), false, Convert.ToInt32(gridViewLoaiPhong.GetRowCellValue(i, gridViewLoaiPhong.Columns[3]))))
            //    {
            //        dsTenPhong.Add(item.TenPhong);
            //    }
            //}
            //for (int i = 0; i < dsTenPhong.Count; i++)
            //{
            //    if (dsTenPhong.Count == 1)
            //    {
            //        break;
            //    }
            //    for (int j = i + 1; j < dsTenPhong.Count; j++)
            //    {
            //        if (dsTenPhong[i].Equals(dsTenPhong[j]))
            //        {
            //            dsTenPhong.RemoveAt(i);
            //        }
            //    }
            //}

            //for (int a = 0; a < gridViewDsKH.RowCount; a++) 
            //{
            //    eKhachHang kh = new eKhachHang();
            //    kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //    int x = 0;
            //    if (kh.SoPhong == null)
            //    {
            //        continue;
            //    }
            //    for (int i = 0; i < dsTenPhong.Count; i++)
            //    {
            //        if (kh.SoPhong.Equals(dsTenPhong[i]))
            //        {
            //            dsTenPhong.RemoveAt(i);
            //            x--;
            //        }
            //    }
            //    x++;
            //}

            //int y = 0;
            //for (int a = y; a < gridViewDsKH.RowCount; a++)
            //{
            //    eKhachHang kh = new eKhachHang();
            //    kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //    for (int i = 0; i < dsTenPhong.Count; i++)
            //    {
            //        int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
            //        for (int j = 0; j < soNguoiToiDa; j++)
            //        {
            //            if (kh.SoPhong != null)
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                gridViewDsKH.SetRowCellValue(a, gridViewDsKH.Columns[3], dsTenPhong[i]);                   
            //            }
            //        }
            //        y++;
            //    }
            //}

            //for (int i = 0; i < dsTenPhong.Count; i++)
            //{
            //    for (int a = y; a < gridViewDsKH.RowCount; a++)
            //    {
            //        eKhachHang kh = new eKhachHang();
            //        kh = (eKhachHang)(gridViewDsKH.GetRow(a));
            //        int soNguoiToiDa = lpbus.getsoNguoi_ByID(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(dsTenPhong[i].ToString())));
            //        for (int j = 0; j < soNguoiToiDa; j++)
            //        {
            //            if (kh.SoPhong != null)
            //            {
            //                continue;
            //            }
            //            else
            //            {
            //                gridViewDsKH.SetRowCellValue(a, gridViewDsKH.Columns[3], dsTenPhong[i]);
            //            }
            //        }
            //        y++;
            //    }
            //}
            //cboPhong.DataSource = dsTenPhong;
        }*/

        private void dtmNgayRa_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan date = dtmNgayRa.Value - DateTime.Now.Date;
            if (date.Days < 0)
            {
                MessageBox.Show("Nhập ngày lớn hơn ngày hiện tại");
                dtmNgayRa.Focus();
                return;
            }
        }

        private void frmDatKhachDoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            frm.AnflowLayoutPanel();
            frm.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        private void btnTimDoan_Click(object sender, EventArgs e)
        {
            DoanBUS dbus = new DoanBUS();          
            eDoan doan = new eDoan();
            doan = dbus.getdoan_sdt(txtSdtDoan.Text.Trim());
            txtTenDoan.Text = doan.TenDoan;
            txtDiaChi.Text = doan.DiaChi;
            txtTruongDoan.Text = doan.MaTruongDoan;
        }
    }
}