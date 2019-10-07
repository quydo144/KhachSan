using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class LoaiPhong
    {
        private string maLoaiPhong, tenLoaiPhong;
        private decimal donGia;
        private int soGiuong, soNguoi;

        public LoaiPhong(string maLoaiPhong, string tenLoaiPhong, decimal donGia, int soGiuong, int soNguoi)
        {
            this.maLoaiPhong = maLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.donGia = donGia;
            this.soGiuong = soGiuong;
            this.soNguoi = soNguoi;
        }

        public LoaiPhong()
        {
            this.maLoaiPhong = "";
            this.tenLoaiPhong = "";
            this.donGia = 0;
            this.soGiuong = 0;
            this.soNguoi = 0;
        }

        public string MaLoaiPhong
        {
            get
            {
                return maLoaiPhong;
            }

            set
            {
                maLoaiPhong = value;
            }
        }

        public string TenLoaiPhong
        {
            get
            {
                return tenLoaiPhong;
            }

            set
            {
                tenLoaiPhong = value;
            }
        }

        public decimal DonGia
        {
            get
            {
                return donGia;
            }

            set
            {
                donGia = value;
            }
        }

        public int SoGiuong
        {
            get
            {
                return soGiuong;
            }

            set
            {
                soGiuong = value;
            }
        }

        public int SoNguoi
        {
            get
            {
                return soNguoi;
            }

            set
            {
                soNguoi = value;
            }
        }
    }
}
