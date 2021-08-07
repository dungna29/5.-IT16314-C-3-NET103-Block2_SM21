using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_1_EFCORE_CODEFIRST.Models;
using Microsoft.EntityFrameworkCore;

namespace BAI_1_1_EFCORE_CODEFIRST.DBContext_FPOLY
{
   public class DBContext_Dungna: DbContext//Phải kế thừa lớp DbContext
    {

        //1. Ghi đè 1 phương thức OnConFiguring của lớp cha
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Khi cấu hình đường dẫn nếu chưa có DB thì có thể đặt tên DB ở đây
                optionsBuilder.UseSqlServer("Data Source=DUNGNA_PC2021\\SQLEXPRESS;Initial Catalog=IT16314_EFCODEFIRST;Persist Security Info=True;User ID=dungna29;Password=123");
            }
        }
        //2. Khai báo bảng
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
