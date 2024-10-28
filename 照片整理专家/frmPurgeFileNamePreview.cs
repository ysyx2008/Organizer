using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照片整理专家
{
    public partial class frmPurgeFileNamePreview : Form
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 父框架窗体
        /// </summary>
        frmFramework frmFramework;

        public frmPurgeFileNamePreview(frmFramework form)
        {
            frmFramework = form;
            InitializeComponent();

        }

        private void frmPurgeFileNamePreview_Shown(object sender, EventArgs e)
        {

        }

        public void Refresh(DataTable dt)
        {
            dgvPreview.DataSource = dt;
            dgvPreview.AutoResizeColumns();
            btnAbort.Enabled = true;
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            btnAbort.Enabled = false;
            foreach (DataGridViewRow row in dgvPreview.Rows)
            {
                if (row.IsNewRow == false)
                {
                    string newFileName = Path.Combine(row.Cells["路径"].Value.ToString(), row.Cells["新文件名"].Value.ToString());
                    string oldFileName = Path.Combine(row.Cells["路径"].Value.ToString(), row.Cells["原文件名"].Value.ToString());
                    logger.Info(newFileName + " 撤销为 " + oldFileName);
                    File.Move(newFileName, oldFileName);
                    row.Cells["新文件名"].Value = "";
                    row.Cells["执行状态"].Value = "已撤销";
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
