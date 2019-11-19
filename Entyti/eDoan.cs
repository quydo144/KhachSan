using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eDoan
    {
        private string maDoan, tenDoan, diaChi, maTruongDoan;
        private string sdt;

        public eDoan(string sdt, string maDoan, string tenDoan, string diaChi, string maTruongDoan)
        {
            this.maDoan = maDoan;
            this.tenDoan = tenDoan;
            this.diaChi = diaChi;
            this.maTruongDoan = maTruongDoan;
            this.sdt = sdt;
        }

        public eDoan()
        {

        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public string MaDoan
        {
            get
            {
                return maDoan;
            }

            set
            {
                maDoan = value;
            }
        }

        public string MaTruongDoan
        {
            get
            {
                return maTruongDoan;
            }

            set
            {
                maTruongDoan = value;
            }
        }

        public string TenDoan
        {
            get
            {
                return tenDoan;
            }

            set
            {
                tenDoan = value;
            }
        }

        public string Sdt
        {
            get
            {
                return sdt;
            }

            set
            {
                sdt = value;
            }
        }
    }
}
