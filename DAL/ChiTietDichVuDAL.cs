using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class ChiTietDichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertCTDV(eChiTetDichVu ctdvnew)
        {
            ChiTietDichVu temp = new ChiTietDichVu();
            temp.maThue = ctdvnew.MaThue;
            temp.maPhong = ctdvnew.MaPhong;
            temp.maKhach = ctdvnew.MaKhach;
            temp.maDV = ctdvnew.MaDV;
            temp.soLuong = ctdvnew.SoLuong;
            db.ChiTietDichVus.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public bool maThue_maDV_CoTonTai(string maThue, string maDV)
        {
            ChiTietDichVu ctdv = db.ChiTietDichVus.Where(x => x.maThue.Equals(maThue) && x.maDV.Equals(maDV)).SingleOrDefault();
            if (ctdv == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<eChiTetDichVu> getctdv(string maThue, string maKhach)
        {
            var listdv = db.ChiTietDichVus.Where(x => x.maThue.Trim().Equals(maThue) && x.maKhach.Trim().Equals(maKhach)).ToList();
            List<eChiTetDichVu> ls = new List<eChiTetDichVu>();
            foreach (ChiTietDichVu item in listdv)
            {
                eChiTetDichVu dv = new eChiTetDichVu();
                dv.MaDV = item.maDV.Trim();
                dv.MaThue = item.maThue.Trim();
                dv.SoLuong = Convert.ToInt32(item.soLuong);
                dv.MaKhach = item.maKhach;
                dv.MaPhong = item.maPhong;
                ls.Add(dv);
            }
            return ls;
        }

        public List<eChiTetDichVu> getctdv_byMaThue(string maThue)
        {
            var listdv = db.ChiTietDichVus.Where(x => x.maThue.Trim().Equals(maThue)).ToList();
            List<eChiTetDichVu> ls = new List<eChiTetDichVu>();
            foreach (ChiTietDichVu item in listdv)
            {
                eChiTetDichVu dv = new eChiTetDichVu();
                dv.MaDV = item.maDV.Trim();
                dv.MaThue = item.maThue.Trim();
                dv.SoLuong = Convert.ToInt32(item.soLuong);
                dv.MaKhach = item.maKhach;
                dv.MaPhong = item.maPhong;
                ls.Add(dv);
            }
            return ls;
        }

        public void updateCTDV(eChiTetDichVu update)
        {
            IQueryable<ChiTietDichVu> p = db.ChiTietDichVus.Where(x => x.maThue.Equals(update.MaThue) && x.maDV.Equals(update.MaDV));
            p.First().soLuong = update.SoLuong;
            db.SubmitChanges();
        }

        public List<eChiTetDichVu> getctdv_MaThue_MaPhong(string maThue, string maPhong)
        {
            var listdv = db.ChiTietDichVus.Where(x => x.maThue.Trim().Equals(maThue) && x.maPhong.Trim().Equals(maPhong)).ToList();
            List<eChiTetDichVu> ls = new List<eChiTetDichVu>();
            foreach (ChiTietDichVu item in listdv)
            {
                eChiTetDichVu dv = new eChiTetDichVu();
                dv.MaDV = item.maDV.Trim();
                dv.MaThue = item.maThue.Trim();
                dv.SoLuong = Convert.ToInt32(item.soLuong);
                dv.MaKhach = item.maKhach;
                dv.MaPhong = item.maPhong;
                ls.Add(dv);
            }
            return ls;
        }
    }
}
