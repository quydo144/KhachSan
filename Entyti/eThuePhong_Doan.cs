using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eThuePhong_Doan
    {
        string tenphong, ghiChu;
        double tienPhong, tienDV, tienKM, tienKhac, tienVat;

        public eThuePhong_Doan(string tenphong, string ghiChu, double tienPhong, double tienDV, double tienKM, double tienKhac, double tienVat)
        {
            this.Tenphong = tenphong;
            this.GhiChu = ghiChu;
            this.TienPhong = tienPhong;
            this.TienDV = tienDV;
            this.TienKM = tienKM;
            this.TienKhac = tienKhac;
            this.TienVat = tienVat;
        }
        public eThuePhong_Doan()
        {

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

        public string Tenphong
        {
            get
            {
                return tenphong;
            }

            set
            {
                tenphong = value;
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

        public double TienKM
        {
            get
            {
                return tienKM;
            }

            set
            {
                tienKM = value;
            }
        }

        public double TienPhong
        {
            get
            {
                return tienPhong;
            }

            set
            {
                tienPhong = value;
            }
        }

        public double TienVat
        {
            get
            {
                return tienVat;
            }

            set
            {
                tienVat = value;
            }
        }
    }
}
