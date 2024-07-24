using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace 照片整理专家
{
    public partial class frmOrganizer : Form
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

        public frmOrganizer(frmFramework form)
        {
            frmFramework = form;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            fbdSource.SelectedPath = tbxSource.Text;
            if (fbdSource.ShowDialog() == DialogResult.OK)
            {
                if (tbxDestination.Text == tbxSource.Text)
                {
                    tbxDestination.Text = fbdSource.SelectedPath;
                }
                tbxSource.Text = fbdSource.SelectedPath;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            fbdDestination.SelectedPath = tbxDestination.Text;
            if (fbdDestination.ShowDialog() == DialogResult.OK)
            {
                tbxDestination.Text = fbdDestination.SelectedPath;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (onProcess)
            {
                // 正在整理时，再次点击按钮则中止整理。
                abortProcess = true;
                return;
            }

            #region 初始化各个控件的状态
            onProcess = true;

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Text = "中止";
            btnChangeStyle.Enabled = false;
            cbxIncludeSubDirectory.Enabled = false;
            tbxSource.Enabled = false;
            tbxDestination.Enabled = false;
            rbCopy.Enabled = false;
            rbMove.Enabled = false;
            rbIgnoreNoExif.Enabled = false;
            rbByCreationTime.Enabled = false;
            rbByLastWriteTime.Enabled = false;
            rbIgnoreSameNameFile.Enabled = false;
            rbAutoRename.Enabled = false;
            nUDIgnoreFileSize.Enabled = false;
            progressBar.Maximum = 0;
            progressBar.Value = 0;
            #endregion

            try
            {
                #region 异常检查
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
                    throw new Exception("目标文件夹不存在。");
                }


                if (System.IO.Directory.GetDirectories(tbxDestination.Text).Length > 0 || System.IO.Directory.GetFiles(tbxDestination.Text).Length > 0)
                {
                    if (MessageBox.Show("目标文件夹不是空的，确定要使用“" + tbxDestination.Text + "”这个目录吗？", "注意", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        throw new Exception("整理过程已经中止。");
                    }
                }

                #endregion

                #region 统计需要整理的文件数量
                fileList.Clear();
                fileList = Helper.LoadFiles(tbxSource.Text, cbxIncludeSubDirectory.Checked, (int)nUDIgnoreFileSize.Value * 1024, tbxIgnoreKeyWord.Text);

                int total = fileList.Count;
                logger.Info("总文件数：" + total.ToString());
                progressBar.Maximum = total > 0 ? total - 1 : 0;
                #endregion

                #region 执行整理
                int processed = 0; // 已处理的文件数量
                int sameNameFileCount = 0; // 同名文件数量
                string method = "";
                if (rbAutoRename.Checked)
                {
                    method = "智能处理";
                }
                else if (rbIgnoreSameNameFile.Checked)
                {
                    method = "跳过";
                }

                lbProgress.Text = "0/" + total.ToString() + "，已经整理 " + processed.ToString() + " 个有效文件，" + method + " " + sameNameFileCount.ToString() + " 个同名文件";

                string destRoot = tbxDestination.Text;

                for (int i = 0; i < total; i++)
                {
                    if (abortProcess == true)
                    {
                        throw new Exception("整理过程已经中止。");
                    }

                    FileInfo file = fileList[i];

                    try
                    {
                        lbCurrentFile.Text = (file.FullName.Length < 50 ? file.FullName : file.FullName.Substring(0, 12) + "..." + file.FullName.Substring(file.FullName.Length - 33, 33));
                    }
                    catch (Exception)
                    {
                        logger.Error(file.FullName + "截取文件名时报错");
                        // MessageBox.Show(file.FullName + "显示文件名时出错，不影响整理，点击确认后继续", "提示");
                    }

                    bool ignoreThisFile = false;
                    string destination = "";

                    DateTime capturedTime = DateTime.MinValue;
                    // 读取Exif信息
                    Dictionary<string, string> exif = new Dictionary<string, string>();
                    try
                    {
                        exif = Helper.GetExifByMe(file.FullName);
                        if (exif.ContainsKey("拍摄时间"))
                        {
                            if (!DateTime.TryParseExact(exif["拍摄时间"], "yyyy:MM:dd HH:mm:ss", CultureInfo.CurrentCulture, DateTimeStyles.None, out capturedTime))
                            {
                                if (!DateTime.TryParseExact(exif["拍摄时间"], "ddd MMM dd HH:mm:ss yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out capturedTime))
                                {
                                    if(!DateTime.TryParse(exif["拍摄时间"], out capturedTime))
                                    {
                                        logger.Info("拍摄时间解析异常：" + exif["拍摄时间"]);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 无法判断文件类型时
                        logger.Info(file.FullName + "读取Exif信息时发生异常：" + ex.Message);
                        // isIgnore = true;
                    }

                    // 未能成功解析拍摄时间的处理
                    if (capturedTime == DateTime.MinValue)
                    {
                        if (rbByLastWriteTime.Checked)
                        {
                            capturedTime = file.LastWriteTime;
                        }
                        else if (rbByCreationTime.Checked)
                        {
                            capturedTime = file.CreationTime;
                        }
                        else
                        {
                            ignoreThisFile = true;
                            logger.Info("跳过：" + file.FullName + "。原因：没有Exif拍摄时间信息。");
                        }
                    }

                    #region 处理文件路径
                    string destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.ToString("MM"));

                    switch (lbStyle.Text)
                    {
                        case @"\2020\03\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.ToString("MM"));
                            break;
                        case @"\2020\3\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.Month.ToString());
                            break;
                        case @"\202003\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyyMM"));
                            break;
                        case @"\2020\03\01\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.ToString("MM"), capturedTime.ToString("dd"));
                            break;
                        case @"\2020\0301\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.ToString("MMdd"));
                            break;
                        case @"\20200301\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyyMMdd"));
                            break;
                        case @"\2020\202003\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"), capturedTime.ToString("yyyyMM"));
                            break;
                        case @"\2020\":
                            destPath = Path.Combine(destRoot, capturedTime.ToString("yyyy"));
                            break;
                        default:
                            throw new Exception("没有设置正确的路径格式");
                    }

                    destination = Path.Combine(destPath, file.Name);
                    #endregion

                    // 处理同名文件
                    if (File.Exists(destination))
                    {
                        logger.Info("发现同名文件：" + destination);
                        sameNameFileCount++;
                        if (rbAutoRename.Checked)
                        {
                            FileInfo destFile = new FileInfo(destination);
                            if (file.Length == destFile.Length && IsExactlySameFile(file.FullName, destination))
                            {
                                // 跳过相同文件
                                logger.Info(file.FullName + " 与 " + destination + " 同名并且完全一致，跳过");
                                processed++;
                                ignoreThisFile = true;
                            }
                            else
                            {
                                logger.Info(file.FullName + " 与 " + destination + " 同名但内容并不一致，重命名");
                                destination = Helper.getUnionName(destPath, file);
                            }
                        }
                        else if (rbIgnoreSameNameFile.Checked)
                        {
                            ignoreThisFile = true;
                        }
                    }

                    if (!ignoreThisFile)
                    {
                        // 如果文件未被跳过则进行处理

                        if (!System.IO.Directory.Exists(destPath))
                        {
                            // 创建目的文件夹
                            System.IO.Directory.CreateDirectory(destPath);
                        }

                        if (Path.IsPathRooted(destination) == false)
                        {
                            throw new Exception("目标文件夹" + destination + "不是绝对路径");
                        }

                        if (rbMove.Checked)
                        {
                            // 移动文件
                            logger.Info("移动" + file.FullName + "到" + destination);
                            file.MoveTo(destination);
                        }
                        else if (rbCopy.Checked)
                        {
                            // 复制文件
                            logger.Info("复制" + file.FullName + "到" + destination);
                            file.CopyTo(destination);
                        }

                        processed++;
                    }
                    else
                    {
                        logger.Info("跳过：" + file.FullName);
                    }

                    lbProgress.Text = (i + 1).ToString() + "/" + total.ToString() + "，已经整理 " + processed.ToString() + " 个有效文件，" + method + " " + sameNameFileCount.ToString() + " 个同名文件";

                    Application.DoEvents();
                    progressBar.Value = i;
                }

                MessageBox.Show("恭喜，已经完成整理了！", "完成");
                logger.Info("恭喜，已经完成整理了！");

#if DEBUG
#else
                if (processed > 1000)
                {
                    if(MessageBox.Show("哇，这次一口气整理了" + processed.ToString() + "个文件！！！\r\n\r\n那么，要不要给作者打个赏呢？","不要脸的求赞",MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        frmFramework.支持作者ToolStripMenuItem.PerformClick();
                    }
                }
#endif

                #endregion
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message + "没有权限操作此文件。");
                logger.Error(ex, ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex);
            }

            lbCurrentFile.Text = "";

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Text = "开始";
            btnChangeStyle.Enabled = true;
            cbxIncludeSubDirectory.Enabled = true;
            tbxSource.Enabled = true;
            tbxDestination.Enabled = true;
            rbCopy.Enabled = true;
            rbMove.Enabled = true;
            rbIgnoreNoExif.Enabled = true;
            rbByCreationTime.Enabled = true;
            rbByLastWriteTime.Enabled = true;
            rbIgnoreSameNameFile.Enabled = true;
            rbAutoRename.Enabled = true;
            nUDIgnoreFileSize.Enabled = true;
            onProcess = false;
            abortProcess = false;
        }

        public static bool IsExactlySameFile(string filePath1, string filePath2)
        {
            return Helper.CompareByHash(filePath1, filePath2);
        }

        private void TbxSource_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (System.IO.Directory.Exists(path) == false)
            {
                MessageBox.Show(path + " 不是有效的文件夹！");
                return;
            }

            if (tbxDestination.Text == tbxSource.Text)
            {
                tbxDestination.Text = path;
            }

            tbxSource.Text = path;
        }

        private void TbxDestination_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            if (System.IO.Directory.Exists(path) == false)
            {
                MessageBox.Show(path + " 不是有效的文件夹！");
                return;
            }

            tbxDestination.Text = path;
        }

        private void TbxSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TbxDestination_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void FrmOrganizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            abortProcess = true;
        }

        private void BtnChangeStyle_Click(object sender, EventArgs e)
        {
            // 显示目录结构样式列表
            cmsStyle.Show(btnChangeStyle, new System.Drawing.Point(0, btnChangeStyle.Height));
        }

        private void CmsStyle_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            lbStyle.Text = e.ClickedItem.Text;
        }
    }
}
