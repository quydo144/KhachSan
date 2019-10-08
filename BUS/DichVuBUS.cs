using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class DichVuBUS
    {
        DichVuDAL dvdal = new DichVuDAL();
        public List<eDichVu> getdv()
        {
            return dvdal.getdv();
        }
    }
}
