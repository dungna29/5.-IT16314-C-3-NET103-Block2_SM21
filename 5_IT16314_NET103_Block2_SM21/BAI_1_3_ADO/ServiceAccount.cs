using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_3_ADO
{
    class ServiceAccount
    {
        private List<Account> _lstAccounts;
        private SqlConnection _conn;
        private SqlCommand _cmd;
        private string _connStr;
        public ServiceAccount(string connStr)
        {
            _lstAccounts = new List<Account>();
            _connStr = connStr;
        }

        public string addAccount(Account account)
        {
            if (account == null) return "Thêm thất bại";
            _lstAccounts.Add(account);
            return "Thêm thành công";
        }

        public string editAccount(Account account)
        {
            int index = _lstAccounts.FindIndex(c => c.Id == account.Id);
            if (index== -1)
            {
                return "Không tìm thấy đối tượng";
            }
            _lstAccounts[index] = account;
            return "Sửa thành công";
        }

        public string removeAccount(Guid id)
        {
            if (_lstAccounts.All(c => c.Id != id)) return "Xóa thất bại";
            _lstAccounts.RemoveAt(_lstAccounts.FindIndex(c=>c.Id == id));
            return "Xóa thành công";

        }

        public Account finAccount(Guid id)
        {
            if (_lstAccounts.Where(c => c.Id == id).FirstOrDefault() == null) return null;
            return _lstAccounts.FirstOrDefault(c => c.Id == id);

        }

        public List<Account> getLstAccounts()
        {
            return _lstAccounts;
        }

        public List<Account> getLstAccountsByAcc(string acc)
        {
            return _lstAccounts.Where(c => c.Acc.StartsWith(acc)).ToList();
        }

        public string[] getYearOfBirth()
        {
            string[] arrYears = new string[2021 - 1900];
            int temp = 1900;
            for (int i = 0; i < arrYears.Length; i++)
            {
                arrYears[i] = temp.ToString();
                temp++;
            }

            return arrYears;
        }
        //Triển khai kết nối DB
        public SqlConnection GetSqlConnection(string sqlConnStr)
        {
            return new SqlConnection(sqlConnStr);
        }

        public SqlCommand GetSqlCommand(string query, SqlConnection conn)
        {
            return new SqlCommand(query, conn);
        }
        //Phương thức lấy dữ liệu từ DB
        public List<Account> GetlstAccountsFromDB()
        {
            _conn = GetSqlConnection(_connStr);
            _cmd = GetSqlCommand("Select * from Accounts_ADO", _conn);
            _conn.Open();
            var data = _cmd.ExecuteReader();//Thực thi câu truy vấn
            _lstAccounts = new List<Account>();
            while (data.Read())
            {
                Account acc = new Account();
                acc.Id = new Guid(data["ID"].ToString());
                acc.Acc = data["Acc"].ToString();
                acc.Pass = data["Pass"].ToString();
                acc.Sex = Convert.ToInt32(data["Sex"].ToString());
                acc.YearofBirth = Convert.ToInt32(data["YearofBirth"].ToString());
                acc.Status = Convert.ToBoolean(data["Status"].ToString());
                _lstAccounts.Add(acc);
            }
            _conn.Close();
            return _lstAccounts;
        }
    }
}
