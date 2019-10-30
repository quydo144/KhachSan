using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class PhongBUS
    {
        PhongDAL pdal = new PhongDAL();
        public List<ePhong> getallp()
        {
            return pdal.getallphong();
        }
        public List<ePhong> gettinhtrangp(bool tinhtrang)
        {
            return pdal.gettinhtrangphong(tinhtrang);
        }
        public string maPhong(string ten)
        {
            return pdal.maPhong(ten);
        }
        public void updateTinhTrangPhong(ePhong pupdate)
        {
           pdal.updateTinhTrangPhong(pupdate);
        }
    }
}
