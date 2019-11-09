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
            db.ChiTietThuePhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }

    }
}
