using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照片整理专家
{
    public partial class frmAbout : Form
    {
        /// <summary>
        /// 父框架窗体
        /// </summary>
        frmFramework frmFramework;
        public frmAbout(frmFramework form)
        {
            frmFramework = form;
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://jq.qq.com/?_wv=1027&k=5S35egy");
        }

        private void button_Click(object sender, EventArgs e)
        {
            frmFramework.tsmiFunction.DropDownItems[0].PerformClick();
        }
    }
}
