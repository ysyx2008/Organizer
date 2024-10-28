namespace 照片整理专家
{
    partial class frmPurgeFileName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurgeFileName));
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cbxRemoveSuffix = new System.Windows.Forms.CheckBox();
            this.fbdDestination = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxTrimFilename = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxIncludeSubDirectory
            // 
            this.cbxIncludeSubDirectory.AutoSize = true;
            this.cbxIncludeSubDirectory.Checked = true;
            this.cbxIncludeSubDirectory.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxIncludeSubDirectory.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxIncludeSubDirectory.Location = new System.Drawing.Point(224, 266);
            this.cbxIncludeSubDirectory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.label1.Location = new System.Drawing.Point(36, 221);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "目标文件夹";
            // 
            // tbxSource
            // 
            this.tbxSource.AllowDrop = true;
            this.tbxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSource.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSource.Location = new System.Drawing.Point(224, 215);
            this.tbxSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.button1.Location = new System.Drawing.Point(1033, 210);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 51);
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
            this.label3.Location = new System.Drawing.Point(47, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1069, 135);
            this.label3.TabIndex = 19;
            this.label3.Text = "  批量删除文件名中的多余字符，例如由于复制粘贴而自动产生的(1)、(2)这样的尾部序号，或者空白字符。\r\n\r\n  清理后显示结果比对界面，并提供一次撤销机会。";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(948, 804);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 95);
            this.button3.TabIndex = 20;
            this.button3.Text = "执行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lbCurrentFile
            // 
            this.lbCurrentFile.AutoSize = true;
            this.lbCurrentFile.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCurrentFile.Location = new System.Drawing.Point(65, 896);
            this.lbCurrentFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCurrentFile.Name = "lbCurrentFile";
            this.lbCurrentFile.Size = new System.Drawing.Size(0, 30);
            this.lbCurrentFile.TabIndex = 23;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbProgress.Location = new System.Drawing.Point(65, 804);
            this.lbProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(0, 30);
            this.lbProgress.TabIndex = 22;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(70, 959);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1082, 30);
            this.progressBar.TabIndex = 21;
            // 
            // cbxRemoveSuffix
            // 
            this.cbxRemoveSuffix.AutoSize = true;
            this.cbxRemoveSuffix.Checked = true;
            this.cbxRemoveSuffix.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxRemoveSuffix.Location = new System.Drawing.Point(20, 73);
            this.cbxRemoveSuffix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxRemoveSuffix.Name = "cbxRemoveSuffix";
            this.cbxRemoveSuffix.Size = new System.Drawing.Size(510, 34);
            this.cbxRemoveSuffix.TabIndex = 0;
            this.cbxRemoveSuffix.Text = "删除文件名尾缀类似“(2)”的序号";
            this.cbxRemoveSuffix.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbxTrimFilename);
            this.groupBox2.Controls.Add(this.cbxRemoveSuffix);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(224, 359);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(808, 210);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "执行哪些操作？";
            // 
            // cbxTrimFilename
            // 
            this.cbxTrimFilename.AutoSize = true;
            this.cbxTrimFilename.Checked = true;
            this.cbxTrimFilename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxTrimFilename.Location = new System.Drawing.Point(20, 141);
            this.cbxTrimFilename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTrimFilename.Name = "cbxTrimFilename";
            this.cbxTrimFilename.Size = new System.Drawing.Size(375, 34);
            this.cbxTrimFilename.TabIndex = 1;
            this.cbxTrimFilename.Text = "删除文件名前后空白字符";
            this.cbxTrimFilename.UseVisualStyleBackColor = true;
            // 
            // frmPurgeFileName
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 1102);
            this.Controls.Add(this.groupBox2);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPurgeFileName";
            this.Text = "清理文件名";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmDeduplicate_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmDeduplicate_DragEnter);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.FolderBrowserDialog fbdDestination;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbxRemoveSuffix;
        private System.Windows.Forms.CheckBox cbxTrimFilename;
    }
}