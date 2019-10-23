using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eCTDV
    {
        private string maDV;
        private string tenDV;
        private int soLuong;
        private decimal donGia, thanhTien;

        public eCTDV(string maDV,string tenDV, decimal donGia,int soLuong, decimal thanhTien)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thanhTien = thanhTien;
        }

        public eCTDV()
        {

        }

        public string TenDV
        {
            get
            {
                return tenDV;
            }

            set
            {
                tenDV = value;
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

        public decimal ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
            }
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
    }
}
