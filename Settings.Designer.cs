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
            this.serialPort2_enable = new System.Windows.Forms.CheckBox();
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
            this.checkBox_power = new System.Windows.Forms.CheckBox();
            this.groupBox_serialPort2.SuspendLayout();
            this.groupBox_serialPort1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_serialPort2
            // 
            this.groupBox_serialPort2.Controls.Add(this.serialPort2_enable);
            this.groupBox_serialPort2.Controls.Add(this.comboBox_serialPort2_baudrate);
            this.groupBox_serialPort2.Controls.Add(this.comboBox_serialPort2_portname);
            this.groupBox_serialPort2.Controls.Add(this.label_serialPort2_baudrate);
            this.groupBox_serialPort2.Controls.Add(this.label_serialPort2_portname);
            this.groupBox_serialPort2.Location = new System.Drawing.Point(363, 41);
            this.groupBox_serialPort2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox_serialPort2.Name = "groupBox_serialPort2";
            this.groupBox_serialPort2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox_serialPort2.Size = new System.Drawing.Size(340, 149);
            this.groupBox_serialPort2.TabIndex = 9;
            this.groupBox_serialPort2.TabStop = false;
            this.groupBox_serialPort2.Text = "Fluke 45 Multi-meter";
            // 
            // serialPort2_enable
            // 
            this.serialPort2_enable.AutoSize = true;
            this.serialPort2_enable.Location = new System.Drawing.Point(17, 32);
            this.serialPort2_enable.Margin = new System.Windows.Forms.Padding(5);
            this.serialPort2_enable.Name = "serialPort2_enable";
            this.serialPort2_enable.Size = new System.Drawing.Size(68, 19);
            this.serialPort2_enable.TabIndex = 6;
            this.serialPort2_enable.Text = "Enable";
            this.serialPort2_enable.UseVisualStyleBackColor = true;
            this.serialPort2_enable.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
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
            this.comboBox_serialPort2_baudrate.Location = new System.Drawing.Point(108, 108);
            this.comboBox_serialPort2_baudrate.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_serialPort2_baudrate.Name = "comboBox_serialPort2_baudrate";
            this.comboBox_serialPort2_baudrate.Size = new System.Drawing.Size(212, 23);
            this.comboBox_serialPort2_baudrate.TabIndex = 5;
            this.comboBox_serialPort2_baudrate.SelectedIndexChanged += new System.EventHandler(this.comboBox4_SelectedIndexChanged);
            // 
            // comboBox_serialPort2_portname
            // 
            this.comboBox_serialPort2_portname.FormattingEnabled = true;
            this.comboBox_serialPort2_portname.Location = new System.Drawing.Point(108, 68);
            this.comboBox_serialPort2_portname.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_serialPort2_portname.Name = "comboBox_serialPort2_portname";
            this.comboBox_serialPort2_portname.Size = new System.Drawing.Size(212, 23);
            this.comboBox_serialPort2_portname.TabIndex = 4;
            this.comboBox_serialPort2_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // label_serialPort2_baudrate
            // 
            this.label_serialPort2_baudrate.AutoSize = true;
            this.label_serialPort2_baudrate.Location = new System.Drawing.Point(13, 111);
            this.label_serialPort2_baudrate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_serialPort2_baudrate.Name = "label_serialPort2_baudrate";
            this.label_serialPort2_baudrate.Size = new System.Drawing.Size(61, 15);
            this.label_serialPort2_baudrate.TabIndex = 3;
            this.label_serialPort2_baudrate.Text = "Baudrate:";
            // 
            // label_serialPort2_portname
            // 
            this.label_serialPort2_portname.AutoSize = true;
            this.label_serialPort2_portname.Location = new System.Drawing.Point(11, 71);
            this.label_serialPort2_portname.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_serialPort2_portname.Name = "label_serialPort2_portname";
            this.label_serialPort2_portname.Size = new System.Drawing.Size(65, 15);
            this.label_serialPort2_portname.TabIndex = 2;
            this.label_serialPort2_portname.Text = "Portname:";
            // 
            // groupBox_serialPort1
            // 
            this.groupBox_serialPort1.Controls.Add(this.serialPort1_enable);
            this.groupBox_serialPort1.Controls.Add(this.comboBox_serialPort1_baudrate);
            this.groupBox_serialPort1.Controls.Add(this.comboBox_serialPort1_portname);
            this.groupBox_serialPort1.Controls.Add(this.label_serialPort1_baudrate);
            this.groupBox_serialPort1.Controls.Add(this.label_serialPort1_portname);
            this.groupBox_serialPort1.Location = new System.Drawing.Point(13, 41);
            this.groupBox_serialPort1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox_serialPort1.Name = "groupBox_serialPort1";
            this.groupBox_serialPort1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox_serialPort1.Size = new System.Drawing.Size(340, 149);
            this.groupBox_serialPort1.TabIndex = 8;
            this.groupBox_serialPort1.TabStop = false;
            this.groupBox_serialPort1.Text = "Hotspring Board";
            // 
            // serialPort1_enable
            // 
            this.serialPort1_enable.AutoSize = true;
            this.serialPort1_enable.Location = new System.Drawing.Point(17, 32);
            this.serialPort1_enable.Margin = new System.Windows.Forms.Padding(5);
            this.serialPort1_enable.Name = "serialPort1_enable";
            this.serialPort1_enable.Size = new System.Drawing.Size(68, 19);
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
            this.comboBox_serialPort1_baudrate.Location = new System.Drawing.Point(112, 108);
            this.comboBox_serialPort1_baudrate.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_serialPort1_baudrate.Name = "comboBox_serialPort1_baudrate";
            this.comboBox_serialPort1_baudrate.Size = new System.Drawing.Size(212, 23);
            this.comboBox_serialPort1_baudrate.TabIndex = 5;
            this.comboBox_serialPort1_baudrate.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox_serialPort1_portname
            // 
            this.comboBox_serialPort1_portname.FormattingEnabled = true;
            this.comboBox_serialPort1_portname.Location = new System.Drawing.Point(112, 66);
            this.comboBox_serialPort1_portname.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox_serialPort1_portname.Name = "comboBox_serialPort1_portname";
            this.comboBox_serialPort1_portname.Size = new System.Drawing.Size(212, 23);
            this.comboBox_serialPort1_portname.TabIndex = 4;
            this.comboBox_serialPort1_portname.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label_serialPort1_baudrate
            // 
            this.label_serialPort1_baudrate.AutoSize = true;
            this.label_serialPort1_baudrate.Location = new System.Drawing.Point(17, 110);
            this.label_serialPort1_baudrate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_serialPort1_baudrate.Name = "label_serialPort1_baudrate";
            this.label_serialPort1_baudrate.Size = new System.Drawing.Size(61, 15);
            this.label_serialPort1_baudrate.TabIndex = 3;
            this.label_serialPort1_baudrate.Text = "Baudrate:";
            // 
            // label_serialPort1_portname
            // 
            this.label_serialPort1_portname.AutoSize = true;
            this.label_serialPort1_portname.Location = new System.Drawing.Point(13, 70);
            this.label_serialPort1_portname.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_serialPort1_portname.Name = "label_serialPort1_portname";
            this.label_serialPort1_portname.Size = new System.Drawing.Size(65, 15);
            this.label_serialPort1_portname.TabIndex = 2;
            this.label_serialPort1_portname.Text = "Portname:";
            // 
            // label_serialPort_status
            // 
            this.label_serialPort_status.AutoSize = true;
            this.label_serialPort_status.Location = new System.Drawing.Point(17, 16);
            this.label_serialPort_status.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_serialPort_status.Name = "label_serialPort_status";
            this.label_serialPort_status.Size = new System.Drawing.Size(92, 15);
            this.label_serialPort_status.TabIndex = 67;
            this.label_serialPort_status.Text = "Comport status";
            // 
            // checkBox_power
            // 
            this.checkBox_power.AutoSize = true;
            this.checkBox_power.Location = new System.Drawing.Point(379, 12);
            this.checkBox_power.Margin = new System.Windows.Forms.Padding(5);
            this.checkBox_power.Name = "checkBox_power";
            this.checkBox_power.Size = new System.Drawing.Size(65, 19);
            this.checkBox_power.TabIndex = 7;
            this.checkBox_power.Text = "Power";
            this.checkBox_power.UseVisualStyleBackColor = true;
            this.checkBox_power.CheckedChanged += new System.EventHandler(this.checkBox_power_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 201);
            this.Controls.Add(this.checkBox_power);
            this.Controls.Add(this.label_serialPort_status);
            this.Controls.Add(this.groupBox_serialPort2);
            this.Controls.Add(this.groupBox_serialPort1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.CheckBox serialPort2_enable;
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
        private System.Windows.Forms.CheckBox checkBox_power;
    }
}