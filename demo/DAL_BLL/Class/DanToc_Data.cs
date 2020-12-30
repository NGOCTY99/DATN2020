using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL.Class
{
    public class DanToc_Data
    {
        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();

        public DanToc_Data()
        {

        }

        public dynamic load_datagridview()
        {
            return from dt in db.DANTOCs select dt;
        }
        // KT khóa chính
        public bool ktkc(string madt)
        {

            DANTOC d = db.DANTOCs.Where(t => t.MaDanToc == madt).FirstOrDefault();
            if (d == null)
            {
                return true; // mã ko trùng được thêm vào
            }
            else
            {
                return false;
            }
        }
        // Thêm
        public bool themDT(string madt, string tendt)
        {
            if (ktkc(madt) == true)
            {
                DANTOC dt = new DANTOC();
                dt.MaDanToc = madt;
                dt.TenDanToc = tendt;
                db.DANTOCs.InsertOnSubmit(dt);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        //Sửa 
        public bool suaDT(string madt, string tendt)
        {
            if (ktkc(madt) == false)
            {
                DANTOC suadt = db.DANTOCs.Where(t => t.MaDanToc == madt).FirstOrDefault();
                suadt.TenDanToc = tendt;
                db.SubmitChanges();
                return true;
            }
            else
                return false;
        }

    }
}
