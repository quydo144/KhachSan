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
        private int soLuong;
        private DateTime thoiGianSd;

        public eSuDungDichVu(string maSDDV, string maDV, int soLuong, DateTime thoiGianSd)
        {
            this.maSDDV = maSDDV;
            this.maDV = maDV;
            this.soLuong = soLuong;
            this.thoiGianSd = thoiGianSd;
        }

        public eSuDungDichVu()
        {
            this.maSDDV = "";
            this.maDV = "";
            this.soLuong = 0;
            this.thoiGianSd = Convert.ToDateTime(0);
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
    }
}
