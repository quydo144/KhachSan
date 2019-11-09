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
    }
}
