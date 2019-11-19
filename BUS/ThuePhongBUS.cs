using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;
using DAL;

namespace BUS
{
    public class ThuePhongBUS
    {
        ThuePhongDAL tpdal = new ThuePhongDAL();

        public int insertThuePhong(eThuePhong tp)
        {
            return tpdal.insertThuePhong(tp);
        }

        public List<eThuePhong> getMaThue(string s)
        {
            return tpdal.getMaThue(s);
        }

        public string getMaThueCuoi()
        {
            return tpdal.getMaThueCuoi();
        }

        public void updateThuePhong(eThuePhong tp)
        {
            tpdal.updateThuePhong(tp);
        }

        public string getMaDoan_ByMaThue(string maThue)
        {
            return tpdal.getMaDoan_ByMaThue(maThue);
        }
        public string getMaThue_ByMaDoan(string madoan, byte trangThai)
        {
            return tpdal.getMaThue_ByMaDoan(madoan, trangThai);
        }
    }
}
