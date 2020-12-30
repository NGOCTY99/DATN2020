using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;
using DAL_BLL.Class;
namespace QLDiemTHPT_Winform
{
    public partial class frmPhanQuyen : Form
    {
        string ma;
        public frmPhanQuyen()
        {
            InitializeComponent();
        }
        public void data(string mand)
        {
            this.ma = mand;
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            //loadrole();

        }

        //public void loadrole()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Mã Role");
        //    dt.Columns.Add("Tên của Role");
        //    foreach (var item in role.loadRole())
        //    {
        //        DataRow dr = dt.NewRow();
        //        DataGridViewRow dgvR = (DataGridViewRow)dgvRole.CurrentRow;
        //        dr[0] = item.Role_ID;
        //        dr[1] = item.Role_Name;
        //        dt.Rows.Add(dr);
        //    }
        //    dgvRole.DataSource = dt;
        //}

        public void loadPermission()
        {

        }
        int id = 0;
        private void dgvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        CheckBox checkBox = new CheckBox();
            //        checkBox.Name = "STT";
            //        string x = dgvRole.Rows[e.RowIndex].Cells[0].Value.ToString();
            //        DataTable dt = new DataTable();
            //        dt.Columns.Add("ID");
            //        dt.Columns.Add("Action");
            //        dt.Columns.Add("Code");
            //        dt.Columns.Add(checkBox.Name);
            //        foreach (var item in per.loadPertheoRole(Convert.ToInt32(x)))
            //        {
            //            DataRow dr = dt.NewRow();
            //            DataGridViewRow dgvR = (DataGridViewRow)dgvRole.CurrentRow;
            //            dr[0] = item.Detail_ID;
            //            dr[1] = item.Role_Action;
            //            dr[2] = item.Role_Code;
            //            checkBox.Checked= (bool)item.Check_Detail;
            //            dr[3] = checkBox.Checked;
            //            dt.Rows.Add(dr);
            //        }
            //        //CheckboxColumn.;
            //        dgvPermission.DataSource = dt;
            //    }
            //}
            //catch
            //{
            //    Console.WriteLine("Lỗi rồi");
            //}
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //for (int i = 0; i < dgvRole.Columns.Count - 1; i++)
            //{
            //    for(int j =0; j< dgvPermission.Columns.Count -1; j++)
            //    {
            //        rup.insertRoleND(int.Parse(dgvRole.Rows[i].Cells[0].Value.ToString()),
            //    }    
            //    //NapVaoChiTietPMVaoOBJ(dgvPhieuNhap.Rows[i].Cells[0].Value.ToString(), int.Parse(dgvPhieuNhap.Rows[i].Cells["SoLuongNhap"].Value.ToString()), int.Parse(dgvPhieuNhap.Rows[i].Cells["DonGia"].Value.ToString()));
            //    //chiN.ThemChiTietPhieuNhap(chiO);
            //}
        }
    }
}
