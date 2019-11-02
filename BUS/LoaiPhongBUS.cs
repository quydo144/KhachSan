using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class LoaiPhongBUS
    {
        LoaiPhongDAL lpdal = new LoaiPhongDAL();
        public List<eLoaiPhong> getall()
        {
            return lpdal.getalllp();
        }
        public double donGia(string maLoaiPhong)
        {
            return lpdal.donGia(maLoaiPhong);
        }
    }
}
