using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_1_TongQuanWindowForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lbl_Ten.Text = "Chào các bạn";
        }

        private void btn_ClickVaoDay_Click(object sender, EventArgs e)
        {
           // lbl_HienThi.Text = "Bạn đã bấm vào nút!";
        }

        private void btn_ClickVaoDay_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "Bạn đang giữ chuột!";
        }

        private void btn_ClickVaoDay_MouseUp(object sender, MouseEventArgs e)
        {
            lbl_HienThi.Text = "Bạn đang nhả chuột!";
        }

        private void btn_Chao_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chào bạn " + txt_Name.Text +" Học môn C#3");
        }
    }
}
