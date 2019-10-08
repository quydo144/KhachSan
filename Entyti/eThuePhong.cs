using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eThuePhong
    {
        private string maThuePhong, maPhong, maKH, maNV, maSddv;
        private DateTime ngayVao, ngayRa;
        private float datCoc;

        public eThuePhong(string maThuePhong, string maPhong, string maKH, string maNV, string maSddv, DateTime ngayVao, DateTime ngayRa, float datCoc)
        {
            this.maThuePhong = maThuePhong;
            this.maPhong = maPhong;
            this.maKH = maKH;
            this.maNV = maNV;
            this.maSddv = maSddv;
            this.ngayVao = ngayVao;
            this.ngayRa = ngayRa;
            this.datCoc = datCoc;
        }

        public eThuePhong()
        {
            this.maThuePhong = "";
            this.maPhong = "";
            this.maKH = "";
            this.maNV = "";
            this.maSddv = "";
            this.ngayVao = Convert.ToDateTime(0);
            this.ngayRa = Convert.ToDateTime(0);
            this.datCoc = 0;
        }

        public string MaThuePhong
        {
            get
            {
                return maThuePhong;
            }

            set
            {
                maThuePhong = value;
            }
        }

        public string MaPhong
        {
            get
            {
                return maPhong;
            }

            set
            {
                maPhong = value;
            }
        }

        public string MaKH
        {
            get
            {
                return maKH;
            }

            set
            {
                maKH = value;
            }
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

        public string MaSddv
        {
            get
            {
                return maSddv;
            }

            set
            {
                maSddv = value;
            }
        }

        public DateTime NgayVao
        {
            get
            {
                return ngayVao;
            }

            set
            {
                ngayVao = value;
            }
        }

        public DateTime NgayRa
        {
            get
            {
                return ngayRa;
            }

            set
            {
                ngayRa = value;
            }
        }

        public float DatCoc
        {
            get
            {
                return datCoc;
            }

            set
            {
                datCoc = value;
            }
        }
    }
}
