using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.Models
{
    [Table("Accounts")]//Đặt tên bảng
    public class Account
    {
        [Key]//Chỉ định dưới nó sẽ là khóa chính
        public Guid Id { get; set; }
        [StringLength(29)]//Độ dài của chuỗi
        public string Acc { get; set; }
        [StringLength(29)]
        public string Pass { get; set; }
        public int? Sex { get; set; }
        public int? YearofBirth { get; set; }
        public bool? Status { get; set; }
    }
}
