using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class HoaDonTienPhongBUS
    {
        ThanhToanHoaDonTienPhongDAL ttdal = new ThanhToanHoaDonTienPhongDAL();

        public int insertThanhToan(eHoaDonTienPhong tt)
        {
            return ttdal.insertThanhToan(tt);
        }
        public string gemaHD_BymaThue(string id)
        {
            return ttdal.gemaHD_BymaThue(id);
        }
    }
}
