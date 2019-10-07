using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Home
{
    public partial class frmHome : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void timerDateSystem_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            this.lblTime.Text = time.ToString();
        }

        //private System.Windows.Forms.Label l1;
        //private DevExpress.XtraEditors.PanelControl pnl;
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.pnl = new DevExpress.XtraEditors.PanelControl();
        //    this.lblTT23 = new System.Windows.Forms.Label();
        //    this.l1 = new System.Windows.Forms.Label();
        //    ((System.ComponentModel.ISupportInitialize)(this.pnl)).BeginInit();
        //    this.pnl.SuspendLayout();
        //    this.flowLayoutPanel1.Controls.Add(this.pnl);
        //    // pnl23
        //    // 
        //    this.pnl.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        //    this.pnl.Appearance.Options.UseBackColor = true;
        //    this.pnl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
        //    this.pnl.Controls.Add(this.lblTT23);
        //    this.pnl.Controls.Add(this.l1);
        //    this.pnl.Location = new System.Drawing.Point(527, 679);
        //    this.pnl.Name = "pnl";
        //    this.pnl.Size = new System.Drawing.Size(256, 163);
        //    this.pnl.TabIndex = 26;
        //    // 
        //    // lblTT23
        //    // 
        //    this.lblTT23.BackColor = System.Drawing.Color.Red;
        //    this.lblTT23.Font = new System.Drawing.Font("Tahoma", 12F);
        //    this.lblTT23.Location = new System.Drawing.Point(0, 106);
        //    this.lblTT23.Name = "lblTT23";
        //    this.lblTT23.Size = new System.Drawing.Size(256, 55);
        //    this.lblTT23.TabIndex = 0;
        //    this.lblTT23.Text = "Sẵn sàng";
        //    this.lblTT23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //    // 
        //    // lblP23
        //    // 
        //    this.l1.BackColor = System.Drawing.Color.Red;
        //    this.l1.Font = new System.Drawing.Font("Tahoma", 12F);
        //    this.l1.Location = new System.Drawing.Point(0, 0);
        //    this.l1.Name = "l1";
        //    this.l1.Size = new System.Drawing.Size(256, 163);
        //    this.l1.TabIndex = 0;
        //    this.l1.Text = "Phòng 1";
        //    this.l1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        //    // 

        //    ((System.ComponentModel.ISupportInitialize)(this.pnl)).EndInit();
        //    this.pnl.ResumeLayout(false);
        //}
        private void frmHome_Load(object sender, EventArgs e)
        {
            int s = 0, c = 0;
            foreach (var pnl in flowLayoutPanel1.Controls.OfType<DevExpress.XtraEditors.PanelControl>())
            {
                if (pnl.BackColor == Color.LawnGreen)
                {
                    s++;
                }
                else
                {
                    c++;
                }
            }
            this.toggleSwitchSS.Properties.OffText = "Sẵn sàng " + s.ToString();
            this.toggleSwitchCK.Properties.OffText = "Có khách " + c.ToString();
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
