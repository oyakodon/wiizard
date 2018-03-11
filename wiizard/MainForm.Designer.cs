namespace wiizard
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_debugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_profile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_reloadProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_autoReload = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Readme = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_profile = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox_profile = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_profile,
            this.MenuItem_Help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(949, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuItem_File
            // 
            this.MenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_debugInfo});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(67, 20);
            this.MenuItem_File.Text = "ファイル(&F)";
            // 
            // MenuItem_debugInfo
            // 
            this.MenuItem_debugInfo.Name = "MenuItem_debugInfo";
            this.MenuItem_debugInfo.Size = new System.Drawing.Size(150, 22);
            this.MenuItem_debugInfo.Text = "デバッグ情報(&D)";
            this.MenuItem_debugInfo.Click += new System.EventHandler(this.MenuItem_debugInfo_Click);
            // 
            // MenuItem_profile
            // 
            this.MenuItem_profile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_reloadProfile,
            this.MenuItem_autoReload});
            this.MenuItem_profile.Name = "MenuItem_profile";
            this.MenuItem_profile.Size = new System.Drawing.Size(86, 20);
            this.MenuItem_profile.Text = "プロファイル(&P)";
            // 
            // MenuItem_reloadProfile
            // 
            this.MenuItem_reloadProfile.Name = "MenuItem_reloadProfile";
            this.MenuItem_reloadProfile.Size = new System.Drawing.Size(200, 22);
            this.MenuItem_reloadProfile.Text = "プロファイルの再読込(&R)";
            this.MenuItem_reloadProfile.Click += new System.EventHandler(this.MenuItem_reloadProfile_Click);
            // 
            // MenuItem_autoReload
            // 
            this.MenuItem_autoReload.Checked = true;
            this.MenuItem_autoReload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItem_autoReload.Name = "MenuItem_autoReload";
            this.MenuItem_autoReload.Size = new System.Drawing.Size(200, 22);
            this.MenuItem_autoReload.Text = "プロファイルの変更検知(&A)";
            this.MenuItem_autoReload.Click += new System.EventHandler(this.MenuItem_autoReload_Click);
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Readme,
            this.MenuItem_Version});
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(65, 20);
            this.MenuItem_Help.Text = "ヘルプ(&H)";
            // 
            // MenuItem_Readme
            // 
            this.MenuItem_Readme.Name = "MenuItem_Readme";
            this.MenuItem_Readme.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_Readme.Text = "Readme.md";
            this.MenuItem_Readme.Click += new System.EventHandler(this.MenuItem_Readme_Click);
            // 
            // MenuItem_Version
            // 
            this.MenuItem_Version.Name = "MenuItem_Version";
            this.MenuItem_Version.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_Version.Text = "バージョン情報(&V)";
            this.MenuItem_Version.Click += new System.EventHandler(this.MenuItem_Version_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStat});
            this.statusStrip.Location = new System.Drawing.Point(0, 580);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(949, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // labStat
            // 
            this.labStat.Name = "labStat";
            this.labStat.Size = new System.Drawing.Size(46, 17);
            this.labStat.Text = "Wiizard";
            // 
            // panel_profile
            // 
            this.panel_profile.Controls.Add(this.splitContainer);
            this.panel_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_profile.Location = new System.Drawing.Point(0, 24);
            this.panel_profile.Name = "panel_profile";
            this.panel_profile.Padding = new System.Windows.Forms.Padding(10);
            this.panel_profile.Size = new System.Drawing.Size(949, 556);
            this.panel_profile.TabIndex = 5;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(10, 10);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBox_profile);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.button1);
            this.splitContainer.Size = new System.Drawing.Size(929, 536);
            this.splitContainer.SplitterDistance = 196;
            this.splitContainer.TabIndex = 3;
            // 
            // listBox_profile
            // 
            this.listBox_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_profile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_profile.FormattingEnabled = true;
            this.listBox_profile.ItemHeight = 25;
            this.listBox_profile.Items.AddRange(new object[] {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"});
            this.listBox_profile.Location = new System.Drawing.Point(0, 0);
            this.listBox_profile.Name = "listBox_profile";
            this.listBox_profile.Size = new System.Drawing.Size(196, 536);
            this.listBox_profile.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(394, 51);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 602);
            this.Controls.Add(this.panel_profile);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Wiizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel_profile.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_debugInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Readme;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_profile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_reloadProfile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_autoReload;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labStat;
        private System.Windows.Forms.Panel panel_profile;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBox_profile;
        private System.Windows.Forms.Button button1;
    }
}

