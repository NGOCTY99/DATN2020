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
    public partial class frm_DanToc : Form
    {
        QLDiemTHPTDataContext db = new QLDiemTHPTDataContext();
        DanToc_Data dantoc = new DanToc_Data();
        public frm_DanToc()
        {
            InitializeComponent();
        }

        public void loadDL()
        {
            dgvDanToc.DataSource = dantoc.load_datagridview();
        }
        private void frm_DanToc_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            loadDL();
        }

        private void dgvDanToc_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;

            txtMaDT.Text = dgvDanToc.CurrentRow.Cells[0].Value.ToString();
            txtTenDT.Text = dgvDanToc.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            txtMaDT.Text = "";
            txtTenDT.Text = "";
            txtMaDT.Enabled = true;
            txtMaDT.Focus();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaDT.Enabled = false;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_DanToc_Load(sender, e);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txtMaDT.Enabled == false) // trạng thái sửa
                {
                    if (dantoc.suaDT(txtMaDT.Text, txtTenDT.Text) == true)
                    {
                        MessageBox.Show("Sửa dân tộc thành công");
                        loadDL();
                        txtMaDT.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Sửa dân tộc thất bại");
                    }
                }
                else // trạng thái thêm mới
                {
                    if (txtMaDT.Text != "" && txtTenDT.Text != "")
                    {

                        if (dantoc.themDT(txtMaDT.Text, txtTenDT.Text) == true)
                        {
                            MessageBox.Show("Thêm dân tộc mới thành công");
                            loadDL();
                        }
                        else
                        {
                            MessageBox.Show("Mã dân tộc đã tồn tại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại");
            }
        }
    }
}
