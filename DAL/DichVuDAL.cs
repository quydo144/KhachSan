﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class DichVuDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();
        public List<eDichVu> getdv()
        {
            var listdv = (from x in db.DichVus select x).ToList();
            List<eDichVu> ls = new List<eDichVu>();
            foreach (DichVu item in listdv)
            {
                eDichVu dv = new eDichVu();
                dv.MaDV = item.maDV;
                dv.TenDV = item.tenDichVu;
                dv.DonGia = Convert.ToDecimal(item.donGia);
                dv.SoLuong = Convert.ToInt32(item.soLuongDV);
                ls.Add(dv);
            }
            return ls;
        }

        public int insertDichVu(eDichVu dvmoi)
        {
            DichVu dvtemp = new DichVu();
            dvtemp.maDV = dvmoi.MaDV;
            dvtemp.tenDichVu = dvmoi.TenDV;
            dvtemp.donGia = Convert.ToInt32(dvmoi.DonGia); // Sua lai kieu money
            db.DichVus.InsertOnSubmit(dvtemp);
            db.SubmitChanges();
            return 1;
        }

        public void updateDichVu(eDichVu dvupdate)
        {
            IQueryable<DichVu> dv = db.DichVus.Where(x => x.maDV.Equals(dvupdate.MaDV));

            dv.First().tenDichVu = dvupdate.TenDV;
            dv.First().maDV = dvupdate.MaDV;
            dv.First().donGia = Convert.ToInt32(dvupdate.DonGia);///Sua lai kieu money
            db.SubmitChanges();
        }

        public bool deleteDichVu(string madv)
        {
            DichVu dvtemp = db.DichVus.Where(x => x.maDV == madv).FirstOrDefault();
            if (dvtemp != null)
            {
                db.DichVus.DeleteOnSubmit(dvtemp);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        public eDichVu maTangTuDong()
        {
            eDichVu dv = new eDichVu();
            DichVu item = (from x in db.DichVus orderby x.maDV descending select x).FirstOrDefault();
            dv.MaDV = item.maDV;
            dv.TenDV = item.tenDichVu;
            dv.DonGia = Convert.ToInt32(item.donGia);//Sua lai kieu money
            return dv;
        }

        public List<eDichVu> getAllma(string s)
        {
            var listdv = (from x in db.DichVus where x.maDV.Contains(s) select x).ToList();
            List<eDichVu> ls = new List<eDichVu>();
            foreach (DichVu item in listdv)
            {
                eDichVu dv = new eDichVu();
                dv.MaDV = item.maDV;
                dv.TenDV = item.tenDichVu;
                dv.DonGia = Convert.ToInt32(item.donGia);//Sua lai kiue money
                ls.Add(dv);
            }
            return ls;
        }

        public List<eDichVu> getAllten(string s)
        {
            var listdv = (from x in db.DichVus where x.tenDichVu.Contains(s) select x).ToList();
            List<eDichVu> ls = new List<eDichVu>();
            foreach (DichVu item in listdv)
            {
                eDichVu dv = new eDichVu();
                dv.MaDV = item.maDV;
                dv.TenDV = item.tenDichVu;
                dv.DonGia = Convert.ToInt32(item.donGia); // Sua lai keu money
                ls.Add(dv);
            }
            return ls;
        }
    }
}

