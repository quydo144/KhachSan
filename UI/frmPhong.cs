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
using BUS;
using Entyti;

namespace Home
{
    public partial class frmPhong : DevExpress.XtraEditors.XtraForm
    {
        frmHome frm;

        public frmPhong()
        {
            InitializeComponent();
        }

        public frmPhong(frmHome frm1)
        {
            InitializeComponent();
            frm = frm1;
        }

        List<ePhong> listP; //Khai báo danh sách phòng học (TreeView)
        PhongBUS pBus;
        ePhong p = new ePhong();

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            frmTextPhong frm = new frmTextPhong(this,"Thêm Phòng");
            frm.ShowDialog();
            listP = pBus.getallphong();
            gclDSP.DataSource = listP;
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            pBus = new PhongBUS();
            listP = new List<ePhong>();
            listP = pBus.getallphong();
            gclDSP.DataSource = listP;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            List<ePhong> ls = new List<ePhong>();
            if (gridViewPhong.SelectedRowsCount == 1)
            {              
                PhongBUS ph_bus = new PhongBUS();
                string id = gridViewPhong.GetRowCellValue(gridViewPhong.FocusedRowHandle,gridViewPhong.Columns[0]).ToString();
                frmTextPhong ftph = new frmTextPhong(this, "Sửa Phòng", id.ToString());
                ftph.ShowDialog();                
            }
            else
            {
                MessageBox.Show("Chọn 1 Phòng Cần Sửa", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            ls = pBus.getallphong();
            gclDSP.DataSource = ls;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bool kq;
            DialogResult dlgHoi = MessageBox.Show("Bạn có chắc xóa",
                "Hoi xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dlgHoi == DialogResult.Yes)
            {
                //mới xóa
                kq = pBus.deletePhong(gridViewPhong.GetRowCellValue(gridViewPhong.FocusedRowHandle, gridViewPhong.Columns[0]).ToString());
                if (kq == true)
                {
                    //đưa lại datagridview
                    // string strMaPhong = trePhong.SelectedNode.Tag.ToString();
                    List<ePhong> listP = pBus.getallphong();
                    gclDSP.DataSource = listP;
                }
                else
                {
                    MessageBox.Show("Bạn hãy chọn Phòng cần xóa!");
                }
            }
        }

        private void frmPhong_FormClosing(object sender, FormClosingEventArgs e)
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