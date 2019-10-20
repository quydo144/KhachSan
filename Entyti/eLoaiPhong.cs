using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eLoaiPhong
    {
        private string maLoaiPhong, tenLoaiPhong;
        private decimal donGia;
        private int soNguoi;

        public eLoaiPhong(string maLoaiPhong, string tenLoaiPhong, decimal donGia, int soNguoi)
        {
            this.maLoaiPhong = maLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.donGia = donGia;
            this.soNguoi = soNguoi;
        }

        public eLoaiPhong()
        {

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
