namespace wiizard
{
    partial class DebugInfo
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labBattery = new System.Windows.Forms.Label();
            this.labAcc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labNunchukAcc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picBox_IrWindow = new System.Windows.Forms.PictureBox();
            this.labIrStat = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labIrCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_log = new System.Windows.Forms.ListBox();
            this.labNunchukStick = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_IrWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "+",
            "-",
            "Home",
            "1",
            "2",
            "Up",
            "Down",
            "Left",
            "Right",
            "Z",
            "C"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 200);
            this.checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Battery : ";
            // 
            // labBattery
            // 
            this.labBattery.AutoSize = true;
            this.labBattery.Location = new System.Drawing.Point(210, 190);
            this.labBattery.Name = "labBattery";
            this.labBattery.Size = new System.Drawing.Size(17, 12);
            this.labBattery.TabIndex = 2;
            this.labBattery.Text = "0%";
            // 
            // labAcc
            // 
            this.labAcc.AutoSize = true;
            this.labAcc.Location = new System.Drawing.Point(276, 25);
            this.labAcc.Name = "labAcc";
            this.labAcc.Size = new System.Drawing.Size(35, 12);
            this.labAcc.TabIndex = 4;
            this.labAcc.Text = "0/0/0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Wiimote Acc(XYZ) : ";
            // 
            // labNunchukAcc
            // 
            this.labNunchukAcc.AutoSize = true;
            this.labNunchukAcc.Location = new System.Drawing.Point(276, 53);
            this.labNunchukAcc.Name = "labNunchukAcc";
            this.labNunchukAcc.Size = new System.Drawing.Size(35, 12);
            this.labNunchukAcc.TabIndex = 6;
            this.labNunchukAcc.Text = "0/0/0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nunchuk Acc (XYZ) : ";
            // 
            // picBox_IrWindow
            // 
            this.picBox_IrWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox_IrWindow.Location = new System.Drawing.Point(437, 12);
            this.picBox_IrWindow.Name = "picBox_IrWindow";
            this.picBox_IrWindow.Size = new System.Drawing.Size(200, 200);
            this.picBox_IrWindow.TabIndex = 7;
            this.picBox_IrWindow.TabStop = false;
            // 
            // labIrStat
            // 
            this.labIrStat.AutoSize = true;
            this.labIrStat.Location = new System.Drawing.Point(210, 124);
            this.labIrStat.Name = "labIrStat";
            this.labIrStat.Size = new System.Drawing.Size(71, 12);
            this.labIrStat.TabIndex = 9;
            this.labIrStat.Text = "Not detected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "IR : ";
            // 
            // labIrCount
            // 
            this.labIrCount.AutoSize = true;
            this.labIrCount.Location = new System.Drawing.Point(210, 146);
            this.labIrCount.Name = "labIrCount";
            this.labIrCount.Size = new System.Drawing.Size(11, 12);
            this.labIrCount.TabIndex = 11;
            this.labIrCount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(151, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "IR Count : ";
            // 
            // listBox_log
            // 
            this.listBox_log.FormattingEnabled = true;
            this.listBox_log.HorizontalScrollbar = true;
            this.listBox_log.ItemHeight = 12;
            this.listBox_log.Location = new System.Drawing.Point(12, 218);
            this.listBox_log.Name = "listBox_log";
            this.listBox_log.Size = new System.Drawing.Size(625, 100);
            this.listBox_log.TabIndex = 12;
            // 
            // labNunchukStick
            // 
            this.labNunchukStick.AutoSize = true;
            this.labNunchukStick.Location = new System.Drawing.Point(296, 79);
            this.labNunchukStick.Name = "labNunchukStick";
            this.labNunchukStick.Size = new System.Drawing.Size(23, 12);
            this.labNunchukStick.TabIndex = 14;
            this.labNunchukStick.Text = "0/0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nunchuk Joystick (X/Y) : ";
            // 
            // DebugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 325);
            this.Controls.Add(this.labNunchukStick);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listBox_log);
            this.Controls.Add(this.labIrCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labIrStat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picBox_IrWindow);
            this.Controls.Add(this.labNunchukAcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labAcc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labBattery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DebugInfo";
            this.Text = "DebugInfo";
            ((System.ComponentModel.ISupportInitialize)(this.picBox_IrWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labBattery;
        private System.Windows.Forms.Label labAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labNunchukAcc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBox_IrWindow;
        private System.Windows.Forms.Label labIrStat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labIrCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_log;
        private System.Windows.Forms.Label labNunchukStick;
        private System.Windows.Forms.Label label6;
    }
}