using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI_1_0_EFCORE_DBFIRST.Context;
using BAI_1_0_EFCORE_DBFIRST.Models;

namespace BAI_1_0_EFCORE_DBFIRST
{
    public partial class Form1 : Form
    {
        private List<AccountsAdo> _lstAccounts;
        public Form1()
        {
            InitializeComponent();
            Cach1LoadData();


        }
        void Cach1LoadData()//Cách đã học từ bài tổng quan C#
        {
            DatabaseContext dbContext = new DatabaseContext();
            var temp = dbContext.AccountsAdos.ToList();
            
            _lstAccounts = temp;//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(AccountsAdo);
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
                    DateTime.Now.Year - x.YearofBirth, x.Status == true ? "Hoạt động" : "Không Hoạt động");
            }
        }

    }
}
