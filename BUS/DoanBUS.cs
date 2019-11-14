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
    }
}
