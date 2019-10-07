using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class DichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        public List<ePhong> getphong()
        {
            var lsphong = (from x in db.Phongs select x).ToList();
            foreach (Phong item in lsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.LoaiPhong = item.LoaiPhong;
            }
        }
    }
}
