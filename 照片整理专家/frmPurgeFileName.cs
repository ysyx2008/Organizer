using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 照片整理专家
{
    public partial class frmPurgeFileName : Form
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 父框架窗体
        /// </summary>
        frmFramework frmFramework;

        frmPurgeFileNamePreview frmPurgeFileNamePreview;

        /// <summary>
        /// 待整理的文件列表
        /// </summary>
        List<FileInfo> fileList = new List<FileInfo>();

        /// <summary>
        /// 全局中止整理标记，当设为ture结束整理循环
        /// </summary>
        bool abortProcess = false;

        /// <summary>
        /// 全局整理标记，当设为ture时表示正在整理中
        /// </summary>
        bool onProcess = false;

        public frmPurgeFileName(frmFramework form)
        {
            frmFramework = form;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (onProcess == true)
            {
                abortProcess = true;
                return;
            }
            button1.Enabled = false;
            cbxRemoveSuffix.Enabled = false;
            button3.Text = "中止";
            cbxIncludeSubDirectory.Enabled = false;
            cbxTrimFilename.Enabled = false;

            try
            {

                if (string.IsNullOrEmpty(tbxSource.Text))
                {
                    throw new Exception("目标文件夹路径不能为空");
                }


                if (System.IO.Directory.Exists(tbxSource.Text) == false)
                {
                    throw new Exception("目标文件夹不存在。");
                }

                onProcess = true;

                fileList.Clear();  // 初始化文件列表

                try
                {
                    fileList = Helper.LoadFiles(tbxSource.Text, cbxIncludeSubDirectory.Checked);
                }
                catch (UnauthorizedAccessException ex)
                {
                    throw new Exception(ex.Message + "没有访问权限。");
                }

                int total = fileList.Count;
                DataTable dtPreview = new DataTable();
                dtPreview.Columns.Add(new DataColumn("序号"));
                dtPreview.Columns.Add(new DataColumn("路径"));
                dtPreview.Columns.Add(new DataColumn("原文件名"));
                dtPreview.Columns.Add(new DataColumn("新文件名"));
                dtPreview.Columns.Add(new DataColumn("执行状态"));

                logger.Info("总文件数：" + total.ToString());
                progressBar.Maximum = total > 0 ? total - 1 : 0;

                #region 清理文件名
                int purgedFileCount = 0;   // 重复文件数量

                lbProgress.Text = "0/" + (total - 1 >= 0 ? total - 1 : 0).ToString() + " 找到了 " + purgedFileCount.ToString() + " 个文件";

                for (int i = 0; i < total; i++)
                {
                    if (abortProcess)
                    {
                        MessageBox.Show("清理过程已经终止");
                        logger.Info("清理过程已经终止");
                        break;
                    }
                    progressBar.Value = i;

                    lbCurrentFile.Text = (fileList[i].FullName.Length < 50 ? fileList[i].FullName : fileList[i].FullName.Substring(0, 12) + "..." + fileList[i].FullName.Substring(fileList[i].FullName.Length - 33, 33));

                    string oldFileName = fileList[i].Name;
                    string newFileName = PurgeFileName(fileList[i], cbxRemoveSuffix.Checked, cbxTrimFilename.Checked);
                    if (newFileName != "")
                    {
                        purgedFileCount++;
                        dtPreview.Rows.Add(purgedFileCount, fileList[i].DirectoryName, oldFileName, newFileName, "已更名");
                    }

                    lbProgress.Text = (i + 1).ToString() + "/" + total.ToString() + " 已经处理了 " + purgedFileCount.ToString() + " 个文件";
                    Application.DoEvents();
                }
                #endregion

                frmPurgeFileNamePreview = new frmPurgeFileNamePreview(this.frmFramework);
                frmPurgeFileNamePreview.Show();
                frmPurgeFileNamePreview.Refresh(dtPreview);
                logger.Info("已经处理了" + purgedFileCount.ToString() + "个文件！");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex.Message);
            }

            button1.Enabled = true;
            cbxTrimFilename.Enabled = true;
            button3.Text = "开始";
            cbxIncludeSubDirectory.Enabled = true;
            cbxRemoveSuffix.Enabled = true;

            onProcess = false;
            abortProcess = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            fbdSource.SelectedPath = tbxSource.Text;
            if (fbdSource.ShowDialog() == DialogResult.OK)
            {
                tbxSource.Text = fbdSource.SelectedPath;
            }
        }

        private void tbxSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tbxSource_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (System.IO.Directory.Exists(path) == false)
            {
                MessageBox.Show(path + " 不是有效的文件夹！");
                return;
            }

            tbxSource.Text = path;
        }

        private void frmDeduplicate_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void frmDeduplicate_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (System.IO.Directory.Exists(path) == false)
            {
                MessageBox.Show(path + " 不是有效的文件夹！");
                return;
            }

            tbxSource.Text = path;
        }

        /// <summary>
        /// 清理文件名
        /// </summary>
        /// <param name="file"></param>
        private string PurgeFileName(FileInfo file, bool removeSuffix = true, bool trimWhitespace = true)
        {
            string purgedFileName = Helper.PurgeFileName(Path.GetFileNameWithoutExtension(file.Name), removeSuffix, trimWhitespace);
            if (purgedFileName != "")
            {
                purgedFileName = purgedFileName + file.Extension;
                string newFullName = Path.Combine(file.DirectoryName, purgedFileName);
                FileInfo fiMoveTarget = new FileInfo(Helper.getUnionName(file.DirectoryName, new FileInfo(newFullName)));
                file.MoveTo(fiMoveTarget.FullName);
                return fiMoveTarget.Name;
            }
            else
            {
                return "";
            }
        }

    }
}
