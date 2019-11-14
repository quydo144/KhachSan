using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class DoanDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        public string getDoanID()
        {
            Doan d = (from x in db.Doans orderby x.maDoan select x).SingleOrDefault();
            return d.maDoan;
        }
        public int insertDoan(eDoan newd)
        {
            Doan temd = new Doan();
            temd.maDoan = "";
            temd.diaChi = newd.DiaChi;
            temd.maTruongDoan = newd.MaTruongDoan;
            temd.tenDoan = newd.TenDoan;
            db.Doans.InsertOnSubmit(temd);
            db.SubmitChanges();
            return 1;
        }
    }
}
