using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.Models
{
    [Table("Orders")]//Đặt tên bảng
    public class Order
    {
        [Key]//Chỉ định dưới nó sẽ là khóa chính
        public Guid Id { get; set; }
        [StringLength(29)]//Độ dài của chuỗi
        public string Code { get; set; }
        public DateTime? DateCreate { get; set; }
        public int Status { get; set; }// 1. Chưa thanh toán, 2. Đã thanh toán

        [ForeignKey("AccountId")]//Tạo tên cột khóa phụ
        public Account Account { get; set; }
    }
}
