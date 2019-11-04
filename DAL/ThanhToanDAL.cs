﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class ThanhToanDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThanhToan(eThanhToan tt)
        {
            ThanhToan temp = new ThanhToan();
            temp.maThuePhong = tt.MaThuePhong;
            temp.ngayLap = tt.NgayLap.Date;
            temp.gioLap = tt.GioLap;
            temp.thueVAT = tt.ThueVAT;
            temp.giamGia = tt.GiamGia;
            db.ThanhToans.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }
    }
}
