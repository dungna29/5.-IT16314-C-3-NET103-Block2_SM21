using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_2_CRUD_TAIKHOAN.Models;

namespace BAI_1_2_CRUD_TAIKHOAN.IServices
{
    public interface IServiceAccount
    {
        //1. Phương thức thêm tài khoản
        string addAccount(Account account);
        //2. Phương thức sửa tài khoản
        string editAccount(Account account);
        //3. Phương thức xóa tài khoản
        string removeAccount(int id);
        //4. Phương thức thức tìm kiếm tuyệt đối
        Account finAccount(int id);
        //5. Phương thức lấy danh sách 
        List<Account> getLstAccounts();
        //6. Lọc danh sách theo tài khoản gần đúng tham số là tài khoản truyền vào
        List<Account> getLstAccountsByAcc(string acc);
        //7. Fill data vào List đối tượng khi đọc file lên
        void fillDataToListFromFile(List<Account> lstAccounts);
        //8. Lấy danh sách năm sinh
        string[] getYearOfBirth();
    }
}
