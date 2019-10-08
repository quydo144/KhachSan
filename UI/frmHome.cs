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
                        MessageBox.Show(pnl.Name);
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.Red;
                            lbl.Text = item.TenPhong;
                            break;
                        }
                        foreach (var lbl in pnl.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                        {
                            lbl.BackColor = Color.Red;
                            lbl.Text = "Có khách";
                            break;
                        }
                    }
                    else
                    {
                        pnl.BackColor = Color.LawnGreen;
                        MessageBox.Show(pnl.Name);
                        foreach (var lbl in pnl.Controls.OfType<Label>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = item.TenPhong;
                            break;
                        }
                        foreach (var lbl in pnl.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
                        {
                            lbl.BackColor = Color.LawnGreen;
                            lbl.Text = "Sẵn sàng";
                            break;
                        }
                    }
                }
            }
            //int s = 0, c = 0;
            //foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
            //{
            //    if (pnl.BackColor == Color.LawnGreen)
            //    {
            //        s++;
            //    }
            //    else
            //    {
            //        c++;
            //    }
            //}
            //this.toggleSwitchSS.Properties.OffText = "Sẵn sàng " + s.ToString();
            //this.toggleSwitchCK.Properties.OffText = "Có khách " + c.ToString();
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
    }
}
