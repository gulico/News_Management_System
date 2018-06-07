using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;//窗体美化

namespace News_Management_System
{
    public partial class register : CCSkinMain
    {
        DBHelper db;
        int register_state = -2;

        public register()
        {
            InitializeComponent();
            skinTextBox3.IsPasswordChat = '*';
            skinTextBox4.IsPasswordChat = '*';
            skinComboBox1.SelectedIndex = 0;
            db = new DBHelper();
            db.Connection();
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            skinLabel6.Text = "";//每次按下都要清空label
            skinLabel7.Text = "";
            skinLabel8.Text = "";
            skinLabel9.Text = "";
            skinLabel10.Text = "";
            Boolean Isinputlegal = true;//输入是否合法

            if (skinTextBox2.Text.Length == 0)
            {
                skinLabel6.Text = "*用户名不能为空";
                Isinputlegal = false;
            }
            if (skinTextBox3.Text.Length == 0)
            {
                skinLabel7.Text = "*密码不能为空";
                Isinputlegal = false;
            }
            if (skinTextBox4.Text.Length == 0)
            {
                skinLabel8.Text = "*请确认密码";
                Isinputlegal = false;
            }
            else if(!skinTextBox3.Text.Equals(skinTextBox4.Text))
            {
                skinLabel8.Text = "*两次密码不一致";
                Isinputlegal = false;
            }
            if (skinTextBox5.Text.Length == 0)
            {
                skinLabel9.Text = "*邮箱不能为空";
                Isinputlegal = false;
            }
            if (!skinCheckBox1.Checked)
            {
                skinLabel10.Text = "*请阅读服务条款并同意";
                Isinputlegal = false;
            }

            string name = "";
            string password = "";
            string sex = "";
            string email = "";
            if (Isinputlegal)//输入合法
            {
                name = skinTextBox2.Text.ToString().Trim();
                password = skinTextBox3.Text.ToString().Trim();
                if (skinRadioButton2.Checked)
                    sex = "男";
                else
                    sex = "女";
                email = skinTextBox5.Text.ToString().Trim();
                email = email + skinComboBox1.Text.Trim();

                register_state = db.register(name,password,sex,email);

                switch (register_state)
                {
                    case -1:
                        MessageBox.Show("注册失败");
                        break;
                    case 0:
                        skinLabel6.Text = "*用户名已存在";
                        MessageBox.Show("用户名已存在");
                        break;
                    case 1:
                        MessageBox.Show("注册成功");
                        Form form_sign_in = new sign_in();
                        form_sign_in .Tag= this.Tag;
                        form_sign_in.Show();
                        this.Close();
                        break;
                }
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (register_state != 1)
            {
                ((Form)this.Tag).Show();
            }
            
        }
    }
}
