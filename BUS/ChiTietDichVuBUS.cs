using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class ChiTietDichVuBUS
    {
        ChiTietDichVuDAL ctdvdal = new ChiTietDichVuDAL();

        public int insertCTDV(eChiTetDichVu ctdvnew)
        {
            return ctdvdal.insertCTDV(ctdvnew);
        }

        public bool maThue_maDV_CoTonTai(string maThue, string maDV)
        {
            return ctdvdal.maThue_maDV_CoTonTai(maThue, maDV);
        }

        public List<eChiTetDichVu> getctdv(string maThue, string maKhach)
        {
            return ctdvdal.getctdv(maThue, maKhach);
        }
        public List<eChiTetDichVu> getctdv_byMaThue(string maThue)
        {
            return ctdvdal.getctdv_byMaThue(maThue);
        }
        public void updateCTDV(eChiTetDichVu update)
        {
            ctdvdal.updateCTDV(update);
        }
        public List<eChiTetDichVu> getctdv_MaThue_MaPhong(string maThue, string maPhong)
        {
            return ctdvdal.getctdv_MaThue_MaPhong(maThue, maPhong);
        }
    }
}
