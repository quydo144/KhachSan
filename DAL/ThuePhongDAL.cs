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
            temp.maThue = "";
            temp.maNV = newtp.MaNV;
            temp.soLuongPhong = newtp.SoLuongPhong;
            temp.trangThai = Convert.ToByte(newtp.TrangThai);
            db.ThuePhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public List<eThuePhong> getMaThue(string s)
        {
            var list = (from x in db.ThuePhongs where x.maThue.Trim().Equals(s.Trim()) select x).ToList();
            List<eThuePhong> ls = new List<eThuePhong>();
            foreach (ThuePhong item in list)
            {
                eThuePhong tp = new eThuePhong();
                tp.MaThue = item.maThue.Trim();
                tp.MaNV = item.maNV.Trim();
                ls.Add(tp);
            }
            return ls;
        }

        public string getMaThueCuoi()
        {
            ThuePhong tp = (from x in db.ThuePhongs orderby x.maThue descending select x).FirstOrDefault();
            return tp.maThue;
        }

        //public string getMaThue_ByMaPhongTrangThai(string maPhong, int trangThai)
        //{
        //    ThuePhong tp = db.ThuePhongs.Where(x => x.maPhong.Equals(maPhong) && x.trangThai == 0).FirstOrDefault();   //
        //    return tp.maThue;
        //}

        public void updateThuePhong(eThuePhong tp)
        {
            IQueryable<ThuePhong> tphong = db.ThuePhongs.Where(x => x.maThue.Equals(tp.MaThue));
            tphong.First().trangThai = Convert.ToByte(tp.TrangThai);
            db.SubmitChanges();
        }

        //public string getMaPhong_ByMaThueTrangThai(string maThue, int trangThai)
        //{
        //    ThuePhong tp = db.ThuePhongs.Where(x => x.maThue.Equals(maThue) && x.trangThai == 0).SingleOrDefault();
        //    return tp.maPhong;
        //}

        //public string getmaThue_ByMaPhongTrangThai(string maPhong, int trangThai)
        //{
        //    ThuePhong tp = db.ThuePhongs.Where(x => x.maPhong.Equals(maPhong) && x.trangThai == 0).SingleOrDefault();
        //    return tp.maThue;
        //}
    }
}
