﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eLoaiPhong
    {
        private string maLoaiPhong, tenLoaiPhong;
        private double donGia;
        private int soNguoi;
        private int soPhongTrong;

        public eLoaiPhong(int soPhongTrong, string maLoaiPhong, string tenLoaiPhong, double donGia, int soNguoi)
        {
            this.maLoaiPhong = maLoaiPhong;
            this.tenLoaiPhong = tenLoaiPhong;
            this.donGia = donGia;
            this.soNguoi = soNguoi;
            this.soPhongTrong = soPhongTrong;
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

        public double DonGia
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

        public int SoPhongTrong
        {
            get
            {
                return soPhongTrong;
            }

            set
            {
                soPhongTrong = value;
            }
        }
    }
}
