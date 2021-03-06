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
    public partial class frmLogin : Form
    {
        //Khai báo các Service cần dùng
        private IServiceAccount _iServiceAccount;
        private IServiceFiles _iServiceFiles;
        private List<Account> _lstAccounts;
        private string _filePath;
        public frmLogin()
        {
            InitializeComponent();
            _iServiceAccount = new ServiceAccount();
            _iServiceFiles = new ServiceFiles();
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (_lstAccounts.Any(c=>c.Acc == txt_Acc.Text && c.Pass == txt_Pass.Text))
            {
                frmMain frmMain = new frmMain();//Khởi tạo lớp đối tượng
                frmMain.SenderDataFromLoginToMain(txt_Acc, _filePath);//Gọi phương thức bên main để truyền dữ liệu
                this.Hide();//Ẩn form hiện tại đi
                MessageBox.Show("Đăng nhập thành công", "Thông báo");
                frmMain.Show();//Hiển thị form Main lên
                return;
            }
            MessageBox.Show("Vui lòng kiểm trả lại Acc & Pass","Thông báo");
        }

        private void btn_Opendata_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _filePath = dlg.FileName;//Tên đường dẫn tuyệt đối của file khi mở file data
                lbl_path.Text = _filePath;
                //Đọc file lên và đổ giá trị trị đọc vào List ở form này
                _lstAccounts = _iServiceFiles.openFile<Account>(_filePath);
                //Gán List đối tượng đã đọc từ file vào bên Service
                _iServiceAccount.fillDataToListFromFile(_lstAccounts);
            }
        }

        private void lbl_DangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();//Ẩn form hiện tại
            frmRegister frmRegister = new frmRegister();
            frmRegister.SenderFilePathFromLogin(_filePath);//Truyền đường dẫn từ login sang form đăng ký thông qua tham số của phương thức
            frmRegister.Show();
        }
    }
}
