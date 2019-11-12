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

        public eDoan(string maDoan, string tenDoan, string diaChi, string maTruongDoan)
        {
            this.maDoan = maDoan;
            this.tenDoan = tenDoan;
            this.diaChi = diaChi;
            this.maTruongDoan = maTruongDoan;
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
    }
}
