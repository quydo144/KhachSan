using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
  public class eBC_DoanhThuDV
    {
        private string tenPhong;
        private string tenKH;
        private DateTime ngayLap;
        private double tienDV;

        public string TenPhong
        {
            get
            {
                return tenPhong;
            }

            set
            {
                tenPhong = value;
            }
        }

        public string TenKH
        {
            get
            {
                return tenKH;
            }

            set
            {
                tenKH = value;
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

        public double TienDV
        {
            get
            {
                return tienDV;
            }

            set
            {
                tienDV = value;
            }
        }

        public eBC_DoanhThuDV(string tenPhong, string tenKH, DateTime ngayLap, double tienDV)
        {
            this.TenPhong = tenPhong;
            this.TenKH = tenKH;
            this.NgayLap = ngayLap;
            this.TienDV = tienDV;
        }
        public eBC_DoanhThuDV()
        {
           
        }
    }
}
