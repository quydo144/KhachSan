using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class SuDungDichVuBUS
    {
        SuDungDichVuDAL sddvdal = new SuDungDichVuDAL();

        public int InsertSDDV(eSuDungDichVu p)
        {
            return sddvdal.insertCTDV(p);
        }

        public eSuDungDichVu tangma()
        {
            return sddvdal.maTangTuDong();
        }
    }
}
