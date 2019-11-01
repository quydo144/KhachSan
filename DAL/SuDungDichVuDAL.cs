using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class SuDungDichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public eSuDungDichVu maTangTuDong()
        {
            eSuDungDichVu sddv = new eSuDungDichVu();
            SuDungDichVu item = (from x in db.SuDungDichVus orderby x.maSDDV descending select x).FirstOrDefault();
            sddv.MaSDDV = item.maSDDV;
            sddv.MaDV = item.maDV;
            sddv.MaThue = item.maThue;
            sddv.SoLuong = item.soLuong;
            sddv.NgaySD = item.ngaySuDung;
            sddv.GioSD = item.gioSuDung;
            return sddv;
        }

        public int insertCTDV(eSuDungDichVu ctdvnew)
        {
            SuDungDichVu ctdvtemp = new SuDungDichVu();
            ctdvtemp.maSDDV = ctdvnew.MaSDDV;
            ctdvtemp.maDV = ctdvnew.MaDV;
            ctdvtemp.maThue = ctdvnew.MaThue;
            ctdvtemp.soLuong = ctdvnew.SoLuong;
            ctdvtemp.ngaySuDung = ctdvnew.NgaySD;
            ctdvtemp.gioSuDung = ctdvnew.GioSD;
            db.SuDungDichVus.InsertOnSubmit(ctdvtemp);
            db.SubmitChanges();
            return 1;
        }
    }
}
