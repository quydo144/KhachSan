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
                ls.Add(kh);
            }
            return ls;
        }
        public int insertKH(eKhachHang khmoi)
        {
            KhachHang khtemp = new KhachHang();
            khtemp.maKH = "";
            khtemp.soCMND = khmoi.SoCMND;
            khtemp.soDT = khmoi.SoDT;
            khtemp.tenKh = khmoi.TenKH;
            khtemp.gioiTinh = Convert.ToByte(khmoi.GioiTinh);
            db.KhachHangs.InsertOnSubmit(khtemp);
            db.SubmitChanges();
            return 1;
        }
        public List<eKhachHang> getcmnd(string s)
        {
            var listkh = db.KhachHangs.Where(x => x.soCMND.Trim().Equals(s)).ToList();
            List<eKhachHang> ls = new List<eKhachHang>();
            foreach (KhachHang item in listkh)
            {
                eKhachHang kh = new eKhachHang();
                kh.MaKH = item.maKH.Trim();
                kh.TenKH = item.tenKh.Trim();
                kh.SoCMND = item.soCMND.Trim();
                kh.SoDT = item.soDT.Trim();
                kh.GioiTinh = Convert.ToBoolean(item.gioiTinh);
                ls.Add(kh);
            }
            return ls;
        }

        public eKhachHang getmaKH(string s)
        {
            KhachHang item = (from x in db.KhachHangs where x.maKH.Trim().Equals(s) select x).SingleOrDefault();
            eKhachHang kh = new eKhachHang();
            kh.MaKH = item.maKH.Trim();
            kh.TenKH = item.tenKh.Trim();
            kh.SoCMND = item.soCMND.Trim();
            kh.SoDT = item.soDT.Trim();
            kh.GioiTinh = Convert.ToBoolean(item.gioiTinh);
            return kh;
        }

        public string getenKH_ByID(string id)
        {
            KhachHang nv = db.KhachHangs.Where(x => x.maKH.Equals(id)).SingleOrDefault();
            return nv.tenKh;
        }

        public string gemaKH_ByCMND(string cmnd)
        {
            KhachHang kh = db.KhachHangs.Where(x => x.soCMND.Equals(cmnd)).SingleOrDefault();
            return kh.maKH;
        }

        public eKhachHang getallKhDangO(string maKH)
        {
            var item = (from x in db.KhachHangs where x.maKH.Equals(maKH) select x).SingleOrDefault();
            eKhachHang kh = new eKhachHang();
            kh.MaKH = item.maKH;
            kh.TenKH = item.tenKh.Trim();
            kh.SoCMND = item.soCMND.Trim();
            kh.SoDT = item.soDT.Trim();
            kh.GioiTinh = Convert.ToBoolean(item.gioiTinh);
            return kh;
        }

        public void updateKH(eKhachHang kh)
        {
            IQueryable<KhachHang> item = db.KhachHangs.Where(x => x.maKH.Equals(kh.MaKH));
            item.First().tenKh = kh.TenKH;
            item.First().soCMND = kh.SoCMND;
            item.First().soDT = kh.SoDT;
            item.First().gioiTinh = Convert.ToByte(kh.GioiTinh);
            db.SubmitChanges();
        }
    }
}
