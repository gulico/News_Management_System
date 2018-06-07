namespace News_Management_System
{
    partial class newsdetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newsdetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.commend_panel = new System.Windows.Forms.Panel();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.commend_time = new System.Windows.Forms.Label();
            this.commend = new System.Windows.Forms.Label();
            this.commend_username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newstype = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.context = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.commend_num = new System.Windows.Forms.Label();
            this.add_commend_panel = new System.Windows.Forms.Panel();
            this.add_commend_textbox = new CCWin.SkinControl.SkinTextBox();
            this.add_commend_name = new CCWin.SkinControl.SkinLabel();
            this.add_comend_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.commend_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.add_commend_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.add_commend_panel);
            this.panel1.Controls.Add(this.commend_panel);
            this.panel1.Controls.Add(this.newstype);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.context);
            this.panel1.Controls.Add(this.time);
            this.panel1.Controls.Add(this.author);
            this.panel1.Controls.Add(this.title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 418);
            this.panel1.TabIndex = 0;
            // 
            // commend_panel
            // 
            this.commend_panel.Controls.Add(this.commend_num);
            this.commend_panel.Controls.Add(this.up);
            this.commend_panel.Controls.Add(this.down);
            this.commend_panel.Controls.Add(this.commend_time);
            this.commend_panel.Controls.Add(this.commend);
            this.commend_panel.Controls.Add(this.commend_username);
            this.commend_panel.Controls.Add(this.label1);
            this.commend_panel.Location = new System.Drawing.Point(37, 956);
            this.commend_panel.Name = "commend_panel";
            this.commend_panel.Size = new System.Drawing.Size(593, 203);
            this.commend_panel.TabIndex = 6;
            this.commend_panel.Visible = false;
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.White;
            this.up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.up.Location = new System.Drawing.Point(226, 164);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(75, 23);
            this.up.TabIndex = 7;
            this.up.Text = "上一条";
            this.up.UseVisualStyleBackColor = false;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.White;
            this.down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.down.Location = new System.Drawing.Point(307, 164);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(75, 23);
            this.down.TabIndex = 6;
            this.down.Text = "下一条";
            this.down.UseVisualStyleBackColor = false;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // commend_time
            // 
            this.commend_time.AutoSize = true;
            this.commend_time.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commend_time.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commend_time.Location = new System.Drawing.Point(36, 117);
            this.commend_time.Name = "commend_time";
            this.commend_time.Size = new System.Drawing.Size(32, 17);
            this.commend_time.TabIndex = 5;
            this.commend_time.Text = "时间";
            // 
            // commend
            // 
            this.commend.AutoSize = true;
            this.commend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commend.Location = new System.Drawing.Point(73, 73);
            this.commend.Name = "commend";
            this.commend.Size = new System.Drawing.Size(75, 17);
            this.commend.TabIndex = 4;
            this.commend.Text = "评论balabal";
            // 
            // commend_username
            // 
            this.commend_username.AutoSize = true;
            this.commend_username.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commend_username.Location = new System.Drawing.Point(33, 39);
            this.commend_username.Name = "commend_username";
            this.commend_username.Size = new System.Drawing.Size(56, 17);
            this.commend_username.TabIndex = 3;
            this.commend_username.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "评论：";
            // 
            // newstype
            // 
            this.newstype.AutoSize = true;
            this.newstype.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newstype.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.newstype.Location = new System.Drawing.Point(200, 70);
            this.newstype.Name = "newstype";
            this.newstype.Size = new System.Drawing.Size(54, 20);
            this.newstype.TabIndex = 5;
            this.newstype.Text = "分类：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(37, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(465, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // context
            // 
            this.context.AutoSize = true;
            this.context.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.context.Location = new System.Drawing.Point(33, 414);
            this.context.MaximumSize = new System.Drawing.Size(600, 0);
            this.context.Name = "context";
            this.context.Size = new System.Drawing.Size(9, 38);
            this.context.TabIndex = 3;
            this.context.Text = "\r\n\r\n";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.time.Location = new System.Drawing.Point(373, 70);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(54, 20);
            this.time.TabIndex = 2;
            this.time.Text = "时间：";
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.author.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.author.Location = new System.Drawing.Point(33, 70);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(54, 20);
            this.author.TabIndex = 1;
            this.author.Text = "作者：";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(30, 20);
            this.title.MaximumSize = new System.Drawing.Size(650, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(454, 28);
            this.title.TabIndex = 0;
            this.title.Text = "NINE PERCENT和粉丝，一场没有尽头的battle";
            // 
            // commend_num
            // 
            this.commend_num.AutoSize = true;
            this.commend_num.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.commend_num.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.commend_num.Location = new System.Drawing.Point(506, 117);
            this.commend_num.Name = "commend_num";
            this.commend_num.Size = new System.Drawing.Size(27, 17);
            this.commend_num.TabIndex = 8;
            this.commend_num.Text = "1楼";
            // 
            // add_commend_panel
            // 
            this.add_commend_panel.Controls.Add(this.add_comend_button);
            this.add_commend_panel.Controls.Add(this.add_commend_name);
            this.add_commend_panel.Controls.Add(this.add_commend_textbox);
            this.add_commend_panel.Location = new System.Drawing.Point(37, 773);
            this.add_commend_panel.Name = "add_commend_panel";
            this.add_commend_panel.Size = new System.Drawing.Size(593, 177);
            this.add_commend_panel.TabIndex = 7;
            // 
            // add_commend_textbox
            // 
            this.add_commend_textbox.BackColor = System.Drawing.Color.Transparent;
            this.add_commend_textbox.DownBack = null;
            this.add_commend_textbox.Icon = null;
            this.add_commend_textbox.IconIsButton = false;
            this.add_commend_textbox.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.add_commend_textbox.IsPasswordChat = '\0';
            this.add_commend_textbox.IsSystemPasswordChar = false;
            this.add_commend_textbox.Lines = new string[0];
            this.add_commend_textbox.Location = new System.Drawing.Point(25, 43);
            this.add_commend_textbox.Margin = new System.Windows.Forms.Padding(0);
            this.add_commend_textbox.MaxLength = 32767;
            this.add_commend_textbox.MinimumSize = new System.Drawing.Size(28, 28);
            this.add_commend_textbox.MouseBack = null;
            this.add_commend_textbox.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.add_commend_textbox.Multiline = true;
            this.add_commend_textbox.Name = "add_commend_textbox";
            this.add_commend_textbox.NormlBack = null;
            this.add_commend_textbox.Padding = new System.Windows.Forms.Padding(5);
            this.add_commend_textbox.ReadOnly = false;
            this.add_commend_textbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.add_commend_textbox.Size = new System.Drawing.Size(529, 79);
            // 
            // 
            // 
            this.add_commend_textbox.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.add_commend_textbox.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_commend_textbox.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.add_commend_textbox.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.add_commend_textbox.SkinTxt.Multiline = true;
            this.add_commend_textbox.SkinTxt.Name = "BaseText";
            this.add_commend_textbox.SkinTxt.Size = new System.Drawing.Size(519, 69);
            this.add_commend_textbox.SkinTxt.TabIndex = 0;
            this.add_commend_textbox.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.add_commend_textbox.SkinTxt.WaterText = "";
            this.add_commend_textbox.TabIndex = 8;
            this.add_commend_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.add_commend_textbox.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.add_commend_textbox.WaterText = "";
            this.add_commend_textbox.WordWrap = true;
            // 
            // add_commend_name
            // 
            this.add_commend_name.AutoSize = true;
            this.add_commend_name.BackColor = System.Drawing.Color.Transparent;
            this.add_commend_name.BorderColor = System.Drawing.Color.White;
            this.add_commend_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add_commend_name.Location = new System.Drawing.Point(25, 15);
            this.add_commend_name.Name = "add_commend_name";
            this.add_commend_name.Size = new System.Drawing.Size(121, 17);
            this.add_commend_name.TabIndex = 1;
            this.add_commend_name.Text = "*请登录后再进行评论";
            // 
            // add_comend_button
            // 
            this.add_comend_button.BackColor = System.Drawing.Color.White;
            this.add_comend_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_comend_button.Location = new System.Drawing.Point(479, 125);
            this.add_comend_button.Name = "add_comend_button";
            this.add_comend_button.Size = new System.Drawing.Size(75, 23);
            this.add_comend_button.TabIndex = 8;
            this.add_comend_button.Text = "提交评论";
            this.add_comend_button.UseVisualStyleBackColor = false;
            this.add_comend_button.Click += new System.EventHandler(this.add_comend_button_Click);
            // 
            // newsdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "newsdetail";
            this.Text = "新闻内容";
            this.Load += new System.EventHandler(this.newsdetail_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.commend_panel.ResumeLayout(false);
            this.commend_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.add_commend_panel.ResumeLayout(false);
            this.add_commend_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label context;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label newstype;
        private System.Windows.Forms.Panel commend_panel;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Label commend_time;
        private System.Windows.Forms.Label commend;
        private System.Windows.Forms.Label commend_username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label commend_num;
        private System.Windows.Forms.Panel add_commend_panel;
        private System.Windows.Forms.Button add_comend_button;
        private CCWin.SkinControl.SkinLabel add_commend_name;
        private CCWin.SkinControl.SkinTextBox add_commend_textbox;
    }
}