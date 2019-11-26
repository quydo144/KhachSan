using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class DoanBUS
    {
        DoanDAL ddal = new DoanDAL();
        public string getmaDoanID()
        {
            return ddal.getDoanID();
        }
        public int insertDoan(eDoan newd)
        {
            return ddal.insertDoan(newd);
        }
        public string getTen_ById(string id)
        {
            return ddal.getTen_ById(id);
        }
        public List<eDoan> getdoans()
        {
            return ddal.getdoans();
        }
        public string getTruongDoan_ByTenDoan(string tenDoan)
        {
            return ddal.getTruongDoan_ByTenDoan(tenDoan);
        }
        public string getId_ByTenDoan(string tendoan)
        {
            return ddal.getId_ByTenDoan(tendoan);
        }
        public eDoan getdoan_sdt(string sdt)
        {
            return ddal.getdoan_sdt(sdt);
        }
        public eDoan getdoan_ID(string id)
        {
            return ddal.getdoan_ID(id);
        }
    }
}
