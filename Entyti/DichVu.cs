using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class DichVu
    {
        private string maDV, tenDV;
        private decimal donGia;

        public DichVu(string maDV, string tenDV, decimal donGia)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.donGia = donGia;
        }

        public DichVu()
        {
            this.maDV = "";
            this.tenDV = "";
            this.donGia = 0;
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
    }
}
