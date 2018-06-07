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
    public partial class updata_user : CCSkinMain
    {
        int user_id;
        DBHelper db;
        DataSet userdata;
        public updata_user()
        {
            InitializeComponent();
            skinComboBox1.SelectedIndex = 0;
            db = new DBHelper();
            db.Connection();
        }

        public updata_user(int id)
        {
            InitializeComponent();
            skinComboBox1.SelectedIndex = 0;
            db = new DBHelper();
            db.Connection();
            user_id = id; 
        }

        /*加载窗体*/
        private void updata_user_Load(object sender, EventArgs e)
        {
            userdata = db.find_user(user_id);//获取id对应的用户信息
            if (userdata.Tables[0].Rows.Count > 0)//用户存在
            {
                userid_textbox.Text = userdata.Tables[0].Rows[0]["id"].ToString();
                username_textbox.Text = userdata.Tables[0].Rows[0]["name"].ToString();
                password_textbox.Text = userdata.Tables[0].Rows[0]["password"].ToString();
                if (userdata.Tables[0].Rows[0]["sex"].ToString().Trim().Equals("男"))
                    skinRadioButton2.Checked = true;
                else
                    skinRadioButton3.Checked = true;
                string email_str = userdata.Tables[0].Rows[0]["email"].ToString();
                string[] email_split = new string[5];
                char[] separator = {'@' };
                email_split = email_str.Split(separator);
                email_textbox.Text = email_split[0];
                skinComboBox1.Text = "@"+email_split[1];
            }
        }
        /*确认修改*/
        private void skinButton1_Click(object sender, EventArgs e)
        {
            Boolean Isinputlegal = true;//输入是否合法
            string password = password_textbox.Text.ToString().Trim();
            string email = email_textbox.Text.ToString().Trim();
            if (password.Length == 0)
            {
                Isinputlegal = false;
                MessageBox.Show("密码不能为空");
            }
            if (email.Length == 0)
            {
                Isinputlegal = false;
                MessageBox.Show("邮箱不能为空");
            }

            if (Isinputlegal)
            {
                email = email+skinComboBox1.Text.ToString().Trim();
                string sex = "";
                if(skinRadioButton2.Checked)
                    sex = "男";
                else
                    sex = "女";
                Boolean updata_success = db.updata_user(user_id,password,sex,email);
                if(updata_success)
                    MessageBox.Show("修改成功");
                else
                    MessageBox.Show("修改失败");
            }
            
        }

    }
}
