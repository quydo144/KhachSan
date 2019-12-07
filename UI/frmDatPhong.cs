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
        ThuePhongBUS tpbus = new ThuePhongBUS();
        DichVuBUS dvbus = new DichVuBUS();
        KhachHangBUS khbus = new KhachHangBUS();
        ArrayList mangDichVu = new ArrayList();
        int kieuForm;

        //Truyền dữ liệu từ form này sáng form khác
        public static string TenPhong = string.Empty;
        public static string TenLoaiPhong = string.Empty;
        public static string CMND = string.Empty;
        public static string TenKH = string.Empty;
        public static string SDT = string.Empty;
        public static string GioiTinh = string.Empty;
        public static string emailNV = string.Empty;
        public static string maThue = string.Empty;
        public static string maKhachHang = string.Empty;

        public frmDatPhong()
        {
            InitializeComponent();
        }

        /**Kiểu Form
        1: là form đặt phòng
        2: là form cập nhật dịch vụ**/
        //Form 1
        public frmDatPhong(frmHome sql)
        {
            InitializeComponent();
            frmHome = sql;
            kieuForm = 1;
        }
        //Form 2
        public frmDatPhong(string s)
        {
            InitializeComponent();
            this.Text = s;
            kieuForm = 2;
            panel4.Visible = false;
            panel3.Dock = DockStyle.Fill;
            dgvCTDV.Dock = DockStyle.Fill;
            label5.Visible = false;
            dtmNgayRa.Visible = false;
            btnLuu.Text = "Cập nhật dịch vụ";
            panel12.Location = new Point(666, 0);
            panel12.Size = new Size(245, 54);
            btnLuu.Size = new Size(191, 54);
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
        //Lựa chọn dịch vụ để mua bán
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
        //Xoá những dịch vụ không cần thiết
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = gridViewCTDV.FocusedRowHandle;
            ls.RemoveAt(index);
            gridViewCTDV.DeleteRow(index);
        }

        public void autoCompleteSource()
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
            frmTextKhachHang frm = new frmTextKhachHang();
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (kieuForm == 1)
            {
                PhongBUS pbus = new PhongBUS();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                eThuePhong tp = new eThuePhong();
                NhanVienBUS nvbus = new NhanVienBUS();
                tp.MaNV = nvbus.getmaNV_byEmail(emailNV);
                tp.SoLuongPhong = 1;
                tp.TrangThai = false;
                TimeSpan gioVao = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                TimeSpan gioRa = new TimeSpan(14, 00, 00);
                int a = tpbus.insertThuePhong(tp);
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                if (a == 1)
                {
                    ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
                    cttp.MaThue = tpbus.getMaThueCuoi();
                    cttp.MaKhach = maKH;
                    cttp.MaPhong = pbus.maPhong_byTen(TenPhong);
                    cttp.NgayRa = Convert.ToDateTime(dtmNgayRa.Text).Date;
                    cttp.NgayVao = DateTime.Now.Date;
                    cttp.GioRa = gioRa;
                    cttp.GioVao = gioVao;
                    cttp.TrangThai = false;
                    cttp.TienKhac = 0;
                    cttpbus.insertCTTP(cttp);
                    ePhong p = new ePhong();
                    p.MaPhong = pbus.maPhong_byTen(TenPhong);
                    p.TinhTrang = true;
                    pbus.updateTinhTrangPhong(p);
                    MessageBox.Show("Đặt phòng thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thành công");
                    return;
                }

                DichVuBUS dvbus = new DichVuBUS();
                eDichVu dv = new eDichVu();
                ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
                eChiTetDichVu ctdv = new eChiTetDichVu();
                //Thêm chi tiết dịch vụ nếu có đặt dịch vụ
                if (gridViewCTDV.RowCount > 0)
                {
                    for (int i = 0; i < gridViewCTDV.RowCount; i++)
                    {
                        ctdv.MaThue = cttp.MaThue;
                        ctdv.MaThue = cttp.MaThue;
                        ctdv.MaKhach = cttp.MaKhach;
                        ctdv.MaPhong = cttp.MaPhong;
                        ctdv.MaDV = gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString();
                        ctdv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());
                        int s = ctdvbus.insertCTDV(ctdv);
                        foreach (eDichVu item in mangDichVu)
                        {
                            //Cập nhật lại số lượng trong bảng dịch vụ
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

            if (kieuForm == 2)
            {
                //Thêm chi tiết dịch vụ nếu có đặt dịch vụ
                if (gridViewCTDV.RowCount > 0)
                {

                    for (int i = 0; i < gridViewCTDV.RowCount; i++)
                    {
                        PhongBUS pbus = new PhongBUS();
                        ChiTietDichVuBUS ctdvbus = new ChiTietDichVuBUS();
                        eChiTetDichVu ctdv = new eChiTetDichVu();
                        ctdv.MaThue = maThue.Trim();
                        ctdv.MaKhach = maKhachHang;
                        ctdv.MaPhong = pbus.maPhong_byTen(TenPhong);
                        ctdv.MaDV = gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString();
                        //ctdv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());

                        /**Kiểm tra xem mã thuê và mã dịch vụ đó có trong csdl hay chưa
                        Nếu có thì hãy update lại số lượng
                        Chưa có thì thêm mới chi tiết dịch vụ**/

                        if (!ctdvbus.maThue_maDV_CoTonTai(ctdv.MaThue, ctdv.MaDV))
                        {
                            foreach (var item in ctdvbus.getctdv(ctdv.MaThue, ctdv.MaKhach))
                            {
                                if (item.MaThue == ctdv.MaThue && item.MaDV == ctdv.MaDV)
                                {
                                    ctdv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString()) + item.SoLuong;
                                    ctdvbus.updateCTDV(ctdv);
                                }
                                if (item.MaDV == null)
                                {
                                    ctdv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());
                                    int s = ctdvbus.insertCTDV(ctdv);
                                }
                            }
                        }
                        else
                        {
                            ctdv.SoLuong = Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2]).ToString());
                            int s = ctdvbus.insertCTDV(ctdv);
                        }

                        DichVuBUS dvbus = new DichVuBUS();
                        eDichVu dv = new eDichVu();
                        foreach (eDichVu item in mangDichVu)
                        {
                            //Cập nhật lại số lượng trong bảng dịch vụ
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
                    MessageBox.Show("Cập nhật dịch vụ thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có dịch vụ cần cập nhật xin nhập lại");
                }
            }
        }

        //Chọn ngày để trả phòng, không được chọn ngày nhỏ hơn ngày hiện tại
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
        //Load lại giao diện chính khi đã đặt phòng xong
        private void frmDatPhong_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kieuForm == 1)
            {
                PhongBUS pbus = new PhongBUS();
                frmHome.cleanGiaoDien();
                frmHome.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
            }
        }

        private void txtSeachKH_TextChanged(object sender, EventArgs e)
        {
            string s = txtSeachKH.Text.Trim();
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

        private void gridViewCTDV_MouseMove(object sender, MouseEventArgs e)
        {
            eDichVu dv = new eDichVu();
            for (int i = 0; i < gridViewCTDV.RowCount; i++)
            {
                foreach (eDichVu item in mangDichVu)
                {
                    if (gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[0]).ToString() == item.MaDV && item.SoLuong < Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])))
                    {
                        ls.RemoveAt(i);
                        gridViewCTDV.DeleteRow(i);
                        DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng dịch vụ " + item.TenDV.ToLower() + " đã hết");
                        return;
                    }
                    if (Convert.ToInt32(gridViewCTDV.GetRowCellValue(i, gridViewCTDV.Columns[2])) == 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Số lượng dịch vụ phải lớn hơn 0");
                        return;
                    }
                }
            }
        }
    }
}