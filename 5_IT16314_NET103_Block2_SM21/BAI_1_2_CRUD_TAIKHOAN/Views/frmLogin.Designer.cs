
namespace BAI_1_2_CRUD_TAIKHOAN.Views
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_DangKy = new System.Windows.Forms.LinkLabel();
            this.lbl_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.txt_Acc = new System.Windows.Forms.TextBox();
            this.lbl_path = new System.Windows.Forms.Label();
            this.btn_Opendata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_DangKy
            // 
            this.lbl_DangKy.AutoSize = true;
            this.lbl_DangKy.Location = new System.Drawing.Point(222, 148);
            this.lbl_DangKy.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.lbl_DangKy.Name = "lbl_DangKy";
            this.lbl_DangKy.Size = new System.Drawing.Size(111, 25);
            this.lbl_DangKy.TabIndex = 27;
            this.lbl_DangKy.TabStop = true;
            this.lbl_DangKy.Text = "Đăng ký?";
            this.lbl_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_DangKy_LinkClicked);
            // 
            // lbl_QuenMatKhau
            // 
            this.lbl_QuenMatKhau.AutoSize = true;
            this.lbl_QuenMatKhau.Location = new System.Drawing.Point(149, 109);
            this.lbl_QuenMatKhau.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.lbl_QuenMatKhau.Name = "lbl_QuenMatKhau";
            this.lbl_QuenMatKhau.Size = new System.Drawing.Size(184, 25);
            this.lbl_QuenMatKhau.TabIndex = 26;
            this.lbl_QuenMatKhau.TabStop = true;
            this.lbl_QuenMatKhau.Text = "Quên mật khẩu?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mật khẩu:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tài khoản: ";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(197, 185);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(136, 43);
            this.btn_Login.TabIndex = 23;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // txt_Pass
            // 
            this.txt_Pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_Pass.Location = new System.Drawing.Point(138, 63);
            this.txt_Pass.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.PasswordChar = '*';
            this.txt_Pass.Size = new System.Drawing.Size(191, 31);
            this.txt_Pass.TabIndex = 22;
            this.txt_Pass.Text = "1";
            // 
            // txt_Acc
            // 
            this.txt_Acc.Location = new System.Drawing.Point(138, 21);
            this.txt_Acc.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.txt_Acc.Name = "txt_Acc";
            this.txt_Acc.Size = new System.Drawing.Size(191, 31);
            this.txt_Acc.TabIndex = 21;
            this.txt_Acc.Text = "dungna";
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_path.Location = new System.Drawing.Point(12, 238);
            this.lbl_path.Margin = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(38, 18);
            this.lbl_path.TabIndex = 28;
            this.lbl_path.Text = "Path";
            // 
            // btn_Opendata
            // 
            this.btn_Opendata.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Opendata.Location = new System.Drawing.Point(4, 268);
            this.btn_Opendata.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.btn_Opendata.Name = "btn_Opendata";
            this.btn_Opendata.Size = new System.Drawing.Size(93, 35);
            this.btn_Opendata.TabIndex = 29;
            this.btn_Opendata.Text = "Mở Data";
            this.btn_Opendata.UseVisualStyleBackColor = true;
            this.btn_Opendata.Click += new System.EventHandler(this.btn_Opendata_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 312);
            this.Controls.Add(this.btn_Opendata);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.lbl_DangKy);
            this.Controls.Add(this.lbl_QuenMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.txt_Acc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lbl_DangKy;
        private System.Windows.Forms.LinkLabel lbl_QuenMatKhau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.TextBox txt_Acc;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.Button btn_Opendata;
    }
}