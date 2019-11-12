using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eChiTetDichVu
    {
        private string maThue, maKhach, maPhong, maDV;
        private int soLuong;

        public eChiTetDichVu(string maThue, string maKhach, string maPhong, string maDV, int soLuong)
        {
            this.maThue = maThue;
            this.maKhach = maKhach;
            this.maPhong = maPhong;
            this.maDV = maDV;
            this.soLuong = soLuong;
        }

        public eChiTetDichVu()
        {

        }

        public string MaDV
        {
            get
            {
                return maDV;
            }

            set
            {
                maDV = value;
            }
        }

        public string MaKhach
        {
            get
            {
                return maKhach;
            }

            set
            {
                maKhach = value;
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

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }
    }
}
