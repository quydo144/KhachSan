using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
