using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entyti
{
    public class eHoaDonTienPhong
    {
        private string maHDPhong, maThue, ghiChu;
        private DateTime ngayLap;
        private float thueVAT, khuyenMai;
        private TimeSpan gioLap;
        private double tienKhac;

        public eHoaDonTienPhong(string maHDPhong, string maThue, string ghiChu, DateTime ngayLap, float thueVAT, float khuyenMai, TimeSpan gioLap, double tienKhac)
        {
            this.maHDPhong = maHDPhong;
            this.maThue = maThue;
            this.ghiChu = ghiChu;
            this.ngayLap = ngayLap;
            this.thueVAT = thueVAT;
            this.khuyenMai = khuyenMai;
            this.gioLap = gioLap;
            this.tienKhac = tienKhac;
        }

        public eHoaDonTienPhong()
        {

        }

        public string MaHDPhong
        {
            get
            {
                return maHDPhong;
            }

            set
            {
                maHDPhong = value;
            }
        }

        public string MaThue
        {
            get
            {
                return maThue;
            }

            set
            {
                maThue = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return ngayLap;
            }

            set
            {
                ngayLap = value;
            }
        }

        public float ThueVAT
        {
            get
            {
                return thueVAT;
            }

            set
            {
                thueVAT = value;
            }
        }

        public float KhuyenMai
        {
            get
            {
                return khuyenMai;
            }

            set
            {
                khuyenMai = value;
            }
        }

        public TimeSpan GioLap
        {
            get
            {
                return gioLap;
            }

            set
            {
                gioLap = value;
            }
        }

        public double TienKhac
        {
            get
            {
                return tienKhac;
            }

            set
            {
                tienKhac = value;
            }
        }

        public double tinhTienPhuThu(eChiTietThuePhong item, double tienPhong)
        {
            double phuThu = 0;
            TimeSpan nhan13h = new TimeSpan(13, 00, 00);
            TimeSpan nhan11h = new TimeSpan(11, 00, 00);
            TimeSpan nhan8h = new TimeSpan(8, 00, 00);
            TimeSpan nhan6h = new TimeSpan(6, 00, 00);
            if (item.GioVao <= nhan13h && item.GioVao > nhan11h)
            {
                phuThu = 0.3 * tienPhong;
            }
            else if (item.GioVao <= nhan11h && item.GioVao > nhan8h)
            {
                phuThu = 0.5 * tienPhong;
            }
            else if (item.GioVao < nhan6h)
            {
                phuThu = 0;
            }
            else if (item.GioVao >= nhan13h)
            {
                phuThu = 0;
            }
            return phuThu;
        }

        public double tinhTienPhong(eChiTietThuePhong tp, double tienPhong, DateTime nhanPhong, DateTime traPhong)
        {
            double money = 0;
            TimeSpan date = traPhong - nhanPhong;
            int ngay = date.Days;
            int h = date.Hours;
            int m = date.Minutes;
            //Tính thuê theo giờ
            if (ngay == 0 && h == 0)
            {
                money = (0.2 * tienPhong);
            }
            if (ngay == 0 && h == 1)
            {
                money = (0.3 * tienPhong);
            }
            if (ngay == 0 && h >= 2)
            {
                money = (0.5 * tienPhong);
            }
            if (ngay == 0 && h >= 5)
            {
                money = tienPhong;
            }
            //Tính thuê theo ngày
            if (ngay > 0 && h >= 6)
            {
                money = (ngay * tienPhong + tienPhong);
            }
            if (ngay > 0 && h < 6)
            {
                money = (ngay * tienPhong);
            }
            return money;
        }
    }

}
