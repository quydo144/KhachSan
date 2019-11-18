using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class ChiTietThuePhongBUS
    {
        ChiTietThuePhongDAL cttpdal = new ChiTietThuePhongDAL();

        public int insertCTTP(eChiTietThuePhong cttpnew)
        {
            return cttpdal.insertCTTP(cttpnew);
        }

        public string getMaThue_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            return cttpdal.getMaThue_By_MaPhong_TrangThai(maPhong, trangThai);
        }

        public string getMaKhach_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            return cttpdal.getMaKhach_By_MaPhong_TrangThai(maPhong, trangThai);
        }

        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue_MaPhong(string maThue, string maPhong)
        {
            return cttpdal.getChiTietThuePhong_By_MaThue_MaPhong(maThue, maPhong);
        }

        public void updateChiTietThuePhong(eChiTietThuePhong tp)
        {
            cttpdal.updateChiTietThuePhong(tp);
        }
        public void updateTrangThaiChiTietThuePhong(eChiTietThuePhong tp)
        {
            cttpdal.updateTrangThaiChiTietThuePhong(tp);
        }
        public List<eChiTietThuePhong> getAllKHDangO()
        {
            return cttpdal.getAllKHDangO();
        }
        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue_TrangThai(string maThue, byte trangthai)
        {
            return cttpdal.getChiTietThuePhong_By_MaThue_TrangThai(maThue, trangthai);
        }
        public eChiTietThuePhong getCTTP_By_MaPhong_TrangThai(string maPhong, bool trangThai)
        {
            return cttpdal.getCTTP_By_MaPhong_TrangThai(maPhong, trangThai);
        }
        public List<eChiTietThuePhong> getChiTietThuePhong_By_MaThue(string maThue)
        {
            return cttpdal.getChiTietThuePhong_By_MaThue(maThue);
        }
    }
}
