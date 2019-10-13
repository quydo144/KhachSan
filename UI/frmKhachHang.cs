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

namespace Home
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            cboTKKH.Items.Add("Mã khách hàng");
            cboTKKH.Items.Add("Tên khách hàng");
            cboTKKH.Items.Add("Giới tính");
            cboTKKH.Items.Add("Số điện thoại");
            cboTKKH.Items.Add("Số CMND");
            cboTKKH.SelectedIndex = 4;
        }
    }
}