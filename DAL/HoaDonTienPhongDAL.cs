using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Entyti;

namespace DAL
{
    public class HoaDonTienPhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThanhToan(eHoaDonTienPhong tt)
        {
            HoaDonTienPhong temp = new HoaDonTienPhong();
            temp.maThue = tt.MaThue;
            temp.ngayLap = tt.NgayLap.Date;
            temp.gioLap = tt.GioLap;
            temp.thueVAT = tt.ThueVAT;
            temp.khuyenMai = tt.KhuyenMai;
            temp.ghiChu = tt.GhiChu;
            db.HoaDonTienPhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }
        public string gemaHD_BymaThue(string id)
        {
            HoaDonTienPhong nv = db.HoaDonTienPhongs.Where(x => x.maThue.Equals(id)).SingleOrDefault();
            return nv.maHDPhong;
        }

        public ArrayList getMaThue_byNgay(DateTime date, string maNV)
        {
            ArrayList maThue = new ArrayList();
            var list = from hdtp in db.HoaDonTienPhongs
                       join tp in db.ThuePhongs on hdtp.maThue equals tp.maThue
                       where hdtp.ngayLap == date && tp.maNV.Equals(maNV)
                       select new { hdtp.maThue };
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNgay_to_Ngay(DateTime date1, DateTime date2, string maNV)
        {
            ArrayList maThue = new ArrayList();
            var list = from hdtp in db.HoaDonTienPhongs
                       join tp in db.ThuePhongs on hdtp.maThue equals tp.maThue
                       where date1 <= hdtp.ngayLap && hdtp.ngayLap <= date2 && tp.maNV.Equals(maNV)
                       select new { hdtp.maThue };
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNgay_All(DateTime date)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonTienPhongs.Where(x => x.ngayLap == date).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNgay_to_Ngay_All(DateTime date1, DateTime date2)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonTienPhongs.Where(x => date1 <= x.ngayLap && x.ngayLap <= date2).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byThang_Nam(int thang, int nam)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonTienPhongs.Where(x => x.ngayLap.Month == thang && x.ngayLap.Year == nam).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byQui_Nam(int q , int nam)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonTienPhongs.Where(x => ((x.ngayLap.Month - 1) / 3) + 1 == q && x.ngayLap.Year == nam).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

        public ArrayList getMaThue_byNam( int nam)
        {
            ArrayList maThue = new ArrayList();
            var list = db.HoaDonTienPhongs.Where(x => x.ngayLap.Year == nam).ToList();
            foreach (var item in list)
            {
                maThue.Add(item.maThue);
            }
            return maThue;
        }

    }
}
