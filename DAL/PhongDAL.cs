using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entyti;

namespace DAL
{
    public class PhongDAL
    {
        dbQLKhachSanDataContext db = new dbQLKhachSanDataContext();

        public List<ePhong> getallphong()
        {
            var litsphong = (from x in db.Phongs select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public ePhong gettP_byMa(string ma)
        {
            ePhong phong_ent = new ePhong();
            Phong phong = (from x in db.Phongs where x.maPhong.Equals(ma) select x).SingleOrDefault();
            phong_ent.MaPhong = phong.maPhong;
            phong_ent.MaLoaiPhong = phong.maLoaiPhong;
            phong_ent.TenPhong = phong.tenPhong;
            phong_ent.Tang = Convert.ToInt32(phong.tang);
            phong_ent.GhiChu = phong.ghiChu;
            return phong_ent;
            
        }

        public List<ePhong> gettinhtrangphong(bool tinhtrang)
        {
            var litsphong = (from x in db.Phongs where x.tinhTrang.Equals(tinhtrang) select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public ePhong get_tenP(string tenPhong)
        {
            Phong item = (from x in db.Phongs where x.tenPhong.Equals(tenPhong) select x).SingleOrDefault();
            ePhong p = new ePhong();
            p.MaPhong = item.maPhong;
            p.TenPhong = item.tenPhong;
            p.Tang = Convert.ToInt32(item.tang);
            p.GhiChu = item.ghiChu;
            p.MaLoaiPhong = item.maLoaiPhong;
            p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
            return p;
        }

        public List<ePhong> getLoaiPhong(string maLoaiPhong)
        {
            var litsphong = (from x in db.Phongs where x.maLoaiPhong.Equals(maLoaiPhong) select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public List<ePhong> getLoaiPhong_Trong(string maLoaiPhong, bool tinhTrang)
        {
            var litsphong = (from x in db.Phongs where x.maLoaiPhong.Equals(maLoaiPhong) && x.tinhTrang == tinhTrang select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public List<ePhong> getLoaiPhong_Trong_soLuong(string maLoaiPhong, bool tinhTrang, int n)
        {
            var litsphong = (from x in db.Phongs where x.maLoaiPhong.Equals(maLoaiPhong) && x.tinhTrang == tinhTrang select x).ToList().Take(n);
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public ePhong getEPhong_byID(string ma)
        {
            ePhong p = new ePhong();
            Phong ph = db.Phongs.Where(n => n.maPhong.Trim().Equals(ma)).SingleOrDefault();
            p.MaPhong = ph.maPhong;
            p.TenPhong = ph.tenPhong;
            p.Tang = Convert.ToInt32(ph.tang);
            p.GhiChu = ph.ghiChu;
            p.MaLoaiPhong = ph.maLoaiPhong;
            p.TinhTrang = Convert.ToBoolean(ph.tinhTrang);
            p.SoNgHienTai = Convert.ToInt32(ph.soNguoiHienTai);
            return p;
        }

        public string maPhong_byTen(string tenPhong)
        {
            Phong p = db.Phongs.Where(n => n.tenPhong.Trim().Equals(tenPhong)).SingleOrDefault();
            return p.maPhong;
        }

        public void updateTinhTrangPhong(ePhong pupdate)
        {
            IQueryable<Phong> p = db.Phongs.Where(x => x.maPhong.Equals(pupdate.MaPhong));
            p.First().tinhTrang = Convert.ToBoolean(pupdate.TinhTrang);
            p.First().soNguoiHienTai = pupdate.SoNgHienTai;
            db.SubmitChanges();
        }

        public string getLoaiPhong_ByID(string id)
        {
            Phong p = db.Phongs.Where(n => n.maPhong.Trim().Equals(id)).SingleOrDefault();
            return p.maLoaiPhong.Trim();
        }

        public string getTenPhong_ByID(string id)
        {
            Phong p = db.Phongs.Where(n => n.maPhong.Trim().Equals(id)).SingleOrDefault();
            return p.tenPhong.Trim();
        }

        ArrayList tang = new ArrayList();

        public ArrayList Tang()
        {
            var phong = (from x in db.Phongs select x.tang).Distinct();
            foreach (var item in phong)
            {
                tang.Add(item);
            }
            return tang;
        }

        public List<ePhong> getTang(string tang)
        {
            var litsphong = (from x in db.Phongs where x.tang.Equals(tang) select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public List<ePhong> getTang_PhongTrong(string tang, bool tinhtrang)
        {
            var litsphong = (from x in db.Phongs where x.tang.Equals(tang) && x.tinhTrang == tinhtrang select x).ToList();
            List<ePhong> ls = new List<ePhong>();
            foreach (Phong item in litsphong)
            {
                ePhong p = new ePhong();
                p.MaPhong = item.maPhong;
                p.TenPhong = item.tenPhong;
                p.Tang = Convert.ToInt32(item.tang);
                p.GhiChu = item.ghiChu;
                p.MaLoaiPhong = item.maLoaiPhong;
                p.TinhTrang = Convert.ToBoolean(item.tinhTrang);
                ls.Add(p);
            }
            return ls;
        }

        public bool deletePhong(string map)
        {
            Phong ptemp = db.Phongs.Where(x => x.maPhong == map).FirstOrDefault();
            if (ptemp != null)
            {
                db.Phongs.DeleteOnSubmit(ptemp);
                db.SubmitChanges(); //cập nhật việc xóa vào CSDL
                return true; //xóa thành công
            }
            return false;
        }

        public int updatePhong(ePhong pupdate)
        {
            IQueryable<Phong> p = db.Phongs.Where(x => x.maPhong.Equals(pupdate.MaPhong));
            p.First().maLoaiPhong = pupdate.MaLoaiPhong;
            p.First().ghiChu = pupdate.GhiChu;
            p.First().tang = pupdate.Tang;
            db.SubmitChanges();
            return 1;
        }

        public int insertPhong(ePhong pnew)
        {
            Phong ptemp = new Phong();
            ptemp.maPhong = "";
            ptemp.tenPhong = "";
            ptemp.ghiChu = pnew.GhiChu;
            ptemp.maLoaiPhong = pnew.MaLoaiPhong;
            ptemp.tang = (pnew.Tang);
            ptemp.tinhTrang = pnew.TinhTrang;
            db.Phongs.InsertOnSubmit(ptemp);
            db.SubmitChanges();
            return 1;
        }
    }
}
