using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI_1_1_EFCORE_CODEFIRST.DBContext_FPOLY;
using BAI_1_1_EFCORE_CODEFIRST.Models;

namespace BAI_1_1_EFCORE_CODEFIRST
{
    public partial class Form1 : Form
    {
        private DBContext_Dungna _dbContext;
        public Form1()
        {
            InitializeComponent();
            _dbContext = new DBContext_Dungna();
            _dbContext.Roles.Add(new Role {Id = Guid.NewGuid(), Code = "SV", Name = "Sinh Viên"});
            _dbContext.Roles.Add(new Role {Id = Guid.NewGuid(), Code = "GV",Name = "Giáo Viên"});
            _dbContext.SaveChanges();
        }

    }
}
