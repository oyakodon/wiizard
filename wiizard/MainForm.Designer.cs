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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_newProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_autoReload = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Readme = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_debugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_profile = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox_profile = new System.Windows.Forms.ListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.MenuItem_deleteProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_AccIR = new System.Windows.Forms.TabPage();
            this.combo_acc_x = new System.Windows.Forms.ComboBox();
            this.combo_acc_y = new System.Windows.Forms.ComboBox();
            this.combo_nunchuk_acc_x = new System.Windows.Forms.ComboBox();
            this.combo_nunchuk_acc_y = new System.Windows.Forms.ComboBox();
            this.combo_nunchuk_joy_x = new System.Windows.Forms.ComboBox();
            this.combo_nunchuk_joy_y = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.combo_ir_x = new System.Windows.Forms.ComboBox();
            this.combo_ir_y = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.combo_behavior = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage_buttons = new System.Windows.Forms.TabPage();
            this.panel_config_wiiimg = new System.Windows.Forms.Panel();
            this.picBox_wii = new System.Windows.Forms.PictureBox();
            this.combo_Left = new System.Windows.Forms.ComboBox();
            this.combo_Up = new System.Windows.Forms.ComboBox();
            this.combo_Down = new System.Windows.Forms.ComboBox();
            this.combo_B = new System.Windows.Forms.ComboBox();
            this.combo_Right = new System.Windows.Forms.ComboBox();
            this.combo_Home = new System.Windows.Forms.ComboBox();
            this.combo_A = new System.Windows.Forms.ComboBox();
            this.combo_Plus = new System.Windows.Forms.ComboBox();
            this.combo_Minus = new System.Windows.Forms.ComboBox();
            this.combo_One = new System.Windows.Forms.ComboBox();
            this.combo_Two = new System.Windows.Forms.ComboBox();
            this.combo_C = new System.Windows.Forms.ComboBox();
            this.combo_Z = new System.Windows.Forms.ComboBox();
            this.combo_Joy_Left = new System.Windows.Forms.ComboBox();
            this.combo_Joy_Down = new System.Windows.Forms.ComboBox();
            this.combo_Joy_Right = new System.Windows.Forms.ComboBox();
            this.combo_Joy_Up = new System.Windows.Forms.ComboBox();
            this.check_JoyAsButton = new System.Windows.Forms.CheckBox();
            this.check_UseNunchuk = new System.Windows.Forms.CheckBox();
            this.tabControl_config = new System.Windows.Forms.TabControl();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabPage_AccIR.SuspendLayout();
            this.tabPage_buttons.SuspendLayout();
            this.panel_config_wiiimg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_wii)).BeginInit();
            this.tabControl_config.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_File,
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
            this.MenuItem_newProfile,
            this.MenuItem_deleteProfile,
            this.MenuItem_autoReload});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(67, 20);
            this.MenuItem_File.Text = "ファイル(&F)";
            // 
            // MenuItem_newProfile
            // 
            this.MenuItem_newProfile.Name = "MenuItem_newProfile";
            this.MenuItem_newProfile.Size = new System.Drawing.Size(200, 22);
            this.MenuItem_newProfile.Text = "新規プロファイル(&N)";
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
            this.MenuItem_debugInfo,
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
            // MenuItem_debugInfo
            // 
            this.MenuItem_debugInfo.Name = "MenuItem_debugInfo";
            this.MenuItem_debugInfo.Size = new System.Drawing.Size(157, 22);
            this.MenuItem_debugInfo.Text = "デバッグ情報(&D)";
            this.MenuItem_debugInfo.Click += new System.EventHandler(this.MenuItem_debugInfo_Click);
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
            this.splitContainer.Panel2.Controls.Add(this.tabControl_config);
            this.splitContainer.Panel2.Controls.Add(this.btnRun);
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
            this.listBox_profile.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_profile_DrawItem);
            this.listBox_profile.SelectedIndexChanged += new System.EventHandler(this.listBox_profile_SelectedIndexChanged);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(227, 461);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(261, 51);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "開始";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // MenuItem_deleteProfile
            // 
            this.MenuItem_deleteProfile.Name = "MenuItem_deleteProfile";
            this.MenuItem_deleteProfile.Size = new System.Drawing.Size(200, 22);
            this.MenuItem_deleteProfile.Text = "プロファイルの削除(&D)";
            // 
            // tabPage_AccIR
            // 
            this.tabPage_AccIR.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_AccIR.Controls.Add(this.label13);
            this.tabPage_AccIR.Controls.Add(this.combo_behavior);
            this.tabPage_AccIR.Controls.Add(this.label11);
            this.tabPage_AccIR.Controls.Add(this.label12);
            this.tabPage_AccIR.Controls.Add(this.label9);
            this.tabPage_AccIR.Controls.Add(this.label10);
            this.tabPage_AccIR.Controls.Add(this.combo_ir_y);
            this.tabPage_AccIR.Controls.Add(this.combo_ir_x);
            this.tabPage_AccIR.Controls.Add(this.label8);
            this.tabPage_AccIR.Controls.Add(this.label6);
            this.tabPage_AccIR.Controls.Add(this.label7);
            this.tabPage_AccIR.Controls.Add(this.label4);
            this.tabPage_AccIR.Controls.Add(this.label5);
            this.tabPage_AccIR.Controls.Add(this.label3);
            this.tabPage_AccIR.Controls.Add(this.label2);
            this.tabPage_AccIR.Controls.Add(this.label1);
            this.tabPage_AccIR.Controls.Add(this.combo_nunchuk_joy_y);
            this.tabPage_AccIR.Controls.Add(this.combo_nunchuk_joy_x);
            this.tabPage_AccIR.Controls.Add(this.combo_nunchuk_acc_y);
            this.tabPage_AccIR.Controls.Add(this.combo_nunchuk_acc_x);
            this.tabPage_AccIR.Controls.Add(this.combo_acc_y);
            this.tabPage_AccIR.Controls.Add(this.combo_acc_x);
            this.tabPage_AccIR.Location = new System.Drawing.Point(4, 22);
            this.tabPage_AccIR.Name = "tabPage_AccIR";
            this.tabPage_AccIR.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_AccIR.Size = new System.Drawing.Size(721, 418);
            this.tabPage_AccIR.TabIndex = 1;
            this.tabPage_AccIR.Text = "加速度・IR";
            // 
            // combo_acc_x
            // 
            this.combo_acc_x.FormattingEnabled = true;
            this.combo_acc_x.Location = new System.Drawing.Point(188, 29);
            this.combo_acc_x.Name = "combo_acc_x";
            this.combo_acc_x.Size = new System.Drawing.Size(95, 20);
            this.combo_acc_x.TabIndex = 0;
            this.combo_acc_x.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_acc_y
            // 
            this.combo_acc_y.FormattingEnabled = true;
            this.combo_acc_y.Location = new System.Drawing.Point(188, 55);
            this.combo_acc_y.Name = "combo_acc_y";
            this.combo_acc_y.Size = new System.Drawing.Size(95, 20);
            this.combo_acc_y.TabIndex = 1;
            this.combo_acc_y.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_nunchuk_acc_x
            // 
            this.combo_nunchuk_acc_x.Enabled = false;
            this.combo_nunchuk_acc_x.FormattingEnabled = true;
            this.combo_nunchuk_acc_x.Location = new System.Drawing.Point(188, 144);
            this.combo_nunchuk_acc_x.Name = "combo_nunchuk_acc_x";
            this.combo_nunchuk_acc_x.Size = new System.Drawing.Size(95, 20);
            this.combo_nunchuk_acc_x.TabIndex = 2;
            this.combo_nunchuk_acc_x.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_nunchuk_acc_y
            // 
            this.combo_nunchuk_acc_y.Enabled = false;
            this.combo_nunchuk_acc_y.FormattingEnabled = true;
            this.combo_nunchuk_acc_y.Location = new System.Drawing.Point(188, 170);
            this.combo_nunchuk_acc_y.Name = "combo_nunchuk_acc_y";
            this.combo_nunchuk_acc_y.Size = new System.Drawing.Size(95, 20);
            this.combo_nunchuk_acc_y.TabIndex = 3;
            this.combo_nunchuk_acc_y.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_nunchuk_joy_x
            // 
            this.combo_nunchuk_joy_x.Enabled = false;
            this.combo_nunchuk_joy_x.FormattingEnabled = true;
            this.combo_nunchuk_joy_x.Location = new System.Drawing.Point(515, 144);
            this.combo_nunchuk_joy_x.Name = "combo_nunchuk_joy_x";
            this.combo_nunchuk_joy_x.Size = new System.Drawing.Size(95, 20);
            this.combo_nunchuk_joy_x.TabIndex = 4;
            this.combo_nunchuk_joy_x.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_nunchuk_joy_y
            // 
            this.combo_nunchuk_joy_y.Enabled = false;
            this.combo_nunchuk_joy_y.FormattingEnabled = true;
            this.combo_nunchuk_joy_y.Location = new System.Drawing.Point(515, 170);
            this.combo_nunchuk_joy_y.Name = "combo_nunchuk_joy_y";
            this.combo_nunchuk_joy_y.Size = new System.Drawing.Size(95, 20);
            this.combo_nunchuk_joy_y.TabIndex = 5;
            this.combo_nunchuk_joy_y.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "リモコン加速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(168, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(495, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "ヌンチャク加速度";
            // 
            // combo_ir_x
            // 
            this.combo_ir_x.FormattingEnabled = true;
            this.combo_ir_x.Location = new System.Drawing.Point(515, 29);
            this.combo_ir_x.Name = "combo_ir_x";
            this.combo_ir_x.Size = new System.Drawing.Size(95, 20);
            this.combo_ir_x.TabIndex = 14;
            this.combo_ir_x.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_ir_y
            // 
            this.combo_ir_y.FormattingEnabled = true;
            this.combo_ir_y.Location = new System.Drawing.Point(515, 55);
            this.combo_ir_y.Name = "combo_ir_y";
            this.combo_ir_y.Size = new System.Drawing.Size(95, 20);
            this.combo_ir_y.TabIndex = 15;
            this.combo_ir_y.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(495, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "X:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(495, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "Y:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(448, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "赤外線";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(376, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "ヌンチャクジョイスティック";
            // 
            // combo_behavior
            // 
            this.combo_behavior.FormattingEnabled = true;
            this.combo_behavior.Location = new System.Drawing.Point(188, 255);
            this.combo_behavior.Name = "combo_behavior";
            this.combo_behavior.Size = new System.Drawing.Size(95, 20);
            this.combo_behavior.TabIndex = 20;
            this.combo_behavior.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(131, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "挙動:";
            // 
            // tabPage_buttons
            // 
            this.tabPage_buttons.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_buttons.Controls.Add(this.panel_config_wiiimg);
            this.tabPage_buttons.Location = new System.Drawing.Point(4, 22);
            this.tabPage_buttons.Name = "tabPage_buttons";
            this.tabPage_buttons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_buttons.Size = new System.Drawing.Size(721, 418);
            this.tabPage_buttons.TabIndex = 0;
            this.tabPage_buttons.Text = "ボタン";
            // 
            // panel_config_wiiimg
            // 
            this.panel_config_wiiimg.Controls.Add(this.check_UseNunchuk);
            this.panel_config_wiiimg.Controls.Add(this.check_JoyAsButton);
            this.panel_config_wiiimg.Controls.Add(this.combo_Joy_Up);
            this.panel_config_wiiimg.Controls.Add(this.combo_Joy_Right);
            this.panel_config_wiiimg.Controls.Add(this.combo_Joy_Down);
            this.panel_config_wiiimg.Controls.Add(this.combo_Joy_Left);
            this.panel_config_wiiimg.Controls.Add(this.combo_Z);
            this.panel_config_wiiimg.Controls.Add(this.combo_C);
            this.panel_config_wiiimg.Controls.Add(this.combo_Two);
            this.panel_config_wiiimg.Controls.Add(this.combo_One);
            this.panel_config_wiiimg.Controls.Add(this.combo_Minus);
            this.panel_config_wiiimg.Controls.Add(this.combo_Plus);
            this.panel_config_wiiimg.Controls.Add(this.combo_A);
            this.panel_config_wiiimg.Controls.Add(this.combo_Home);
            this.panel_config_wiiimg.Controls.Add(this.combo_Right);
            this.panel_config_wiiimg.Controls.Add(this.combo_B);
            this.panel_config_wiiimg.Controls.Add(this.combo_Down);
            this.panel_config_wiiimg.Controls.Add(this.combo_Up);
            this.panel_config_wiiimg.Controls.Add(this.combo_Left);
            this.panel_config_wiiimg.Controls.Add(this.picBox_wii);
            this.panel_config_wiiimg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_config_wiiimg.Location = new System.Drawing.Point(3, 3);
            this.panel_config_wiiimg.Name = "panel_config_wiiimg";
            this.panel_config_wiiimg.Padding = new System.Windows.Forms.Padding(10);
            this.panel_config_wiiimg.Size = new System.Drawing.Size(715, 412);
            this.panel_config_wiiimg.TabIndex = 2;
            // 
            // picBox_wii
            // 
            this.picBox_wii.BackColor = System.Drawing.Color.Transparent;
            this.picBox_wii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_wii.Image = ((System.Drawing.Image)(resources.GetObject("picBox_wii.Image")));
            this.picBox_wii.Location = new System.Drawing.Point(10, 10);
            this.picBox_wii.Name = "picBox_wii";
            this.picBox_wii.Size = new System.Drawing.Size(695, 392);
            this.picBox_wii.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_wii.TabIndex = 1;
            this.picBox_wii.TabStop = false;
            // 
            // combo_Left
            // 
            this.combo_Left.FormattingEnabled = true;
            this.combo_Left.Location = new System.Drawing.Point(76, 51);
            this.combo_Left.Name = "combo_Left";
            this.combo_Left.Size = new System.Drawing.Size(53, 20);
            this.combo_Left.TabIndex = 2;
            this.combo_Left.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Up
            // 
            this.combo_Up.FormattingEnabled = true;
            this.combo_Up.Location = new System.Drawing.Point(149, 3);
            this.combo_Up.Name = "combo_Up";
            this.combo_Up.Size = new System.Drawing.Size(53, 20);
            this.combo_Up.TabIndex = 3;
            this.combo_Up.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Down
            // 
            this.combo_Down.FormattingEnabled = true;
            this.combo_Down.Location = new System.Drawing.Point(192, 93);
            this.combo_Down.Name = "combo_Down";
            this.combo_Down.Size = new System.Drawing.Size(53, 20);
            this.combo_Down.TabIndex = 4;
            this.combo_Down.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_B
            // 
            this.combo_B.FormattingEnabled = true;
            this.combo_B.Location = new System.Drawing.Point(271, 139);
            this.combo_B.Name = "combo_B";
            this.combo_B.Size = new System.Drawing.Size(53, 20);
            this.combo_B.TabIndex = 5;
            this.combo_B.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Right
            // 
            this.combo_Right.FormattingEnabled = true;
            this.combo_Right.Location = new System.Drawing.Point(220, 51);
            this.combo_Right.Name = "combo_Right";
            this.combo_Right.Size = new System.Drawing.Size(53, 20);
            this.combo_Right.TabIndex = 6;
            this.combo_Right.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Home
            // 
            this.combo_Home.FormattingEnabled = true;
            this.combo_Home.Location = new System.Drawing.Point(149, 160);
            this.combo_Home.Name = "combo_Home";
            this.combo_Home.Size = new System.Drawing.Size(53, 20);
            this.combo_Home.TabIndex = 7;
            this.combo_Home.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_A
            // 
            this.combo_A.FormattingEnabled = true;
            this.combo_A.Location = new System.Drawing.Point(91, 120);
            this.combo_A.Name = "combo_A";
            this.combo_A.Size = new System.Drawing.Size(53, 20);
            this.combo_A.TabIndex = 8;
            this.combo_A.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Plus
            // 
            this.combo_Plus.FormattingEnabled = true;
            this.combo_Plus.Location = new System.Drawing.Point(91, 204);
            this.combo_Plus.Name = "combo_Plus";
            this.combo_Plus.Size = new System.Drawing.Size(53, 20);
            this.combo_Plus.TabIndex = 9;
            this.combo_Plus.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Minus
            // 
            this.combo_Minus.FormattingEnabled = true;
            this.combo_Minus.Location = new System.Drawing.Point(204, 204);
            this.combo_Minus.Name = "combo_Minus";
            this.combo_Minus.Size = new System.Drawing.Size(53, 20);
            this.combo_Minus.TabIndex = 10;
            this.combo_Minus.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_One
            // 
            this.combo_One.FormattingEnabled = true;
            this.combo_One.Location = new System.Drawing.Point(192, 290);
            this.combo_One.Name = "combo_One";
            this.combo_One.Size = new System.Drawing.Size(53, 20);
            this.combo_One.TabIndex = 11;
            this.combo_One.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Two
            // 
            this.combo_Two.FormattingEnabled = true;
            this.combo_Two.Location = new System.Drawing.Point(192, 326);
            this.combo_Two.Name = "combo_Two";
            this.combo_Two.Size = new System.Drawing.Size(53, 20);
            this.combo_Two.TabIndex = 12;
            this.combo_Two.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_C
            // 
            this.combo_C.Enabled = false;
            this.combo_C.FormattingEnabled = true;
            this.combo_C.Location = new System.Drawing.Point(577, 104);
            this.combo_C.Name = "combo_C";
            this.combo_C.Size = new System.Drawing.Size(53, 20);
            this.combo_C.TabIndex = 13;
            this.combo_C.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Z
            // 
            this.combo_Z.Enabled = false;
            this.combo_Z.FormattingEnabled = true;
            this.combo_Z.Location = new System.Drawing.Point(577, 150);
            this.combo_Z.Name = "combo_Z";
            this.combo_Z.Size = new System.Drawing.Size(53, 20);
            this.combo_Z.TabIndex = 14;
            this.combo_Z.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Joy_Left
            // 
            this.combo_Joy_Left.Enabled = false;
            this.combo_Joy_Left.FormattingEnabled = true;
            this.combo_Joy_Left.Location = new System.Drawing.Point(335, 117);
            this.combo_Joy_Left.Name = "combo_Joy_Left";
            this.combo_Joy_Left.Size = new System.Drawing.Size(53, 20);
            this.combo_Joy_Left.TabIndex = 15;
            this.combo_Joy_Left.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Joy_Down
            // 
            this.combo_Joy_Down.Enabled = false;
            this.combo_Joy_Down.FormattingEnabled = true;
            this.combo_Joy_Down.Location = new System.Drawing.Point(395, 177);
            this.combo_Joy_Down.Name = "combo_Joy_Down";
            this.combo_Joy_Down.Size = new System.Drawing.Size(53, 20);
            this.combo_Joy_Down.TabIndex = 16;
            this.combo_Joy_Down.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Joy_Right
            // 
            this.combo_Joy_Right.Enabled = false;
            this.combo_Joy_Right.FormattingEnabled = true;
            this.combo_Joy_Right.Location = new System.Drawing.Point(448, 117);
            this.combo_Joy_Right.Name = "combo_Joy_Right";
            this.combo_Joy_Right.Size = new System.Drawing.Size(53, 20);
            this.combo_Joy_Right.TabIndex = 17;
            this.combo_Joy_Right.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // combo_Joy_Up
            // 
            this.combo_Joy_Up.Enabled = false;
            this.combo_Joy_Up.FormattingEnabled = true;
            this.combo_Joy_Up.Location = new System.Drawing.Point(395, 60);
            this.combo_Joy_Up.Name = "combo_Joy_Up";
            this.combo_Joy_Up.Size = new System.Drawing.Size(53, 20);
            this.combo_Joy_Up.TabIndex = 18;
            this.combo_Joy_Up.SelectedIndexChanged += new System.EventHandler(this.profile_UI_SelectedIndexChanged);
            // 
            // check_JoyAsButton
            // 
            this.check_JoyAsButton.AutoSize = true;
            this.check_JoyAsButton.Location = new System.Drawing.Point(384, 369);
            this.check_JoyAsButton.Name = "check_JoyAsButton";
            this.check_JoyAsButton.Size = new System.Drawing.Size(194, 16);
            this.check_JoyAsButton.TabIndex = 19;
            this.check_JoyAsButton.Text = "ジョイスティックをボタンとして使用する";
            this.check_JoyAsButton.UseVisualStyleBackColor = true;
            this.check_JoyAsButton.CheckedChanged += new System.EventHandler(this.check_JoyAsButton_CheckedChanged);
            // 
            // check_UseNunchuk
            // 
            this.check_UseNunchuk.AutoSize = true;
            this.check_UseNunchuk.Enabled = false;
            this.check_UseNunchuk.Location = new System.Drawing.Point(384, 338);
            this.check_UseNunchuk.Name = "check_UseNunchuk";
            this.check_UseNunchuk.Size = new System.Drawing.Size(119, 16);
            this.check_UseNunchuk.TabIndex = 20;
            this.check_UseNunchuk.Text = "ヌンチャクを使用する";
            this.check_UseNunchuk.UseVisualStyleBackColor = true;
            this.check_UseNunchuk.CheckedChanged += new System.EventHandler(this.check_UseNunchuk_CheckedChanged);
            // 
            // tabControl_config
            // 
            this.tabControl_config.Controls.Add(this.tabPage_buttons);
            this.tabControl_config.Controls.Add(this.tabPage_AccIR);
            this.tabControl_config.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl_config.Location = new System.Drawing.Point(0, 0);
            this.tabControl_config.Name = "tabControl_config";
            this.tabControl_config.SelectedIndex = 0;
            this.tabControl_config.Size = new System.Drawing.Size(729, 444);
            this.tabControl_config.TabIndex = 2;
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
            this.tabPage_AccIR.ResumeLayout(false);
            this.tabPage_AccIR.PerformLayout();
            this.tabPage_buttons.ResumeLayout(false);
            this.panel_config_wiiimg.ResumeLayout(false);
            this.panel_config_wiiimg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_wii)).EndInit();
            this.tabControl_config.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Readme;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel labStat;
        private System.Windows.Forms.Panel panel_profile;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox listBox_profile;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_newProfile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_autoReload;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_debugInfo;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_deleteProfile;
        private System.Windows.Forms.TabControl tabControl_config;
        private System.Windows.Forms.TabPage tabPage_buttons;
        private System.Windows.Forms.Panel panel_config_wiiimg;
        private System.Windows.Forms.CheckBox check_UseNunchuk;
        private System.Windows.Forms.CheckBox check_JoyAsButton;
        private System.Windows.Forms.ComboBox combo_Joy_Up;
        private System.Windows.Forms.ComboBox combo_Joy_Right;
        private System.Windows.Forms.ComboBox combo_Joy_Down;
        private System.Windows.Forms.ComboBox combo_Joy_Left;
        private System.Windows.Forms.ComboBox combo_Z;
        private System.Windows.Forms.ComboBox combo_C;
        private System.Windows.Forms.ComboBox combo_Two;
        private System.Windows.Forms.ComboBox combo_One;
        private System.Windows.Forms.ComboBox combo_Minus;
        private System.Windows.Forms.ComboBox combo_Plus;
        private System.Windows.Forms.ComboBox combo_A;
        private System.Windows.Forms.ComboBox combo_Home;
        private System.Windows.Forms.ComboBox combo_Right;
        private System.Windows.Forms.ComboBox combo_B;
        private System.Windows.Forms.ComboBox combo_Down;
        private System.Windows.Forms.ComboBox combo_Up;
        private System.Windows.Forms.ComboBox combo_Left;
        private System.Windows.Forms.PictureBox picBox_wii;
        private System.Windows.Forms.TabPage tabPage_AccIR;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox combo_behavior;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox combo_ir_y;
        private System.Windows.Forms.ComboBox combo_ir_x;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_nunchuk_joy_y;
        private System.Windows.Forms.ComboBox combo_nunchuk_joy_x;
        private System.Windows.Forms.ComboBox combo_nunchuk_acc_y;
        private System.Windows.Forms.ComboBox combo_nunchuk_acc_x;
        private System.Windows.Forms.ComboBox combo_acc_y;
        private System.Windows.Forms.ComboBox combo_acc_x;
    }
}

