using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using Entyti;
using System.Threading;

namespace Home
{
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string s;
        decimal donGia;
        int stt = 0;
        List<ePhong> listp = new List<ePhong>();
        PhongBUS pbus = new PhongBUS();
        List<eLoaiPhong> listlp = new List<eLoaiPhong>();
        LoaiPhongBUS lpbus = new LoaiPhongBUS();
        public frmHome()
        {
            InitializeComponent();
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

        public decimal donGiaphong(string maLoaiPhong)
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

        private void loaiphong()
        {
            foreach (var item in pbus.getallp())
            {
                stt++;
                DevExpress.XtraEditors.PanelControl P0001 = new DevExpress.XtraEditors.PanelControl();
                Label lbl = new Label();
                ((ISupportInitialize)(P0001)).BeginInit();
                P0001.SuspendLayout();
                flowLayoutPanel1.Controls.Add(P0001);
                // P0001
                P0001.Appearance.BackColor = Color.LawnGreen;
                P0001.Appearance.Options.UseBackColor = true;
                P0001.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
                P0001.Controls.Add(lbl);
                P0001.Location = new Point(3, 3);
                if (stt < 10)
                {
                    P0001.Name = "P000" + stt;
                }
                else if (stt >=10 && stt <100)
                {
                    P0001.Name = "P00" + stt;
                }
                else if(stt >= 100 && stt < 1000)
                {
                    P0001.Name = "P0" + stt;
                }
                else
                {
                    P0001.Name = "P" + stt;
                }
                P0001.Size = new Size(256, 163);
                // lbl2
                lbl.BackColor = Color.LawnGreen;
                lbl.Font = new Font("Tahoma", 10F);
                lbl.Dock = DockStyle.Fill;
                lbl.Size = new Size(252, 159);
                lbl.Text = "Phòng " + stt;
                lbl.TextAlign = ContentAlignment.TopCenter;
                ((ISupportInitialize)(P0001)).EndInit();
                P0001.ResumeLayout(false);
            }
        }

        public void frmHome_Load(object sender, EventArgs e)
        {
            loaiphong();
            listp = pbus.gettinhtrangp(true);
            foreach (var item in listp)
            {
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.Red;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.Red;
                            lbl.Text = item.TenPhong;
                            lbl.DoubleClick += new EventHandler(lblred_Click);
                            lbl.ContextMenuStrip = cmnstrpCoKhach;
                        }
                    }
                }
            }

            foreach (var item in pbus.gettinhtrangp(false))
            {
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                {
                    if (pnl.Name.Equals(item.MaPhong.Trim()))
                    {
                        pnl.BackColor = Color.LawnGreen;
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = item.TenPhong+ "\r\n\r\nLoại phòng: Phòng " + tenloaiphong(item.MaLoaiPhong.Trim())+ "\r\n\r\n" + donGiaphong(item.MaLoaiPhong.Trim());
                            lbl.MouseDown += new MouseEventHandler(lbl_ClickTP);
                            lbl.ContextMenuStrip = cmnstrpSanSang;
                        }
                    }
                }
            }
        }

        public void lblred_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan();
            frm.ShowDialog();
        }

        private void lbl_ClickTP(object sender, MouseEventArgs e)
        {
            Label lbl = sender as Label;
            if (e.Button == MouseButtons.Right)
            {
                string[] list = lbl.Text.Split('\r');
                frmDatPhong.TenPhong = list[0];
                frmDatPhong.TenLoaiPhong = list[2].Substring(12, 13);
            }
        }

        private void toggleSwitchSS_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitchSS.IsOn != true)
            {
                int s = 0;
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
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
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
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
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
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
                foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
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
            frmDatPhong frm = new frmDatPhong();
            //frm.MdiParent = this;
            //frm.Show();
            frm.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
            //DevExpress.XtraEditors.PanelControl P = new DevExpress.XtraEditors.PanelControl();
            //Label l = new Label();
            //panel.Controls.Add(flowLayoutPanel2);
            //panel.Controls.Add(flowLayoutPanel1);
            //panel.AutoScroll = true;
            //flowLayoutPanel2.SuspendLayout();
            //flowLayoutPanel2.Controls.Add(P);
            //flowLayoutPanel2.SuspendLayout();
            //flowLayoutPanel2.AutoScroll = true;
            //flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowOnly;
            //flowLayoutPanel2.BackColor = Color.Gray;

            //P.Appearance.BackColor = Color.Red;
            //P.Appearance.Options.UseBackColor = true;
            //P.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            //P.Appearance.BackColor = Color.Red;
            //P.Appearance.Options.UseBackColor = true;
            //// P.Controls.Add(lc);
            //P.Controls.Add(l);
            //P.Location = new Point(527, 341);
            //P.Name = "P0013";
            //P.Size = new Size(256, 163);

            //P.Controls.Add(l);
            //P.Size = new Size(256, 163);
            //flowLayoutPanel2.Location = new Point(0, 800);
            //flowLayoutPanel2.Name = "flowLayoutPanel2";
            ////P0001.Hide();
            //l.BackColor = Color.Red;
            //l.Dock = DockStyle.Fill;
            //l.Text = "123";
            //l.TextAlign = ContentAlignment.TopCenter;
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
            frmThanhToan frm = new frmThanhToan();
            frm.ShowDialog();
        }

        private void DatPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            frmDatPhong frm = new frmDatPhong();
            frm.ShowDialog();
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name.Equals("frmDangNhap"))
                {
                    item.Show();
                }
            }           
        }

        private void frmHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Close();
            //foreach (Form item in Application.OpenForms)
            //{
            //    if (item.Name.Equals("frmDangNhap"))
            //    {
            //        item.Close();
            //    }
            //}
        }
    }
}
