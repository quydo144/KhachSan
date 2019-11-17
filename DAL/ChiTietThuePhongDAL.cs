using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class ChiTietThuePhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertCTTP(eChiTietThuePhong cttpnew)
        {
            ChiTietThuePhong temp = new ChiTietThuePhong();
            temp.maThue = cttpnew.MaThue;
            temp.maPhong = cttpnew.MaPhong;
            temp.maKhach = cttpnew.MaKhach;
            temp.ngayRa = cttpnew.NgayRa;
            temp.ngayVao = cttpnew.NgayVao;
            temp.gioRa = cttpnew.GioRa;
            temp.gioVao = cttpnew.GioVao;
            temp.trangThai = Convert.ToByte(cttpnew.TrangThai);
            temp.ghiChu = cttpnew.GhiChu;
            temp.tienKhac = Convert.ToDecimal(cttpnew.TienKhac);
            db.ChiTietThuePhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

        public string getMaThue_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            string maThue = "";
            ChiTietThuePhong cttpnull = db.ChiTietThuePhongs.Where(x => x.maPhong.Equals(maPhong) && x.trangThai == Convert.ToByte(trangThai) && x.ghiChu == null).SingleOrDefault();          
            ChiTietThuePhong cttpkhacnull = db.ChiTietThuePhongs.Where(x => x.maPhong.Equals(maPhong) && x.trangThai == Convert.ToByte(trangThai) && x.ghiChu != null).SingleOrDefault();          
            if (cttpnull == null)
            {
                maThue = cttpkhacnull.maThue;
            }
            if (cttpkhacnull == null)
            {
                maThue = cttpnull.maThue;
            }
            return maThue;

        }

        public string getMaKhach_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            ChiTietThuePhong cttp = db.ChiTietThuePhongs.Where(x =>x.maPhong.Equals(maPhong) && x.trangThai == Convert.ToByte(trangThai)).SingleOrDefault();
            return cttp.maKhach;
        }

        public eChiTietThuePhong getCTTP_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            ChiTietThuePhong item = db.ChiTietThuePhongs.Where(x => x.maPhong.Equals(maPhong) && x.trangThai == Convert.ToByte(false)).SingleOrDefault();
            eChiTietThuePhong cttp = new eChiTietThuePhong();
            cttp.MaThue = item.maThue;
            cttp.MaKhach = item.maKhach;
            cttp.MaPhong = item.maPhong;
            cttp.NgayRa = item.ngayRa;
            cttp.NgayVao = item.ngayVao;
            cttp.GioRa = item.gioRa;
            cttp.GioVao = item.gioVao;
            cttp.TrangThai = Convert.ToBoolean(item.trangThai);
            cttp.GhiChu = item.ghiChu;
            cttp.TienKhac = Convert.ToDouble(item.tienKhac);
            return cttp;
        }

        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue(string maThue)
        {
            var list = db.ChiTietThuePhongs.Where(x => x.maThue.Equals(maThue)).ToList();
            List<eChiTietThuePhong> ls = new List<eChiTietThuePhong>();           
            foreach (var item in list)
            {
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                cttp.MaThue = item.maThue;
                cttp.MaKhach = item.maKhach;
                cttp.MaPhong = item.maPhong;
                cttp.NgayRa = item.ngayRa;
                cttp.NgayVao = item.ngayVao;
                cttp.GioRa = item.gioRa;
                cttp.GioVao = item.gioVao;
                cttp.TrangThai = Convert.ToBoolean(item.trangThai);
                ls.Add(cttp);
            }
            return ls;
        }

        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue_TrangThai(string maThue, byte trangthai)
        {
            var list = db.ChiTietThuePhongs.Where(x => x.maThue.Equals(maThue)  && x.trangThai==trangthai).ToList();
            List<eChiTietThuePhong> ls = new List<eChiTietThuePhong>();
            foreach (var item in list)
            {
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                cttp.MaThue = item.maThue;
                cttp.MaKhach = item.maKhach;
                cttp.MaPhong = item.maPhong;
                cttp.NgayRa = item.ngayRa;
                cttp.NgayVao = item.ngayVao;
                cttp.GioRa = item.gioRa;
                cttp.GioVao = item.gioVao;
                cttp.TrangThai = Convert.ToBoolean(item.trangThai);
                ls.Add(cttp);
            }
            return ls;
        }

        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue_MaPhong(string maThue, string maPhong)
        {
            var list = db.ChiTietThuePhongs.Where(x => x.maThue.Equals(maThue) && x.maPhong.Equals(maPhong)).ToList();
            List<eChiTietThuePhong> ls = new List<eChiTietThuePhong>();
            foreach (var item in list)
            {
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                cttp.MaThue = item.maThue;
                cttp.MaKhach = item.maKhach;
                cttp.MaPhong = item.maPhong;
                cttp.NgayRa = item.ngayRa;
                cttp.NgayVao = item.ngayVao;
                cttp.GioRa = item.gioRa;
                cttp.GioVao = item.gioVao;
                cttp.TrangThai = Convert.ToBoolean(item.trangThai);
                ls.Add(cttp);
            }
            return ls;
        }

        public void updateChiTietThuePhong(eChiTietThuePhong tp)
        {
            IQueryable<ChiTietThuePhong> cttp = db.ChiTietThuePhongs.Where(x => x.maThue.Equals(tp.MaThue) && x.maKhach.Equals(tp.MaKhach));
            cttp.First().trangThai = Convert.ToByte(tp.TrangThai);
            cttp.First().ngayRa = tp.NgayRa;
            cttp.First().gioRa = tp.GioRa;
            cttp.First().tienKhac = Convert.ToDecimal(tp.TienKhac);
            cttp.First().ghiChu = tp.GhiChu;
            db.SubmitChanges();
        }

        public List<eChiTietThuePhong> getAllKHDangO()
        {
            var list = db.ChiTietThuePhongs.Where(x => x.trangThai == 0 ).ToList();
            List<eChiTietThuePhong> ls = new List<eChiTietThuePhong>();
            foreach (var item in list)
            {
                eChiTietThuePhong cttp = new eChiTietThuePhong();
                cttp.MaThue = item.maThue;
                cttp.MaKhach = item.maKhach;
                cttp.MaPhong = item.maPhong;
                cttp.NgayRa = item.ngayRa;
                cttp.NgayVao = item.ngayVao;
                cttp.GioRa = item.gioRa;
                cttp.GioVao = item.gioVao;
                cttp.TrangThai = Convert.ToBoolean(item.trangThai);
                ls.Add(cttp);
            }
            return ls;
        }
    }
}
