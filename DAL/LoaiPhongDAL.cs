using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class LoaiPhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        
        public List<eLoaiPhong> getalllp()
        {
            var ls = (from x in db.LoaiPhongs select x).ToList();
            List<eLoaiPhong> list = new List<eLoaiPhong>();
            foreach (var item in ls)
            {
                eLoaiPhong lp = new eLoaiPhong();
                lp.MaLoaiPhong = item.maLoaiPhong.Trim();
                lp.TenLoaiPhong = item.tenLoaiPhong.Trim();
                lp.DonGia = Convert.ToDouble(item.donGia);
                lp.SoNguoi = Convert.ToInt32(item.soNguoiToiDa);
                list.Add(lp);
            }
            return list;
        }

        public double donGia(string maLoaiPhong)
        {
            LoaiPhong lp = db.LoaiPhongs.Where(n => n.maLoaiPhong.Trim().Equals(maLoaiPhong)).SingleOrDefault();
            return Convert.ToDouble(lp.donGia);
        }
    }
}
