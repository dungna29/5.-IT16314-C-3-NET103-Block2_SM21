using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_2_CRUD_TAIKHOAN.Views
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public void SenderDataFromLoginToMain(TextBox valueAcc,string path)
        {
            lbl_AccLogin.Text = "Chào mừng bạn: " + valueAcc.Text;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Khi bấm vào dấu x thoát chương trình sẽ show lên thông báo bao gồm 2 nút lựa chọn Yes và No. Nếu chọn Yes thì sẽ đóng toàn bộ chương trình lại
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
         

        }
    }
}
