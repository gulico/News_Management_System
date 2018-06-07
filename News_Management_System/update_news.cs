using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using System.IO;//窗体美化

namespace News_Management_System
{
    public partial class update_news : CCSkinMain
    {
        int news_id;
        DBHelper db;
        DataSet newsdate;
        System.IO.FileInfo file;
        string destinationFile = "";
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
        public update_news()
        {
            InitializeComponent();
            db = new DBHelper();
            db.Connection();
        }

        public update_news(int id)
        {
            InitializeComponent();
            news_id = id;
            db = new DBHelper();
            db.Connection();
        }
        /*加载窗体*/
        private void update_news_Load(object sender, EventArgs e)
        {
            newsdate = db.find_news(news_id);
            if (newsdate.Tables[0].Rows.Count > 0)//新闻存在
            {
                title.Text = newsdate.Tables[0].Rows[0]["title"].ToString();
                author.Text = newsdate.Tables[0].Rows[0]["author"].ToString();
                newstype.SelectedIndex = int.Parse(newsdate.Tables[0].Rows[0]["type"].ToString());
                pic.Text = newsdate.Tables[0].Rows[0]["picture"].ToString();
                dateTimePicker1.Text = newsdate.Tables[0].Rows[0]["time"].ToString();
                string contextFile = "";
                try
                {
                    contextFile = System.Windows.Forms.Application.StartupPath + newsdate.Tables[0].Rows[0]["context"].ToString();
                    //System.Console.WriteLine("文章路径"+contextFile);
                    FileStream fs = new FileStream(contextFile, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs, Encoding.Default);
                    List<string> lists = this.newsarticle.Lines.ToList<string>();
                    string line = null;
                    while((line = sr.ReadLine()) != null)
                    {
                        lists.Add(line);
                    }
                    sr.Close();
                    this.newsarticle.Lines = lists.ToArray();

                }
                catch (IOException ex)
                {
                    Console.WriteLine("正文读取错误");
                    Console.WriteLine(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片|*.jpg";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                file = new System.IO.FileInfo(ofd.FileName);
                //其他代码
                pic.Text = ofd.FileName;
                destinationFile = @"\pic\" + file.Name;
                try
                {
                    if (file.Exists)
                    {
                        file.CopyTo(System.Windows.Forms.Application.StartupPath + destinationFile, true);
                        MessageBox.Show("图片更改成功");
                    }
                }
                catch
                {

                }
            }
        }

        /*修改新闻按钮*/
        private void addnews_Click(object sender, EventArgs e)
        {
            string tip = "";
            skinLabel6.Text = "";//每次点击都要刷新提示
            Boolean Isinputlegal = true;//输入是否合法
            if (title.Text.Length == 0)
            {
                tip = tip + "标题不能为空；";
                Isinputlegal = false;
            }
            if (author.Text.Length == 0)
            {
                tip = tip + "作者不能为空；";
                Isinputlegal = false;
            }
            if (pic.Text.Length == 0)
            {
                tip = tip + "图片不能为空；";
                Isinputlegal = false;
            }
            if (newsarticle.Text.Length == 0)
            {
                tip = tip + "文章内容不能为空；";
            }
            skinLabel6.Text = tip;
            if (Isinputlegal)
            {
                string title_str = title.Text.ToString().Trim();
                int type_int = newstype.SelectedIndex;
                string author_str = author.Text.ToString().Trim();
                string datatime_str = dateTimePicker1.Text.ToString().Trim();
                string contextFile = "";
                //把文章内容存入\newscontext\标题.txt
                Boolean context_success = true;
                try
                {
                    contextFile = @"\newscontext\" + title_str + ".txt";
                    StreamWriter sw = new StreamWriter(System.Windows.Forms.Application.StartupPath + contextFile, false, System.Text.Encoding.Default);//第二个参数false覆盖
                    for (int index = 0; index < newsarticle.Lines.GetUpperBound(0); index++)
                    {
                        sw.WriteLine(newsarticle.Lines[index]);
                    }
                    sw.Close();

                }
                catch (IOException ex)
                {
                    Console.WriteLine("正文写入错误");
                    Console.WriteLine(ex.Message);
                    context_success = false;
                }
                if (context_success)
                {
                    Boolean addSuccess = db.update_News(news_id, title_str, type_int, author_str, datatime_str, contextFile, destinationFile);
                    switch (addSuccess)
                    {
                        case true:
                            MessageBox.Show("修改成功");
                            
                            break;
                        case false:
                            MessageBox.Show("修改失败");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("文章正文储存失败");
                }

            }
        }
    }
}
