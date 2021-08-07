using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_1_EFCORE_CODEFIRST.DBContext_FPOLY;
using BAI_1_1_EFCORE_CODEFIRST.Models;

namespace BAI_1_1_EFCORE_CODEFIRST.Services
{
   public class ServiceQL
    {
        private List<Account> _lstAccounts;
        private List<Order> _lstOrders;
        private List<OrderDetail> _lstOrderDetails;
        private List<Product> _lstProducts;
        private List<Role> _lstRoles;
        private DBContext_Dungna _dbContext;
        public ServiceQL()
        {
            _dbContext = new DBContext_Dungna();
            _lstAccounts = new List<Account>();
            _lstOrders = new List<Order>();
            _lstOrderDetails = new List<OrderDetail>();
            _lstProducts = new List<Product>();
            _lstRoles = new List<Role>();
            GetlstAccountsFromDB();
            GetlstRolesFromDB();
        }
        #region 1. Chức năng quản lý tài khoản
        public List<Role> GetlstRoles()
        {
            return _lstRoles;
        }

        public void GetlstRolesFromDB()
        {
            _lstRoles = _dbContext.Roles.ToList();
        }
        public List<Account> GetlstAccounts()
        {
            return _lstAccounts;
        }

        public void GetlstAccountsFromDB()
        {
            _lstAccounts = _dbContext.Accounts.ToList();
        }

        public string AddAccount(Account account)
        {
            _dbContext.Add(account);
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Thêm thành công";
        }
        public string UpdateAccount(Account account)
        {
            _dbContext.Update(account);
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Sửa thành công";
        }
        public string DeleteAccount(Guid id)
        {
            _dbContext.Remove(_lstAccounts.FirstOrDefault(c => c.Id == id));
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Xóa thành công";
        }
        //Tìm kiếm gần đúng
        public List<Account> GetlstAccounts(string acc)
        {
            return _lstAccounts.Where(c => c.Acc.ToLower().StartsWith(acc)).ToList();
        }
        #endregion
    }
}
