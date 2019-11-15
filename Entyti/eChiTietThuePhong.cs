using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
    public class eChiTietThuePhong
    {
        private string maThue, maKhach, maPhong;
        private DateTime ngayVao, ngayRa;
        private TimeSpan gioVao, gioRa;
        private bool trangThai;
        double tienKhac;
        string ghiChu;

        public eChiTietThuePhong(double tienKhac, string ghiChu, string maThue, string maKhach, string maPhong, DateTime ngayVao, DateTime ngayRa, TimeSpan gioVao, TimeSpan gioRa, bool trangThai)
        {
            this.maThue = maThue;
            this.maKhach = maKhach;
            this.maPhong = maPhong;
            this.ngayVao = ngayVao;
            this.ngayRa = ngayRa;
            this.gioVao = gioVao;
            this.gioRa = gioRa;
            this.trangThai = trangThai;
            this.tienKhac = tienKhac;
            this.ghiChu = ghiChu;
        }

        public eChiTietThuePhong()
        {

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

        public string MaKhach
        {
            get
            {
                return maKhach;
            }

            set
            {
                maKhach = value;
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

        public TimeSpan GioVao
        {
            get
            {
                return gioVao;
            }

            set
            {
                gioVao = value;
            }
        }

        public TimeSpan GioRa
        {
            get
            {
                return gioRa;
            }

            set
            {
                gioRa = value;
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

        public double TienKhac
        {
            get
            {
                return tienKhac;
            }

            set
            {
                tienKhac = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
            }
        }
    }
}
