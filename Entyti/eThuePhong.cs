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
        private bool trangThai;
        private int soLuongPhong;
        private string maDoan;

        public eThuePhong(string maThue, string maNV, bool trangThai, int soLuongPhong, string maDoan)
        {
            this.maThue = maThue;
            this.maNV = maNV;
            this.trangThai = trangThai;
            this.soLuongPhong = soLuongPhong;
            this.maDoan = maDoan;
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

        public bool TrangThai
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

        public int SoLuongPhong
        {
            get
            {
                return soLuongPhong;
            }

            set
            {
                soLuongPhong = value;
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
    }
}
