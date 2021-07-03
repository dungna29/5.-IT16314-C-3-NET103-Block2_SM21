using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_2_CRUD_TAIKHOAN.IServices;
using BAI_1_2_CRUD_TAIKHOAN.Models;

namespace BAI_1_2_CRUD_TAIKHOAN.Services
{
    class ServiceAccount: IServiceAccount
    {
        private List<Account> _lstAccounts;
        public ServiceAccount()
        {
            _lstAccounts = new List<Account>();
        }

        public string addAccount(Account account)
        {
            if (account == null) return "Thêm thất bại";
            _lstAccounts.Add(account);
            return "Thêm thành công";
        }

        public string editAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public string removeAccount(int id)
        {
            if (_lstAccounts.All(c => c.Id != id)) return "Xóa thất bại";
            _lstAccounts.RemoveAt(_lstAccounts.FindIndex(c=>c.Id == id));
            return "Xóa thành công";

        }

        public Account finAccount(int id)
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
        public void fillDataToListFromFile(List<Account> lstAccounts)
        {
            _lstAccounts = lstAccounts;
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
    }
}
