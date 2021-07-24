using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BAI_1_0_EFCORE_DBFIRST.Models
{
    [Table("Accounts_ADO")]
    public partial class AccountsAdo
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Acc { get; set; }
        [StringLength(50)]
        public string Pass { get; set; }
        public int? Sex { get; set; }
        public int? YearofBirth { get; set; }
        public bool? Status { get; set; }
    }
}
