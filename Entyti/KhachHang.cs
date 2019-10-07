using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class KhachHang
    {
        private string maKH, tenKH, soCMND, soDT;
        private bool gioiTinh;

        public KhachHang(string maKH, string tenKH, string soCMND, string soDT, bool gioiTinh)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soCMND = soCMND;
            this.soDT = soDT;
            this.gioiTinh = gioiTinh;
        }

        public KhachHang()
        {
            this.maKH = "";
            this.tenKH = "";
            this.soCMND = "";
            this.soDT = "";
            this.gioiTinh = true;
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

        public string SoCMND
        {
            get
            {
                return soCMND;
            }

            set
            {
                soCMND = value;
            }
        }

        public string SoDT
        {
            get
            {
                return soDT;
            }

            set
            {
                soDT = value;
            }
        }

        public bool GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }
    }
}
