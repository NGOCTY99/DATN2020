using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LopHoc_Data
    {
        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();
        public LopHoc_Data()
        {

        }
        public dynamic loadDataGridView()
        {
            var Lops = from l in db.LOPs
                       from k in db.KHOILOPs
                       from nh in db.NAMHOCs
                       from gv in db.GIAOVIENs
                       where l.MaKhoiLop == k.MaKhoiLop &&
                             l.MaNamHoc == nh.MaNamHoc &&
                             l.MaGiaoVien == gv.MaGiaoVien
                       select new
                       {
                           l.MaLop,
                           l.TenLop,
                           k.TenKhoiLop,
                           nh.TenNamHoc,
                           l.SiSo,
                           gv.TenGiaoVien
                       };
            return Lops;
        }


        public IQueryable<KHOILOP> loadKhoiLop()
        {
            return from l in db.KHOILOPs select l;
        }

        public IQueryable<NAMHOC> loadNamHoc()
        {
            return from nh in db.NAMHOCs select nh;
        }
        public IQueryable<GIAOVIEN> loadGiaoVien()
        {
            return from gv in db.GIAOVIENs select gv;
        }

        //CRUD lớp học

        public bool ktkc(string malop)
        {

            LOP l = db.LOPs.Where(t => t.MaLop == malop).FirstOrDefault();
            if (l == null)
            {
                return true; // mã ko trùng được thêm vào
            }
            else
            {
                return false;
            }
        }

        // thêm lớp học mới
        public bool themLop(string malop, string tenlop, string makhoi, string manamhoc, int siso, string magv)
        {
            if (ktkc(malop) == true)
            {
                LOP lop = new LOP();
                lop.MaLop = malop;
                lop.TenLop = tenlop;
                lop.MaKhoiLop = makhoi;
                lop.MaNamHoc = manamhoc;
                lop.SiSo = siso;
                lop.MaGiaoVien = magv;
                db.LOPs.InsertOnSubmit(lop);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        // Xóa lớp
        //public bool xoaLop(string malop)
        //{
        //    LOP l = db.LOPs.Where(t => t.MaLop == malop).FirstOrDefault();
        //    db.LOPs.DeleteOnSubmit(l);
        //    db.SubmitChanges();
        //    return true;
        //}

        //Sửa lớp (sỉ số, GVCN)
        public bool suaLop(string malop, int siso, string magv)
        {
            if (ktkc(malop) == false)
            {
                LOP sualop = db.LOPs.Where(t => t.MaLop == malop).FirstOrDefault();
                sualop.SiSo = siso;
                sualop.MaGiaoVien = magv;
                db.SubmitChanges();
                return true;
            }
            else
                return false;
        }

        // Lọc - tìm kiếm 
        // theo mã khối lớp
        public dynamic load_dgv_Theo_MaKhoiLop(string makhoilop)
        {
            var Lops = from l in db.LOPs
                       from k in db.KHOILOPs
                       from nh in db.NAMHOCs
                       from gv in db.GIAOVIENs

                       from p in db.PHANLOPs

                       where l.MaKhoiLop == k.MaKhoiLop &&
                             l.MaNamHoc == nh.MaNamHoc &&
                             l.MaGiaoVien == gv.MaGiaoVien &&
                             p.MaLop == l.MaLop &&
                             l.MaKhoiLop == makhoilop
                       select new
                       {
                           l.MaLop,
                           l.TenLop,
                           k.TenKhoiLop,
                           nh.TenNamHoc,
                           l.SiSo,
                           gv.TenGiaoVien
                       };

            return Lops;
        }
        //theo mã năm học
        public dynamic load_dgv_Theo_MaNamHoc(string manh)
        {
            var nh = from l in db.LOPs
                     from k in db.KHOILOPs
                     from n in db.NAMHOCs
                     from gv in db.GIAOVIENs
                     where l.MaKhoiLop == k.MaKhoiLop &&
                           l.MaNamHoc == n.MaNamHoc &&
                           l.MaGiaoVien == gv.MaGiaoVien &&
                           l.MaNamHoc == manh
                     select new
                     {
                         l.MaLop,
                         l.TenLop,
                         k.TenKhoiLop,
                         n.TenNamHoc,
                         l.SiSo,
                         gv.TenGiaoVien
                     };
            return nh;
        }

        public dynamic demSiSoLopHoc(string malop)
        {
            return db.PHANLOPs.Where(t => t.MaLop == malop).Count();
        }


        public IEnumerable<LOP> loaddl()
        {
            return db.LOPs.Select(t => t);
        }
        public string loadTenKhoi(string makhoi)
        {
            return db.KHOILOPs.SingleOrDefault(t => t.MaKhoiLop == makhoi).TenKhoiLop.ToString(); ;
        }
        public string loadNamHoc(string namhoc)
        {
            return db.NAMHOCs.SingleOrDefault(t => t.MaNamHoc == namhoc).TenNamHoc.ToString(); ;
        }
        public string loadTenGV(string magv)
        {
            return db.GIAOVIENs.SingleOrDefault(t => t.MaGiaoVien == magv).TenGiaoVien.ToString(); ;
        }
    }
}
