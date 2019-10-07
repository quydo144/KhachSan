using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eSuDungDichVu
    {
        private string maSDDV;
        private DichVu dv;
        private int soLuong;
        private DateTime thoiGianSd;

        public eSuDungDichVu(string maSDDV, DichVu dv, int soLuong, DateTime thoiGianSd)
        {
            this.maSDDV = maSDDV;
            this.dv = dv;
            this.soLuong = soLuong;
            this.thoiGianSd = thoiGianSd;
        }

        public eSuDungDichVu()
        {
            this.maSDDV = "";
            this.dv = null;
            this.soLuong = 0;
            this.thoiGianSd = Convert.ToDateTime(0);
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

        public DichVu Dv
        {
            get
            {
                return dv;
            }

            set
            {
                dv = value;
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
