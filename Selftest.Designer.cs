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
            this.button_primemix = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.checkBox_RC = new System.Windows.Forms.CheckBox();
            this.checkBox_RB = new System.Windows.Forms.CheckBox();
            this.checkBox_RA = new System.Windows.Forms.CheckBox();
            this.textBox_resistance = new System.Windows.Forms.TextBox();
            this.label_resistance = new System.Windows.Forms.Label();
            this.button_prime2 = new System.Windows.Forms.Button();
            this.button_prime10 = new System.Windows.Forms.Button();
            this.button_port = new System.Windows.Forms.Button();
            this.button_6b595_status = new System.Windows.Forms.Button();
            this.button_6b595_calculate = new System.Windows.Forms.Button();
            this.button_nop = new System.Windows.Forms.Button();
            this.label_6b595_result = new System.Windows.Forms.Label();
            this.textBox_nop_number = new System.Windows.Forms.TextBox();
            this.button_echo_status = new System.Windows.Forms.Button();
            this.pictureBox_blue = new System.Windows.Forms.PictureBox();
            this.pictureBox_green = new System.Windows.Forms.PictureBox();
            this.pictureBox_yellow = new System.Windows.Forms.PictureBox();
            this.pictureBox_red = new System.Windows.Forms.PictureBox();
            this.button_io = new System.Windows.Forms.Button();
            this.groupBox_6B595 = new System.Windows.Forms.GroupBox();
            this.groupBox_button = new System.Windows.Forms.GroupBox();
            this.groupBox_nop = new System.Windows.Forms.GroupBox();
            this.groupBox_prime = new System.Windows.Forms.GroupBox();
            this.label_voltage = new System.Windows.Forms.Label();
            this.button_voltage = new System.Windows.Forms.Button();
            this.groupBox_voltage = new System.Windows.Forms.GroupBox();
            this.button_settings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_red)).BeginInit();
            this.groupBox_6B595.SuspendLayout();
            this.groupBox_button.SuspendLayout();
            this.groupBox_nop.SuspendLayout();
            this.groupBox_prime.SuspendLayout();
            this.groupBox_voltage.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_primemix
            // 
            this.button_primemix.Location = new System.Drawing.Point(63, 68);
            this.button_primemix.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_primemix.Name = "button_primemix";
            this.button_primemix.Size = new System.Drawing.Size(149, 26);
            this.button_primemix.TabIndex = 0;
            this.button_primemix.Text = "2, 3, 5, 7, 10, 11, 13, 17, 19";
            this.button_primemix.UseVisualStyleBackColor = true;
            this.button_primemix.Click += new System.EventHandler(this.button_primemix_Click);
            // 
            // checkBox_RC
            // 
            this.checkBox_RC.AutoSize = true;
            this.checkBox_RC.Location = new System.Drawing.Point(88, 17);
            this.checkBox_RC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_RC.Name = "checkBox_RC";
            this.checkBox_RC.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RC.TabIndex = 13;
            this.checkBox_RC.Text = "RC";
            this.checkBox_RC.UseVisualStyleBackColor = true;
            this.checkBox_RC.CheckedChanged += new System.EventHandler(this.checkBox_RC_CheckedChanged);
            // 
            // checkBox_RB
            // 
            this.checkBox_RB.AutoSize = true;
            this.checkBox_RB.Location = new System.Drawing.Point(48, 17);
            this.checkBox_RB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_RB.Name = "checkBox_RB";
            this.checkBox_RB.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RB.TabIndex = 12;
            this.checkBox_RB.Text = "RB";
            this.checkBox_RB.UseVisualStyleBackColor = true;
            this.checkBox_RB.CheckedChanged += new System.EventHandler(this.checkBox_RB_CheckedChanged);
            // 
            // checkBox_RA
            // 
            this.checkBox_RA.AutoSize = true;
            this.checkBox_RA.Location = new System.Drawing.Point(7, 17);
            this.checkBox_RA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_RA.Name = "checkBox_RA";
            this.checkBox_RA.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RA.TabIndex = 11;
            this.checkBox_RA.Text = "RA";
            this.checkBox_RA.UseVisualStyleBackColor = true;
            this.checkBox_RA.CheckedChanged += new System.EventHandler(this.checkBox_RA_CheckedChanged);
            // 
            // textBox_resistance
            // 
            this.textBox_resistance.Location = new System.Drawing.Point(150, 42);
            this.textBox_resistance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_resistance.Name = "textBox_resistance";
            this.textBox_resistance.Size = new System.Drawing.Size(62, 22);
            this.textBox_resistance.TabIndex = 23;
            this.textBox_resistance.Text = "0.2";
            this.textBox_resistance.TextChanged += new System.EventHandler(this.textBox_resistance_TextChanged);
            // 
            // label_resistance
            // 
            this.label_resistance.AutoSize = true;
            this.label_resistance.Location = new System.Drawing.Point(5, 45);
            this.label_resistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_resistance.Name = "label_resistance";
            this.label_resistance.Size = new System.Drawing.Size(142, 12);
            this.label_resistance.TabIndex = 22;
            this.label_resistance.Text = "Resistance: (Below 512 ohm)";
            // 
            // button_prime2
            // 
            this.button_prime2.Location = new System.Drawing.Point(7, 68);
            this.button_prime2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_prime2.Name = "button_prime2";
            this.button_prime2.Size = new System.Drawing.Size(18, 26);
            this.button_prime2.TabIndex = 24;
            this.button_prime2.Text = "2";
            this.button_prime2.UseVisualStyleBackColor = true;
            this.button_prime2.Click += new System.EventHandler(this.button_prime2_Click);
            // 
            // button_prime10
            // 
            this.button_prime10.Location = new System.Drawing.Point(27, 68);
            this.button_prime10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_prime10.Name = "button_prime10";
            this.button_prime10.Size = new System.Drawing.Size(33, 26);
            this.button_prime10.TabIndex = 25;
            this.button_prime10.Text = "10";
            this.button_prime10.UseVisualStyleBackColor = true;
            this.button_prime10.Click += new System.EventHandler(this.button_prime10_Click);
            // 
            // button_port
            // 
            this.button_port.Location = new System.Drawing.Point(238, 18);
            this.button_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_port.Name = "button_port";
            this.button_port.Size = new System.Drawing.Size(70, 22);
            this.button_port.TabIndex = 26;
            this.button_port.Text = "Connect";
            this.button_port.UseVisualStyleBackColor = true;
            this.button_port.Click += new System.EventHandler(this.button_port_Click);
            // 
            // button_6b595_status
            // 
            this.button_6b595_status.Location = new System.Drawing.Point(6, 11);
            this.button_6b595_status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_6b595_status.Name = "button_6b595_status";
            this.button_6b595_status.Size = new System.Drawing.Size(53, 26);
            this.button_6b595_status.TabIndex = 27;
            this.button_6b595_status.Text = "6B595";
            this.button_6b595_status.UseVisualStyleBackColor = true;
            this.button_6b595_status.Click += new System.EventHandler(this.button_6b595_status_Click);
            // 
            // button_6b595_calculate
            // 
            this.button_6b595_calculate.Location = new System.Drawing.Point(63, 11);
            this.button_6b595_calculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_6b595_calculate.Name = "button_6b595_calculate";
            this.button_6b595_calculate.Size = new System.Drawing.Size(59, 26);
            this.button_6b595_calculate.TabIndex = 28;
            this.button_6b595_calculate.Text = "Calculate";
            this.button_6b595_calculate.UseVisualStyleBackColor = true;
            this.button_6b595_calculate.Click += new System.EventHandler(this.button_6b595_calculate_Click);
            // 
            // button_nop
            // 
            this.button_nop.Location = new System.Drawing.Point(61, 14);
            this.button_nop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_nop.Name = "button_nop";
            this.button_nop.Size = new System.Drawing.Size(44, 22);
            this.button_nop.TabIndex = 29;
            this.button_nop.Text = "Nop";
            this.button_nop.UseVisualStyleBackColor = true;
            this.button_nop.Click += new System.EventHandler(this.button_nop_Click);
            // 
            // label_6b595_result
            // 
            this.label_6b595_result.AutoSize = true;
            this.label_6b595_result.Location = new System.Drawing.Point(126, 18);
            this.label_6b595_result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_6b595_result.Name = "label_6b595_result";
            this.label_6b595_result.Size = new System.Drawing.Size(37, 12);
            this.label_6b595_result.TabIndex = 31;
            this.label_6b595_result.Text = "6B595";
            // 
            // textBox_nop_number
            // 
            this.textBox_nop_number.Location = new System.Drawing.Point(5, 14);
            this.textBox_nop_number.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_nop_number.Name = "textBox_nop_number";
            this.textBox_nop_number.Size = new System.Drawing.Size(52, 22);
            this.textBox_nop_number.TabIndex = 32;
            this.textBox_nop_number.Text = "100";
            // 
            // button_echo_status
            // 
            this.button_echo_status.Location = new System.Drawing.Point(140, 13);
            this.button_echo_status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_echo_status.Name = "button_echo_status";
            this.button_echo_status.Size = new System.Drawing.Size(70, 22);
            this.button_echo_status.TabIndex = 33;
            this.button_echo_status.Text = "Echo";
            this.button_echo_status.UseVisualStyleBackColor = true;
            this.button_echo_status.Click += new System.EventHandler(this.button_echo_status_Click);
            // 
            // pictureBox_blue
            // 
            this.pictureBox_blue.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_blue.Location = new System.Drawing.Point(3, 16);
            this.pictureBox_blue.Name = "pictureBox_blue";
            this.pictureBox_blue.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_blue.TabIndex = 34;
            this.pictureBox_blue.TabStop = false;
            // 
            // pictureBox_green
            // 
            this.pictureBox_green.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_green.Location = new System.Drawing.Point(58, 16);
            this.pictureBox_green.Name = "pictureBox_green";
            this.pictureBox_green.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_green.TabIndex = 35;
            this.pictureBox_green.TabStop = false;
            // 
            // pictureBox_yellow
            // 
            this.pictureBox_yellow.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_yellow.Location = new System.Drawing.Point(112, 16);
            this.pictureBox_yellow.Name = "pictureBox_yellow";
            this.pictureBox_yellow.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_yellow.TabIndex = 36;
            this.pictureBox_yellow.TabStop = false;
            // 
            // pictureBox_red
            // 
            this.pictureBox_red.Image = global::Hotspring.Properties.Resources.black;
            this.pictureBox_red.Location = new System.Drawing.Point(166, 16);
            this.pictureBox_red.Name = "pictureBox_red";
            this.pictureBox_red.Size = new System.Drawing.Size(48, 48);
            this.pictureBox_red.TabIndex = 37;
            this.pictureBox_red.TabStop = false;
            // 
            // button_io
            // 
            this.button_io.Location = new System.Drawing.Point(220, 16);
            this.button_io.Name = "button_io";
            this.button_io.Size = new System.Drawing.Size(53, 48);
            this.button_io.TabIndex = 38;
            this.button_io.Text = "Button";
            this.button_io.UseVisualStyleBackColor = true;
            this.button_io.Click += new System.EventHandler(this.button_io_Click);
            // 
            // groupBox_6B595
            // 
            this.groupBox_6B595.Controls.Add(this.label_6b595_result);
            this.groupBox_6B595.Controls.Add(this.button_6b595_status);
            this.groupBox_6B595.Controls.Add(this.button_6b595_calculate);
            this.groupBox_6B595.Location = new System.Drawing.Point(12, 112);
            this.groupBox_6B595.Name = "groupBox_6B595";
            this.groupBox_6B595.Size = new System.Drawing.Size(181, 47);
            this.groupBox_6B595.TabIndex = 39;
            this.groupBox_6B595.TabStop = false;
            this.groupBox_6B595.Text = "6B595";
            // 
            // groupBox_button
            // 
            this.groupBox_button.Controls.Add(this.pictureBox_red);
            this.groupBox_button.Controls.Add(this.pictureBox_blue);
            this.groupBox_button.Controls.Add(this.button_io);
            this.groupBox_button.Controls.Add(this.pictureBox_green);
            this.groupBox_button.Controls.Add(this.pictureBox_yellow);
            this.groupBox_button.Location = new System.Drawing.Point(12, 164);
            this.groupBox_button.Name = "groupBox_button";
            this.groupBox_button.Size = new System.Drawing.Size(280, 70);
            this.groupBox_button.TabIndex = 40;
            this.groupBox_button.TabStop = false;
            this.groupBox_button.Text = "Button";
            // 
            // groupBox_nop
            // 
            this.groupBox_nop.Controls.Add(this.textBox_nop_number);
            this.groupBox_nop.Controls.Add(this.button_nop);
            this.groupBox_nop.Location = new System.Drawing.Point(199, 112);
            this.groupBox_nop.Name = "groupBox_nop";
            this.groupBox_nop.Size = new System.Drawing.Size(111, 46);
            this.groupBox_nop.TabIndex = 41;
            this.groupBox_nop.TabStop = false;
            this.groupBox_nop.Text = "Nop";
            // 
            // groupBox_prime
            // 
            this.groupBox_prime.Controls.Add(this.button_prime2);
            this.groupBox_prime.Controls.Add(this.button_prime10);
            this.groupBox_prime.Controls.Add(this.button_primemix);
            this.groupBox_prime.Controls.Add(this.label_resistance);
            this.groupBox_prime.Controls.Add(this.textBox_resistance);
            this.groupBox_prime.Controls.Add(this.button_echo_status);
            this.groupBox_prime.Controls.Add(this.checkBox_RB);
            this.groupBox_prime.Controls.Add(this.checkBox_RC);
            this.groupBox_prime.Controls.Add(this.checkBox_RA);
            this.groupBox_prime.Location = new System.Drawing.Point(13, 5);
            this.groupBox_prime.Name = "groupBox_prime";
            this.groupBox_prime.Size = new System.Drawing.Size(215, 101);
            this.groupBox_prime.TabIndex = 42;
            this.groupBox_prime.TabStop = false;
            this.groupBox_prime.Text = "Prime";
            // 
            // label_voltage
            // 
            this.label_voltage.AutoSize = true;
            this.label_voltage.Location = new System.Drawing.Point(65, 17);
            this.label_voltage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_voltage.Name = "label_voltage";
            this.label_voltage.Size = new System.Drawing.Size(40, 12);
            this.label_voltage.TabIndex = 44;
            this.label_voltage.Text = "5.000V";
            // 
            // button_voltage
            // 
            this.button_voltage.Location = new System.Drawing.Point(6, 13);
            this.button_voltage.Margin = new System.Windows.Forms.Padding(2);
            this.button_voltage.Name = "button_voltage";
            this.button_voltage.Size = new System.Drawing.Size(51, 19);
            this.button_voltage.TabIndex = 43;
            this.button_voltage.Text = "Get";
            this.button_voltage.UseVisualStyleBackColor = true;
            this.button_voltage.Click += new System.EventHandler(this.button_voltage_Click);
            // 
            // groupBox_voltage
            // 
            this.groupBox_voltage.Controls.Add(this.button_voltage);
            this.groupBox_voltage.Controls.Add(this.label_voltage);
            this.groupBox_voltage.Location = new System.Drawing.Point(12, 240);
            this.groupBox_voltage.Name = "groupBox_voltage";
            this.groupBox_voltage.Size = new System.Drawing.Size(121, 37);
            this.groupBox_voltage.TabIndex = 45;
            this.groupBox_voltage.TabStop = false;
            this.groupBox_voltage.Text = "Voltage";
            // 
            // button_settings
            // 
            this.button_settings.Location = new System.Drawing.Point(238, 47);
            this.button_settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_settings.Name = "button_settings";
            this.button_settings.Size = new System.Drawing.Size(70, 22);
            this.button_settings.TabIndex = 46;
            this.button_settings.Text = "Settings";
            this.button_settings.UseVisualStyleBackColor = true;
            this.button_settings.Click += new System.EventHandler(this.button_settings_Click);
            // 
            // Selftest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 286);
            this.Controls.Add(this.button_settings);
            this.Controls.Add(this.groupBox_voltage);
            this.Controls.Add(this.groupBox_prime);
            this.Controls.Add(this.groupBox_nop);
            this.Controls.Add(this.groupBox_button);
            this.Controls.Add(this.groupBox_6B595);
            this.Controls.Add(this.button_port);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.groupBox_nop.ResumeLayout(false);
            this.groupBox_nop.PerformLayout();
            this.groupBox_prime.ResumeLayout(false);
            this.groupBox_prime.PerformLayout();
            this.groupBox_voltage.ResumeLayout(false);
            this.groupBox_voltage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_primemix;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.CheckBox checkBox_RC;
        private System.Windows.Forms.CheckBox checkBox_RB;
        private System.Windows.Forms.CheckBox checkBox_RA;
        private System.Windows.Forms.TextBox textBox_resistance;
        private System.Windows.Forms.Label label_resistance;
        private System.Windows.Forms.Button button_prime2;
        private System.Windows.Forms.Button button_prime10;
        private System.Windows.Forms.Button button_port;
        private System.Windows.Forms.Button button_6b595_status;
        private System.Windows.Forms.Button button_6b595_calculate;
        private System.Windows.Forms.Button button_nop;
        private System.Windows.Forms.Label label_6b595_result;
        private System.Windows.Forms.TextBox textBox_nop_number;
        private System.Windows.Forms.Button button_echo_status;
        private System.Windows.Forms.PictureBox pictureBox_blue;
        private System.Windows.Forms.PictureBox pictureBox_green;
        private System.Windows.Forms.PictureBox pictureBox_yellow;
        private System.Windows.Forms.PictureBox pictureBox_red;
        private System.Windows.Forms.Button button_io;
        private System.Windows.Forms.GroupBox groupBox_6B595;
        private System.Windows.Forms.GroupBox groupBox_button;
        private System.Windows.Forms.GroupBox groupBox_nop;
        private System.Windows.Forms.GroupBox groupBox_prime;
        private System.Windows.Forms.Label label_voltage;
        private System.Windows.Forms.Button button_voltage;
        private System.Windows.Forms.GroupBox groupBox_voltage;
        private System.Windows.Forms.Button button_settings;
    }
}