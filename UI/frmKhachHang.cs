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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        frmHome frm;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        public frmKhachHang(frmHome sql)
        {
            InitializeComponent();
            frm = sql;
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            cboTKKH.Items.Add("Mã khách hàng");
            cboTKKH.Items.Add("Tên khách hàng");
            cboTKKH.Items.Add("Giới tính");
            cboTKKH.Items.Add("Số điện thoại");
            cboTKKH.Items.Add("Số CMND");
            cboTKKH.SelectedIndex = 4;
            LoadKHDangThuePhong();
        }

        public void LoadKHDangThuePhong()
        {
            List<eKhachHang> ls = new List<eKhachHang>();
            KhachHangBUS khbus = new KhachHangBUS();
            ChiTietThuePhongBUS cttpbus = new ChiTietThuePhongBUS();
            foreach (var item in cttpbus.getAllKHDangO())
            {
                ls.Add(khbus.getallKhDangO(item.MaKhach));
            }
            gridControlDsKH.DataSource = ls.ToList();
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            txtTK.ForeColor = Color.Black;
            txtTK.Clear();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frmTextKhachHang frm = new frmTextKhachHang(this);
            frm.ShowDialog();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (gridViewDsKh.SelectedRowsCount == 1)
            {
                KhachHangBUS khbus = new KhachHangBUS();
                string id = gridViewDsKh.GetRowCellValue(gridViewDsKh.FocusedRowHandle, gridViewDsKh.Columns[0]).ToString();
                frmTextKhachHang ftph = new frmTextKhachHang(this, id);
                ftph.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chọn 1 Phòng Cần Sửa", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            if (frm.ExitAllForm())
            {
                frm.AnflowLayoutPanel();
                frm.TaoGiaoDienPhong(pbus.getallphong(), pbus.gettinhtrangp(false), pbus.gettinhtrangp(true), "Phòng");
            }
        }
    }
}