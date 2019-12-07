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
    public class HoaDonTienPhongBUS
    {
        HoaDonTienPhongDAL ttdal = new HoaDonTienPhongDAL();

        public int insertThanhToan(eHoaDonTienPhong tt)
        {
            return ttdal.insertThanhToan(tt);
        }
        public string gemaHD_BymaThue(string id)
        {
            return ttdal.gemaHD_BymaThue(id);
        }
        public ArrayList getMaThue_byNgay(DateTime date, string maNV)
        {
            return ttdal.getMaThue_byNgay(date,maNV);
        }
        public ArrayList getMaThue_byNgay_to_Ngay(DateTime date1, DateTime date2, string maNV)
        {
            return ttdal.getMaThue_byNgay_to_Ngay(date1, date2,maNV);
        }
        public ArrayList getMaThue_byNgay_All(DateTime date)
        {
            return ttdal.getMaThue_byNgay_All(date);
        }
        public ArrayList getMaThue_byNgay_to_Ngay_All(DateTime date1, DateTime date2)
        {
            return ttdal.getMaThue_byNgay_to_Ngay_All(date1, date2);
        }
        public ArrayList getMaThue_byThang_Nam(int thang, int nam)
        {
            return ttdal.getMaThue_byThang_Nam(thang, nam);
        }
        public ArrayList getMaThue_byNam(int nam)
        {
            return ttdal.getMaThue_byNam(nam);
        }
        public ArrayList getMaThue_byQui_Nam(int q, int nam)
        {
            return ttdal.getMaThue_byQui_Nam(q, nam);
        }
    }
}
