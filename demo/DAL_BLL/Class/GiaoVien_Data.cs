using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL.Class
{
    public class GiaoVien_Data
    {
        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();
        public IEnumerable<GIAOVIEN> loadGV()
        {
            return db.GIAOVIENs.Select(t => t);
        }
    }
}
