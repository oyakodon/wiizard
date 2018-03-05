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
            this.label1 = new System.Windows.Forms.Label();
            this.labProfileName = new System.Windows.Forms.Label();
            this.btnToggleMode = new System.Windows.Forms.Button();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Readme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
            this.MenuItem_Help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(284, 24);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "プロファイル: ";
            // 
            // labProfileName
            // 
            this.labProfileName.AutoSize = true;
            this.labProfileName.Location = new System.Drawing.Point(81, 38);
            this.labProfileName.Name = "labProfileName";
            this.labProfileName.Size = new System.Drawing.Size(31, 12);
            this.labProfileName.TabIndex = 2;
            this.labProfileName.Text = "None";
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Location = new System.Drawing.Point(14, 71);
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(258, 35);
            this.btnToggleMode.TabIndex = 3;
            this.btnToggleMode.Text = "停止(&S)";
            this.btnToggleMode.UseVisualStyleBackColor = true;
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
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
            // MenuItem_Version
            // 
            this.MenuItem_Version.Name = "MenuItem_Version";
            this.MenuItem_Version.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_Version.Text = "バージョン情報(&V)";
            this.MenuItem_Version.Click += new System.EventHandler(this.MenuItem_Version_Click);
            // 
            // MenuItem_Readme
            // 
            this.MenuItem_Readme.Name = "MenuItem_Readme";
            this.MenuItem_Readme.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_Readme.Text = "Readme.md";
            this.MenuItem_Readme.Click += new System.EventHandler(this.MenuItem_Readme_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 118);
            this.Controls.Add(this.btnToggleMode);
            this.Controls.Add(this.labProfileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Wiizard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_debugInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labProfileName;
        private System.Windows.Forms.Button btnToggleMode;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Readme;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
    }
}

