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
            loadNamSinh();//Load data vào combobox khi form được chạy
            dgrid_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadTable();
        }

        void loadTable()
        {
            TheLoai tl = new TheLoai();
            //Cách 1:
            //dgrid_Table.DataSource = tl.GetListTheLoais();

            //Cách 2: DataTable
            DataTable table = new DataTable();
            //Tạo tên cột và kiểu dữ liệu cột
            table.Columns.Add("Mã TL", typeof(string));
            table.Columns.Add("Tên TL", typeof(string));
            table.Columns.Add("TT", typeof(string));
            table.Columns.Add("Trạng thái sửa", typeof(string));

            //Fill Data
            foreach (var x in tl.GetListTheLoais())
            {
                table.Rows.Add(x.MaTheLoai, x.TenTheLoai, x.TrangThai, x.statuEdit);
            }
            //dgrid_Table.DataSource = table;
            
            //Cách 3: Làm việc trực tiếp với data grid view
            //Cần tạo code và định nghĩa số lượng cột
            dgrid_Table.ColumnCount = 3;//Tạo số lượng cột
            dgrid_Table.Columns[0].Name = "Tên";
            dgrid_Table.Columns[1].Name = "TT";
            dgrid_Table.Columns[2].Name = "TT Sửa";

            //Fill Data
            foreach (var x in tl.GetListTheLoais())
            {
                dgrid_Table.Rows.Add( x.TenTheLoai, x.TrangThai, x.statuEdit);
            }
        }

        void loadNamSinh()
        {
            int temp = 1600;
            for (int i = 0; i <= 2021-1600; i++)
            {
                cbo_NamSinh.Items.Add(temp);
                temp++;
            }

            cbo_NamSinh.SelectedIndex = cbo_NamSinh.FindStringExact("1989");
            //cbo_NamSinh.SelectedIndex = 2021 - 1600;//Combobox sẽ hiển thị giá trị cuối cùng trong tập giá trị của combox
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
