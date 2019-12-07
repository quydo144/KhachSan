using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Entyti;

namespace DAL
{
    public class HoaDonDichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThanhToanDV(eHoaDonDichVu dv)
        {
            HoaDonDichVu temp = new HoaDonDichVu();
            temp.maHDDV = dv.MaHDDV;
            temp.maThue = dv.MaThue;
            temp.maPhong = dv.MaPhong;
            temp.maKhach = dv.MaKH;
            temp.ngayLap = dv.NgayLap;
            temp.gioLap = dv.GioLap;
            db.HoaDonDichVus.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public string gemaHD_BymaThue_maPhong(string mathue, string maphong)
        {
            HoaDonDichVu nv = db.HoaDonDichVus.Where(x => x.maThue.Equals(mathue) && x.maPhong.Equals(maphong)).SingleOrDefault();
            return nv.maHDDV.Trim();
        }

        public bool kiemTraTonTai(string maThue, string maPhong)
        {
            HoaDonDichVu hddv = db.HoaDonDichVus.Where(x => x.maThue.Equals(maThue) && x.maPhong.Equals(maPhong)).SingleOrDefault();
            if (hddv == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ArrayList getMaThue_byNgay(DateTime date, string maNV)
        {
            ArrayList maThue = new ArrayList();
            var list = from hddv in db.HoaDonDichVus
                       join tp in db.ThuePhongs on hddv.maThue equals tp.maThue
                       where hddv.ngayLap == date && tp.maNV.Equals(maNV)
                       select new { hddv.maThue };
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }
        public ArrayList getMaThue_byNgay_to_Ngay(DateTime date1, DateTime date2, string maNV)
        {
            ArrayList maThue = new ArrayList();
            var list = from hddv in db.HoaDonDichVus
                       join tp in db.ThuePhongs on hddv.maThue equals tp.maThue
                       where date1 <= hddv.ngayLap && hddv.ngayLap <= date2 && tp.maNV.Equals(maNV)
                       select new { hddv.maThue };
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNgay_All(DateTime date)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonDichVus.Where(x => x.ngayLap == date).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNgay_to_Ngay_All(DateTime date1, DateTime date2)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonDichVus.Where(x => date1 <= x.ngayLap && x.ngayLap <= date2).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }
        public DateTime getNgay_byMaThue(string maThue)
        {
            HoaDonDichVu hddv = db.HoaDonDichVus.Where(x => x.maThue.Equals(maThue)).FirstOrDefault();
            return Convert.ToDateTime(hddv.ngayLap);
        }
    }
}
