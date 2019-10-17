using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class KhachHangBUS
    {
        KhachHangDAL khdal = new KhachHangDAL();
        public List<eKhachHang> get()
        {
            return khdal.get();
        }

        public List<eKhachHang> getcmnd(string s)
        {
            return khdal.getcmnd(s);
        }
    }
}
