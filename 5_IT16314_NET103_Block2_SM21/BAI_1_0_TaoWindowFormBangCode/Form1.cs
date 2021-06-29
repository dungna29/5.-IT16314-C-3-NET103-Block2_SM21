using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_0_TaoWindowFormBangCode
{
    class Form1:Form
    {
        private Label lblName;
        private Button btnClick;
        public Form1()
        {
            //Phần 1. Tạo form
            this.Text = "Csharp 3";
            this.Size = new Size(600, 300);

            //Phần 2 Thêm Label vào form
            lblName = new Label();
            lblName.Text = " Chào các bạn ";
            lblName.Location = new Point(100, 100);
            this.Controls.Add(lblName);

            //Phần 3 thêm Button vào form
            btnClick = new Button();
            btnClick.Text = " Click vào đây ";
            btnClick.Width = 300;
            btnClick.Location = new Point(200, 200);
            this.Controls.Add(btnClick);
        }

        public static void Main(string[] arg)
        {
            Application.Run(new Form1());
        }
    }
}
