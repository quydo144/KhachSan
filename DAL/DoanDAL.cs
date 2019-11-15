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
            Doan d = (from x in db.Doans orderby x.maDoan descending select x).FirstOrDefault();
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
        public List<eDoan> getdoans()
        {
            var listd = (from x in db.Doans select x).ToList();
            List<eDoan> ls = new List<eDoan>();
            foreach (Doan item in listd)
            {
                eDoan d = new eDoan();
                d.MaDoan = item.maDoan.Trim();
                d.TenDoan = item.tenDoan.Trim();
                d.MaTruongDoan = item.maTruongDoan.Trim();
                d.DiaChi = item.diaChi.Trim();
                ls.Add(d);
            }
            return ls;
        }
        public string getTen_ById(string id)
        {
            Doan d = db.Doans.Where(x => x.maDoan.Equals(id)).SingleOrDefault();
            return d.tenDoan;
        }
        public string getTD_ByTenDoan(string id)
        {
            Doan d = db.Doans.Where(x => x.tenDoan.Contains(id)).SingleOrDefault();
            return d.maTruongDoan;
        }
        public string getId_ByTenDoan(string tendoan)
        {
            Doan d = db.Doans.Where(x => x.tenDoan.Contains(tendoan)).SingleOrDefault();
            return d.maDoan;
        }
    }
}
