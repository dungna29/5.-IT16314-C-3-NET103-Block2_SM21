using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI_1_1_EFCORE_CODEFIRST.DBContext_FPOLY;
using BAI_1_1_EFCORE_CODEFIRST.Models;
using BAI_1_1_EFCORE_CODEFIRST.Services;

namespace BAI_1_1_EFCORE_CODEFIRST
{
    public partial class Form1 : Form
    {
        private ServiceQL _serviceQl;

        public Form1()
        {
            InitializeComponent();
            _serviceQl = new ServiceQL();
            LoadRole();
            LoadGridAccount();
            LoadGioiTinh();
            rdb_HoatDong.Checked = true;
            LoadGridProduct();
            rdb_HoatDongSP.Checked = true;
        }
        #region 1. Chức năng quản lý tài khoản
        void LoadGioiTinh()
        {
            cbx_GioiTinh.Items.Add("Nam");
            cbx_GioiTinh.Items.Add("Nữ");
            cbx_GioiTinh.SelectedIndex = 0;
        }
        void LoadRole()
        {
            foreach (var x in _serviceQl.GetlstRoles())
            {
                cbx_LoaiTK.Items.Add(x.Name);
            }

            cbx_LoaiTK.SelectedIndex = 0;
        }

        void LoadGridAccount()
        {
            drgrid_Acc.ColumnCount = 4;
            drgrid_Acc.Columns[0].Name = "Tài khoản";
            drgrid_Acc.Columns[1].Name = "Giới tính";
            drgrid_Acc.Columns[2].Name = "Trạng thái";
            drgrid_Acc.Columns[3].Name = "Loại TK";
            drgrid_Acc.Rows.Clear();
            if (_serviceQl.GetlstAccounts().Count < 0) return;
            foreach (var x in _serviceQl.GetlstAccounts())
            {
                drgrid_Acc.Rows.Add(x.Acc, x.Sex == 1 ? "Nam" : "Nữ", x.Status == true ? "Hoạt động" : "Không hoạt động", _serviceQl.GetlstRoles().Where(c => c.Id == x.Roles.Id).Select(c => c.Name).FirstOrDefault());
            }
        }
        void LoadGridAccount(string acc)
        {
            drgrid_Acc.ColumnCount = 4;
            drgrid_Acc.Columns[0].Name = "Tài khoản";
            drgrid_Acc.Columns[1].Name = "Giới tính";
            drgrid_Acc.Columns[2].Name = "Trạng thái";
            drgrid_Acc.Columns[3].Name = "Loại TK";
            drgrid_Acc.Rows.Clear();
            if (_serviceQl.GetlstAccounts().Count < 0) return;
            foreach (var x in _serviceQl.GetlstAccounts(acc))
            {
                drgrid_Acc.Rows.Add(x.Acc, x.Sex == 1 ? "Nam" : "Nữ", x.Status == true ? "Hoạt động" : "Không hoạt động", _serviceQl.GetlstRoles().Where(c => c.Id == x.Roles.Id).Select(c => c.Name).FirstOrDefault());
            }
        }

        private void btn_ThemAcc_Click(object sender, EventArgs e)
        {
            Account acc = new Account
            {
                Acc = txt_Acc.Text,
                Sex = cbx_GioiTinh.Text == "Nam" ? 1 : 0,
                Status = rdb_HoatDong.Checked,
                Roles = _serviceQl.GetlstRoles().Where(c => c.Name == cbx_LoaiTK.Text).FirstOrDefault(),
            };
            MessageBox.Show(_serviceQl.AddAccount(acc), "Thông báo");
            LoadGridAccount();
        }

        private void btn_SuaAcc_Click(object sender, EventArgs e)
        {
            var acc = _serviceQl.GetlstAccounts().FirstOrDefault(c => c.Acc == txt_Acc.Text);
            acc.Sex = cbx_GioiTinh.Text == "Nam" ? 1 : 0;
            acc.Status = rdb_HoatDong.Checked;
            acc.Roles = _serviceQl.GetlstRoles().Where(c => c.Name == cbx_LoaiTK.Text).FirstOrDefault();
            MessageBox.Show(_serviceQl.UpdateAccount(acc), "Thông báo");
            LoadGridAccount();
        }

        private void btn_XoaAcc_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_serviceQl.DeleteAccount(_serviceQl.GetlstAccounts().Where(c => c.Acc == txt_Acc.Text).Select(c => c.Id).FirstOrDefault()), "Thông báo");
            LoadGridAccount();
        }

        private void drgrid_Acc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == _serviceQl.GetlstAccounts().Count || rowIndex == -1) return;
            txt_Acc.Text = drgrid_Acc.Rows[rowIndex].Cells[0].Value.ToString();
            var acc = _serviceQl.GetlstAccounts().FirstOrDefault(c => c.Acc == txt_Acc.Text);
            cbx_GioiTinh.Text = drgrid_Acc.Rows[rowIndex].Cells[1].Value.ToString();
            if (acc.Status == true)
            {
                rdb_HoatDong.Checked = true;
            }
            else
            {
                rdb_KhongHoatDong.Checked = true;
            }

            cbx_LoaiTK.Text = _serviceQl.GetlstRoles().Where(c => c.Id == acc.Roles.Id).Select(c => c.Name)
                .FirstOrDefault();
        }

        private void txt_TimAcc_TextChanged(object sender, EventArgs e)
        {
            LoadGridAccount(txt_TimAcc.Text.ToLower());
        }
        #endregion

        #region 2. Chức năng quản lý sản phẩm

        void LoadGridProduct()
        {
            DataGridViewButtonColumn btnXoaGrid = new DataGridViewButtonColumn();
            btnXoaGrid.Name = "Column_btnXoaGrid";
            btnXoaGrid.HeaderText = "Nút xóa";
            btnXoaGrid.UseColumnTextForButtonValue = true;
            btnXoaGrid.Text = "Xóa";

            dgrid_Sp.ColumnCount = 4;
            dgrid_Sp.Columns[0].Name = "Tên";
            dgrid_Sp.Columns[1].Name = "Số lượng";
            dgrid_Sp.Columns[2].Name = "Giá";
            dgrid_Sp.Columns[3].Name = "Trạng Thái";
            dgrid_Sp.Columns.Add(btnXoaGrid);
            dgrid_Sp.Rows.Clear();
            if (_serviceQl.GetlstProduct().Count < 0) return;
            foreach (var x in _serviceQl.GetlstProduct())
            {
                dgrid_Sp.Rows.Add(x.Name, x.Quantity, x.Price, x.Status == true ? "Hoạt động" : "Không hoạt động");
            }
        }
        void LoadGridProduct(string name)
        {
            dgrid_Sp.ColumnCount = 4;
            dgrid_Sp.Columns[0].Name = "Tên";
            dgrid_Sp.Columns[1].Name = "Số lượng";
            dgrid_Sp.Columns[2].Name = "Giá";
            dgrid_Sp.Columns[3].Name = "Trạng Thái";
            dgrid_Sp.Rows.Clear();
            if (_serviceQl.GetlstProduct().Count < 0) return;
            foreach (var x in _serviceQl.GetlstProduct(name))
            {
                dgrid_Sp.Rows.Add(x.Name, x.Quantity, x.Price, x.Status == true ? "Hoạt động" : "Không hoạt động");
            }
        }
        private void btn_ThemSp_Click(object sender, EventArgs e)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Name = txt_TenSP.Text,
                Quantity = Convert.ToInt32(txt_SoLuongSP.Text),
                Price = Convert.ToDouble(txt_GiaoTienSP.Text),
                Status = rdb_HoatDongSP.Checked

            };
            MessageBox.Show(_serviceQl.AddProduct(product), "Thông báo");
            LoadGridProduct();
        }


        #endregion

        private void dgrid_Sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            var columns = e.ColumnIndex;
            if (e.ColumnIndex == dgrid_Sp.Columns["Column_btnXoaGrid"].Index)
            {
                
            }
        }
    }
}
