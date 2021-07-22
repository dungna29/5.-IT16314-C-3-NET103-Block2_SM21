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
    public partial class Form1 : Form
    {
        private string _sqlConnectionStr = @"Data Source=DUNGNA_PC2021\SQLEXPRESS;Initial Catalog=CSharp3_Dungna29;Persist Security Info=True;User ID=dungna29;Password=123";//Chuỗi kết nối csdl
        private SqlConnection _conn;
        private SqlCommand _cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_KetNoi_Click(object sender, EventArgs e)
        {
            //1. Khởi tạo kết nối vào CSDL
            _conn = new SqlConnection(_sqlConnectionStr);
            //2. Mở kết nối
            _conn.Open();
            //3. Mở kết nối xong thì thực hiện 1 hành động nào đó
            //4. Khởi tạo 1 câu Query với SqlCommand
            _cmd = new SqlCommand("Select * from Accounts_ADO", _conn);
            //5. Thực thi và hứng dữ liệu vào SqlDataAdapter
            SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);//Đổ dữ liệu vào Table
            dataGridView1.DataSource = table;
            //6. Sau khi thực hiện xong hành động thì đóng kết nối
            _conn.Close();
        }
    }
}
