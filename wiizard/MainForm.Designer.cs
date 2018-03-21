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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_Profile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_EditProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_debugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Readme = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRun = new System.Windows.Forms.Button();
            this.labName = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStat});
            this.statusStrip.Location = new System.Drawing.Point(0, 145);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(268, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip";
            // 
            // labStat
            // 
            this.labStat.Name = "labStat";
            this.labStat.Size = new System.Drawing.Size(46, 17);
            this.labStat.Text = "Wiizard";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Profile,
            this.MenuItem_Help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(268, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip";
            // 
            // MenuItem_Profile
            // 
            this.MenuItem_Profile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_EditProfile,
            this.toolStripSeparator1});
            this.MenuItem_Profile.Name = "MenuItem_Profile";
            this.MenuItem_Profile.Size = new System.Drawing.Size(86, 20);
            this.MenuItem_Profile.Text = "プロファイル(&P)";
            // 
            // MenuItem_EditProfile
            // 
            this.MenuItem_EditProfile.Name = "MenuItem_EditProfile";
            this.MenuItem_EditProfile.Size = new System.Drawing.Size(180, 22);
            this.MenuItem_EditProfile.Tag = "Invulnerable";
            this.MenuItem_EditProfile.Text = "プロファイルの編集(&E)";
            this.MenuItem_EditProfile.Click += new System.EventHandler(this.MenuItem_EditProfile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            this.toolStripSeparator1.Tag = "Invulnerable";
            // 
            // MenuItem_Help
            // 
            this.MenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_debugInfo,
            this.MenuItem_Readme,
            this.MenuItem_Version});
            this.MenuItem_Help.Name = "MenuItem_Help";
            this.MenuItem_Help.Size = new System.Drawing.Size(65, 20);
            this.MenuItem_Help.Text = "ヘルプ(&H)";
            // 
            // MenuItem_debugInfo
            // 
            this.MenuItem_debugInfo.Name = "MenuItem_debugInfo";
            this.MenuItem_debugInfo.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_debugInfo.Text = "デバッグ情報(&D)";
            this.MenuItem_debugInfo.Click += new System.EventHandler(this.MenuItem_debugInfo_Click);
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
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnRun.Location = new System.Drawing.Point(62, 80);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(146, 47);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "開始";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // labName
            // 
            this.labName.Font = new System.Drawing.Font("Yu Gothic UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labName.Location = new System.Drawing.Point(12, 35);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(244, 30);
            this.labName.TabIndex = 8;
            this.labName.Text = "(未選択)";
            this.labName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 167);
            this.Controls.Add(this.labName);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Name = "MainForm";
            this.Text = "Wiizard";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labStat;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Readme;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_debugInfo;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Profile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_EditProfile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}