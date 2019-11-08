﻿using System;
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
        }

        private void txtTK_Enter(object sender, EventArgs e)
        {
            txtTK.ForeColor = Color.Black;
            txtTK.Clear();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            KhachHangBUS khbus = new KhachHangBUS();
            eKhachHang newkh = new eKhachHang();
            newkh.TenKH = txtTenKH.Text;
            newkh.SoCMND = txtCMND.Text;
            newkh.SoDT = txtSDT.Text;
            if (radNam.Checked == true) newkh.GioiTinh = true;
            else newkh.GioiTinh = false;
            newkh.MaDoan = "";
            int kq = khbus.InsertKH(newkh);
        }

        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            PhongBUS pbus = new PhongBUS();
            JoinTable_BUS joinbus = new JoinTable_BUS();
            frm.AnflowLayoutPanel();
            frm.TaoGiaoDienPhong(pbus.getallp(), pbus.gettinhtrangp(false), joinbus.GetPhong_ThuePhong(true, 0), "Phòng");
        }
    }
}