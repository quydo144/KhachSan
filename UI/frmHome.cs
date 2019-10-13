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

namespace Home
{
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<ePhong> listp = new List<ePhong>();
        PhongBUS pbus = new PhongBUS();
        public frmHome()
        {
            InitializeComponent();
        }

        private void timerDateSystem_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.lblTime.Text = time.ToString();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

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
                            lbl.DoubleClick += new EventHandler(lbl_Click);
                        }
                        foreach (var lbl in pnl.Controls.OfType<DevExpress.XtraEditors.LabelControl>())
                        {
                            lbl.BackColor = Color.Red;
                            lbl.Text = "Có khách";
                            lbl.Click += new EventHandler(lbl_Click);
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
                            lbl.Text = item.TenPhong;
                            lbl.Click += new EventHandler(lbl_Click);
                        }
                        foreach (var lbl in pnl.Controls.OfType<DevExpress.XtraEditors.LabelControl>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = "Sẵn sàng";
                            lbl.Click += new EventHandler(lbl_Click);
                        }
                    }
                }
            }
        }

        public void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            DevExpress.XtraEditors.LabelControl lbld = sender as DevExpress.XtraEditors.LabelControl;
            if ( lbl!=null || lbld!=null)
            {

                    frmThanhToan frm = new frmThanhToan();
                    frm.Show();

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
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel2 = new FlowLayoutPanel();
            DevExpress.XtraEditors.PanelControl P = new DevExpress.XtraEditors.PanelControl();
            Label l = new Label();
            panel.Controls.Add(flowLayoutPanel2);
            panel.Controls.Add(flowLayoutPanel1);
            panel.AutoScroll = true;
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.Controls.Add(P);
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowOnly;
            flowLayoutPanel2.BackColor = Color.Gray;

            P.Appearance.BackColor = Color.Red;
            P.Appearance.Options.UseBackColor = true;
            P.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            P.Appearance.BackColor = Color.Red;
            P.Appearance.Options.UseBackColor = true;
           // P.Controls.Add(lc);
            P.Controls.Add(l);
            P.Location = new Point(527, 341);
            P.Name = "P0013";
            P.Size = new Size(256, 163);

            P.Controls.Add(l);
            P.Size = new Size(256, 163);
            flowLayoutPanel2.Location = new Point(0, 800);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            P0001.Hide();
            l.BackColor = Color.Red;
            l.Dock = DockStyle.Fill;
            l.Text = "123";
            l.TextAlign = ContentAlignment.TopCenter;
        }

        private void btndmk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDoiMK frm = new frmDoiMK();
            frm.ShowDialog();
        }
    }
}
