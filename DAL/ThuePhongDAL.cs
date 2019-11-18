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
            temp.maDoan = newtp.MaDoan;
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
                tp.MaDoan = item.maDoan;
                tp.SoLuongPhong = item.soLuongPhong;
                tp.TrangThai = Convert.ToBoolean(item.trangThai);
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

        public string getMaDoan_ByMaThue(string maThue)
        {
            ThuePhong tp = db.ThuePhongs.Where(x => x.maThue.Equals(maThue)).SingleOrDefault();
            return tp.maDoan;
        }

        public void updateThuePhong(eThuePhong tp)
        {
            IQueryable<ThuePhong> tphong = db.ThuePhongs.Where(x => x.maThue.Equals(tp.MaThue));
            tphong.First().trangThai = Convert.ToByte(tp.TrangThai);
            db.SubmitChanges();
        }
        public string getMaThue_ByMaDoan(string madoan, byte trangThai)
        {
            ThuePhong tp = db.ThuePhongs.Where(x => x.maDoan.Equals(madoan) && x.trangThai == trangThai).SingleOrDefault();
            return tp.maThue;
        }

    }
}
