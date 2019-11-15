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
using Entyti;
using BUS;

namespace Home
{
    public partial class frmDoan : DevExpress.XtraEditors.XtraForm
    {
        public frmDoan()
        {
            InitializeComponent();
        }

        List<eDoan> lsDoan;
        DoanBUS dbus;
        eDoan ed = new eDoan();
        private void frmDoan_Load(object sender, EventArgs e)
        {

        }
    }
}