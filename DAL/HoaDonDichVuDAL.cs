﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class HoaDonDichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThanhToanDV(eHoaDonDichVu dv)
        {
            HoaDonDichVu temp = new HoaDonDichVu();
            temp.maHDDV = dv.MaHDDV;
            temp.maThue = dv.MaThue;
            temp.maPhong = dv.MaPhong;
            temp.maKhach = dv.MaKH;
            temp.ngayLap = dv.NgayLap;
            temp.gioLap = dv.GioLap;
            db.HoaDonDichVus.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public string gemaHD_BymaThue_maPhong(string mathue, string maphong)
        {
            HoaDonDichVu nv = db.HoaDonDichVus.Where(x => x.maThue.Equals(mathue) && x.maPhong.Equals(maphong)).SingleOrDefault();
            return nv.maHDDV.Trim();
        }

        public bool kiemTraTonTai(string maThue, string maPhong)
        {
            HoaDonDichVu hddv = db.HoaDonDichVus.Where(x => x.maThue.Equals(maThue) && x.maPhong.Equals(maPhong)).SingleOrDefault();
            if (hddv == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
