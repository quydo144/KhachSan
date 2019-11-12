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
    public partial class frmTextPhong : DevExpress.XtraEditors.XtraForm
    {
        string lb_TitleName;
        string id_Phong;
        int kieuForm;
        frmPhong frmP;

        public frmTextPhong()
        {
            InitializeComponent();
        }

        public frmTextPhong(frmPhong fql, string title)
        {
            InitializeComponent();
            lb_TitleName = title;
            kieuForm = 1;
            frmP = fql;
        }
        public frmTextPhong(frmPhong fql, string title, string id_P)
        {
            InitializeComponent();
            lb_TitleName = title;
            id_Phong = id_P;
            kieuForm = 2;
            frmP = fql;
        }

        private void frmTextPhong_Load(object sender, EventArgs e)
        {
            if (kieuForm == 2)
            {
                PhongBUS pbus = new PhongBUS();
                ePhong p_ent = new ePhong();
                p_ent = pbus.getEPhong_byID(id_Phong);
                txtTenPhong.Text = p_ent.TenPhong.Trim();
                txtGhiChu.Text = null;
                bteTang.Text = p_ent.Tang.ToString();
                LoaiPhongBUS lpbus = new LoaiPhongBUS();
                cbxLoaiPhong.Text = lpbus.getTen_Byma(p_ent.MaLoaiPhong);
            }
            else
            {
                lbTieuDe.Text = lb_TitleName;
                cbxLoaiPhong.SelectedIndex = 0;
            }
        }
        private bool CheckNull()
        {
            if (cbxLoaiPhong.Text.Equals(""))
            {
                return false;
            }
            if (bteTang.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
        private void Luu_Them()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PhongBUS pbus = new PhongBUS();
            ePhong p_ent = new ePhong();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            p_ent.GhiChu = txtGhiChu.Text.Trim();
            p_ent.Tang = Convert.ToInt32(bteTang.Value.ToString());
            p_ent.MaLoaiPhong = lpbus.getma_ByTen(cbxLoaiPhong.Text);
            if (pbus.ThemPhong(p_ent)==1)
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ds == DialogResult.Yes)
                {
                    //Clear_TextBox();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Luu_Sua()
        {
            if (!CheckNull())
            {
                MessageBox.Show("Chưa Nhập Đủ Thông Tin", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PhongBUS pbus = new PhongBUS();
            ePhong p_ent = new ePhong();
            LoaiPhongBUS lpbus = new LoaiPhongBUS();
            p_ent.MaPhong = id_Phong;
            p_ent.TenPhong = txtTenPhong.Text.Trim();
            p_ent.GhiChu = txtGhiChu.Text.Trim();
            p_ent.Tang = Convert.ToInt32(bteTang.Value.ToString());
            p_ent.MaLoaiPhong = lpbus.getma_ByTen(cbxLoaiPhong.Text);         
            if (pbus.CapNhatPhong(p_ent)==1)
            {
                DialogResult ds = MessageBox.Show("Lưu Thành Công, Tiếp Tục ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (ds == DialogResult.Yes)
                {
                    //Clear_TextBox();
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                DialogResult ds = MessageBox.Show("Lưu Thất Bại, Thử Lại ?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (ds == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (kieuForm == 1)
            {
                Luu_Them();
            }
            if (kieuForm == 2)
            {
                Luu_Sua();
            }
        }

    }
}