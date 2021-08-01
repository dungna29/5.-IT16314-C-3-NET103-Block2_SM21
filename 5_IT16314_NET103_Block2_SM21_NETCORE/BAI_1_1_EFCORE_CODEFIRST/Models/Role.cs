using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(10)]
        public string Code { get; set; }//sv,gv,bv....
        [StringLength(50)]
        public string Name { get; set; }//Sinh viên, Giáo viên, Bảo vệ ....
    }
}
