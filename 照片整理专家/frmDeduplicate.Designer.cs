namespace 照片整理专家
{
    partial class frmDeduplicate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeduplicate));
            this.cbxIncludeSubDirectory = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxSource = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.fbdSource = new System.Windows.Forms.FolderBrowserDialog();
            this.lbCurrentFile = new System.Windows.Forms.Label();
            this.lbProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxDestination = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbxByPixel = new System.Windows.Forms.CheckBox();
            this.fbdDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxIncludeSubDirectory
            // 
            this.cbxIncludeSubDirectory.AutoSize = true;
            this.cbxIncludeSubDirectory.Checked = true;
            this.cbxIncludeSubDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeSubDirectory.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxIncludeSubDirectory.Location = new System.Drawing.Point(210, 218);
            this.cbxIncludeSubDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.cbxIncludeSubDirectory.Name = "cbxIncludeSubDirectory";
            this.cbxIncludeSubDirectory.Size = new System.Drawing.Size(225, 34);
            this.cbxIncludeSubDirectory.TabIndex = 18;
            this.cbxIncludeSubDirectory.Text = "包括子文件夹";
            this.cbxIncludeSubDirectory.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(48, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "源文件夹";
            // 
            // tbxSource
            // 
            this.tbxSource.AllowDrop = true;
            this.tbxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSource.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSource.Location = new System.Drawing.Point(210, 169);
            this.tbxSource.Margin = new System.Windows.Forms.Padding(4);
            this.tbxSource.Name = "tbxSource";
            this.tbxSource.ReadOnly = true;
            this.tbxSource.Size = new System.Drawing.Size(802, 45);
            this.tbxSource.TabIndex = 16;
            this.tbxSource.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbxSource_DragDrop);
            this.tbxSource.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbxSource_DragEnter);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1020, 163);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 52);
            this.button1.TabIndex = 15;
            this.button1.Text = "选择";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(47, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1069, 93);
            this.label3.TabIndex = 19;
            this.label3.Text = "    精确比对源文件夹中的所有文件，所有重复的文件只在源文件夹中保留一份，其他均转移到回收文件夹。\r\n";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(948, 507);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 95);
            this.button3.TabIndex = 20;
            this.button3.Text = "启动去重";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbCurrentFile
            // 
            this.lbCurrentFile.AutoSize = true;
            this.lbCurrentFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurrentFile.Location = new System.Drawing.Point(65, 709);
            this.lbCurrentFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentFile.Name = "lbCurrentFile";
            this.lbCurrentFile.Size = new System.Drawing.Size(0, 30);
            this.lbCurrentFile.TabIndex = 23;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProgress.Location = new System.Drawing.Point(65, 616);
            this.lbProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 30);
            this.lbProgress.TabIndex = 22;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(70, 662);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1082, 29);
            this.progressBar.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 26;
            this.label2.Text = "回收文件夹";
            // 
            // tbxDestination
            // 
            this.tbxDestination.AllowDrop = true;
            this.tbxDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDestination.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxDestination.Location = new System.Drawing.Point(210, 275);
            this.tbxDestination.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDestination.Name = "tbxDestination";
            this.tbxDestination.ReadOnly = true;
            this.tbxDestination.Size = new System.Drawing.Size(802, 45);
            this.tbxDestination.TabIndex = 25;
            this.toolTip.SetToolTip(this.tbxDestination, "找出来的重复文件将被转移到这里");
            this.tbxDestination.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbxDestination_DragDrop);
            this.tbxDestination.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbxDestination_DragEnter);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(1020, 270);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 50);
            this.button2.TabIndex = 24;
            this.button2.Text = "选择";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxByPixel
            // 
            this.cbxByPixel.AutoSize = true;
            this.cbxByPixel.Checked = true;
            this.cbxByPixel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxByPixel.Location = new System.Drawing.Point(21, 40);
            this.cbxByPixel.Margin = new System.Windows.Forms.Padding(4);
            this.cbxByPixel.Name = "cbxByPixel";
            this.cbxByPixel.Size = new System.Drawing.Size(195, 34);
            this.cbxByPixel.TabIndex = 0;
            this.cbxByPixel.Text = "像素级比较";
            this.toolTip.SetToolTip(this.cbxByPixel, "对文件大小和长宽相同的图片逐个像素进行比较，完全相同时作为重复文件处理。\r\n支持jpg、png、bmp、gif、exif、wmf、emf、tiff、icon图片格" +
        "式。\r\n优先保留包含拍摄日期的图片。");
            this.cbxByPixel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbxByPixel);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(210, 367);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(808, 92);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件大小相同但内容不一致的图片？";
            // 
            // frmDeduplicate
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 1102);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxDestination);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbCurrentFile);
            this.Controls.Add(this.lbProgress);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxIncludeSubDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxSource);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDeduplicate";
            this.Text = "精确去重";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmDeduplicate_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmDeduplicate_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxIncludeSubDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FolderBrowserDialog fbdSource;
        private System.Windows.Forms.Label lbCurrentFile;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxDestination;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog fbdDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxByPixel;
    }
}