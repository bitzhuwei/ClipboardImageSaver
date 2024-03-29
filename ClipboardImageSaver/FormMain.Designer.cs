﻿namespace ClipboardImageSaver
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowsePath = new System.Windows.Forms.Button();
			this.lblPath = new System.Windows.Forms.Label();
			this.txtPrefix = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtInfo = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.btnDistinct = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.pgbDistinct = new System.Windows.Forms.ProgressBar();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.btnOpenFolder = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(89, 16);
			this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(349, 29);
			this.txtPath.TabIndex = 1;
			// 
			// btnBrowsePath
			// 
			this.btnBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowsePath.Location = new System.Drawing.Point(442, 16);
			this.btnBrowsePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnBrowsePath.Name = "btnBrowsePath";
			this.btnBrowsePath.Size = new System.Drawing.Size(115, 29);
			this.btnBrowsePath.TabIndex = 2;
			this.btnBrowsePath.Text = "browse...";
			this.btnBrowsePath.UseVisualStyleBackColor = true;
			this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(6, 18);
			this.lblPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(59, 19);
			this.lblPath.TabIndex = 0;
			this.lblPath.Text = "Path:";
			this.lblPath.DoubleClick += new System.EventHandler(this.lblPath_DoubleClick);
			// 
			// txtPrefix
			// 
			this.txtPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPrefix.Location = new System.Drawing.Point(89, 49);
			this.txtPrefix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtPrefix.Name = "txtPrefix";
			this.txtPrefix.Size = new System.Drawing.Size(349, 29);
			this.txtPrefix.TabIndex = 1;
			this.txtPrefix.Text = "bitzhuwei.cnblogs.com";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 52);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "Prefix:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnBrowsePath);
			this.groupBox1.Controls.Add(this.btnOpenFolder);
			this.groupBox1.Controls.Add(this.txtPath);
			this.groupBox1.Controls.Add(this.lblPath);
			this.groupBox1.Controls.Add(this.txtPrefix);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 14F);
			this.groupBox1.Location = new System.Drawing.Point(9, 10);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(561, 87);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Save To";
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Font = new System.Drawing.Font("宋体", 14F);
			this.btnStart.Location = new System.Drawing.Point(451, 181);
			this.btnStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(119, 27);
			this.btnStart.TabIndex = 6;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txtInfo
			// 
			this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtInfo.Location = new System.Drawing.Point(9, 101);
			this.txtInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtInfo.Multiline = true;
			this.txtInfo.Name = "txtInfo";
			this.txtInfo.ReadOnly = true;
			this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtInfo.Size = new System.Drawing.Size(438, 107);
			this.txtInfo.TabIndex = 5;
			// 
			// btnDistinct
			// 
			this.btnDistinct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDistinct.Enabled = false;
			this.btnDistinct.Font = new System.Drawing.Font("宋体", 14F);
			this.btnDistinct.Location = new System.Drawing.Point(451, 150);
			this.btnDistinct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDistinct.Name = "btnDistinct";
			this.btnDistinct.Size = new System.Drawing.Size(119, 27);
			this.btnDistinct.TabIndex = 7;
			this.btnDistinct.Text = "Distinct";
			this.btnDistinct.UseVisualStyleBackColor = true;
			this.btnDistinct.Click += new System.EventHandler(this.btnDistinct_Click);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.WorkerReportsProgress = true;
			this.backgroundWorker1.WorkerSupportsCancellation = true;
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// pgbDistinct
			// 
			this.pgbDistinct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pgbDistinct.Location = new System.Drawing.Point(451, 181);
			this.pgbDistinct.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pgbDistinct.Name = "pgbDistinct";
			this.pgbDistinct.Size = new System.Drawing.Size(119, 26);
			this.pgbDistinct.TabIndex = 9;
			this.pgbDistinct.Visible = false;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "Clipboard Image Saver";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
			// 
			// btnOpenFolder
			// 
			this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpenFolder.Location = new System.Drawing.Point(442, 18);
			this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(2);
			this.btnOpenFolder.Name = "btnOpenFolder";
			this.btnOpenFolder.Size = new System.Drawing.Size(115, 27);
			this.btnOpenFolder.TabIndex = 3;
			this.btnOpenFolder.Text = "Open Path";
			this.btnOpenFolder.UseVisualStyleBackColor = true;
			this.btnOpenFolder.Visible = false;
			this.btnOpenFolder.Click += new System.EventHandler(this.btnOpenFolder_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(579, 218);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.txtInfo);
			this.Controls.Add(this.btnDistinct);
			this.Controls.Add(this.pgbDistinct);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormMain";
			this.Text = "Clipboard Image Saver @ http://bitzhuwei.cnblogs.com";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnDistinct;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar pgbDistinct;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Button btnOpenFolder;
	}
}