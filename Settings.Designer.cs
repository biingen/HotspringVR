namespace Hotspring
{
    partial class Settings
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
            this.groupBox_serialPort2 = new System.Windows.Forms.GroupBox();
            this.radioButton_HP34401A = new System.Windows.Forms.RadioButton();
            this.radioButton_fluke45 = new System.Windows.Forms.RadioButton();
            this.comboBox_serialPort2_baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_serialPort2_portname = new System.Windows.Forms.ComboBox();
            this.label_serialPort2_baudrate = new System.Windows.Forms.Label();
            this.label_serialPort2_portname = new System.Windows.Forms.Label();
            this.groupBox_serialPort1 = new System.Windows.Forms.GroupBox();
            this.serialPort1_enable = new System.Windows.Forms.CheckBox();
            this.comboBox_serialPort1_baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_serialPort1_portname = new System.Windows.Forms.ComboBox();
            this.label_serialPort1_baudrate = new System.Windows.Forms.Label();
            this.label_serialPort1_portname = new System.Windows.Forms.Label();
            this.label_serialPort_status = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.groupBox_serialPort2.SuspendLayout();
            this.groupBox_serialPort1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_serialPort2
            // 
            this.groupBox_serialPort2.Controls.Add(this.radioButton_HP34401A);
            this.groupBox_serialPort2.Controls.Add(this.radioButton_fluke45);
            this.groupBox_serialPort2.Controls.Add(this.comboBox_serialPort2_baudrate);
            this.groupBox_serialPort2.Controls.Add(this.comboBox_serialPort2_portname);
            this.groupBox_serialPort2.Controls.Add(this.label_serialPort2_baudrate);
            this.groupBox_serialPort2.Controls.Add(this.label_serialPort2_portname);
            this.groupBox_serialPort2.Location = new System.Drawing.Point(10, 160);
            this.groupBox_serialPort2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_serialPort2.Name = "groupBox_serialPort2";
            this.groupBox_serialPort2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_serialPort2.Size = new System.Drawing.Size(198, 119);
            this.groupBox_serialPort2.TabIndex = 9;
            this.groupBox_serialPort2.TabStop = false;
            this.groupBox_serialPort2.Text = "Resistance measurement";
            // 
            // radioButton_HP34401A
            // 
            this.radioButton_HP34401A.AutoSize = true;
            this.radioButton_HP34401A.Location = new System.Drawing.Point(109, 26);
            this.radioButton_HP34401A.Name = "radioButton_HP34401A";
            this.radioButton_HP34401A.Size = new System.Drawing.Size(78, 16);
            this.radioButton_HP34401A.TabIndex = 8;
            this.radioButton_HP34401A.TabStop = true;
            this.radioButton_HP34401A.Text = "HP 34401A";
            this.radioButton_HP34401A.UseVisualStyleBackColor = true;
            this.radioButton_HP34401A.CheckedChanged += new System.EventHandler(this.radioButton_HP34401A_CheckedChanged);
            // 
            // radioButton_fluke45
            // 
            this.radioButton_fluke45.AutoSize = true;
            this.radioButton_fluke45.Location = new System.Drawing.Point(18, 26);
            this.radioButton_fluke45.Name = "radioButton_fluke45";
            this.radioButton_fluke45.Size = new System.Drawing.Size(64, 16);
            this.radioButton_fluke45.TabIndex = 7;
            this.radioButton_fluke45.TabStop = true;
            this.radioButton_fluke45.Text = "Fluke 45";
            this.radioButton_fluke45.UseVisualStyleBackColor = true;
            this.radioButton_fluke45.CheckedChanged += new System.EventHandler(this.radioButton_fluke45_CheckedChanged);
            // 
            // comboBox_serialPort2_baudrate
            // 
            this.comboBox_serialPort2_baudrate.FormattingEnabled = true;
            this.comboBox_serialPort2_baudrate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBox_serialPort2_baudrate.Location = new System.Drawing.Point(87, 86);
            this.comboBox_serialPort2_baudrate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_serialPort2_baudrate.Name = "comboBox_serialPort2_baudrate";
            this.comboBox_serialPort2_baudrate.Size = new System.Drawing.Size(100, 20);
            this.comboBox_serialPort2_baudrate.TabIndex = 5;
            this.comboBox_serialPort2_baudrate.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox_serialPort2_portname
            // 
            this.comboBox_serialPort2_portname.FormattingEnabled = true;
            this.comboBox_serialPort2_portname.Location = new System.Drawing.Point(87, 54);
            this.comboBox_serialPort2_portname.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_serialPort2_portname.Name = "comboBox_serialPort2_portname";
            this.comboBox_serialPort2_portname.Size = new System.Drawing.Size(100, 20);
            this.comboBox_serialPort2_portname.TabIndex = 4;
            this.comboBox_serialPort2_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label_serialPort2_baudrate
            // 
            this.label_serialPort2_baudrate.AutoSize = true;
            this.label_serialPort2_baudrate.Location = new System.Drawing.Point(16, 89);
            this.label_serialPort2_baudrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serialPort2_baudrate.Name = "label_serialPort2_baudrate";
            this.label_serialPort2_baudrate.Size = new System.Drawing.Size(50, 12);
            this.label_serialPort2_baudrate.TabIndex = 3;
            this.label_serialPort2_baudrate.Text = "Baudrate:";
            // 
            // label_serialPort2_portname
            // 
            this.label_serialPort2_portname.AutoSize = true;
            this.label_serialPort2_portname.Location = new System.Drawing.Point(14, 57);
            this.label_serialPort2_portname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serialPort2_portname.Name = "label_serialPort2_portname";
            this.label_serialPort2_portname.Size = new System.Drawing.Size(52, 12);
            this.label_serialPort2_portname.TabIndex = 2;
            this.label_serialPort2_portname.Text = "Portname:";
            // 
            // groupBox_serialPort1
            // 
            this.groupBox_serialPort1.Controls.Add(this.button_refresh);
            this.groupBox_serialPort1.Controls.Add(this.serialPort1_enable);
            this.groupBox_serialPort1.Controls.Add(this.comboBox_serialPort1_baudrate);
            this.groupBox_serialPort1.Controls.Add(this.comboBox_serialPort1_portname);
            this.groupBox_serialPort1.Controls.Add(this.label_serialPort1_baudrate);
            this.groupBox_serialPort1.Controls.Add(this.label_serialPort1_portname);
            this.groupBox_serialPort1.Location = new System.Drawing.Point(10, 33);
            this.groupBox_serialPort1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_serialPort1.Name = "groupBox_serialPort1";
            this.groupBox_serialPort1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_serialPort1.Size = new System.Drawing.Size(198, 119);
            this.groupBox_serialPort1.TabIndex = 8;
            this.groupBox_serialPort1.TabStop = false;
            this.groupBox_serialPort1.Text = "Hotspring board";
            // 
            // serialPort1_enable
            // 
            this.serialPort1_enable.AutoSize = true;
            this.serialPort1_enable.Location = new System.Drawing.Point(13, 26);
            this.serialPort1_enable.Margin = new System.Windows.Forms.Padding(4);
            this.serialPort1_enable.Name = "serialPort1_enable";
            this.serialPort1_enable.Size = new System.Drawing.Size(56, 16);
            this.serialPort1_enable.TabIndex = 6;
            this.serialPort1_enable.Text = "Enable";
            this.serialPort1_enable.UseVisualStyleBackColor = true;
            this.serialPort1_enable.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox_serialPort1_baudrate
            // 
            this.comboBox_serialPort1_baudrate.FormattingEnabled = true;
            this.comboBox_serialPort1_baudrate.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBox_serialPort1_baudrate.Location = new System.Drawing.Point(84, 86);
            this.comboBox_serialPort1_baudrate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_serialPort1_baudrate.Name = "comboBox_serialPort1_baudrate";
            this.comboBox_serialPort1_baudrate.Size = new System.Drawing.Size(103, 20);
            this.comboBox_serialPort1_baudrate.TabIndex = 5;
            this.comboBox_serialPort1_baudrate.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox_serialPort1_portname
            // 
            this.comboBox_serialPort1_portname.FormattingEnabled = true;
            this.comboBox_serialPort1_portname.Location = new System.Drawing.Point(84, 53);
            this.comboBox_serialPort1_portname.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_serialPort1_portname.Name = "comboBox_serialPort1_portname";
            this.comboBox_serialPort1_portname.Size = new System.Drawing.Size(103, 20);
            this.comboBox_serialPort1_portname.TabIndex = 4;
            this.comboBox_serialPort1_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label_serialPort1_baudrate
            // 
            this.label_serialPort1_baudrate.AutoSize = true;
            this.label_serialPort1_baudrate.Location = new System.Drawing.Point(13, 88);
            this.label_serialPort1_baudrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serialPort1_baudrate.Name = "label_serialPort1_baudrate";
            this.label_serialPort1_baudrate.Size = new System.Drawing.Size(50, 12);
            this.label_serialPort1_baudrate.TabIndex = 3;
            this.label_serialPort1_baudrate.Text = "Baudrate:";
            // 
            // label_serialPort1_portname
            // 
            this.label_serialPort1_portname.AutoSize = true;
            this.label_serialPort1_portname.Location = new System.Drawing.Point(10, 56);
            this.label_serialPort1_portname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serialPort1_portname.Name = "label_serialPort1_portname";
            this.label_serialPort1_portname.Size = new System.Drawing.Size(52, 12);
            this.label_serialPort1_portname.TabIndex = 2;
            this.label_serialPort1_portname.Text = "Portname:";
            // 
            // label_serialPort_status
            // 
            this.label_serialPort_status.AutoSize = true;
            this.label_serialPort_status.Location = new System.Drawing.Point(13, 13);
            this.label_serialPort_status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_serialPort_status.Name = "label_serialPort_status";
            this.label_serialPort_status.Size = new System.Drawing.Size(75, 12);
            this.label_serialPort_status.TabIndex = 67;
            this.label_serialPort_status.Text = "Comport status";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(112, 17);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 29);
            this.button_refresh.TabIndex = 68;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 286);
            this.Controls.Add(this.label_serialPort_status);
            this.Controls.Add(this.groupBox_serialPort2);
            this.Controls.Add(this.groupBox_serialPort1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox_serialPort2.ResumeLayout(false);
            this.groupBox_serialPort2.PerformLayout();
            this.groupBox_serialPort1.ResumeLayout(false);
            this.groupBox_serialPort1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_serialPort2;
        private System.Windows.Forms.ComboBox comboBox_serialPort2_baudrate;
        private System.Windows.Forms.ComboBox comboBox_serialPort2_portname;
        private System.Windows.Forms.Label label_serialPort2_baudrate;
        private System.Windows.Forms.Label label_serialPort2_portname;
        private System.Windows.Forms.GroupBox groupBox_serialPort1;
        private System.Windows.Forms.CheckBox serialPort1_enable;
        private System.Windows.Forms.ComboBox comboBox_serialPort1_baudrate;
        private System.Windows.Forms.ComboBox comboBox_serialPort1_portname;
        private System.Windows.Forms.Label label_serialPort1_baudrate;
        private System.Windows.Forms.Label label_serialPort1_portname;
        private System.Windows.Forms.Label label_serialPort_status;
        private System.Windows.Forms.RadioButton radioButton_HP34401A;
        private System.Windows.Forms.RadioButton radioButton_fluke45;
        private System.Windows.Forms.Button button_refresh;
    }
}