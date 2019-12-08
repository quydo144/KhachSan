using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using BUS;
using Entyti;
using System.Threading;

namespace Home
{
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public bool isDead = false;
        bool isDangXuat = false;
        frmDangNhap frmDangNhap;
        string s;
        double donGia;
        string TenPhong;
        List<ePhong> listp = new List<ePhong>();
        PhongBUS pbus = new PhongBUS();
        List<eLoaiPhong> listlp = new List<eLoaiPhong>();
        LoaiPhongBUS lpbus = new LoaiPhongBUS();

        public frmHome()
        {
            InitializeComponent();
        }

        public frmHome(frmDangNhap sql)
        {
            InitializeComponent();
            frmDangNhap = sql;
        }

        private void timerDateSystem_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.lblTime.Text = time.ToString();
        }

        public string tenloaiphong(string maLoaiPhong)
        {

            foreach (var item in lpbus.getall())
            {
                if (item.MaLoaiPhong.Trim().Equals(maLoaiPhong))
                {
                    s = item.TenLoaiPhong;
                }
            }
            return s;
        }

        public double donGiaphong(string maLoaiPhong)
        {
            foreach (var item in lpbus.getall())
            {
                if (item.MaLoaiPhong.Trim().Equals(maLoaiPhong))
                {
                    donGia = item.DonGia;
                }
            }
            return donGia;
        }

        public void frmHome_Load(object sender, EventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        /**Tạo sự kiện kích chuột phải vào label để lấy các thông tin trong label đó
         * ra truyền qua các form khác* */
        public void lblred_Click(object sender, MouseEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                string ttPhong = lbl.Text;
                string[] lsPhong = ttPhong.Split('\r');
                string tenPhong = lsPhong[0].Trim();
                frmTraKhachLe.TenPhong = tenPhong;
                frmDatPhong.TenLoaiPhong = "Phòng " + lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(tenPhong)));
                frmTraKhachLe.LoaiPhong = "Phòng " + lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(tenPhong)));
                frmDatPhong.TenPhong = tenPhong;
                frmTraKhachLe.MaThue = cttpbus.getMaThue_By_MaPhong_TrangThai(pbus.maPhong_byTen(tenPhong), false);
                frmDatPhong.maThue = cttpbus.getMaThue_By_MaPhong_TrangThai(pbus.maPhong_byTen(tenPhong), false);
                frmDatPhong.maKhachHang = cttpbus.getMaKhach_By_MaPhong_TrangThai(pbus.maPhong_byTen(tenPhong), false);
                frmDoiPhong.TenPhong = tenPhong;
                frmDoiPhong.maThue = cttpbus.getMaThue_By_MaPhong_TrangThai(pbus.maPhong_byTen(tenPhong), false);
                TenPhong = tenPhong;
            }
        }


        public void lblred_MouseHover(object sender, EventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            ThuePhongBUS tpbus = new ThuePhongBUS();
            KhachHangBUS khbus = new KhachHangBUS();
            Label lbl = sender as Label;
            string ttPhong = lbl.Text;
            string[] lsPhong = ttPhong.Split('\r');
            string mathue = cttpbus.getMaThue_By_MaPhong_TrangThai(pbus.maPhong_byTen(lsPhong[0].Trim()), false);
            string ttThuePhong = "";
            int stt = 0;
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(mathue,pbus.maPhong_byTen(lsPhong[0].Trim())))
            {
                stt++;
                ttThuePhong += "Khách hàng " + stt + " : " + khbus.getenKH_ByID(item.MaKhach) + "\n";
            }
            foreach (var item in cttpbus.getChiTietThuePhong_By_MaThue_MaPhong(mathue, pbus.maPhong_byTen(lsPhong[0].Trim())))
            {
                if (item.NgayRa < DateTime.Now.Date)
                {
                    ttThuePhong += "Ngày ra: " + DateTime.Now.Date.ToShortDateString();
                }
                else
                {
                    ttThuePhong += "Ngày ra: " + item.NgayRa.ToShortDateString();
                }
                break;
            }
            toolTipTTThuePhong.SetToolTip(lbl, ttThuePhong);
        }

        /**Tạo sự kiện kích chuột phải vào label để lấy các thông tin trong label đó
         * ra truyền qua các form khác
         * */
        private void lbl_ClickTP(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                frmDatPhong.TenPhong = lbl.Text;
                frmDatPhong.TenLoaiPhong = "Phòng " + lpbus.getTen_Byma(pbus.getLoaiPhong_ByID(pbus.maPhong_byTen(lbl.Text)));
            }
        }

        //Load giao diện các phòng trống và phòng có chứa khách hàng
        public void TaoGiaoDienPhong(List<ePhong> soPhong, List<ePhong> phongTrong, List<ePhong> coKhach, string title)
        {
            //Tạo ra một flowLayoutPanel để chứa các panel                   
            PhongBUS pbus = new PhongBUS();
            FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            Label text = new Label();
            text.Size = new Size(1850, 30);
            text.TextAlign = ContentAlignment.TopCenter;
            text.Text = title;
            flowLayoutPanel3.Controls.Add(text);
            //Tạo các label để chứa thông tin, màu sắc thể hiện các phòng
            foreach (var item in soPhong)
            {
                DevExpress.XtraEditors.PanelControl P0001 = new DevExpress.XtraEditors.PanelControl();
                Label lbl = new Label();
                flowLayoutPanel3.Controls.Add(P0001);
                P0001.Appearance.Options.UseBackColor = true;
                P0001.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                P0001.Controls.Add(lbl);
                P0001.Location = new Point(3, 3);
                P0001.Name = item.MaPhong;
                P0001.Size = new Size(170, 150);
                lbl.Font = new Font("Tahoma", 9F);
                lbl.Dock = DockStyle.Fill;
                lbl.Size = new Size(150, 120);
                lbl.TextAlign = ContentAlignment.TopCenter;
            }
            //Load thông tin của phòng trống vào từng label
            foreach (var item in phongTrong)
            {
                foreach (var pnl in flowLayoutPanel3.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.LawnGreen;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            string ma = item.MaPhong.Substring(3, 5);
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = "Phòng " + Convert.ToInt32(ma);
                            lbl.MouseDown += new MouseEventHandler(lbl_ClickTP);
                            lbl.ContextMenuStrip = cmnstrpSanSang;
                        }
                    }
                }
            }
            //Load thông tin của phòng đang có khách vào từng label
            foreach (var item in coKhach)
            {
                foreach (var pnl in flowLayoutPanel3.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
                            string ma = item.MaPhong.Substring(3, 5);
                            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
                            DoanBUS dbus = new DoanBUS();
                            ThuePhongBUS tpbus = new ThuePhongBUS();
                            foreach (var thuePhong in tpbus.getMaThue(cttpbus.getMaThue_By_MaPhong_TrangThai(item.MaPhong, false)))
                            {
                                if (thuePhong.MaDoan == null)
                                {
                                    lbl.Text = "Phòng " + Convert.ToInt32(ma);
                                }
                                else
                                {
                                    string tendoan = dbus.getTen_ById(tpbus.getMaDoan_ByMaThue(cttpbus.getMaThue_By_MaPhong_TrangThai(item.MaPhong, false)));
                                    string tenPhong = "Phòng " + Convert.ToInt32(ma);
                                    lbl.Text = tenPhong + "\n\n\rĐoàn: " + tendoan;
                                }
                            }
                            lbl.MouseDown += new MouseEventHandler(lblred_Click);
                            lbl.MouseHover += new EventHandler(lblred_MouseHover);
                            lbl.ContextMenuStrip = cmnstrpCoKhach;
                        }
                    }
                }
            }

        }
        //Lọc các phòng trống có trong hệ thống
        private void toggleSwitchSS_Toggled(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>())
            {
                if (toggleSwitchSS.IsOn != true)
                {
                    int s = 0;
                    foreach (var pnl in item.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                    {
                        if (pnl.BackColor == Color.LawnGreen)
                        {
                            s++;
                        }
                        pnl.Show();
                    }
                    this.toggleSwitchSS.Properties.OffText = "Sẵn sàng";
                }
                else
                {
                    int s = 0;
                    foreach (var pnl in item.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                    {
                        if (pnl.BackColor != Color.LawnGreen)
                        {
                            pnl.Hide();
                        }
                        else
                        {
                            s++;
                        }
                    }
                    this.toggleSwitchSS.Properties.OnText = "Sẵn sàng";
                }
            }

        }
        //Lọc các phòng đang có khách ở
        private void toggleSwitchCK_Toggled(object sender, EventArgs e)
        {
            foreach (var item in flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>())
            {
                if (toggleSwitchCK.IsOn != true)
                {
                    int s = 0;
                    foreach (var pnl in item.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                    {
                        if (pnl.BackColor == Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))))
                        {
                            s++;
                        }
                        pnl.Show();
                    }
                    this.toggleSwitchCK.Properties.OffText = "Có khách ";
                }
                else
                {
                    int s = 0;
                    foreach (var pnl in item.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                    {
                        if (pnl.BackColor != Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))))
                        {
                            pnl.Hide();
                        }
                        else
                        {
                            s++;
                        }
                    }
                    this.toggleSwitchCK.Properties.OnText = "Có khách ";
                }
            }
        }

        private bool ExitForm(DevExpress.XtraEditors.XtraForm frm)
        {
            foreach (var item in MdiChildren)
            {
                if (item.Name == frm.Name)
                {
                    item.Activate();
                    return true;
                }
            }
            return false;
        }

        public bool ExitAllForm()
        {
            int stt = 0;
            foreach (var item in MdiChildren)
            {
                stt++;
            }
            if (stt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AnflowLayoutPanel()
        {
            flowLayoutPanel1.Show();
            foreach (var item in flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>())
            {
                item.Dispose();
            }
            cleanGiaoDien();
            panel1.Visible = true;
        }


        private void btndmk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }

        private void btndv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDichVu frm = new frmDichVu(this);
            panel1.Visible = false;
            if (ExitForm(frm)) return;
            flowLayoutPanel1.Hide();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhong frm = new frmPhong(this);
            panel1.Visible = false;
            if (ExitForm(frm)) return;
            flowLayoutPanel1.Hide();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKhachHang frm = new frmKhachHang(this);
            panel1.Visible = false;
            if (ExitForm(frm)) return;
            flowLayoutPanel1.Hide();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(this);
            panel1.Visible = false;
            if (ExitForm(frm)) return;
            flowLayoutPanel1.Hide();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thuePhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThuePhongBUS tpbus = new ThuePhongBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            foreach (eThuePhong item in tpbus.getMaThue(cttpbus.getMaThue_By_MaPhong_TrangThai(pbus.maPhong_byTen(TenPhong), false)))
            {
                if (item.MaDoan != null)
                {
                    frmTraKhachLe frm = new frmTraKhachLe(this, item.MaDoan);
                    frm.ShowDialog();
                }
                else
                {
                    frmTraKhachLe frm = new frmTraKhachLe(this);
                    frm.ShowDialog();
                }
            }
        }

        private void DatPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong frm = new frmDatPhong(this);
            frm.ShowDialog();
        }

        private void back_login()
        {
            Application.Run(new frmDangNhap());
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isDangXuat = true;
            DialogResult ds = MessageBox.Show("Bạn Có Muốn Đăng Xuất ?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ds == DialogResult.Yes)
            {
                Thread th = new Thread(back_login);
#pragma warning disable CS0618 // Type or member is obsolete
                th.ApartmentState = ApartmentState.STA;
#pragma warning restore CS0618 // Type or member is obsolete

                th.Start();

                this.Close();
            }
            else
            {
                return;
            }
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isDangXuat)
            {
                DialogResult ds = MessageBox.Show("Bạn Có Muốn Thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        public void cleanGiaoDien()
        {
            foreach (var item in flowLayoutPanel1.Controls.OfType<FlowLayoutPanel>())
            {
                item.Hide();
            }
            FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn500_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getDOnGia(0, 500000))
            {
                TaoGiaoDienPhong(pbus.getLoaiPhong(item.MaLoaiPhong), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, true), "Phòng 1 triệu đồng đến 1 triệu 500 nghìn đồng");
            }
        }

        private void btnTheoPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
        }

        private void btnTheoLoaiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Normal")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Normal"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Normal"), true), "Phòng Normal");
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Double")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Double"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Double"), true), "Phòng Double");
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Triple")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Triple"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Triple"),true), "Phòng Triple");
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Family")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Family"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Family"),true), "Phòng Family");
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Vip")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Vip"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Vip"), true), "Phòng Vip");
            TaoGiaoDienPhong(pbus.getLoaiPhong(lpbus.getma_ByTen("Deluxe")), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Deluxe"), false), pbus.getLoaiPhong_Trong(lpbus.getma_ByTen("Deluxe"), true), "Phòng Deluxe");
        }

        private void btnTheoTang_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            foreach (var item in pbus.Tang())
            {
                TaoGiaoDienPhong(pbus.getTang(item.ToString()), pbus.getTang_PhongTrong(item.ToString(), false), pbus.getTang_PhongTrong(item.ToString(), true), "Tầng " + item.ToString());
            }
        }

        private void btn1000_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getDOnGia(500000, 1000000))
            {
                TaoGiaoDienPhong(pbus.getLoaiPhong(item.MaLoaiPhong), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, true), "Phòng 500,000 đồng đến 1 triệu đồng");
            }
        }

        private void btn1500_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getDOnGia(1000000, 1500000))
            {
                TaoGiaoDienPhong(pbus.getLoaiPhong(item.MaLoaiPhong), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, true), "Phòng 1 triệu đồng đến 1 triệu 500 nghìn đồng");
            }
        }

        private void btnHon1500_ItemClick(object sender, ItemClickEventArgs e)
        {
            cleanGiaoDien();
            PhongBUS pbus = new PhongBUS();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            foreach (var item in lpbus.getDOnGia(1500000, int.MaxValue))
            {
                TaoGiaoDienPhong(pbus.getLoaiPhong(item.MaLoaiPhong), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, false), pbus.getLoaiPhong_Trong(item.MaLoaiPhong, true), "Phòng trên 1 triệu 500 nghìn đồng");
            }
        }

        private void ThemDichVuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatPhong frm = new frmDatPhong("Cập nhật dịch vụ");
            frm.ShowDialog();
        }

        private void btnDatPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDatKhachDoan frm = new frmDatKhachDoan(this);
            frm.ShowDialog();
        }

        private void DoiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiPhong frm = new frmDoiPhong(this);
            frm.ShowDialog();
        }

        private void btnKhachDoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTraKhachDoan frm = new frmTraKhachDoan(this);
            frm.ShowDialog();
        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
