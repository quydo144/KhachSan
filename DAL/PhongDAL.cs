using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class PhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        public List<ePhong> getallphong()
        {
            var litsphong = (from x in db.Phongs select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public List<ePhong> gettinhtrangphong(bool tinhtrang)
        {
            var litsphong = (from x in db.Phongs where x.tinhTrang.Equals(tinhtrang) select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }
    }
}
