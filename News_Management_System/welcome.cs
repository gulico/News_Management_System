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
    
    public partial class welcome : CCSkinMain
    {
        public int sign_in_state = 0;//0:未登录;1:用户登录;2:管理员登录
        public int limit = -1;//管理员级别：-1普通用户；0最高级别管理员；1新闻审核员；2新闻录入员
        public string name = "";
        DBHelper db;
        DataSet ds;
        public enum newsType
        {
            社会=0,
            国际=1,
            军事=2,
            时尚=3,
            娱乐=4,
            搞笑=5,
            八卦=6,
            体育=7,
            汽车=8,
            历史=9
            
        }
        public int newsTypechosed = 0;//默认选定0
        public welcome()
        {
            InitializeComponent();
            change_priviliege(0,"",-1);
            db = new DBHelper();
            db.Connection();
        }
        
        public void change_ToolStripMenuItem(int oldType,int newType)
        {
            load_news();
            switch (oldType)
            {
                case (int)newsType.社会:
                    社会ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.国际:
                    国际ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.军事:
                    军事ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.时尚:
                    时尚ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.娱乐:
                    娱乐ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.搞笑:
                    搞笑ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.八卦:
                    八卦ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.体育:
                    体育ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.汽车:
                    汽车ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
                case (int)newsType.历史:
                    历史ToolStripMenuItem.BackColor = System.Drawing.Color.Azure;
                    break;
            }

            switch (newType)
            {
                case (int)newsType.社会:
                    社会ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.国际:
                    国际ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.军事:
                    军事ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.时尚:
                    时尚ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.娱乐:
                    娱乐ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.搞笑:
                    搞笑ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.八卦:
                    八卦ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.体育:
                    体育ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.汽车:
                    汽车ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
                case (int)newsType.历史:
                    历史ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(128, 208, 255);
                    break;
            }
        }
        private void 社会ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.社会);
            newsTypechosed = (int)newsType.社会;
        }

        private void 国际ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.国际);
            newsTypechosed = (int)newsType.国际;
        }

        private void 军事ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.军事);
            newsTypechosed = (int)newsType.军事;
        }

        private void 时尚ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.时尚);
            newsTypechosed = (int)newsType.时尚;
        }

        private void 娱乐ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.娱乐);
            newsTypechosed = (int)newsType.娱乐;
        }

        private void 搞笑ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.搞笑);
            newsTypechosed = (int)newsType.搞笑;
        }

        private void 八卦ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.八卦);
            newsTypechosed = (int)newsType.八卦;
        }

        private void 体育ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.体育);
            newsTypechosed = (int)newsType.体育;
        }

        private void 汽车ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.汽车);
            newsTypechosed = (int)newsType.汽车;
        }

        private void 历史ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            change_ToolStripMenuItem(newsTypechosed, (int)newsType.历史);
            newsTypechosed = (int)newsType.历史;
        }

        /*
         * 按下登录按钮
         */
        private void button1_Click(object sender, EventArgs e)
        {
            Form form_sign_in = new sign_in();
            form_sign_in .Tag= this;
            this.Hide();
            form_sign_in.Show();
            
        }
        /*
         * 按下注册按钮
         */
        private void button2_Click(object sender, EventArgs e)
        {
            Form form_register = new register();
            form_register.Tag = this;
            this.Hide();
            form_register.Show();
        }
        /*按下管理按钮*/
        private void button3_Click(object sender, EventArgs e)
        {
            Form form_manager = new manager(limit);
            form_manager.Show();
        }

        public void change_priviliege(int newsign_in_state,string newname,int newlimit)
        {
            sign_in_state = newsign_in_state;
            if (sign_in_state == 0)//未登录
            {
                skinPanel2.Visible = true;//登录、注册按钮可用
                button5.Visible = false;//隐藏注销按钮
                button3.Visible = false;//管理按钮隐藏
                name = "";
            }
            else if (sign_in_state == 1)//普通用户登录
            {
                skinPanel2.Visible = false;//登录、注册按钮不可用
                button5.Visible = true;//启用注销按钮
                name = newname;
                //label2.Visible = true;
                //label2.Text = "欢迎" + name + "!";
            }
            else if (sign_in_state == 2)
            {//管理员登录
                skinPanel2.Visible = false;//登录、注册按钮不可用
                button5.Visible = true;//启用注销按钮
                button3.Visible = true;//管理按钮启用
                name = newname;
                limit = newlimit;
                //skinLabel1.Visible = true;
               // skinLabel1.Text = "欢迎管理员" + name + "!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            change_priviliege(0, "",-1);
            MessageBox.Show("注销成功");
        }

        /*加载窗体*/
        private void welcome_Load(object sender, EventArgs e)
        {
            load_news();
        }

        /*加载新闻*/
        public void load_news()
        {
            ds = db.find_newsByType(newsTypechosed);
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] is Panel)
                {
                    for (int j = 0; j < (panel1.Controls[i] as Panel).Controls.Count; j++)
                    {
                        if (!(ds.Tables[0].Rows.Count > i))//若没有新闻了就把小panel隐藏
                        {
                            (panel1.Controls[i] as Panel).Visible = false;
                            continue;
                        }
                        else
                        {
                            (panel1.Controls[i] as Panel).Visible = true;
                        }
                        if ((panel1.Controls[i] as Panel).Controls[j] is Label)
                        {//填充标题 
                            ((panel1.Controls[i] as Panel).Controls[j] as Label).Text = ds.Tables[0].Rows[i]["title"].ToString();
                        }
                        else if ((panel1.Controls[i] as Panel).Controls[j] is PictureBox)
                        {//填充图片
                            //使tag携带新闻id
                            ((panel1.Controls[i] as Panel).Controls[j] as PictureBox).Tag = ds.Tables[0].Rows[i]["id"].ToString();
                            string picpath = System.Windows.Forms.Application.StartupPath + ds.Tables[0].Rows[i]["picture"].ToString();
                            ((panel1.Controls[i] as Panel).Controls[j] as PictureBox).Image = Image.FromFile(picpath);
                        }
                    }
                }
            }
        }

        /*点击左上角图片*/
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form form_newsdetail = new newsdetail(int.Parse(pictureBox4.Tag.ToString()),name);
            form_newsdetail.Show();
        }

        /*点击右上角图片*/
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form form_newsdetail = new newsdetail(int.Parse(pictureBox3.Tag.ToString()),name);
            form_newsdetail.Show();
        }

        /*点击左下角图片*/
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form form_newsdetail = new newsdetail(int.Parse(pictureBox2.Tag.ToString()),name);
            form_newsdetail.Show();
        }

        /*点击右下角图片*/
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form form_newsdetail = new newsdetail(int.Parse(pictureBox1.Tag.ToString()),name);
            form_newsdetail.Show();
        }
    }
}
