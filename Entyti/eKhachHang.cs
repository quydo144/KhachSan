using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eKhachHang
    {
        private string maKH, tenKH, soCMND, soDT;
        private bool gioiTinh;
        private string soPhong;
        private string thoiGianNhanPhong;

        public eKhachHang(string thoiGianNhanPhong, string soPhong, string maKH, string tenKH, string soCMND, string soDT, bool gioiTinh)
        {
            this.maKH = maKH;
            this.tenKH = tenKH;
            this.soCMND = soCMND;
            this.soDT = soDT;
            this.gioiTinh = gioiTinh;
            this.soPhong = soPhong;
            this.thoiGianNhanPhong = thoiGianNhanPhong;
        }

        public eKhachHang()
        {

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

        public string SoPhong
        {
            get
            {
                return soPhong;
            }

            set
            {
                soPhong = value;
            }
        }

        public string ThoiGianNhanPhong
        {
            get
            {
                return thoiGianNhanPhong;
            }

            set
            {
                thoiGianNhanPhong = value;
            }
        }
    }
}
