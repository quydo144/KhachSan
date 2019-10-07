using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class ePhong
    {
        private string maPhong, tenPhong, ghiChu;
        private eLoaiPhong loaiPhong;
        private int tang;

        public ePhong(string maPhong, string tenPhong, string ghiChu, eLoaiPhong loaiPhong, int tang)
        {
            this.maPhong = maPhong;
            this.tenPhong = tenPhong;
            this.ghiChu = ghiChu;
            this.loaiPhong = loaiPhong;
            this.tang = tang;
        }

        public ePhong()
        {
            this.maPhong = "";
            this.tenPhong = "";
            this.ghiChu = "";
            this.loaiPhong = null;
            this.tang = 0;
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

        public eLoaiPhong LoaiPhong
        {
            get
            {
                return loaiPhong;
            }

            set
            {
                loaiPhong = value;
            }
        }

        public int Tang
        {
            get
            {
                return tang;
            }

            set
            {
                tang = value;
            }
        }
    }
}