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
    public partial class sign_in : CCSkinMain
    {
        DBHelper db;
        public sign_in()
        {
            InitializeComponent();
            db = new DBHelper();
            db.Connection();
            skinTextBox2.IsPasswordChat = '*';
        }
        /*
         * 按钮按下登录
         * 登录成功弹出massagebox提示登录成功
         */
        private void skinButton1_Click(object sender, EventArgs e)
        {
            skinLabel3.Text = "";//每次按下都要清空label
            skinLabel4.Text = "";
            Boolean Isinputlegal = true;//输入是否合法
            if (skinTextBox1.Text.Length == 0)
            {
                skinLabel3.Text = "*用户名不能为空";
                Isinputlegal = false;
            }
            if (skinTextBox2.Text.Length == 0)
            {
                skinLabel4.Text = "*密码不能为空";
                Isinputlegal = false;
            }

            string name = "";
            string password = "";
            Boolean isUser = true;
            if (Isinputlegal)//输入合法
            {
                name = skinTextBox1.Text.ToString().Trim();
                password = skinTextBox2.Text.ToString().Trim();
                isUser = skinRadioButton1.Checked;
                int sign_in_state = db.sign_in(name, password, isUser);
                System.Console.WriteLine("登录状态： "+sign_in_state);
                switch (sign_in_state)
                {
                    case -1:
                        skinLabel4.Text = "*密码错误";
                        break;
                    case 0:
                        skinLabel3.Text = "*用户名不存在";
                        break;
                    case 1:
                        MessageBox.Show("登陆成功");
                        ((welcome)this.Tag).change_priviliege(1,name,-1);
                        this.Close();
                        break;
                    case 2:
                        MessageBox.Show("最高权限管理员登陆成功");
                        ((welcome)this.Tag).change_priviliege(2, name, 0);
                        this.Close();
                        break;
                    case 3:
                        MessageBox.Show("新闻审核员登陆成功");
                        ((welcome)this.Tag).change_priviliege(2, name, 1);
                        this.Close();
                        break;
                    case 4:
                        MessageBox.Show("新闻录入员登陆成功");
                        ((welcome)this.Tag).change_priviliege(2, name, 2);
                        this.Close();
                        break;
                            
                        
                }
            }
        }

        /*
         * 关闭时show被hide的welcome
         */
        protected override void OnClosing(CancelEventArgs e)
        {
            ((Form)this.Tag).Show(); 
        }
    }
}
