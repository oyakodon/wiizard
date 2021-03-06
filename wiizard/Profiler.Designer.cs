﻿namespace wiizard
{
    partial class Profiler
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
            this.MenuItem_newProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_deleteProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Readme = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labStat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_profile = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listBox_profile = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tabControl_config = new System.Windows.Forms.TabControl();
            this.tabPage_buttons = new System.Windows.Forms.TabPage();
            this.panel_config_wiiimg = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.combo_behavior = new System.Windows.Forms.ComboBox();
            this.picBox_wii = new System.Windows.Forms.PictureBox();
            this.tabPage_advconfig = new System.Windows.Forms.TabPage();
            this.listBox_models = new System.Windows.Forms.ListBox();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.num_delay = new System.Windows.Forms.NumericUpDown();
            this.check_inc = new System.Windows.Forms.CheckBox();
            this.num_value = new System.Windows.Forms.NumericUpDown();
            this.combo_modKey = new System.Windows.Forms.ComboBox();
            this.listBox_actions = new System.Windows.Forms.ListBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel_setJoystick = new System.Windows.Forms.Panel();
            this.radioBtn_JoyWASD = new System.Windows.Forms.RadioButton();
            this.radioBtn_JoyMouse = new System.Windows.Forms.RadioButton();
            this.radioBtn_JoyNone = new System.Windows.Forms.RadioButton();
            this.panel_setKeyMouse = new System.Windows.Forms.Panel();
            this.radioBtn_key = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.combo_mouse = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.combo_key = new System.Windows.Forms.ComboBox();
            this.radioBtn_mouse = new System.Windows.Forms.RadioButton();
            this.radioBtn_none = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_profile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl_config.SuspendLayout();
            this.tabPage_buttons.SuspendLayout();
            this.panel_config_wiiimg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_wii)).BeginInit();
            this.tabPage_advconfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_delay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_value)).BeginInit();
            this.panel_setJoystick.SuspendLayout();
            this.panel_setKeyMouse.SuspendLayout();
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
            this.MenuItem_deleteProfile});
            this.MenuItem_File.Name = "MenuItem_File";
            this.MenuItem_File.Size = new System.Drawing.Size(67, 20);
            this.MenuItem_File.Text = "ファイル(&F)";
            // 
            // MenuItem_newProfile
            // 
            this.MenuItem_newProfile.Name = "MenuItem_newProfile";
            this.MenuItem_newProfile.Size = new System.Drawing.Size(176, 22);
            this.MenuItem_newProfile.Text = "新規プロファイル(&N)";
            // 
            // MenuItem_deleteProfile
            // 
            this.MenuItem_deleteProfile.Name = "MenuItem_deleteProfile";
            this.MenuItem_deleteProfile.Size = new System.Drawing.Size(176, 22);
            this.MenuItem_deleteProfile.Text = "プロファイルの削除(&D)";
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
            this.statusStrip.Location = new System.Drawing.Point(0, 506);
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
            this.panel_profile.Size = new System.Drawing.Size(949, 482);
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
            this.splitContainer.Panel2.Controls.Add(this.btnSave);
            this.splitContainer.Panel2.Controls.Add(this.btnApply);
            this.splitContainer.Panel2.Controls.Add(this.tabControl_config);
            this.splitContainer.Panel2.Controls.Add(this.panel_setJoystick);
            this.splitContainer.Panel2.Controls.Add(this.panel_setKeyMouse);
            this.splitContainer.Size = new System.Drawing.Size(929, 462);
            this.splitContainer.SplitterDistance = 196;
            this.splitContainer.TabIndex = 3;
            // 
            // listBox_profile
            // 
            this.listBox_profile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_profile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_profile.FormattingEnabled = true;
            this.listBox_profile.ItemHeight = 25;
            this.listBox_profile.Location = new System.Drawing.Point(0, 0);
            this.listBox_profile.Name = "listBox_profile";
            this.listBox_profile.Size = new System.Drawing.Size(196, 462);
            this.listBox_profile.TabIndex = 0;
            this.listBox_profile.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_profile_DrawItem);
            this.listBox_profile.SelectedIndexChanged += new System.EventHandler(this.listBox_profile_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSave.Location = new System.Drawing.Point(532, 405);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(171, 37);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "設定ファイルに保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(532, 352);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(171, 37);
            this.btnApply.TabIndex = 15;
            this.btnApply.Text = "適用(&A)";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tabControl_config
            // 
            this.tabControl_config.Controls.Add(this.tabPage_buttons);
            this.tabControl_config.Controls.Add(this.tabPage_advconfig);
            this.tabControl_config.Location = new System.Drawing.Point(3, 3);
            this.tabControl_config.Name = "tabControl_config";
            this.tabControl_config.SelectedIndex = 0;
            this.tabControl_config.Size = new System.Drawing.Size(502, 446);
            this.tabControl_config.TabIndex = 2;
            this.tabControl_config.SelectedIndexChanged += new System.EventHandler(this.tabControl_config_SelectedIndexChanged);
            // 
            // tabPage_buttons
            // 
            this.tabPage_buttons.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_buttons.Controls.Add(this.panel_config_wiiimg);
            this.tabPage_buttons.Location = new System.Drawing.Point(4, 22);
            this.tabPage_buttons.Name = "tabPage_buttons";
            this.tabPage_buttons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_buttons.Size = new System.Drawing.Size(494, 420);
            this.tabPage_buttons.TabIndex = 0;
            this.tabPage_buttons.Text = "全般";
            // 
            // panel_config_wiiimg
            // 
            this.panel_config_wiiimg.Controls.Add(this.label13);
            this.panel_config_wiiimg.Controls.Add(this.combo_behavior);
            this.panel_config_wiiimg.Controls.Add(this.picBox_wii);
            this.panel_config_wiiimg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_config_wiiimg.Location = new System.Drawing.Point(3, 3);
            this.panel_config_wiiimg.Name = "panel_config_wiiimg";
            this.panel_config_wiiimg.Padding = new System.Windows.Forms.Padding(10);
            this.panel_config_wiiimg.Size = new System.Drawing.Size(488, 414);
            this.panel_config_wiiimg.TabIndex = 2;
            this.panel_config_wiiimg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_config_wiiimg_MouseClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(274, 354);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 12);
            this.label13.TabIndex = 25;
            this.label13.Text = "挙動:";
            // 
            // combo_behavior
            // 
            this.combo_behavior.DropDownWidth = 150;
            this.combo_behavior.FormattingEnabled = true;
            this.combo_behavior.Location = new System.Drawing.Point(311, 351);
            this.combo_behavior.Name = "combo_behavior";
            this.combo_behavior.Size = new System.Drawing.Size(108, 20);
            this.combo_behavior.TabIndex = 24;
            // 
            // picBox_wii
            // 
            this.picBox_wii.BackColor = System.Drawing.Color.Transparent;
            this.picBox_wii.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_wii.Enabled = false;
            this.picBox_wii.Image = global::wiizard.Properties.Resources.fig_wiimote;
            this.picBox_wii.InitialImage = global::wiizard.Properties.Resources.fig_wiimote;
            this.picBox_wii.Location = new System.Drawing.Point(10, 10);
            this.picBox_wii.Name = "picBox_wii";
            this.picBox_wii.Size = new System.Drawing.Size(468, 394);
            this.picBox_wii.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_wii.TabIndex = 1;
            this.picBox_wii.TabStop = false;
            // 
            // tabPage_advconfig
            // 
            this.tabPage_advconfig.BackColor = System.Drawing.Color.Transparent;
            this.tabPage_advconfig.Controls.Add(this.listBox_models);
            this.tabPage_advconfig.Controls.Add(this.btnDeleteAction);
            this.tabPage_advconfig.Controls.Add(this.num_delay);
            this.tabPage_advconfig.Controls.Add(this.check_inc);
            this.tabPage_advconfig.Controls.Add(this.num_value);
            this.tabPage_advconfig.Controls.Add(this.combo_modKey);
            this.tabPage_advconfig.Controls.Add(this.listBox_actions);
            this.tabPage_advconfig.Controls.Add(this.label21);
            this.tabPage_advconfig.Controls.Add(this.label17);
            this.tabPage_advconfig.Controls.Add(this.label18);
            this.tabPage_advconfig.Location = new System.Drawing.Point(4, 22);
            this.tabPage_advconfig.Name = "tabPage_advconfig";
            this.tabPage_advconfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_advconfig.Size = new System.Drawing.Size(494, 420);
            this.tabPage_advconfig.TabIndex = 2;
            this.tabPage_advconfig.Text = "詳細";
            // 
            // listBox_models
            // 
            this.listBox_models.FormattingEnabled = true;
            this.listBox_models.ItemHeight = 12;
            this.listBox_models.Location = new System.Drawing.Point(15, 24);
            this.listBox_models.Name = "listBox_models";
            this.listBox_models.Size = new System.Drawing.Size(88, 376);
            this.listBox_models.TabIndex = 28;
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Location = new System.Drawing.Point(274, 165);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(171, 26);
            this.btnDeleteAction.TabIndex = 23;
            this.btnDeleteAction.Text = "この動作を削除";
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            // 
            // num_delay
            // 
            this.num_delay.Location = new System.Drawing.Point(377, 86);
            this.num_delay.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.num_delay.Name = "num_delay";
            this.num_delay.Size = new System.Drawing.Size(79, 19);
            this.num_delay.TabIndex = 27;
            // 
            // check_inc
            // 
            this.check_inc.AutoSize = true;
            this.check_inc.Location = new System.Drawing.Point(274, 119);
            this.check_inc.Name = "check_inc";
            this.check_inc.Size = new System.Drawing.Size(92, 16);
            this.check_inc.TabIndex = 26;
            this.check_inc.Text = "インクリメンタル";
            this.check_inc.UseVisualStyleBackColor = true;
            // 
            // num_value
            // 
            this.num_value.Enabled = false;
            this.num_value.Location = new System.Drawing.Point(377, 61);
            this.num_value.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_value.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.num_value.Name = "num_value";
            this.num_value.Size = new System.Drawing.Size(79, 19);
            this.num_value.TabIndex = 25;
            // 
            // combo_modKey
            // 
            this.combo_modKey.DropDownWidth = 120;
            this.combo_modKey.Enabled = false;
            this.combo_modKey.FormattingEnabled = true;
            this.combo_modKey.Location = new System.Drawing.Point(377, 34);
            this.combo_modKey.Name = "combo_modKey";
            this.combo_modKey.Size = new System.Drawing.Size(79, 20);
            this.combo_modKey.TabIndex = 15;
            // 
            // listBox_actions
            // 
            this.listBox_actions.FormattingEnabled = true;
            this.listBox_actions.ItemHeight = 12;
            this.listBox_actions.Location = new System.Drawing.Point(109, 24);
            this.listBox_actions.Name = "listBox_actions";
            this.listBox_actions.Size = new System.Drawing.Size(144, 376);
            this.listBox_actions.TabIndex = 11;
            this.listBox_actions.SelectedIndexChanged += new System.EventHandler(this.listBox_actions_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(272, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(19, 12);
            this.label21.TabIndex = 9;
            this.label21.Text = "値:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(272, 37);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 12);
            this.label17.TabIndex = 6;
            this.label17.Text = "装飾キー:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(272, 88);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 12);
            this.label18.TabIndex = 7;
            this.label18.Text = "遅延(ms):";
            // 
            // panel_setJoystick
            // 
            this.panel_setJoystick.Controls.Add(this.radioBtn_JoyWASD);
            this.panel_setJoystick.Controls.Add(this.radioBtn_JoyMouse);
            this.panel_setJoystick.Controls.Add(this.radioBtn_JoyNone);
            this.panel_setJoystick.Location = new System.Drawing.Point(507, 85);
            this.panel_setJoystick.Name = "panel_setJoystick";
            this.panel_setJoystick.Size = new System.Drawing.Size(214, 217);
            this.panel_setJoystick.TabIndex = 25;
            // 
            // radioBtn_JoyWASD
            // 
            this.radioBtn_JoyWASD.AutoSize = true;
            this.radioBtn_JoyWASD.Location = new System.Drawing.Point(21, 32);
            this.radioBtn_JoyWASD.Name = "radioBtn_JoyWASD";
            this.radioBtn_JoyWASD.Size = new System.Drawing.Size(88, 16);
            this.radioBtn_JoyWASD.TabIndex = 25;
            this.radioBtn_JoyWASD.TabStop = true;
            this.radioBtn_JoyWASD.Text = "WASDに対応";
            this.radioBtn_JoyWASD.UseVisualStyleBackColor = true;
            // 
            // radioBtn_JoyMouse
            // 
            this.radioBtn_JoyMouse.AutoSize = true;
            this.radioBtn_JoyMouse.Location = new System.Drawing.Point(21, 97);
            this.radioBtn_JoyMouse.Name = "radioBtn_JoyMouse";
            this.radioBtn_JoyMouse.Size = new System.Drawing.Size(83, 16);
            this.radioBtn_JoyMouse.TabIndex = 27;
            this.radioBtn_JoyMouse.TabStop = true;
            this.radioBtn_JoyMouse.Text = "マウスに対応";
            this.radioBtn_JoyMouse.UseVisualStyleBackColor = true;
            // 
            // radioBtn_JoyNone
            // 
            this.radioBtn_JoyNone.AutoSize = true;
            this.radioBtn_JoyNone.Location = new System.Drawing.Point(21, 158);
            this.radioBtn_JoyNone.Name = "radioBtn_JoyNone";
            this.radioBtn_JoyNone.Size = new System.Drawing.Size(83, 16);
            this.radioBtn_JoyNone.TabIndex = 28;
            this.radioBtn_JoyNone.TabStop = true;
            this.radioBtn_JoyNone.Text = "割り当てなし";
            this.radioBtn_JoyNone.UseVisualStyleBackColor = true;
            // 
            // panel_setKeyMouse
            // 
            this.panel_setKeyMouse.Controls.Add(this.radioBtn_key);
            this.panel_setKeyMouse.Controls.Add(this.label16);
            this.panel_setKeyMouse.Controls.Add(this.combo_mouse);
            this.panel_setKeyMouse.Controls.Add(this.label20);
            this.panel_setKeyMouse.Controls.Add(this.combo_key);
            this.panel_setKeyMouse.Controls.Add(this.radioBtn_mouse);
            this.panel_setKeyMouse.Controls.Add(this.radioBtn_none);
            this.panel_setKeyMouse.Location = new System.Drawing.Point(507, 85);
            this.panel_setKeyMouse.Name = "panel_setKeyMouse";
            this.panel_setKeyMouse.Size = new System.Drawing.Size(214, 217);
            this.panel_setKeyMouse.TabIndex = 24;
            // 
            // radioBtn_key
            // 
            this.radioBtn_key.AutoSize = true;
            this.radioBtn_key.Location = new System.Drawing.Point(24, 26);
            this.radioBtn_key.Name = "radioBtn_key";
            this.radioBtn_key.Size = new System.Drawing.Size(72, 16);
            this.radioBtn_key.TabIndex = 18;
            this.radioBtn_key.TabStop = true;
            this.radioBtn_key.Text = "キーボード";
            this.radioBtn_key.UseVisualStyleBackColor = true;
            this.radioBtn_key.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 51);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 12);
            this.label16.TabIndex = 16;
            this.label16.Text = "キー:";
            // 
            // combo_mouse
            // 
            this.combo_mouse.DropDownWidth = 120;
            this.combo_mouse.Enabled = false;
            this.combo_mouse.FormattingEnabled = true;
            this.combo_mouse.Location = new System.Drawing.Point(117, 129);
            this.combo_mouse.Name = "combo_mouse";
            this.combo_mouse.Size = new System.Drawing.Size(79, 20);
            this.combo_mouse.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(53, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(31, 12);
            this.label20.TabIndex = 17;
            this.label20.Text = "動作:";
            // 
            // combo_key
            // 
            this.combo_key.DropDownWidth = 120;
            this.combo_key.Enabled = false;
            this.combo_key.FormattingEnabled = true;
            this.combo_key.Location = new System.Drawing.Point(117, 48);
            this.combo_key.Name = "combo_key";
            this.combo_key.Size = new System.Drawing.Size(79, 20);
            this.combo_key.TabIndex = 19;
            // 
            // radioBtn_mouse
            // 
            this.radioBtn_mouse.AutoSize = true;
            this.radioBtn_mouse.Location = new System.Drawing.Point(24, 106);
            this.radioBtn_mouse.Name = "radioBtn_mouse";
            this.radioBtn_mouse.Size = new System.Drawing.Size(50, 16);
            this.radioBtn_mouse.TabIndex = 20;
            this.radioBtn_mouse.TabStop = true;
            this.radioBtn_mouse.Text = "マウス";
            this.radioBtn_mouse.UseVisualStyleBackColor = true;
            this.radioBtn_mouse.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // radioBtn_none
            // 
            this.radioBtn_none.AutoSize = true;
            this.radioBtn_none.Location = new System.Drawing.Point(24, 180);
            this.radioBtn_none.Name = "radioBtn_none";
            this.radioBtn_none.Size = new System.Drawing.Size(83, 16);
            this.radioBtn_none.TabIndex = 21;
            this.radioBtn_none.TabStop = true;
            this.radioBtn_none.Text = "割り当てなし";
            this.radioBtn_none.UseVisualStyleBackColor = true;
            this.radioBtn_none.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // Profiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 528);
            this.Controls.Add(this.panel_profile);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Profiler";
            this.Text = "Wiizard Profiler";
            this.Load += new System.EventHandler(this.Profiler_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel_profile.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl_config.ResumeLayout(false);
            this.tabPage_buttons.ResumeLayout(false);
            this.panel_config_wiiimg.ResumeLayout(false);
            this.panel_config_wiiimg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_wii)).EndInit();
            this.tabPage_advconfig.ResumeLayout(false);
            this.tabPage_advconfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_delay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_value)).EndInit();
            this.panel_setJoystick.ResumeLayout(false);
            this.panel_setJoystick.PerformLayout();
            this.panel_setKeyMouse.ResumeLayout(false);
            this.panel_setKeyMouse.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem MenuItem_newProfile;
        private System.Windows.Forms.ToolStripMenuItem MenuItem_deleteProfile;
        private System.Windows.Forms.TabControl tabControl_config;
        private System.Windows.Forms.TabPage tabPage_buttons;
        private System.Windows.Forms.Panel panel_config_wiiimg;
        private System.Windows.Forms.PictureBox picBox_wii;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabPage_advconfig;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox listBox_actions;
        private System.Windows.Forms.CheckBox check_inc;
        private System.Windows.Forms.NumericUpDown num_value;
        private System.Windows.Forms.ComboBox combo_modKey;
        private System.Windows.Forms.NumericUpDown num_delay;
        private System.Windows.Forms.ComboBox combo_mouse;
        private System.Windows.Forms.ComboBox combo_key;
        private System.Windows.Forms.RadioButton radioBtn_none;
        private System.Windows.Forms.RadioButton radioBtn_mouse;
        private System.Windows.Forms.RadioButton radioBtn_key;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox combo_behavior;
        private System.Windows.Forms.ListBox listBox_models;
        private System.Windows.Forms.Panel panel_setJoystick;
        private System.Windows.Forms.Panel panel_setKeyMouse;
        private System.Windows.Forms.RadioButton radioBtn_JoyMouse;
        private System.Windows.Forms.RadioButton radioBtn_JoyNone;
        private System.Windows.Forms.RadioButton radioBtn_JoyWASD;
    }
}

