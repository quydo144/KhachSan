﻿using System;
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

        //public string getMaThue_ByMaPhongTrangThai(string maPhong, int trangThai)
        //{
        //    return tpdal.getMaThue_ByMaPhongTrangThai(maPhong, trangThai);
        //}

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

        //public string getMaPhong_ByMaThueTrangThai(string maThue, int trangThai)
        //{
        //    return tpdal.getMaPhong_ByMaThueTrangThai(maThue, trangThai);
        //}

        //public string getmaThue_ByMaPhongTrangThai(string maPhong, int trangThai)
        //{
        //    return tpdal.getmaThue_ByMaPhongTrangThai(maPhong, trangThai);
        //}

    }
}
