using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace News_Management_System
{
    class DBHelper
    {
        SqlConnection con;
        //创建连接
        public void Connection()
        {
            string constr = "server=.;database=newsData;integrated security=SSPI";
            con = new SqlConnection(constr);
        }

        /*
         * 登录读取用户名密码
         * 返回值 ：0用户名不存在 ，-1密码错误，
         * 1普通用户登陆成功，2最高权限管理员，3新闻审核员，4新闻录入员
         */
        public int sign_in(string name, string psd, Boolean isUser)
        {
            Boolean Havename = false;
            string search_psd = "";
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql;
                if (isUser)//普通用户
                    sql = "select * from user_info where name = '" + name + "'";
                else
                    sql = "select * from admin_info where name = '" + name + "'";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                if (ds.Tables[0].Rows.Count > 0)//用户存在
                {
                    search_psd = ds.Tables[0].Rows[0]["password"].ToString();
                    Havename = true;
                }

                con.Close();
            }
            catch
            {
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            if (search_psd.Equals(psd)){
                if (isUser)
                    return 1;
                else
                {
                    int limit = int.Parse(ds.Tables[0].Rows[0]["limit"].ToString().Trim());
                    if (limit == 0)//最高权限管理员
                        return 2;
                    else if (limit == 1)//新闻审核员
                        return 3;
                    else
                        return 4;
                }
            }  
            else if (Havename)
                return -1;
            else
                return 0;

        }
        /*
         * 注册
         * 返回值：0用户名已存在;1注册成功;-1注册失败
         */
        public int register(string name,string password ,string sex,string email)
        {
            Boolean Havename = false;//是否存在相同用户
            Boolean register_success = false;
            try
            {
                con.Open();
                string sql = "select * from user_info where name = '" + name + "'";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                if (ds.Tables[0].Rows.Count > 0)//用户存在
                {
                    Havename = true;
                }
                else//用户不存在，向数据库中添加新用户
                {
                    sql = "insert into user_info(name,password,sex,email)Values('"+name+"','"+password+"','"+sex+"','"+email+"')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    register_success = true;
                }
                con.Close();
            }
            catch
            {

            }

            if (con.State == ConnectionState.Open)
                con.Close();

            if (Havename)
                return 0;
            else if (register_success)
                return 1;
            else
                return -1;
        }
        /*
         * 添加新闻
         * 返回值：true添加成功；false添加失败
         */
        public Boolean addNews(string title,int type,string author,string datatime,string context,string pic)
        {
            //标题，分类，作者，日期，图片路径，正文
            Boolean success = false;
            //string search_psd = "";
            try
            {
                con.Open();
                string sql;
                sql = "insert into news(title,type,author,time,context,picture,passed)Values('" + title + "'," + type + ",'" + author + "','" + datatime + "','" + context + "','" + pic +"',0)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            if (success)
                return true;
            return false;
        }
        /*
         * 添加管理员
         * 返回值：0用户名已存在;1注册成功;-1注册失败
         */
        public int addAdmin(string name, string password)
        {
            Boolean Havename = false;//是否存在相同用户
            Boolean register_success = false;
            try
            {
                con.Open();
                string sql = "select * from admin_info where name = '" + name + "'";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                if (ds.Tables[0].Rows.Count > 0)//用户存在
                {
                    Havename = true;
                }
                else//用户不存在，向数据库中添加新用户
                {
                    sql = "insert into admin_info(name,password)Values('" + name + "','" + password + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    register_success = true;
                }
                con.Close();
            }
            catch
            {

            }

            if (con.State == ConnectionState.Open)
                con.Close();

            if (Havename)
                return 0;
            else if (register_success)
                return 1;
            else
                return -1;
        }
        /*
         * 获取user表格
         * 返回值：DataSet数据集
         */
        public DataSet show_usertable()
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql = "select * from user_info";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {

            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }

        /*
         * 获取特定id 的用户
         * 返回值：DataSet
         */
        public DataSet find_user(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql;
                sql = "select * from user_info where id = " + id + "";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }
        
        /*
         * 更新特定id的用户信息
         * 参数：id 用户标识符；password 密码；sex 性别；email 邮箱
         * 返回值：true更新成功
         */
        public Boolean updata_user(int id,string password,string sex,string email)
        {
            Boolean success = false;
            try
            {
                con.Open();
                string sql = "update user_info set password = '"+password+"',sex = '"+sex+"',email = '"+email+"'  where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch (SqlException e)
            {
                System.Console.WriteLine(e.ToString());
            }

            if (con.State == ConnectionState.Open)
                con.Close();
            return success;
        }
        /*
         * 删除特定id 用户
         * 返回值：true删除成功
         */
        public Boolean delete_user(int id)
        {
            Boolean success = false;
            try
            {
                con.Open();
                string sql = "delete user_info where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch (SqlException e)
            {
                System.Console.WriteLine(e.ToString());
            }

            if (con.State == ConnectionState.Open)
                con.Close();
            return success;
        }

        /*
         * 获取news表格
         * 返回值：DataSet数据集
         */
        public DataSet show_newstable()
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql = "select * from news";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {

            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }

        /*
         * 获取特定id 的新闻
         * 返回值：DataSet
         */
        public DataSet find_news(int id)
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql;
                sql = "select * from news where id = " + id + "";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }
        
        /*
         * 修改新闻
         * 返回值：true修改成功
         */
        public Boolean update_News(int id,string title, int type, string author, string datatime, string context, string pic){
            //标题，分类，作者，日期，图片路径，正文
            Boolean success = false;
            //string search_psd = "";
            try
            {
                con.Open();
                string sql;
                sql = "update news set title = '" + title + "',type = " + type + ",author = '" + author + "',time = '" + datatime + "',context = '" + context + "',picture = '" + pic + "'  where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            if (success)
                return true;
            return false;
        }
        /*
         * 删除新闻
         * 返回值：true成功删除
         */
        public Boolean delete_news(int id)
        {
            Boolean success = false;
            try
            {
                con.Open();
                string sql = "delete news where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch (SqlException e)
            {
                System.Console.WriteLine(e.ToString());
            }

            if (con.State == ConnectionState.Open)
                con.Close();
            return success;
        }

        /*
         * 获取特定type而且通过审核的新闻
         * 返回值：DataSet
         */
        public DataSet find_newsByType(int type)
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql;
                sql = "select * from news where type = " + type + "and passed = 1" ;
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }

        /*
         * 获取特定id 的评论
         * 返回值：DataSet
         */
        public DataSet find_commendBynewsid(int news_id)
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql;
                sql = "select * from commend where news_id = " + news_id + "";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }

        /*
         * 添加评论
         * 参数：user_name 用户名 ；news_id 新闻id ；commend_text 评论内容；time评论时间
         * 返回值：true评论成功
         */
        public Boolean addCommend(string user_name, int news_id, string commend_text, string time)
        {
            Boolean success = false;
            try
            {
                con.Open();
                string sql;
                sql = "insert into commend(user_name,news_id,commend_text,time)Values('" + user_name + "'," + news_id + ",'" + commend_text + "','" + time + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            if (success)
                return true;
            return false;
        }

        /*
        * 获取news未通过审核的新闻
        * 返回值：DataSet数据集
        */
        public DataSet show_newsUnpassed()
        {
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                string sql = "select * from news where passed = 0";
                //获取数据数据适配器
                SqlDataAdapter data = new SqlDataAdapter(sql, con);
                data.Fill(ds);//把查询到的数据放入DataSet ds数据集中
                con.Close();
            }
            catch
            {

            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return ds;
        }

        /*新闻通过审核*/
        public Boolean update_NewsPassed(int id)
        {
            //标题，分类，作者，日期，图片路径，正文
            Boolean success = false;
            //string search_psd = "";
            try
            {
                con.Open();
                string sql;
                sql = "update news set passed = 1 where id = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                success = true;
                con.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.ToString());
            }
            if (con.State == ConnectionState.Open)
                con.Close();

            if (success)
                return true;
            return false;
        }
    }

}
