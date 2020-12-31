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
namespace testVS2019_Winform.Controller
{
    public partial class frm_LopHoc : Form
    {

        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();
        LopHoc_Data lophoc = new LopHoc_Data();
        public frm_LopHoc()
        {
            InitializeComponent();
        }
        
        private void frm_LopHoc_Load(object sender, EventArgs e)
        {
            // load dữ liệu tên dgvLopHoc
            // dgvLopHoc.DataSource = lophoc.loadDataGridView();
            loadDSLop();
            // load dữ liệu lên cboKhoiLop
            cboKhoiLop.DataSource = lophoc.loadKhoiLop();
            cboKhoiLop.ValueMember = "MaKhoiLop";
            cboKhoiLop.DisplayMember = "TenKhoiLop";
            //Load dữ liệu lên cboNamHoc
            cboMaNamHoc.DataSource = lophoc.loadNamHoc();
            cboMaNamHoc.ValueMember = "MaNamHoc";
            cboMaNamHoc.DisplayMember = "TenNamHoc";
            // Load dữ liệu lên cboGiaoVien
            cboGVCN.DataSource = lophoc.loadGiaoVien();
            cboGVCN.ValueMember = "MaGiaoVien";
            cboGVCN.DisplayMember = "TenGiaoVien";
        }
        public void loadLoptheoMaKhoi()
        {
            dgvLopHoc.DataSource = lophoc.load_dgv_Theo_MaKhoiLop(cboKhoiLop.SelectedValue.ToString());
        }

        private void dgvLopHoc_SelectionChanged(object sender, EventArgs e)
        {
            int ss = lophoc.demSiSoLopHoc(dgvLopHoc.CurrentRow.Cells[0].Value.ToString());
            txtMaLop.Text = dgvLopHoc.CurrentRow.Cells[0].Value.ToString();
            txtTenLop.Text = dgvLopHoc.CurrentRow.Cells[1].Value.ToString();
            cboKhoiLop.Text = dgvLopHoc.CurrentRow.Cells[2].Value.ToString();
            cboMaNamHoc.Text = dgvLopHoc.CurrentRow.Cells[3].Value.ToString();
           // txtSiSo.Text = dgvLopHoc.CurrentRow.Cells[4].Value.ToString();
            cboGVCN.Text = dgvLopHoc.CurrentRow.Cells[5].Value.ToString();
            txtSiSo.Text = ss.ToString();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaLop.Enabled = true;
            txtTenLop.Enabled = true;
            cboMaNamHoc.Enabled = true;
            cboKhoiLop.Enabled = true;
            txtMaLop.Text = "";
            txtSiSo.Text = "";
            txtTenLop.Text = "";
            cboGVCN.Text = "";
            cboKhoiLop.Text = "";
            cboMaNamHoc.Text = "";
            txtMaLop.Focus();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //cho phép sửa sỉ số lớp và GVCN
            txtMaLop.Enabled = false;
            txtTenLop.Enabled = false;
            cboMaNamHoc.Enabled = false;
            cboKhoiLop.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    if (lophoc.xoaLop(txtMaLop.Text) == true)
            //    {
            //        MessageBox.Show("Xóa thành công");
            //        frm_LopHoc_Load(sender, e);
            //    }
            //    else
            //        MessageBox.Show("Xóa thất bại");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Xóa thất bại, lỗi ràng buộc khóa chính");
            //}
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            int ss = int.Parse(txtSiSo.Text);
                if (ss > 30 && ss < 45)
                {
                    if (txtMaLop.Enabled == false) // Trạng thái sửa
                {
                    if (lophoc.suaLop(txtMaLop.Text, ss, cboGVCN.SelectedValue.ToString()) == true)
                    {
                        MessageBox.Show("Sửa lớp học thành công");
                        frm_LopHoc_Load(sender, e);
                        txtMaLop.Enabled = true;
                        txtTenLop.Enabled = true;
                        cboMaNamHoc.Enabled = true;
                        cboKhoiLop.Enabled = true;
                    }
                    else
                        MessageBox.Show("Thất bại");
                }    
                else // trạng thái thêm mới
                 {
                   
                    if (lophoc.themLop(txtMaLop.Text, txtTenLop.Text, cboKhoiLop.SelectedValue.ToString(), cboMaNamHoc.SelectedValue.ToString(), ss, cboGVCN.SelectedValue.ToString()) == true)
                    {
                        MessageBox.Show("Thêm lớp học mới thành công");
                        frm_LopHoc_Load(sender, e);
                    }
                    else
                        MessageBox.Show("Lớp học này đã có");
                  }
                }
                else
                {
                    MessageBox.Show("Sỉ số lớp học tối thiểu 30, tối đa 45 học sinh");
                }
            }
            catch
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void txtSiSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboKhoiLop_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadLoptheoMaKhoi();
        }
        public void loadDSLop()
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("Mã lớp");
            Dt.Columns.Add("Tên lớp");
            Dt.Columns.Add("Tên khối lớp");
            Dt.Columns.Add("Năm học");
            Dt.Columns.Add("Sĩ số");
            Dt.Columns.Add("Giáo viên chủ nhiệm");
            foreach (var item in lophoc.loaddl())
            {
                DataRow dr = Dt.NewRow();
                DataGridViewRow dgvR = (DataGridViewRow)dgvLopHoc.CurrentRow;
                dr[0] = item.MaLop;
                dr[1] = item.TenLop;
                dr[2] = lophoc.loadTenKhoi(item.MaKhoiLop);
                dr[3] = lophoc.loadNamHoc(item.MaNamHoc);
                dr[4] = lophoc.demSiSoLopHoc(item.MaLop);
                dr[5] = lophoc.loadTenGV(item.MaGiaoVien);
                Dt.Rows.Add(dr);
            }
            dgvLopHoc.DataSource = Dt;
        }
    }
}
