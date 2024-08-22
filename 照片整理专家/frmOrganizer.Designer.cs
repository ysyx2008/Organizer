namespace 照片整理专家
{
    partial class frmOrganizer
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrganizer));
            this.button1 = new System.Windows.Forms.Button();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDestination = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
            this.fbdDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.rbMove = new System.Windows.Forms.RadioButton();
            this.rbCopy = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbProgress = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbByCreationTime = new System.Windows.Forms.RadioButton();
            this.rbIgnoreNoExif = new System.Windows.Forms.RadioButton();
            this.rbByLastWriteTime = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbAutoRename = new System.Windows.Forms.RadioButton();
            this.rbIgnoreSameNameFile = new System.Windows.Forms.RadioButton();
            this.cbxIncludeSubDirectory = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCurrentFile = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.nUDIgnoreFileSize = new System.Windows.Forms.NumericUpDown();
            this.tbxIgnoreKeyWord = new System.Windows.Forms.TextBox();
            this.cbxOrganizByDeviceType = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnChangeStyle = new System.Windows.Forms.Button();
            this.lbStyle = new System.Windows.Forms.Label();
            this.cmsStyle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIgnoreFileSize)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.cmsStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(991, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // tbxSource
            // 
            this.tbxSource.AllowDrop = true;
            this.tbxSource.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxSource.Location = new System.Drawing.Point(227, 145);
            this.tbxSource.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.ReadOnly = true;
            this.tbxSource.Size = new System.Drawing.Size(754, 45);
            this.tbxSource.TabIndex = 1;
            this.tbxSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbxSource_DragDrop);
            this.tbxSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbxSource_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(62, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "源文件夹";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(37, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "目标文件夹";
            // 
            // tbxDestination
            // 
            this.tbxDestination.AllowDrop = true;
            this.tbxDestination.Font = new System.Drawing.Font("宋体", 11F);
            this.tbxDestination.Location = new System.Drawing.Point(227, 262);
            this.tbxDestination.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(754, 45);
            this.tbxDestination.TabIndex = 4;
            this.tbxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.TbxDestination_DragDrop);
            this.tbxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.TbxDestination_DragEnter);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(991, 262);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(929, 825);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 95);
            this.button3.TabIndex = 6;
            this.button3.Text = "启动整理";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // fbdSource
            // 
            this.fbdSource.Description = "请选择源文件夹";
            // 
            // fbdDestination
            // 
            this.fbdDestination.Description = "请选择 目标文件夹";
            // 
            // rbMove
            // 
            this.rbMove.AutoSize = true;
            this.rbMove.Location = new System.Drawing.Point(163, 38);
            this.rbMove.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbMove.Name = "rbMove";
            this.rbMove.Size = new System.Drawing.Size(104, 34);
            this.rbMove.TabIndex = 7;
            this.rbMove.Text = "移动";
            this.toolTip.SetToolTip(this.rbMove, "将源文件夹中的文件移动到目标文件夹，大部分时候整理速度更快。");
            this.rbMove.UseVisualStyleBackColor = true;
            // 
            // rbCopy
            // 
            this.rbCopy.AutoSize = true;
            this.rbCopy.Checked = true;
            this.rbCopy.Location = new System.Drawing.Point(30, 38);
            this.rbCopy.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbCopy.Name = "rbCopy";
            this.rbCopy.Size = new System.Drawing.Size(104, 34);
            this.rbCopy.TabIndex = 8;
            this.rbCopy.TabStop = true;
            this.rbCopy.Text = "复制";
            this.toolTip.SetToolTip(this.rbCopy, "只复制、不操作源文件夹中的文件，更加安全。速度较慢。");
            this.rbCopy.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMove);
            this.groupBox1.Controls.Add(this.rbCopy);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(227, 469);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(908, 92);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "整理文件的方法？";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(67, 1014);
            this.progressBar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1068, 25);
            this.progressBar.TabIndex = 10;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProgress.Location = new System.Drawing.Point(63, 953);
            this.lbProgress.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 30);
            this.lbProgress.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbByCreationTime);
            this.groupBox2.Controls.Add(this.rbIgnoreNoExif);
            this.groupBox2.Controls.Add(this.rbByLastWriteTime);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(227, 588);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(908, 92);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件没有拍摄时间时？";
            // 
            // rbByCreationTime
            // 
            this.rbByCreationTime.AutoSize = true;
            this.rbByCreationTime.Location = new System.Drawing.Point(521, 38);
            this.rbByCreationTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbByCreationTime.Name = "rbByCreationTime";
            this.rbByCreationTime.Size = new System.Drawing.Size(284, 34);
            this.rbByCreationTime.TabIndex = 9;
            this.rbByCreationTime.Text = "根据创建时间整理";
            this.toolTip.SetToolTip(this.rbByCreationTime, "视频和其他文件不包含Exif信息，可选择此项一并整理。\r\n");
            this.rbByCreationTime.UseVisualStyleBackColor = true;
            // 
            // rbIgnoreNoExif
            // 
            this.rbIgnoreNoExif.AutoSize = true;
            this.rbIgnoreNoExif.Checked = true;
            this.rbIgnoreNoExif.Location = new System.Drawing.Point(30, 38);
            this.rbIgnoreNoExif.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbIgnoreNoExif.Name = "rbIgnoreNoExif";
            this.rbIgnoreNoExif.Size = new System.Drawing.Size(104, 34);
            this.rbIgnoreNoExif.TabIndex = 7;
            this.rbIgnoreNoExif.TabStop = true;
            this.rbIgnoreNoExif.Text = "跳过";
            this.toolTip.SetToolTip(this.rbIgnoreNoExif, "只想整理出含有Exif信息的原始照片时请选择此项。");
            this.rbIgnoreNoExif.UseVisualStyleBackColor = true;
            // 
            // rbByLastWriteTime
            // 
            this.rbByLastWriteTime.AutoSize = true;
            this.rbByLastWriteTime.Location = new System.Drawing.Point(163, 38);
            this.rbByLastWriteTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbByLastWriteTime.Name = "rbByLastWriteTime";
            this.rbByLastWriteTime.Size = new System.Drawing.Size(284, 34);
            this.rbByLastWriteTime.TabIndex = 8;
            this.rbByLastWriteTime.Text = "根据修改时间整理";
            this.toolTip.SetToolTip(this.rbByLastWriteTime, "视频和其他文件不包含Exif信息，可选择此项一并整理。\r\n推荐选择。");
            this.rbByLastWriteTime.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbAutoRename);
            this.groupBox3.Controls.Add(this.rbIgnoreSameNameFile);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(227, 708);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox3.Size = new System.Drawing.Size(908, 90);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "目标文件夹存在同名文件时？";
            // 
            // rbAutoRename
            // 
            this.rbAutoRename.AutoSize = true;
            this.rbAutoRename.Checked = true;
            this.rbAutoRename.Location = new System.Drawing.Point(30, 38);
            this.rbAutoRename.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbAutoRename.Name = "rbAutoRename";
            this.rbAutoRename.Size = new System.Drawing.Size(284, 34);
            this.rbAutoRename.TabIndex = 9;
            this.rbAutoRename.TabStop = true;
            this.rbAutoRename.Text = "智能处理（推荐）";
            this.toolTip.SetToolTip(this.rbAutoRename, "使用MD5算法精确比较文件内容，不相同就自动重命名后保存，相同则采取以下操作：\r\n    “复制”方法整理时：跳过源文件夹中的文件。\r\n    “移动”方法整理时" +
        "：转移到目标文件夹下的“重复文件回收站”。\r\n推荐选择。");
            this.rbAutoRename.UseVisualStyleBackColor = true;
            // 
            // rbIgnoreSameNameFile
            // 
            this.rbIgnoreSameNameFile.AutoSize = true;
            this.rbIgnoreSameNameFile.Location = new System.Drawing.Point(361, 38);
            this.rbIgnoreSameNameFile.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rbIgnoreSameNameFile.Name = "rbIgnoreSameNameFile";
            this.rbIgnoreSameNameFile.Size = new System.Drawing.Size(104, 34);
            this.rbIgnoreSameNameFile.TabIndex = 7;
            this.rbIgnoreSameNameFile.Text = "跳过";
            this.toolTip.SetToolTip(this.rbIgnoreSameNameFile, "跳过这个文件，不作处理。");
            this.rbIgnoreSameNameFile.UseVisualStyleBackColor = true;
            // 
            // cbxIncludeSubDirectory
            // 
            this.cbxIncludeSubDirectory.AutoSize = true;
            this.cbxIncludeSubDirectory.Checked = true;
            this.cbxIncludeSubDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeSubDirectory.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxIncludeSubDirectory.Location = new System.Drawing.Point(227, 203);
            this.cbxIncludeSubDirectory.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cbxIncludeSubDirectory.Name = "cbxIncludeSubDirectory";
            this.cbxIncludeSubDirectory.Size = new System.Drawing.Size(225, 34);
            this.cbxIncludeSubDirectory.TabIndex = 14;
            this.cbxIncludeSubDirectory.Text = "包括子文件夹";
            this.cbxIncludeSubDirectory.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(63, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1024, 77);
            this.label3.TabIndex = 15;
            this.label3.Text = "    根据拍摄时间整理源文件夹中的照片和其他文件，按照指定的目录结构存放到目标文件夹。";
            // 
            // lbCurrentFile
            // 
            this.lbCurrentFile.AutoSize = true;
            this.lbCurrentFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurrentFile.Location = new System.Drawing.Point(63, 1065);
            this.lbCurrentFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCurrentFile.Name = "lbCurrentFile";
            this.lbCurrentFile.Size = new System.Drawing.Size(0, 30);
            this.lbCurrentFile.TabIndex = 16;
            // 
            // nUDIgnoreFileSize
            // 
            this.nUDIgnoreFileSize.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDIgnoreFileSize.Location = new System.Drawing.Point(543, 821);
            this.nUDIgnoreFileSize.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nUDIgnoreFileSize.Name = "nUDIgnoreFileSize";
            this.nUDIgnoreFileSize.Size = new System.Drawing.Size(157, 42);
            this.nUDIgnoreFileSize.TabIndex = 21;
            this.toolTip.SetToolTip(this.nUDIgnoreFileSize, "小于该大小的文件将不被整理。用于跳过一些缩略图。");
            // 
            // tbxIgnoreKeyWord
            // 
            this.tbxIgnoreKeyWord.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxIgnoreKeyWord.Location = new System.Drawing.Point(605, 878);
            this.tbxIgnoreKeyWord.Name = "tbxIgnoreKeyWord";
            this.tbxIgnoreKeyWord.Size = new System.Drawing.Size(144, 42);
            this.tbxIgnoreKeyWord.TabIndex = 23;
            this.toolTip.SetToolTip(this.tbxIgnoreKeyWord, "如果文件名（包括后缀名）中含有这些内容，则文件会被跳过，不做整理。");
            // 
            // cbxOrganizByDeviceType
            // 
            this.cbxOrganizByDeviceType.AutoSize = true;
            this.cbxOrganizByDeviceType.Font = new System.Drawing.Font("宋体", 10F);
            this.cbxOrganizByDeviceType.Location = new System.Drawing.Point(592, 45);
            this.cbxOrganizByDeviceType.Name = "cbxOrganizByDeviceType";
            this.cbxOrganizByDeviceType.Size = new System.Drawing.Size(255, 34);
            this.cbxOrganizByDeviceType.TabIndex = 24;
            this.cbxOrganizByDeviceType.Text = "按拍摄设备整理";
            this.toolTip.SetToolTip(this.cbxOrganizByDeviceType, "勾选后将会读取Exif中的设备型号，并将设备型号作为第一级目录，然后再按日期建立文件夹结构。");
            this.cbxOrganizByDeviceType.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxOrganizByDeviceType);
            this.groupBox4.Controls.Add(this.btnChangeStyle);
            this.groupBox4.Controls.Add(this.lbStyle);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(227, 350);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox4.Size = new System.Drawing.Size(908, 92);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "整理后的目录结构（以2020年3月1日为例）";
            // 
            // btnChangeStyle
            // 
            this.btnChangeStyle.Location = new System.Drawing.Point(322, 38);
            this.btnChangeStyle.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnChangeStyle.Name = "btnChangeStyle";
            this.btnChangeStyle.Size = new System.Drawing.Size(151, 47);
            this.btnChangeStyle.TabIndex = 1;
            this.btnChangeStyle.Text = "更改";
            this.btnChangeStyle.UseVisualStyleBackColor = true;
            this.btnChangeStyle.Click += new System.EventHandler(this.BtnChangeStyle_Click);
            // 
            // lbStyle
            // 
            this.lbStyle.AutoSize = true;
            this.lbStyle.Location = new System.Drawing.Point(26, 47);
            this.lbStyle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbStyle.Name = "lbStyle";
            this.lbStyle.Size = new System.Drawing.Size(148, 30);
            this.lbStyle.TabIndex = 0;
            this.lbStyle.Text = "\\2020\\03\\";
            // 
            // cmsStyle
            // 
            this.cmsStyle.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.cmsStyle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.toolStripMenuItem4,
            this.toolStripSeparator1,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripSeparator3,
            this.toolStripMenuItem9});
            this.cmsStyle.Name = "contextMenuStrip";
            this.cmsStyle.Size = new System.Drawing.Size(275, 374);
            this.cmsStyle.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CmsStyle_ItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem2.Text = "\\2020\\03\\";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem3.Text = "\\2020\\3\\";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem1.Text = "\\2020\\202003\\";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(271, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem4.Text = "\\202003\\";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(271, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem5.Text = "\\2020\\03\\01\\";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem6.Text = "\\2020\\0301\\";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem7.Text = "\\20200301\\";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(271, 6);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(274, 44);
            this.toolStripMenuItem9.Text = "\\2020\\";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(227, 823);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(283, 30);
            this.label4.TabIndex = 19;
            this.label4.Text = "文件大小不得低于：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(706, 823);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 30);
            this.label5.TabIndex = 20;
            this.label5.Text = "KB";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(232, 881);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(343, 30);
            this.label6.TabIndex = 22;
            this.label6.Text = "忽略包含关键字的文件：";
            // 
            // frmOrganizer
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 1181);
            this.Controls.Add(this.tbxIgnoreKeyWord);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nUDIgnoreFileSize);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lbCurrentFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxIncludeSubDirectory);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmOrganizer";
            this.Text = "照片整理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrganizer_FormClosing);
            this.Load += new System.EventHandler(this.FrmOrganizer_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmOrganizer_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmOrganizer_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIgnoreFileSize)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.cmsStyle.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDestination;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog fbdSource;
        private System.Windows.Forms.FolderBrowserDialog fbdDestination;
        private System.Windows.Forms.RadioButton rbMove;
        private System.Windows.Forms.RadioButton rbCopy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbByCreationTime;
        private System.Windows.Forms.RadioButton rbIgnoreNoExif;
        private System.Windows.Forms.RadioButton rbByLastWriteTime;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbIgnoreSameNameFile;
        private System.Windows.Forms.CheckBox cbxIncludeSubDirectory;
        private System.Windows.Forms.RadioButton rbAutoRename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCurrentFile;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbStyle;
        private System.Windows.Forms.ContextMenuStrip cmsStyle;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.Button btnChangeStyle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDIgnoreFileSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxIgnoreKeyWord;
        private System.Windows.Forms.CheckBox cbxOrganizByDeviceType;
    }
}

