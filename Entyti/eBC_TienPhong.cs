using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entyti
{
   public class eBC_TienPhong
    {
        private string tenKH;
        private DateTime tgianVao, tgianRa;
        private double tienPhong;

        public eBC_TienPhong(string tenKH, DateTime tgianVao, DateTime tgianRa, double tienPhong)
        {
            this.TenKH = tenKH;
            this.TgianVao = tgianVao;
            this.TgianRa = tgianRa;
            this.TienPhong = tienPhong;
        }

        public eBC_TienPhong()
        {
            
        }
        public string TenKH
        {
            get
            {
                return tenKH;
            }

            set
            {
                tenKH = value;
            }
        }

        public DateTime TgianRa
        {
            get
            {
                return tgianRa;
            }

            set
            {
                tgianRa = value;
            }
        }

        public DateTime TgianVao
        {
            get
            {
                return tgianVao;
            }

            set
            {
                tgianVao = value;
            }
        }

        public double TienPhong
        {
            get
            {
                return tienPhong;
            }

            set
            {
                tienPhong = value;
            }
        }
    }
}
