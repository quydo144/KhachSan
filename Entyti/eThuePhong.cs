using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eThuePhong
    {
        private string maThuePhong;
        private ePhong p;
        private eKhachHang kh;
        private eNhanVien nv;
        private eSuDungDichVu sddv;
        private DateTime ngayVao, ngayRa;
        private float datCoc;

        public eThuePhong(string maThuePhong, ePhong p, eKhachHang kh, eNhanVien nv, eSuDungDichVu sddv, DateTime ngayVao, DateTime ngayRa, float datCoc)
        {
            this.maThuePhong = maThuePhong;
            this.p = p;
            this.kh = kh;
            this.nv = nv;
            this.sddv = sddv;
            this.ngayVao = ngayVao;
            this.ngayRa = ngayRa;
            this.datCoc = datCoc;
        }

        public eThuePhong()
        {
            this.maThuePhong = "";
            this.p = null;
            this.kh = null;
            this.nv = null;
            this.sddv = null;
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

        public ePhong P
        {
            get
            {
                return p;
            }

            set
            {
                p = value;
            }
        }

        public eKhachHang Kh
        {
            get
            {
                return kh;
            }

            set
            {
                kh = value;
            }
        }

        public eNhanVien Nv
        {
            get
            {
                return nv;
            }

            set
            {
                nv = value;
            }
        }

        public eSuDungDichVu Sddv
        {
            get
            {
                return sddv;
            }

            set
            {
                sddv = value;
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
