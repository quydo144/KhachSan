using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eSuDungDichVu
    {
        private string maSDDV, maDV;
        private string maThue;
        private int soLuong;
        private DateTime thoiGianSd;

        public eSuDungDichVu(string maSDDV, string maDV, string maThue, int soLuong, DateTime thoiGianSd)
        {
            this.maSDDV = maSDDV;
            this.maDV = maDV;
            this.soLuong = soLuong;
            this.maThue = maThue;
            this.thoiGianSd = thoiGianSd;
        }

        public eSuDungDichVu()
        {

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

        public string MaSDDV
        {
            get
            {
                return maSDDV;
            }

            set
            {
                maSDDV = value;
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

        public DateTime ThoiGianSd
        {
            get
            {
                return thoiGianSd;
            }

            set
            {
                thoiGianSd = value;
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
    }
}
