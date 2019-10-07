using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eThanhToan
    {
        private string maHD;
        private eThuePhong thuePhong;
        private DateTime ngayLap;
        private float thueVAT, giamGia;

        public eThanhToan(string maHD, eThuePhong thuePhong, DateTime ngayLap, float thueVAT, float giamGia)
        {
            this.maHD = maHD;
            this.thuePhong = thuePhong;
            this.ngayLap = ngayLap;
            this.thueVAT = thueVAT;
            this.giamGia = giamGia;
        }

        public eThanhToan()
        {
            this.maHD = "";
            this.thuePhong = null;
            this.ngayLap = Convert.ToDateTime(0); ;
            this.thueVAT = 0;
            this.giamGia = 0;
        }

        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public eThuePhong ThuePhong
        {
            get
            {
                return thuePhong;
            }

            set
            {
                thuePhong = value;
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

        public float GiamGia
        {
            get
            {
                return giamGia;
            }

            set
            {
                giamGia = value;
            }
        }
    }
}
