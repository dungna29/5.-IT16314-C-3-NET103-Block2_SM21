using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_3_ADO
{
    public partial class _2_MainAccount_ADO : Form
    {
        private ServiceAccount _serviceAccount;
        private string _sqlConnectionStr = @"Data Source=DUNGNA_PC2021\SQLEXPRESS;Initial Catalog=CSharp3_Dungna29;Persist Security Info=True;User ID=dungna29;Password=123";//Chuỗi kết nối csdl
        private List<Account> _lstAccounts;
        public _2_MainAccount_ADO()
        {
            InitializeComponent();
            _serviceAccount = new ServiceAccount(_sqlConnectionStr);
            LoadDataToGrid();
        }
        void LoadDataToGrid()
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _serviceAccount.GetlstAccountsFromDB();//Lấy List Account
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
