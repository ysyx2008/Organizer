using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace 照片整理专家
{
    public partial class frmFramework : Form
    {

        /// <summary>
        /// 用于保存原始的窗体标题，以便切换窗体时显示不同的标题
        /// </summary>
        string defaultTitle = "";

        frmAbout frmAbout;

        /// <summary>
        /// 功能窗体列表
        /// </summary>
        Dictionary<string, Form> forms = new Dictionary<string, Form>();

        public frmFramework()
        {
            InitializeComponent();
        }

        private void Framework_Load(object sender, EventArgs e)
        {
            // 保存默认窗体标题
            defaultTitle = Text;

            frmAbout = new frmAbout(this);

            // 添加功能窗口列表
            forms.Add("照片整理", new frmOrganizer(this));
            forms.Add("精确去重", new frmDeduplicate(this));


            // 将功能窗口添加到菜单
            int i = 0;
            foreach (var form in forms)
            {
                form.Value.TopLevel = false;  // 非顶级窗口  
                form.Value.FormBorderStyle = FormBorderStyle.None;  // 不显示标题栏  
                form.Value.Dock = DockStyle.Fill;  // 填充panel  

                ToolStripMenuItem item = new ToolStripMenuItem(form.Key);
                item.Click += Item_Click;
                tsmiFunction.DropDownItems.Insert(i, item);

                if (i == 0)
                {
                    item.PerformClick();
                }

                i++;
            }

            frmAbout.TopLevel = false;
            frmAbout.FormBorderStyle = FormBorderStyle.None;
            frmAbout.Dock = DockStyle.Fill;

            tsslVersion.Text = "版本号：" + Application.ProductVersion;


#if DEBUG
            支持作者ToolStripMenuItem.Visible = false;
#else
            支持作者ToolStripMenuItem.Visible = true;
#endif
        }

        /// <summary>
        /// 点击功能窗体按钮时自动打开对应功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (forms[item.Text] == null || forms[item.Text].IsDisposed)
            {
                MessageBox.Show(item.Text + "窗体未创建或已关闭", "错误提示");
                return;
            }
            panel.Controls.Clear();  // 清空原有的控件  
            panel.Controls.Add(forms[item.Text]);  // 添加新窗体  
            forms[item.Text].Show();
            Text = defaultTitle + " - " + item.Text;
        }

        private void 查看日志文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string logfile = Path.Combine(Environment.CurrentDirectory, "logs.txt");
            if (File.Exists(logfile))
            {
                System.Diagnostics.Process.Start(logfile);
            }
            else
            {
                MessageBox.Show("没有找到日志文件");
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();  // 清空原有的控件  
            panel.Controls.Add(frmAbout);  // 添加新窗体  
            frmAbout.Show();
            Text = defaultTitle + " - " + frmAbout.Text;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject("照片整理专家下载地址：http://www.shiningsoft.com.cn/Organizer/publish.htm", true);
            MessageBox.Show("已经把软件的下载地址复制到剪贴板上，快去分享给其他小伙伴吧！");
        }

        private void 支持作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();  // 清空原有的控件  
            panel.Controls.Add(frmAbout);  // 添加新窗体  
            frmAbout.Show();
            Text = defaultTitle + " - " + frmAbout.Text;
        }
    }
}
