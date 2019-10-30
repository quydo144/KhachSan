using System;
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
            temp.maThue = newtp.MaThuePhong;
            temp.maKhach = newtp.MaKH;
            temp.maNV = newtp.MaNV;
            temp.maPhong = newtp.MaPhong;
            temp.ngayVao = newtp.NgayVao;
            temp.ngayRa = newtp.NgayRa;
            db.ThuePhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public eThuePhong maTangTuDong()
        {
            eThuePhong thuephong = new eThuePhong();
            ThuePhong item = (from x in db.ThuePhongs orderby x.maThue descending select x).FirstOrDefault();
            thuephong.MaThuePhong = item.maThue;
            thuephong.MaPhong = item.maPhong;
            thuephong.MaKH = item.maKhach;
            thuephong.MaNV = item.maNV;
            thuephong.NgayVao = item.ngayVao;
            thuephong.NgayRa = item.ngayRa;
            return thuephong;
        }
    }
}
