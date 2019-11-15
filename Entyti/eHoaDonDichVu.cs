using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eHoaDonDichVu
    {
        private string maHDDV, maThue, maKH, maPhong;

        public eHoaDonDichVu(string maHDDV, string maThue, string maKH, string maPhong)
        {
            this.maHDDV = maHDDV;
            this.maThue = maThue;
            this.maKH = maKH;
            this.maPhong = maPhong;
        }
        
        public eHoaDonDichVu()
        {

        }

        public string MaHDDV
        {
            get
            {
                return maHDDV;
            }

            set
            {
                maHDDV = value;
            }
        }

        public string MaKH
        {
            get
            {
                return maKH;
            }

            set
            {
                maKH = value;
            }
        }

        public string MaPhong
        {
            get
            {
                return maPhong;
            }

            set
            {
                maPhong = value;
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

        public double tinhDichVu(double donGia, int sluong)
        {
            double money = 0;
            money = donGia * sluong;
            return money;
        }
    }
}
