namespace Hotspring
{
    partial class Selftest
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.checkBox_RC = new System.Windows.Forms.CheckBox();
            this.checkBox_RB = new System.Windows.Forms.CheckBox();
            this.checkBox_RA = new System.Windows.Forms.CheckBox();
            this.textBox_resistance = new System.Windows.Forms.TextBox();
            this.label_resistance = new System.Windows.Forms.Label();
            this.button_6b595_get = new System.Windows.Forms.Button();
            this.label_6b595_result = new System.Windows.Forms.Label();
            this.textBox_usb = new System.Windows.Forms.TextBox();
            this.button_echo_status = new System.Windows.Forms.Button();
            this.pictureBox_blue = new System.Windows.Forms.PictureBox();
            this.pictureBox_green = new System.Windows.Forms.PictureBox();
            this.pictureBox_yellow = new System.Windows.Forms.PictureBox();
            this.pictureBox_red = new System.Windows.Forms.PictureBox();
            this.groupBox_6B595 = new System.Windows.Forms.GroupBox();
            this.checkBox_6b595 = new System.Windows.Forms.CheckBox();
            this.groupBox_button = new System.Windows.Forms.GroupBox();
            this.checkBox_button = new System.Windows.Forms.CheckBox();
            this.groupBox_usb = new System.Windows.Forms.GroupBox();
            this.checkBox_usb = new System.Windows.Forms.CheckBox();
            this.groupBox_prime = new System.Windows.Forms.GroupBox();
            this.radioButton_power_step = new System.Windows.Forms.RadioButton();
            this.radioButton_prime = new System.Windows.Forms.RadioButton();
            this.radioButton_power10 = new System.Windows.Forms.RadioButton();
            this.radioButton_power2 = new System.Windows.Forms.RadioButton();
            this.button_test1 = new System.Windows.Forms.Button();
            this.label_voltage = new System.Windows.Forms.Label();
            this.button_voltage = new System.Windows.Forms.Button();
            this.groupBox_voltage = new System.Windows.Forms.GroupBox();
            this.checkBox_voltage = new System.Windows.Forms.CheckBox();
            this.groupBox_stressbox = new System.Windows.Forms.GroupBox();
            this.button_test2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_red)).BeginInit();
            this.groupBox_6B595.SuspendLayout();
            this.groupBox_button.SuspendLayout();
            this.groupBox_usb.SuspendLayout();
            this.groupBox_prime.SuspendLayout();
            this.groupBox_voltage.SuspendLayout();
            this.groupBox_stressbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_RC
            // 
            this.checkBox_RC.AutoSize = true;
            this.checkBox_RC.Location = new System.Drawing.Point(117, 21);
            this.checkBox_RC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RC.Name = "checkBox_RC";
            this.checkBox_RC.Size = new System.Drawing.Size(47, 19);
            this.checkBox_RC.TabIndex = 13;
            this.checkBox_RC.Text = "RC";
            this.checkBox_RC.UseVisualStyleBackColor = true;
            this.checkBox_RC.CheckedChanged += new System.EventHandler(this.checkBox_RC_CheckedChanged);
            // 
            // checkBox_RB
            // 
            this.checkBox_RB.AutoSize = true;
            this.checkBox_RB.Location = new System.Drawing.Point(64, 21);
            this.checkBox_RB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RB.Name = "checkBox_RB";
            this.checkBox_RB.Size = new System.Drawing.Size(47, 19);
            this.checkBox_RB.TabIndex = 12;
            this.checkBox_RB.Text = "RB";
            this.checkBox_RB.UseVisualStyleBackColor = true;
            this.checkBox_RB.CheckedChanged += new System.EventHandler(this.checkBox_RB_CheckedChanged);
            // 
            // checkBox_RA
            // 
            this.checkBox_RA.AutoSize = true;
            this.checkBox_RA.Location = new System.Drawing.Point(9, 21);
            this.checkBox_RA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RA.Name = "checkBox_RA";
            this.checkBox_RA.Size = new System.Drawing.Size(48, 19);
            this.checkBox_RA.TabIndex = 11;
            this.checkBox_RA.Text = "RA";
            this.checkBox_RA.UseVisualStyleBackColor = true;
            this.checkBox_RA.CheckedChanged += new System.EventHandler(this.checkBox_RA_CheckedChanged);
            // 
            // textBox_resistance
            // 
            this.textBox_resistance.Location = new System.Drawing.Point(276, 45);
            this.textBox_resistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_resistance.Name = "textBox_resistance";
            this.textBox_resistance.Size = new System.Drawing.Size(63, 25);
            this.textBox_resistance.TabIndex = 23;
            this.textBox_resistance.Text = "0.2";
            this.textBox_resistance.TextChanged += new System.EventHandler(this.textBox_resistance_TextChanged);
            // 
            // label_resistance
            // 
            this.label_resistance.AutoSize = true;
            this.label_resistance.Location = new System.Drawing.Point(197, 49);
            this.label_resistance.Name = "label_resistance";
            this.label_resistance.Size = new System.Drawing.Size(73, 15);
            this.label_resistance.TabIndex = 22;
            this.label_resistance.Text = "Resistance: ";
            // 
            // button_6b595_get
            // 
            this.button_6b595_get.Location = new System.Drawing.Point(91, 14);
            this.button_6b595_get.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_6b595_get.Name = "button_6b595_get";
            this.button_6b595_get.Size = new System.Drawing.Size(68, 24);
            this.button_6b595_get.TabIndex = 28;
            this.button_6b595_get.Text = "Get";
            this.button_6b595_get.UseVisualStyleBackColor = true;
            this.button_6b595_get.Click += new System.EventHandler(this.button_6b595_get_Click);
            // 
            // label_6b595_result
            // 
            this.label_6b595_result.AutoSize = true;
            this.label_6b595_result.Location = new System.Drawing.Point(169, 12);
            this.label_6b595_result.Name = "label_6b595_result";
            this.label_6b595_result.Size = new System.Drawing.Size(44, 15);
            this.label_6b595_result.TabIndex = 31;
            this.label_6b595_result.Text = "6B595";
            // 
            // textBox_usb
            // 
            this.textBox_usb.Location = new System.Drawing.Point(75, 15);
            this.textBox_usb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_usb.Name = "textBox_usb";
            this.textBox_usb.Size = new System.Drawing.Size(63, 25);
            this.textBox_usb.TabIndex = 32;
            this.textBox_usb.Text = "100";
            this.textBox_usb.TextChanged += new System.EventHandler(this.textBox_usb_TextChanged);
            // 
            // button_echo_status
            // 
            this.button_echo_status.Location = new System.Drawing.Point(308, 18);
            this.button_echo_status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_echo_status.Name = "button_echo_status";
            this.button_echo_status.Size = new System.Drawing.Size(75, 22);
            this.button_echo_status.TabIndex = 33;
            this.button_echo_status.Text = "Echo";
            this.button_echo_status.UseVisualStyleBackColor = true;
            this.button_echo_status.Visible = false;
            this.button_echo_status.Click += new System.EventHandler(this.button_echo_status_Click);
            // 
            // pictureBox_blue
            // 
            this.pictureBox_blue.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_blue.Location = new System.Drawing.Point(89, 18);
            this.pictureBox_blue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_blue.Name = "pictureBox_blue";
            this.pictureBox_blue.Size = new System.Drawing.Size(64, 60);
            this.pictureBox_blue.TabIndex = 34;
            this.pictureBox_blue.TabStop = false;
            // 
            // pictureBox_green
            // 
            this.pictureBox_green.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_green.Location = new System.Drawing.Point(163, 18);
            this.pictureBox_green.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_green.Name = "pictureBox_green";
            this.pictureBox_green.Size = new System.Drawing.Size(64, 60);
            this.pictureBox_green.TabIndex = 35;
            this.pictureBox_green.TabStop = false;
            // 
            // pictureBox_yellow
            // 
            this.pictureBox_yellow.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_yellow.Location = new System.Drawing.Point(235, 18);
            this.pictureBox_yellow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_yellow.Name = "pictureBox_yellow";
            this.pictureBox_yellow.Size = new System.Drawing.Size(64, 60);
            this.pictureBox_yellow.TabIndex = 36;
            this.pictureBox_yellow.TabStop = false;
            // 
            // pictureBox_red
            // 
            this.pictureBox_red.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_red.Location = new System.Drawing.Point(307, 18);
            this.pictureBox_red.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_red.Name = "pictureBox_red";
            this.pictureBox_red.Size = new System.Drawing.Size(64, 60);
            this.pictureBox_red.TabIndex = 37;
            this.pictureBox_red.TabStop = false;
            // 
            // groupBox_6B595
            // 
            this.groupBox_6B595.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_6B595.Controls.Add(this.checkBox_6b595);
            this.groupBox_6B595.Controls.Add(this.label_6b595_result);
            this.groupBox_6B595.Controls.Add(this.button_6b595_get);
            this.groupBox_6B595.Controls.Add(this.button_echo_status);
            this.groupBox_6B595.Location = new System.Drawing.Point(21, 119);
            this.groupBox_6B595.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_6B595.Name = "groupBox_6B595";
            this.groupBox_6B595.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_6B595.Size = new System.Drawing.Size(388, 45);
            this.groupBox_6B595.TabIndex = 39;
            this.groupBox_6B595.TabStop = false;
            this.groupBox_6B595.Text = "TPIC6B595";
            // 
            // checkBox_6b595
            // 
            this.checkBox_6b595.AutoSize = true;
            this.checkBox_6b595.Location = new System.Drawing.Point(11, 18);
            this.checkBox_6b595.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_6b595.Name = "checkBox_6b595";
            this.checkBox_6b595.Size = new System.Drawing.Size(66, 19);
            this.checkBox_6b595.TabIndex = 31;
            this.checkBox_6b595.Text = "6B595";
            this.checkBox_6b595.UseVisualStyleBackColor = true;
            this.checkBox_6b595.CheckedChanged += new System.EventHandler(this.checkBox_6b595_CheckedChanged);
            // 
            // groupBox_button
            // 
            this.groupBox_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_button.Controls.Add(this.checkBox_button);
            this.groupBox_button.Controls.Add(this.pictureBox_red);
            this.groupBox_button.Controls.Add(this.pictureBox_blue);
            this.groupBox_button.Controls.Add(this.pictureBox_green);
            this.groupBox_button.Controls.Add(this.pictureBox_yellow);
            this.groupBox_button.Location = new System.Drawing.Point(23, 171);
            this.groupBox_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_button.Name = "groupBox_button";
            this.groupBox_button.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_button.Size = new System.Drawing.Size(387, 88);
            this.groupBox_button.TabIndex = 40;
            this.groupBox_button.TabStop = false;
            this.groupBox_button.Text = "Button";
            // 
            // checkBox_button
            // 
            this.checkBox_button.AutoSize = true;
            this.checkBox_button.Location = new System.Drawing.Point(7, 20);
            this.checkBox_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_button.Name = "checkBox_button";
            this.checkBox_button.Size = new System.Drawing.Size(67, 19);
            this.checkBox_button.TabIndex = 32;
            this.checkBox_button.Text = "Button";
            this.checkBox_button.UseVisualStyleBackColor = true;
            this.checkBox_button.CheckedChanged += new System.EventHandler(this.checkBox_button_CheckedChanged);
            // 
            // groupBox_usb
            // 
            this.groupBox_usb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_usb.Controls.Add(this.checkBox_usb);
            this.groupBox_usb.Controls.Add(this.textBox_usb);
            this.groupBox_usb.Location = new System.Drawing.Point(257, 266);
            this.groupBox_usb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_usb.Name = "groupBox_usb";
            this.groupBox_usb.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_usb.Size = new System.Drawing.Size(152, 46);
            this.groupBox_usb.TabIndex = 41;
            this.groupBox_usb.TabStop = false;
            this.groupBox_usb.Text = "USB";
            // 
            // checkBox_usb
            // 
            this.checkBox_usb.AutoSize = true;
            this.checkBox_usb.Location = new System.Drawing.Point(7, 19);
            this.checkBox_usb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_usb.Name = "checkBox_usb";
            this.checkBox_usb.Size = new System.Drawing.Size(56, 19);
            this.checkBox_usb.TabIndex = 45;
            this.checkBox_usb.Text = "USB";
            this.checkBox_usb.UseVisualStyleBackColor = true;
            this.checkBox_usb.CheckedChanged += new System.EventHandler(this.checkBox_usb_CheckedChanged);
            // 
            // groupBox_prime
            // 
            this.groupBox_prime.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox_prime.Controls.Add(this.radioButton_power_step);
            this.groupBox_prime.Controls.Add(this.radioButton_prime);
            this.groupBox_prime.Controls.Add(this.radioButton_power10);
            this.groupBox_prime.Controls.Add(this.radioButton_power2);
            this.groupBox_prime.Controls.Add(this.button_test1);
            this.groupBox_prime.Controls.Add(this.label_resistance);
            this.groupBox_prime.Controls.Add(this.textBox_resistance);
            this.groupBox_prime.Controls.Add(this.checkBox_RB);
            this.groupBox_prime.Controls.Add(this.checkBox_RC);
            this.groupBox_prime.Controls.Add(this.checkBox_RA);
            this.groupBox_prime.Location = new System.Drawing.Point(5, 6);
            this.groupBox_prime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_prime.Name = "groupBox_prime";
            this.groupBox_prime.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_prime.Size = new System.Drawing.Size(415, 80);
            this.groupBox_prime.TabIndex = 42;
            this.groupBox_prime.TabStop = false;
            this.groupBox_prime.Text = "Power, Prime, Step";
            // 
            // radioButton_power_step
            // 
            this.radioButton_power_step.AutoSize = true;
            this.radioButton_power_step.Location = new System.Drawing.Point(297, 20);
            this.radioButton_power_step.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_power_step.Name = "radioButton_power_step";
            this.radioButton_power_step.Size = new System.Drawing.Size(105, 19);
            this.radioButton_power_step.TabIndex = 30;
            this.radioButton_power_step.TabStop = true;
            this.radioButton_power_step.Text = "2^N + 2 ~ 32";
            this.radioButton_power_step.UseVisualStyleBackColor = true;
            // 
            // radioButton_prime
            // 
            this.radioButton_prime.AutoSize = true;
            this.radioButton_prime.Location = new System.Drawing.Point(9, 46);
            this.radioButton_prime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_prime.Name = "radioButton_prime";
            this.radioButton_prime.Size = new System.Drawing.Size(168, 19);
            this.radioButton_prime.TabIndex = 29;
            this.radioButton_prime.TabStop = true;
            this.radioButton_prime.Text = "2, 3, 5, 7, 10, 11, 13, 17";
            this.radioButton_prime.UseVisualStyleBackColor = true;
            // 
            // radioButton_power10
            // 
            this.radioButton_power10.AutoSize = true;
            this.radioButton_power10.Location = new System.Drawing.Point(232, 20);
            this.radioButton_power10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_power10.Name = "radioButton_power10";
            this.radioButton_power10.Size = new System.Drawing.Size(59, 19);
            this.radioButton_power10.TabIndex = 28;
            this.radioButton_power10.TabStop = true;
            this.radioButton_power10.Text = "10^N";
            this.radioButton_power10.UseVisualStyleBackColor = true;
            // 
            // radioButton_power2
            // 
            this.radioButton_power2.AutoSize = true;
            this.radioButton_power2.Location = new System.Drawing.Point(175, 20);
            this.radioButton_power2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_power2.Name = "radioButton_power2";
            this.radioButton_power2.Size = new System.Drawing.Size(52, 19);
            this.radioButton_power2.TabIndex = 27;
            this.radioButton_power2.TabStop = true;
            this.radioButton_power2.Text = "2^N";
            this.radioButton_power2.UseVisualStyleBackColor = true;
            // 
            // button_test1
            // 
            this.button_test1.Location = new System.Drawing.Point(345, 45);
            this.button_test1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_test1.Name = "button_test1";
            this.button_test1.Size = new System.Drawing.Size(63, 28);
            this.button_test1.TabIndex = 26;
            this.button_test1.Text = "Test";
            this.button_test1.UseVisualStyleBackColor = true;
            this.button_test1.Click += new System.EventHandler(this.button_test1_Click);
            // 
            // label_voltage
            // 
            this.label_voltage.AutoSize = true;
            this.label_voltage.Location = new System.Drawing.Point(164, 22);
            this.label_voltage.Name = "label_voltage";
            this.label_voltage.Size = new System.Drawing.Size(53, 15);
            this.label_voltage.TabIndex = 44;
            this.label_voltage.Text = "5.000 V";
            // 
            // button_voltage
            // 
            this.button_voltage.Location = new System.Drawing.Point(91, 16);
            this.button_voltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_voltage.Name = "button_voltage";
            this.button_voltage.Size = new System.Drawing.Size(68, 24);
            this.button_voltage.TabIndex = 43;
            this.button_voltage.Text = "Get";
            this.button_voltage.UseVisualStyleBackColor = true;
            this.button_voltage.Click += new System.EventHandler(this.button_voltage_Click);
            // 
            // groupBox_voltage
            // 
            this.groupBox_voltage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_voltage.Controls.Add(this.checkBox_voltage);
            this.groupBox_voltage.Controls.Add(this.button_voltage);
            this.groupBox_voltage.Controls.Add(this.label_voltage);
            this.groupBox_voltage.Location = new System.Drawing.Point(21, 266);
            this.groupBox_voltage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_voltage.Name = "groupBox_voltage";
            this.groupBox_voltage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_voltage.Size = new System.Drawing.Size(228, 46);
            this.groupBox_voltage.TabIndex = 45;
            this.groupBox_voltage.TabStop = false;
            this.groupBox_voltage.Text = "Voltage";
            // 
            // checkBox_voltage
            // 
            this.checkBox_voltage.AutoSize = true;
            this.checkBox_voltage.Location = new System.Drawing.Point(8, 18);
            this.checkBox_voltage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_voltage.Name = "checkBox_voltage";
            this.checkBox_voltage.Size = new System.Drawing.Size(73, 19);
            this.checkBox_voltage.TabIndex = 38;
            this.checkBox_voltage.Text = "Voltage";
            this.checkBox_voltage.UseVisualStyleBackColor = true;
            this.checkBox_voltage.CheckedChanged += new System.EventHandler(this.checkBox_voltage_CheckedChanged);
            // 
            // groupBox_stressbox
            // 
            this.groupBox_stressbox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_stressbox.Controls.Add(this.button_test2);
            this.groupBox_stressbox.Location = new System.Drawing.Point(5, 94);
            this.groupBox_stressbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_stressbox.Name = "groupBox_stressbox";
            this.groupBox_stressbox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox_stressbox.Size = new System.Drawing.Size(415, 255);
            this.groupBox_stressbox.TabIndex = 46;
            this.groupBox_stressbox.TabStop = false;
            this.groupBox_stressbox.Text = "Stress Test";
            // 
            // button_test2
            // 
            this.button_test2.Location = new System.Drawing.Point(16, 220);
            this.button_test2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_test2.Name = "button_test2";
            this.button_test2.Size = new System.Drawing.Size(388, 29);
            this.button_test2.TabIndex = 31;
            this.button_test2.Text = "Test";
            this.button_test2.UseVisualStyleBackColor = true;
            this.button_test2.Click += new System.EventHandler(this.button_test2_Click);
            // 
            // Selftest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 358);
            this.Controls.Add(this.groupBox_voltage);
            this.Controls.Add(this.groupBox_prime);
            this.Controls.Add(this.groupBox_usb);
            this.Controls.Add(this.groupBox_button);
            this.Controls.Add(this.groupBox_6B595);
            this.Controls.Add(this.groupBox_stressbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Selftest";
            this.Text = "Selftest";
            this.Load += new System.EventHandler(this.Selftest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_red)).EndInit();
            this.groupBox_6B595.ResumeLayout(false);
            this.groupBox_6B595.PerformLayout();
            this.groupBox_button.ResumeLayout(false);
            this.groupBox_button.PerformLayout();
            this.groupBox_usb.ResumeLayout(false);
            this.groupBox_usb.PerformLayout();
            this.groupBox_prime.ResumeLayout(false);
            this.groupBox_prime.PerformLayout();
            this.groupBox_voltage.ResumeLayout(false);
            this.groupBox_voltage.PerformLayout();
            this.groupBox_stressbox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.CheckBox checkBox_RC;
        private System.Windows.Forms.CheckBox checkBox_RB;
        private System.Windows.Forms.CheckBox checkBox_RA;
        private System.Windows.Forms.TextBox textBox_resistance;
        private System.Windows.Forms.Label label_resistance;
        private System.Windows.Forms.Button button_6b595_get;
        private System.Windows.Forms.Label label_6b595_result;
        private System.Windows.Forms.TextBox textBox_usb;
        private System.Windows.Forms.Button button_echo_status;
        private System.Windows.Forms.PictureBox pictureBox_blue;
        private System.Windows.Forms.PictureBox pictureBox_green;
        private System.Windows.Forms.PictureBox pictureBox_yellow;
        private System.Windows.Forms.PictureBox pictureBox_red;
        private System.Windows.Forms.GroupBox groupBox_6B595;
        private System.Windows.Forms.GroupBox groupBox_button;
        private System.Windows.Forms.GroupBox groupBox_usb;
        private System.Windows.Forms.GroupBox groupBox_prime;
        private System.Windows.Forms.Label label_voltage;
        private System.Windows.Forms.Button button_voltage;
        private System.Windows.Forms.GroupBox groupBox_voltage;
        private System.Windows.Forms.RadioButton radioButton_power10;
        private System.Windows.Forms.RadioButton radioButton_power2;
        private System.Windows.Forms.RadioButton radioButton_prime;
        private System.Windows.Forms.RadioButton radioButton_power_step;
        private System.Windows.Forms.CheckBox checkBox_6b595;
        private System.Windows.Forms.CheckBox checkBox_button;
        private System.Windows.Forms.CheckBox checkBox_voltage;
        private System.Windows.Forms.CheckBox checkBox_usb;
        private System.Windows.Forms.GroupBox groupBox_stressbox;
        private System.Windows.Forms.Button button_test1;
        private System.Windows.Forms.Button button_test2;
    }
}