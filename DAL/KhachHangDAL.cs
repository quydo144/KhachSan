using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class KhachHangDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public List<eKhachHang> get()
        {
            var listkh = (from x in db.KhachHangs select x).ToList();
            List<eKhachHang> ls = new List<eKhachHang>();
            foreach (KhachHang item in listkh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKH = item.maKH.Trim();
                kh.TenKH = item.tenKh.Trim();
                kh.SoCMND = item.soCMND.Trim();
                kh.SoDT = item.soDT.Trim();
                kh.GioiTinh = Convert.ToBoolean(item.gioiTinh);
                kh.MaDoan = item.maDoan;
                ls.Add(kh);
            }
            return ls;
        }

        public List<eKhachHang> getcmnd(string s)
        {
            var listkh = (from x in db.KhachHangs where x.soCMND.Contains(s) select x).ToList();
            List<eKhachHang> ls = new List<eKhachHang>();
            foreach (KhachHang item in listkh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKH = item.maKH.Trim();
                kh.TenKH = item.tenKh.Trim();
                kh.SoCMND = item.soCMND.Trim();
                kh.SoDT = item.soDT.Trim();
                kh.GioiTinh = Convert.ToBoolean(item.gioiTinh);
                kh.MaDoan = item.maDoan;
                ls.Add(kh);
            }
            return ls;
        }
    }
}
