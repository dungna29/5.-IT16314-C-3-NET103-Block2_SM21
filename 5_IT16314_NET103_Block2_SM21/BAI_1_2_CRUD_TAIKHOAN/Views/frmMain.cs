using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI_1_2_CRUD_TAIKHOAN.IServices;
using BAI_1_2_CRUD_TAIKHOAN.Models;
using BAI_1_2_CRUD_TAIKHOAN.Services;

namespace BAI_1_2_CRUD_TAIKHOAN.Views
{
    public partial class frmMain : Form
    {
        //Khai báo các Service cần dùng
        private IServiceAccount _iServiceAccount;
        private IServiceFiles _iServiceFiles;
        private List<Account> _lstAccounts;
        private string _filePath;
        private Account _account;
       
        public frmMain()
        {
            InitializeComponent();
            _iServiceFiles = new ServiceFiles();
            _iServiceAccount = new ServiceAccount();
            LoadDataToGrid();
            loadCbxNamSinh();
            rbtnNam.Checked = true;
            cbxKhongHoatDong.Checked = true;
        }
        void loadCbxNamSinh()
        {
            foreach (var x in _iServiceAccount.getYearOfBirth())
            {
                cmbNamSinh.Items.Add(x);
            }
            //Hiển thị giá trị cuối cùng của Combobox trừ đi 10
            cmbNamSinh.SelectedIndex = _iServiceAccount.getYearOfBirth().Length - 10;
        }
        void LoadDataToGrid()
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _iServiceAccount.getLstAccounts();//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(Account);
            int slThuocTinh = type.GetProperties().Length;
            dgrid_Account.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrid_Account.Columns[0].Name = "Id";
            dgrid_Account.Columns[1].Name = "Tài Khoản";
            dgrid_Account.Columns[2].Name = "Mật Khẩu";
            dgrid_Account.Columns[3].Name = "Giới Tính";
            dgrid_Account.Columns[4].Name = "Năm Sinh";
            dgrid_Account.Columns[5].Name = "Tuổi";
            dgrid_Account.Columns[6].Name = "Trạng Thái";
            dgrid_Account.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrid_Account.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }

        public void SenderDataFromLoginToMain(TextBox valueAcc, string path)
        {
            lbl_AccLogin.Text = "Chào mừng bạn: " + valueAcc.Text;
            _filePath = path;
            //Khi truyền dường dẫn từ form login lên main thì chúng ta đọc file và đổ dữ liệu vào Account Service
            _iServiceAccount.fillDataToListFromFile(_iServiceFiles.openFile<Account>(path));
            LoadDataToGrid();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Khi bấm vào dấu x thoát chương trình sẽ show lên thông báo bao gồm 2 nút lựa chọn Yes và No. Nếu chọn Yes thì sẽ đóng toàn bộ chương trình lại
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            _account = new Account();
            _account.Id = _lstAccounts.Count;
            _account.Acc = txtAcc.Text;
            _account.Pass = txtPass.Text;
            _account.Sex = rbtnNam.Checked ? 1 : 0;
            _account.YearofBirth = Convert.ToInt32(cmbNamSinh.SelectedItem);
            _account.Status = cbxHoatDong.Checked;
            MessageBox.Show(_iServiceAccount.addAccount(_account), "Thông báo");
            LoadDataToGrid();//Sau khi thêm mới phải load lại Grid
        }

        private void Mn_LuuFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_iServiceFiles.saveFile(_filePath, _lstAccounts), "Thông báo");
        }

        private void cbxHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHoatDong.Checked)
            {
                cbxKhongHoatDong.Checked = false;
            }
        }

        private void cbxKhongHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxKhongHoatDong.Checked)
            {
                cbxHoatDong.Checked = false;
            }
        }

        private void dgrid_Account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1. Lấy index row được bấm
            int rowIndex = e.RowIndex;
            if (rowIndex == _lstAccounts.Count) return;//Khi bấm vào dòng cuối của grid nằm ngoài index của List hiện tại thì sẽ ko làm gì
            //2. Lấy ra giá trị tại cột ID
            var idAccount = dgrid_Account.Rows[rowIndex].Cells[0].Value;
            //3. Gọi phương thức tìm kiếm bên Service
            _account = new Account();
            _account = _iServiceAccount.finAccount(Convert.ToInt32(idAccount));
            //4. Khi đối tượng đc tìm thấy thì sẽ fill data lên trên các Control
            txtAcc.Text = _account.Acc;
            txtPass.Text = _account.Pass;
            rbtnNam.Checked = _account.Sex == 1 ? true : false;
            rbtnNu.Checked = _account.Sex == 0 ? true : false;
            cmbNamSinh.SelectedIndex = cmbNamSinh.FindString(_account.YearofBirth.ToString());
            cbxHoatDong.Checked = _account.Status ? true : false;
            cbxKhongHoatDong.Checked = _account.Status == false ? true : false;
            
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_iServiceAccount.removeAccount(_lstAccounts.Where(c => c.Acc == txtAcc.Text).Select(c => c.Id).FirstOrDefault()));
            //sau khi xóa cần load data
            LoadDataToGrid();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            _account.Acc = txtAcc.Text;
            _account.Pass = txtPass.Text;
            _account.Sex = rbtnNam.Checked ? 1 : 0;
            _account.YearofBirth = Convert.ToInt32(cmbNamSinh.SelectedItem);
            _account.Status = cbxHoatDong.Checked;
            MessageBox.Show(_iServiceAccount.editAccount(_account), "Thông báo");
            //Sau khi sửa load data
            LoadDataToGrid();
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e){
            LoadDataToGridByAcc(txtTimKiem.Text);
        }
        void LoadDataToGridByAcc(string acc)
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _iServiceAccount.getLstAccountsByAcc(acc);//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(Account);
            int slThuocTinh = type.GetProperties().Length;
            dgrid_Account.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrid_Account.Columns[0].Name = "Id";
            dgrid_Account.Columns[1].Name = "Tài Khoản";
            dgrid_Account.Columns[2].Name = "Mật Khẩu";
            dgrid_Account.Columns[3].Name = "Giới Tính";
            dgrid_Account.Columns[4].Name = "Năm Sinh";
            dgrid_Account.Columns[5].Name = "Tuổi";
            dgrid_Account.Columns[6].Name = "Trạng Thái";
            dgrid_Account.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrid_Account.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }
    }
}
