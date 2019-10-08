using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eDichVu
    {
        private string maDV, tenDV;
        private decimal donGia;

        public eDichVu(string maDV, string tenDV, decimal donGia)
        {
            this.maDV = maDV;
            this.tenDV = tenDV;
            this.donGia = donGia;
        }

        public eDichVu()
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
