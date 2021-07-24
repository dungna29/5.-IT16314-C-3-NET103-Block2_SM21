using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private SqlConnection _conn;
        private SqlCommand _cmd;
        public _2_MainAccount_ADO()
        {
            InitializeComponent();
            _serviceAccount = new ServiceAccount(_sqlConnectionStr);
            Cach1LoadData();
            Cach3LoadData();
            Cach4LoadData();
        }
        void Cach1LoadData()//Cách đã học từ bài tổng quan C#
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

        void Cach2LoadData()//SqlDataAdapter
        {
            _conn = new SqlConnection(_sqlConnectionStr);
            _conn.Open();//Mở kết nối vào CSDL
            _cmd = new SqlCommand("Select * from Accounts_ADO", _conn);
            //Sử dụng SqlDataAdapter hứng dữ liệu khi truy vấn
            SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd);

            //DataTable là con của Dataset và nó tương ứng 1 bảng trong CSDL bao gồm row và col
            //DataSet là tập hợp các bảng bên trong

            //Dùng Datable
            DataTable tb = new DataTable();
            dataAdapter.Fill(tb);//Đổ dữ liệu vào Table
            dgrid_Account2.DataSource = tb;
            //Với cách này không nên can thiệp vào tên các cột có trong CSDL. Và nếu muốn can thiệp phải sử dụng cách Truy vấn với câu SQL có từ khóa AS.
            _conn.Close();//Sau khi thực hiện 1 hành động thì đóng kết nốt

        }
        void Cach3LoadData()//Không sử dụng SqlCommand
        {
            _conn = new SqlConnection(_sqlConnectionStr);
            _conn.Open();//Mở kết nối vào CSDL
            //Sử dụng SqlDataAdapter hứng dữ liệu khi truy vấn
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Accounts_ADO", _conn);

            //DataTable là con của Dataset và nó tương ứng 1 bảng trong CSDL bao gồm row và col
            //DataSet là tập hợp các bảng bên trong

            //Dùng Datable
            DataTable tb = new DataTable();
            dataAdapter.Fill(tb);//Đổ dữ liệu vào Table
            dgrid_Account2.DataSource = tb;
            //Với cách này không nên can thiệp vào tên các cột có trong CSDL. Và nếu muốn can thiệp phải sử dụng cách Truy vấn với câu SQL có từ khóa AS.
            _conn.Close();//Sau khi thực hiện 1 hành động thì đóng kết nốt

        }
        void Cach4LoadData()//Không sử dụng SqlCommand
        {
            _conn = new SqlConnection(_sqlConnectionStr);
            _conn.Open();//Mở kết nối vào CSDL
            //Sử dụng SqlDataAdapter hứng dữ liệu khi truy vấn
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Accounts_ADO", _conn);

            //DataTable là con của Dataset và nó tương ứng 1 bảng trong CSDL bao gồm row và col
            //DataSet là tập hợp các bảng bên trong

            //Dùng DataSet
            DataSet dataset = new DataSet();
            dataAdapter.Fill(dataset);//Đổ dữ liệu vào Table
            dgrid_Account3.DataSource = dataset.Tables[0];//Vì nó là tập hợp các bảng bên trong vì vậy không thể gán trực tiếp
           
            _conn.Close();//Sau khi thực hiện 1 hành động thì đóng kết nốt

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            _conn = new SqlConnection(_sqlConnectionStr);
            _conn.Open();//Mở kết nối vào CSDL
            string query = @"INSERT INTO Accounts_ADO(Acc,Pass,Sex,YearofBirth,Status) VALUES (@Acc,@Pass,@Sex,@YearofBirth,@Status)";
            _cmd = new SqlCommand(query, _conn);
            _cmd.CommandText = query;
            _cmd.Parameters.AddWithValue("@Acc", txtAcc.Text);
            _cmd.Parameters.AddWithValue("@Pass", txtPass.Text);
            _cmd.Parameters.AddWithValue("@Sex", rbtnNam.Checked?1:0);
            _cmd.Parameters.AddWithValue("@YearofBirth", cmbNamSinh.Text);
            _cmd.Parameters.AddWithValue("@Status", cbxHoatDong.Checked);

            _cmd.ExecuteNonQuery();//Thực thi câu truy vấn không trả về dữ liệu
            _conn.Close();//Sau khi thực hiện 1 hành động thì đóng kết nốt
            Cach1LoadData();
            Cach3LoadData();
            Cach4LoadData();
        }
    }
}
