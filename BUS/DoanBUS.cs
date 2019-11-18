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
        public string getDoanID()
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
        public string getTD_ByTenDoan(string id)
        {
            return ddal.getTD_ByTenDoan(id);
        }
        public string getId_ByTenDoan(string tendoan)
        {
            return ddal.getId_ByTenDoan(tendoan);
        }
    }
}
