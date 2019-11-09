using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eThuePhong
    {
        private string maThue, maNV;
        private int trangThai;

        public eThuePhong(string maThue, string maNV, int trangThai)
        {
            this.maThue = maThue;
            this.maNV = maNV;
            this.trangThai = trangThai;
        }

        public eThuePhong()
        {

        }

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
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

        public int TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
    }
}
