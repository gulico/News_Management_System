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
using System.IO;

namespace News_Management_System
{
    public partial class newsdetail : CCSkinMain
    {
        int news_id;
        string user_name;
        DBHelper db;
        DataSet newsdate;
        DataSet commendData;
        int commend_index = -1;
        public enum newsType
        {
            社会 = 0,
            国际 = 1,
            军事 = 2,
            时尚 = 3,
            娱乐 = 4,
            搞笑 = 5,
            八卦 = 6,
            体育 = 7,
            汽车 = 8,
            历史 = 9

        }

        public newsdetail()
        {
            InitializeComponent();
            db = new DBHelper();
            db.Connection();
        }

        public newsdetail(int id,string name)
        {
            InitializeComponent();
            news_id = id;
            db = new DBHelper();
            db.Connection();
            user_name = name;
        }
        /*
         * 加载窗口
         * 同时加载新闻
         */
        private void newsdetail_Load(object sender, EventArgs e)
        {
            newsdate = db.find_news(news_id);
            if (newsdate.Tables[0].Rows.Count > 0)//新闻存在
            {
                title.Text = newsdate.Tables[0].Rows[0]["title"].ToString();
                author.Text = "作者："+newsdate.Tables[0].Rows[0]["author"].ToString();
                string type_str = Enum.GetName(typeof(newsType), newsdate.Tables[0].Rows[0]["type"]);
                newstype.Text = "分类：" + type_str;
                string picpath = System.Windows.Forms.Application.StartupPath + newsdate.Tables[0].Rows[0]["picture"].ToString();
                pictureBox1.Image = Image.FromFile(picpath);
                time.Text = "时间"+newsdate.Tables[0].Rows[0]["time"].ToString();
                string contextFile = "";
                try
                {
                    contextFile = System.Windows.Forms.Application.StartupPath + newsdate.Tables[0].Rows[0]["context"].ToString();
                    FileStream fs = new FileStream(contextFile, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        context.Text = context.Text + line + "\n";
                    }
                    sr.Close();

                }
                catch (IOException ex)
                {
                    Console.WriteLine("正文读取错误");
                    Console.WriteLine(ex.Message);
                }

                //设置添加评论的位置
                Point add_commend_position = new Point(add_commend_panel.Location.X, context.Location.Y + context.Size.Height + 50);
                add_commend_panel.Location = add_commend_position;
                if(user_name.Length>0)
                {
                    add_comend_button.Enabled = true;
                    add_commend_name.Text = user_name;
                }
                else
                {
                    add_comend_button.Enabled = false;
                }
                commendData = db.find_commendBynewsid(news_id);
                if (commendData.Tables[0].Rows.Count > 0)//存在评论
                {
                    commend_index = 0;
                    //设置评论区域的位置
                    Point p = new Point(commend_panel.Location.X, add_commend_panel.Location.Y + add_commend_panel.Size.Height + 50);
                    commend_panel.Location = p;
                    commend_panel.Visible = true;
                    load_commend();
                }
                
            }
        }

        /*下一条评论*/
        private void down_Click(object sender, EventArgs e)
        {
            ++commend_index;
            load_commend();
        }

        /*上一条评论*/
        private void up_Click(object sender, EventArgs e)
        {
            --commend_index;
            load_commend();
        }

        /*加载评论*/
        public void load_commend(){
            commend_username.Text = "用户名：" + commendData.Tables[0].Rows[commend_index]["user_name"].ToString();
            commend.Text = commendData.Tables[0].Rows[commend_index]["commend_text"].ToString();
            commend_time.Text = commendData.Tables[0].Rows[commend_index]["time"].ToString();
            commend_num.Text = (commend_index + 1) + " 楼";
            if (commend_index > 0)
                up.Visible = true;
            else
                up.Visible = false;
            if (commend_index + 1 < commendData.Tables[0].Rows.Count)
                down.Visible = true;
            else
                down.Visible = false;
        }

        /*提交评论*/
        private void add_comend_button_Click(object sender, EventArgs e)
        {
            string commend_text = add_commend_textbox.Text;
            Boolean success = db.addCommend(user_name, news_id, commend_text, DateTime.Now.ToString());
            if (success)
            {
                add_commend_textbox.Text = "";
                MessageBox.Show("评论成功");
                commendData = db.find_commendBynewsid(news_id);
                commend_index = 0;
                load_commend();
            }
            else
                MessageBox.Show("评论失败");
                

        }

        /*
         * 关闭时清空文章
         */
        protected override void OnClosing(CancelEventArgs e)
        {
            context.Text = "";
        }

    }
}
