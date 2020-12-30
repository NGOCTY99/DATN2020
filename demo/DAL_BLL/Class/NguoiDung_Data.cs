using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DAL_BLL.Class
{
    public class NguoiDung_Data
    {
        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();
        public IEnumerable<NGUOIDUNG> loadND()
        {
            return db.NGUOIDUNGs.Select(t => t);
        }


    }
}
