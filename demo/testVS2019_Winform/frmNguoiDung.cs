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
    public partial class frmNguoiDung : Form
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }
        GiaoVien_Data gv = new GiaoVien_Data();
        DangNhap_Data dn = new DangNhap_Data();
        NguoiDung_Data db = new NguoiDung_Data();
        NhomNguoiDung_Data nnd = new NhomNguoiDung_Data();
        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            loadNDung();
            loadGV();
            loadLoaiND();
        }

        public void loadNDung()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã người dùng");
            dt.Columns.Add("Mã loại");
            dt.Columns.Add("Họ tên giáo viên");
            dt.Columns.Add("Tên đăng nhập");
            dt.Columns.Add("Mật khẩu");
            dt.Columns.Add("Mã giáo viên");
            foreach (var item in db.loadND())
            {
                DataRow dr = dt.NewRow();
                DataGridViewRow dgvR = (DataGridViewRow)dgvND.CurrentRow;
                dr[0] = item.MaND;
                dr[1] = nnd.loadLoai(item.MaLoai);
                dr[2] = dn.loadten(item.TenND);
                dr[3] = item.TenDNhap;
                dr[4] = item.MatKhau;
                dr[5] = item.TenND;
                dt.Rows.Add(dr);
            }
            dgvND.DataSource = dt;
            DataGridViewButtonColumn select = new DataGridViewButtonColumn();
            select.HeaderText = "Chọn";
            select.UseColumnTextForButtonValue = true;
            select.Text = "Chọn";
            dgvND.Columns.Add(select);
            this.dgvND.Columns[5].Visible = false;
        }

        public void loadLoaiND()
        {
            cboLoaiND.DataSource = nnd.loadNhom();
            cboLoaiND.DisplayMember = "TENLOAIND";
            cboLoaiND.ValueMember = "MALOAI";
        }

        public void loadGV()
        {
            cboGV.DataSource = gv.loadGV();
            cboGV.DisplayMember = "TenGiaoVien";
            cboGV.ValueMember = "MaGiaoVien";
        }

        private void dgvND_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cboGV.Text= cboLoaiND.Text = "";
                DataGridViewRow row = this.dgvND.Rows[e.RowIndex];
                cboLoaiND.SelectedText = row.Cells[1].Value.ToString();
                cboGV.SelectedText = row.Cells[2].Value.ToString();
                txtTenDN.Text = row.Cells[3].Value.ToString();
                txtMK.Text = row.Cells[4].Value.ToString();
                btnDelete.Enabled = btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
            }
            catch
            {
                Console.WriteLine("Lỗi rồi");
            }
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhanQuyen frm = new frmPhanQuyen();
            frm.Show();
        }

        private void dgvND_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    string x = dgvND.Rows[e.RowIndex].Cells[5].Value.ToString();
                    //MessageBox.Show("Tên giáo viên" + x);
                    frmPhanQuyen myform = new frmPhanQuyen();
                    myform.data(x);
                    myform.Show();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }
    }
}
