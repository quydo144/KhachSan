﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class ThuePhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThuePhong(eThuePhong newtp)
        {
            ThuePhong temp = new ThuePhong();
            temp.maThuePhong = newtp.MaThuePhong;
            temp.maKhach = newtp.MaKH;
            temp.maNV = newtp.MaNV;
            temp.maPhong = newtp.MaPhong;
            temp.maSDDV = newtp.MaSddv;
            temp.ngayVao = newtp.NgayVao;
            temp.ngayRa = newtp.NgayRa;
            temp.datCoc = newtp.DatCoc;
            db.ThuePhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public eThuePhong maTangTuDong()
        {
            eThuePhong thuephong = new eThuePhong();
            ThuePhong item = (from x in db.ThuePhongs orderby x.maThuePhong descending select x).FirstOrDefault();
            thuephong.MaThuePhong = item.maThuePhong;
            thuephong.MaPhong = item.maPhong;
            thuephong.MaKH = item.maKhach;
            thuephong.MaNV = item.maNV;
            thuephong.MaSddv = item.maSDDV;
            thuephong.NgayVao = item.ngayVao;
            thuephong.NgayRa = item.ngayRa;
            thuephong.DatCoc = item.datCoc;
            return thuephong;
        }
    }
}
