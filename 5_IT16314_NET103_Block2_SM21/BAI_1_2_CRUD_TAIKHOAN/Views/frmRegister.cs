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
    public partial class frmRegister : Form
    {
        //Khai báo các Service cần dùng
        private IServiceAccount _iServiceAccount;
        private IServiceFiles _iServiceFiles;
        private List<Account> _lstAccounts;
        private string _filePath;
        private Account _account;
        public frmRegister()
        {
            InitializeComponent();
            //Khởi tạo
            _iServiceAccount = new ServiceAccount();
            _iServiceFiles = new ServiceFiles();
            _lstAccounts = new List<Account>();
            rbtnNam.Checked = true;
            loadCbxNamSinh();//Load năm sinh khi chạy chương trình
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
        //Phương thức lấy đường dẫn từ form login truyền lên form đăng ký
        public void SenderFilePathFromLogin(string duongDan)
        {
            _filePath = duongDan;
        }

        private void btn_TaoTaiKhoan_Click(object sender, EventArgs e)
        {
            //Bước 1: Đọc file lên để lấy dữ liệu bên trong file data gán lại cho list toàn cục
            _lstAccounts = _iServiceFiles.openFile<Account>(_filePath);
            if (_lstAccounts == null)
            {
                _lstAccounts = new List<Account>();
            }
            //Bước 2: Khởi tạo và gán giá trị đối tường và thêm đối tượng vào cuối của danh sách đang có.Nếu không đọc file lên sẽ bị ghi đè mất dữ liệu và luôn chỉ có đối tượng mới được lưu.
            _account = new Account();
            _account.Id = _lstAccounts.Count;
            _account.Acc = txtAcc.Text;
            _account.Pass = txtPass.Text;
            _account.Sex = rbtnNam.Checked ? 1 : 0;
            _account.YearofBirth = Convert.ToInt32(cmbNamSinh.SelectedItem);
            _lstAccounts.Add(_account);
            //Bước 3: Lưu file
            MessageBox.Show(_iServiceFiles.saveFile(_filePath, _lstAccounts), "Thông báo");
            //Bước 4: Quay về bên form main
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();

        }
    }
}
