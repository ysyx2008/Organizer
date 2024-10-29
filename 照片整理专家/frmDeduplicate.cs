using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace 照片整理专家
{
    public partial class frmDeduplicate : Form
    {
        /// <summary>
        /// 日志记录器
        /// </summary>
        static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 父框架窗体
        /// </summary>
        frmFramework frmFramework;

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

        public frmDeduplicate(frmFramework form)
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
            button2.Enabled = false;
            button3.Text = "中止";
            cbxIncludeSubDirectory.Enabled = false;
            cbxByPixel.Enabled = false;

            try
            {

                if (string.IsNullOrEmpty(tbxSource.Text))
                {
                    throw new Exception("源文件夹路径不能为空");
                }

                if (string.IsNullOrEmpty(tbxDestination.Text))
                {
                    throw new Exception("目标文件夹路径不能为空。");
                }

                if (System.IO.Directory.Exists(tbxSource.Text) == false)
                {
                    throw new Exception("源文件夹不存在。");
                }

                if (System.IO.Directory.Exists(tbxDestination.Text) == false)
                {
                    try
                    {
                        Directory.CreateDirectory(tbxDestination.Text);
                    }
                    catch (Exception ex)
                    {

                        throw new Exception("创建回收文件夹失败：" + ex.Message);
                    }
                }


                if (System.IO.Directory.GetDirectories(tbxDestination.Text).Length > 0 || System.IO.Directory.GetFiles(tbxDestination.Text).Length > 0)
                {
                    if (MessageBox.Show("目标文件夹不是空的，确定要使用“" + tbxDestination.Text + "”这个目录吗？", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        throw new Exception("整理过程已经中止。");
                    }
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
                logger.Info("总文件数：" + total.ToString());
                progressBar.Maximum = total > 0 ? total - 2 : 0;

                // 按照文件大小排序
                fileList.Sort((left, right) =>
                {
                    if (left.Length > right.Length)
                        return 1;
                    else if (left.Length == right.Length)
                        return 0;
                    else
                        return -1;
                });

                #region 删除重复文件
                int duplicationCount = 0;   // 重复文件数量
                long totalFileLength = 0;   // 重复文件的总空间大小

                lbProgress.Text = "0/" + (total - 2 >= 0 ? total - 2 : 0).ToString() + " 找到了 " + duplicationCount.ToString() + " 个重复文件，节约 " + Helper.HumanReadableFilesize((double)totalFileLength) + " 空间";

                for (int i = 0; i < total - 1 ; i++)
                {
                    if (abortProcess)
                    {
                        MessageBox.Show("去重过程已经终止");
                        logger.Info("去重过程已经终止");
                        break;
                    }
                    progressBar.Value = i;

                    lbCurrentFile.Text = (fileList[i].FullName.Length < 50 ? fileList[i].FullName : fileList[i].FullName.Substring(0, 12) + "..." + fileList[i].FullName.Substring(fileList[i].FullName.Length - 33, 33));

                    if (fileList[i].Length == fileList[i + 1].Length)
                    {
                        if (Helper.CompareByByteArray(fileList[i].FullName, fileList[i + 1].FullName))
                        {
                            logger.Info("{0} 与 {1} 是重复文件", fileList[i].FullName, fileList[i + 1].FullName);
                            duplicationCount++;
                            MoveToDestinationDiretory(fileList[i]);
                            totalFileLength += fileList[i].Length;
                        }
                        else if (cbxByPixel.Checked)
                        {
                            try
                            {
                                if (Helper.CompareByPixel(fileList[i], fileList[i + 1]))
                                {
                                    logger.Info("{0} 与 {1} 的像素信息完全相同，是重复照片", fileList[i].FullName, fileList[i + 1].FullName);
                                    duplicationCount++;
                                    if (Helper.haveExif(fileList[i + 1]) == true)
                                    {
                                        MoveToDestinationDiretory(fileList[i]);
                                    }
                                    else
                                    {
                                        MoveToDestinationDiretory(fileList[i + 1]);
                                    }
                                    totalFileLength += fileList[i].Length;
                                }
                                else
                                {
                                    logger.Info("{0} 与 {1} 的像素对比失败", fileList[i].FullName, fileList[i + 1].FullName);
                                }
                            }
                            catch (Exception ex)
                            {
                                logger.Error("{0} 与 {1} 的像素对比异常，原因：{2}", fileList[i].FullName, fileList[i + 1].FullName, ex.Message);
                            }
                        }
                    }
                    
                    lbProgress.Text = i.ToString()+"/"+(total-2).ToString()+" 找到了 "+duplicationCount.ToString()+" 个重复文件，节约 " + Helper.HumanReadableFilesize((double)totalFileLength) + " 空间";
                    Application.DoEvents();
                }
                #endregion

                MessageBox.Show("完成去重，找到了" + duplicationCount.ToString() + "个重复文件！");
                logger.Info("完成去重，找到了" + duplicationCount.ToString() + "个重复文件！");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex.Message);
            }

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Text = "开始";
            cbxIncludeSubDirectory.Enabled = true;
            cbxByPixel.Enabled = true;

            onProcess = false;
            abortProcess = false;
        }

        private void MoveToDestinationDiretory(FileInfo file)
        {
            try
            {
                string subDirctory = "";
                if (file.DirectoryName != tbxSource.Text)
                {
                    subDirctory = file.DirectoryName.Substring(tbxSource.Text.Length + 1);
                }
                string recyclePath = Path.Combine(tbxDestination.Text, subDirctory);
                FileInfo target = new FileInfo(Helper.getUnionName(recyclePath, file));
                if (Directory.Exists(target.DirectoryName) == false)
                {
                    Directory.CreateDirectory(target.DirectoryName);
                }
                logger.Info("移动" + file.FullName + "到" + target);
                file.MoveTo(target.FullName);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("移动" + file.FullName + "到" + tbxDestination.Text + "失败：" + ex.Message + "没有访问权限。");
                logger.Error("移动" + file.FullName + "到" + tbxDestination.Text + "失败：" + ex.Message + "没有访问权限。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("移动" + file.FullName + "到" + tbxDestination.Text + "失败：" + ex.Message);
                logger.Error("移动" + file.FullName + "到" + tbxDestination.Text + "失败：" + ex.Message);
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            fbdDestination.SelectedPath = tbxDestination.Text;
            if (fbdDestination.ShowDialog() == DialogResult.OK)
            {
                tbxDestination.Text = fbdDestination.SelectedPath;
            }
        }

        private void tbxDestination_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void tbxDestination_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (System.IO.Directory.Exists(path) == false)
            {
                MessageBox.Show(path + " 不是有效的文件夹！");
                return;
            }

            tbxDestination.Text = path;
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

            if (tbxDestination.Text == tbxSource.Text)
            {
                tbxDestination.Text = Path.Combine(path, "回收文件夹");
            }

            tbxSource.Text = path;
        }
    }
}
