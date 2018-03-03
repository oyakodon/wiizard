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
            this.labNunchukAcc.Location = new System.Drawing.Point(276, 64);
            this.labNunchukAcc.Name = "labNunchukAcc";
            this.labNunchukAcc.Size = new System.Drawing.Size(35, 12);
            this.labNunchukAcc.TabIndex = 6;
            this.labNunchukAcc.Text = "0/0/0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(151, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Nunchuk Acc (XYZ) : ";
            // 
            // DebugInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 233);
            this.Controls.Add(this.labNunchukAcc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labAcc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labBattery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "DebugInfo";
            this.Text = "DebugInfo";
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
    }
}