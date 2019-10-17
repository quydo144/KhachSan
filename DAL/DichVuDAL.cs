using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class DichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        public List<eDichVu> getdv()
        {
            var listdv = (from x in db.DichVus select x).ToList();
            List<eDichVu> ls = new List<eDichVu>();
            foreach (DichVu item in listdv)
            {
                eDichVu dv = new eDichVu();
                dv.MaDV = item.maDV;
                dv.TenDV = item.tenDichVu;
                dv.DonGia = Convert.ToDecimal(item.donGia);
                dv.SoLuong = Convert.ToInt32(item.soLuongDV);
                ls.Add(dv);
            }
            return ls;
        }
    }
}
