using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class ThanhToanHoaDonTienPhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public int insertThanhToan(eHoaDonTienPhong tt)
        {
            HoaDonTienPhong temp = new HoaDonTienPhong();
            temp.maThue = tt.MaThue;
            temp.ngayLap = tt.NgayLap.Date;
            temp.gioLap = tt.GioLap;
            temp.thueVAT = tt.ThueVAT;
            temp.khuyenMai = tt.KhuyenMai;
            temp.tienKhac = Convert.ToDecimal(tt.TienKhac);
            temp.ghiChu = tt.GhiChu;
            db.HoaDonTienPhongs.InsertOnSubmit(temp);
            db.SubmitChanges();
            return 1;
        }
        public string gemaHD_BymaThue(string id)
        {
            HoaDonTienPhong nv = db.HoaDonTienPhongs.Where(x => x.maThue.Equals(id)).SingleOrDefault();
            return nv.maHDPhong;
        }
    }
}
