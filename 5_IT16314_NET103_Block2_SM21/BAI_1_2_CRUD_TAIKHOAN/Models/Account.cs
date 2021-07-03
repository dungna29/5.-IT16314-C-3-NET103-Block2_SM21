using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_2_CRUD_TAIKHOAN.Models
{
    [Serializable]
    public class Account
    {
        public int Id { get; set; }
        public string Acc { get; set; }//Tài khoản
        public string Pass { get; set; }//Mật khẩu
        public int Sex { get; set; }//Giới tính 1 = Nam 0 Nữ
        public int YearofBirth { get; set; }//Năm sinh 
        public bool Status { get; set; }//True = Hoạt động Còn False = ko hoạt động
    }
}
