using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class ThuePhongBUS
    {
        ThuePhongDAL tpdal = new ThuePhongDAL();

        public eThuePhong tangma()
        {
            return tpdal.maTangTuDong();
        }
    }
}
