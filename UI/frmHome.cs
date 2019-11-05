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
        List<ePhong> listp = new List<ePhong>();
        PhongBUS pbus = new PhongBUS();
        List<eLoaiPhong> listlp = new List<eLoaiPhong>();
        LoaiPhongBUS lpbus = new LoaiPhongBUS();
        JoinTable_BUS joinbus = new JoinTable_BUS();

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

        public void loadphong(List<ePhong> ls)
        {
            int stt = 0;
            foreach (var item in ls)
            {
                stt++;
                DevExpress.XtraEditors.PanelControl P0001 = new DevExpress.XtraEditors.PanelControl();
                Label lbl = new Label();
                ((ISupportInitialize)(P0001)).BeginInit();
                P0001.SuspendLayout();
                flowLayoutPanel2.Controls.Add(P0001);
                // P0001
                P0001.Appearance.Options.UseBackColor = true;
                P0001.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                P0001.Controls.Add(lbl);
                P0001.Location = new Point(3, 3);
                P0001.Name = item.MaPhong;
                // lbl2
                lbl.Font = new Font("Tahoma", 10F);
                lbl.Dock = DockStyle.Fill;
                lbl.Size = new Size(252, 159);
                lbl.Text = item.TenPhong;
                lbl.TextAlign = ContentAlignment.TopCenter;
                ((ISupportInitialize)(P0001)).EndInit();
                P0001.ResumeLayout(false);
            }
        }

        public void textPhongTrong(List<ePhong> lsTrue)
        {
            foreach (var item in lsTrue)
            {
                foreach (var pnl in flowLayoutPanel2.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.LawnGreen;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nGiá phòng: " + donGiaphong(item.MaLoaiPhong.Trim());
                            lbl.MouseDown += new MouseEventHandler(lbl_ClickTP);
                            lbl.ContextMenuStrip = cmnstrpSanSang;
                        }
                    }
                }
            }
        }

        public void textPhongCoKhach(List<eHonLoan> lsTrue)
        {
            foreach (var item in lsTrue)
            {
                string[] s = { item.MaThue, item.MaPhong };
                foreach (var pnl in flowLayoutPanel2.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.Red;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.Red;
                            if (item.NgayTra < DateTime.Now)
                            {
                                lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nMã thuê phòng: " + item.MaThue + "\r\n\r\nNgày trả: " + DateTime.Now.Date.ToShortDateString();
                            }
                            else
                            {
                                lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nMã thuê phòng: " + item.MaThue + "\r\n\r\nNgày trả: " + item.NgayTra.Date.ToShortDateString();
                            }
                            lbl.MouseDown += new MouseEventHandler(lblred_Click);
                            lbl.ContextMenuStrip = cmnstrpCoKhach;
                        }
                    }
                }
            }
        }

        public void frmHome_Load(object sender, EventArgs e)
        {
            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            //loadphong(pbus.getallp());
            //flowLayoutPanel2.Hide();
            TaoGiaoDienPhong(pbus.getallp(), pbus.gettinhtrangp(false), joinbus.GetPhong_ThuePhong(true, 0));
            //textPhongCoKhach(joinbus.GetPhong_ThuePhong(true, 0));
            //textPhongTrong(pbus.gettinhtrangp(false));
        }

        public void lblred_Click(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                string[] list = lbl.Text.Split('\r');
                frmThanhToan.TenPhong = list[0];
                if (list[2].Substring(12, 10).Equals(" Phòng Vip"))
                {
                    frmThanhToan.LoaiPhong = list[2].Substring(12, 10);
                }
                else
                {
                    frmThanhToan.LoaiPhong = list[2].Substring(12, 13);
                }
                frmThanhToan.MaThue = list[4].Substring(15, 9);
            }
        }

        private void lbl_ClickTP(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                string[] list = lbl.Text.Split('\r');
                frmDatPhong.TenPhong = list[0];
                if (list[2].Substring(12, 10).Equals(" Phòng Vip"))
                {
                    frmDatPhong.TenLoaiPhong = list[2].Substring(12, 10);
                }
                else
                {
                    frmDatPhong.TenLoaiPhong = list[2].Substring(12, 13);
                }                            
            }
        }

        public void TaoGiaoDienPhong(List<ePhong> soPhong, List<ePhong> phongTrong, List<eHonLoan> coKhach)
        {
            

            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            FlowLayoutPanel flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
            Label text = new Label();
            text.Size = new Size(1850, 40);
            text.TextAlign = ContentAlignment.MiddleCenter;
            text.Text = "ABC";
            flowLayoutPanel3.Controls.Add(text);

            foreach (var item in soPhong)
            {
                DevExpress.XtraEditors.PanelControl P0001 = new DevExpress.XtraEditors.PanelControl();
                Label lbl = new Label();
                ((ISupportInitialize)(P0001)).BeginInit();
                P0001.SuspendLayout();
                flowLayoutPanel3.Controls.Add(P0001);
                P0001.Appearance.Options.UseBackColor = true;
                P0001.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                P0001.Controls.Add(lbl);
                P0001.Location = new Point(3, 3);
                P0001.Name = item.MaPhong;
                P0001.Size = new Size(256, 163);
                lbl.Font = new Font("Tahoma", 10F);
                lbl.Dock = DockStyle.Fill;
                lbl.Size = new Size(252, 159);
                lbl.Text = item.TenPhong;
                lbl.TextAlign = ContentAlignment.TopCenter;
                ((ISupportInitialize)(P0001)).EndInit();
                P0001.ResumeLayout(false);
            }

            foreach (var item in phongTrong)
            {
                foreach (var pnl in flowLayoutPanel3.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.LawnGreen;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nGiá phòng: " + donGiaphong(item.MaLoaiPhong.Trim());
                            lbl.MouseDown += new MouseEventHandler(lbl_ClickTP);
                            lbl.ContextMenuStrip = cmnstrpSanSang;
                        }
                    }
                }
            }


            foreach (var item in coKhach)
            {
                string[] s = { item.MaThue, item.MaPhong };
                foreach (var pnl in flowLayoutPanel3.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.Red;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.Red;
                            if (item.NgayTra < DateTime.Now)
                            {
                                lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nMã thuê phòng: " + item.MaThue + "\r\n\r\nNgày trả: " + DateTime.Now.Date.ToShortDateString();
                            }
                            else
                            {
                                lbl.Text = item.TenPhong + "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim()) + "\r\n\r\nMã thuê phòng: " + item.MaThue + "\r\n\r\nNgày trả: " + item.NgayTra.Date.ToShortDateString();
                            }
                            lbl.MouseDown += new MouseEventHandler(lblred_Click);
                            lbl.ContextMenuStrip = cmnstrpCoKhach;
                        }
                    }
                }
            }


        }

        private void toggleSwitchSS_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitchSS.IsOn != true)
            {
                int s = 0;
                foreach (var pnl in this.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.BackColor == Color.LawnGreen)
                    {
                        s++;
                    }
                    pnl.Show();
                }
                this.toggleSwitchSS.Properties.OffText = "Sẵn sàng " + s.ToString();
            }
            else
            {
                int s = 0;
                foreach (var pnl in this.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
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
                this.toggleSwitchSS.Properties.OnText = "Sẵn sàng " + s.ToString();
            }
        }

        private void toggleSwitchCK_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitchCK.IsOn != true)
            {
                int s = 0;
                foreach (var pnl in this.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.BackColor == Color.Red)
                    {
                        s++;
                    }
                    pnl.Show();
                }
                this.toggleSwitchCK.Properties.OffText = "Có khách " + s.ToString();
            }
            else
            {
                int s = 0;
                foreach (var pnl in this.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.BackColor != Color.Red)
                    {
                        pnl.Hide();
                    }
                    else
                    {
                        s++;
                    }
                }
                this.toggleSwitchCK.Properties.OnText = "Có khách " + s.ToString();
            }
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDatPhong frm = new frmDatPhong(this);
            frm.ShowDialog();
        }

        private void btndmk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }

        private void btndv_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDichVu frm = new frmDichVu();
            frm.ShowDialog();
        }

        private void btnphong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhong frm = new frmPhong();
            frm.ShowDialog();
        }

        private void btnKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }

        private void btnNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }

        private void thuePhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan(this);
            frm.ShowDialog();
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
            DialogResult ds = MessageBox.Show("Bạn Có Muốn Đăng Xuất ?", "QUAY VỀ ĐĂNG NHẬP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
            //if (isDead == false)
            //{
            //    if (!isDangXuat)
            //    {
            //        DialogResult ds = MessageBox.Show("Bạn Có Muốn Thoát ?", "THOÁT", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            //        if (ds == DialogResult.Yes)
            //        {
            //            Environment.Exit(0);
            //        }
            //        else
            //        {
            //            e.Cancel = true;
            //        }
            //    }
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<eHonLoan> ls = new List<eHonLoan>();
            List<ePhong> phRong = new List<ePhong>();       //Phòng rỗng
            List<ePhong> phKhach = new List<ePhong>();       //Phòng có khách
            JoinTable_BUS joinbus = new JoinTable_BUS();
            PhongBUS pbus = new PhongBUS();
            foreach (var item in joinbus.GetPhong_ThuePhong(true, 0))
            {
                pbus.getEPhong_byID(item.MaPhong);
                phKhach.Add(pbus.getEPhong_byID(item.MaPhong));
            }
            TaoGiaoDienPhong(pbus.gettinhtrangp(false), pbus.gettinhtrangp(false), ls);     //Phòng trống
            TaoGiaoDienPhong(phKhach, phRong, joinbus.GetPhong_ThuePhong(true, 0));      //Phòng có khách
        }
    }
}
