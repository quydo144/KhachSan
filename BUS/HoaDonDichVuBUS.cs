using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Entyti;
using DAL;

namespace BUS
{
    public class HoaDonDichVuBUS
    {
        HoaDonDichVuDAL hddvdal = new HoaDonDichVuDAL();

        public int insertThanhToanDV(eHoaDonDichVu dv)
        {
            return hddvdal.insertThanhToanDV(dv);
        }

        public string gemaHD_BymaThue_maPhong(string mathue, string maphong)
        {
            return hddvdal.gemaHD_BymaThue_maPhong(mathue, maphong);
        }

        public bool kiemTraTonTai(string maThue, string maPhong)
        {
            return hddvdal.kiemTraTonTai(maThue, maPhong);
        }

        public ArrayList getMaThue_byNgay(DateTime date, string maNV)
        {
            return hddvdal.getMaThue_byNgay(date, maNV);
        }

        public ArrayList getMaThue_byNgay_to_Ngay(DateTime date1, DateTime date2, string maNV)
        {
            return hddvdal.getMaThue_byNgay_to_Ngay(date1, date2, maNV);
        }

        public ArrayList getMaThue_byNgay_All(DateTime date)
        {
            return hddvdal.getMaThue_byNgay_All(date);
        }

        public ArrayList getMaThue_byNgay_to_Ngay_All(DateTime date1, DateTime date2)
        {
            return hddvdal.getMaThue_byNgay_to_Ngay_All(date1, date2);
        }

        public DateTime getNgay_byMaThue(string maThue)
        {
            return hddvdal.getNgay_byMaThue(maThue);
        }
    }
}
