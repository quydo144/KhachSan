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
            temp.trangThai = Convert.ToByte(newtp.TrangThai);
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
            thuephong.TrangThai = item.trangThai;
            return thuephong;
        }

        public List<eThuePhong> getMaThuePhong(string s)
        {
            var list = (from x in db.ThuePhongs where x.maThue.Trim().Equals(s.Trim()) select x).ToList();
            List<eThuePhong> ls = new List<eThuePhong>();
            foreach (ThuePhong item in list)
            {
                eThuePhong tp = new eThuePhong();
                tp.MaThuePhong = item.maThue.Trim();
                tp.MaNV = item.maNV.Trim();
                tp.MaPhong = item.maPhong.Trim();
                tp.NgayRa = item.ngayRa;
                tp.MaKH = item.maKhach.Trim();
                tp.TrangThai = item.trangThai;
                tp.NgayVao = item.ngayVao;
                ls.Add(tp);
            }
            return ls;
        }
    }
}
