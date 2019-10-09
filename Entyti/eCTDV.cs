using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eCTDV
    {
        private string tenDV;
        private int soLuong;
        private decimal donGia, thanhTien;

        public eCTDV(string tenDV, int soLuong, decimal donGia, decimal thanhTien)
        {
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
    }
}
