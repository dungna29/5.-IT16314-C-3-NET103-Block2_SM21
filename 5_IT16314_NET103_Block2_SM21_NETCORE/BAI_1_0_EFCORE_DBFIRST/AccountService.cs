using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_0_EFCORE_DBFIRST.Context;
using BAI_1_0_EFCORE_DBFIRST.Models;

namespace BAI_1_0_EFCORE_DBFIRST
{
    class AccountService
    {
        private List<AccountsAdo> _lstAccountsAdos;
        private DatabaseContext _dbContext;//Nhân viên phục vụ các thao tác với CSDl
        public AccountService()
        {
            _lstAccountsAdos = new List<AccountsAdo>();
            _dbContext = new DatabaseContext();
            GetlstAccountsDB();
        }

        public List<AccountsAdo> GetLstAccountsAdos()
        {
            return _lstAccountsAdos;
        }

        private void GetlstAccountsDB()
        {
            _lstAccountsAdos = _dbContext.AccountsAdos.ToList();//Lấy dữ liệu trong bảng Account ở DB
        }

        /// <summary>
        /// Phương thức thêm đối tượng vào trong CSDl
        /// </summary>
        /// <param name="acc">Truyền vào 1 đối tượng Account</param>
        /// <returns>Thêm thành công trả về true</returns>
        public bool Insert(AccountsAdo acc)
        {
            _dbContext.AccountsAdos.Add(acc);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(AccountsAdo acc)
        {
            _dbContext.AccountsAdos.Update(acc);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(Guid id)
        {
            var temp = _lstAccountsAdos.Where(c => c.Id == id).FirstOrDefault();
            _dbContext.AccountsAdos.Remove(temp);
            _dbContext.SaveChanges();
            return true;
        }
        public List<AccountsAdo> GetLstAccountsAdosByAcc(string acc)
        {
            return _lstAccountsAdos.Where(c=>c.Acc.StartsWith(acc)).ToList();
        }

        
    }
}
