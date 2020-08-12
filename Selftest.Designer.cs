﻿namespace Hotspring
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
            this.button_prime = new System.Windows.Forms.Button();
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
            this.button_6b595 = new System.Windows.Forms.Button();
            this.button_6b595_result = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_prime
            // 
            this.button_prime.Location = new System.Drawing.Point(136, 59);
            this.button_prime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_prime.Name = "button_prime";
            this.button_prime.Size = new System.Drawing.Size(71, 26);
            this.button_prime.TabIndex = 0;
            this.button_prime.Text = "Prime(2-19)";
            this.button_prime.UseVisualStyleBackColor = true;
            this.button_prime.Click += new System.EventHandler(this.button_prime_Click);
            // 
            // checkBox_RC
            // 
            this.checkBox_RC.AutoSize = true;
            this.checkBox_RC.Location = new System.Drawing.Point(92, 11);
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
            this.checkBox_RB.Location = new System.Drawing.Point(53, 11);
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
            this.checkBox_RA.Checked = true;
            this.checkBox_RA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RA.Location = new System.Drawing.Point(12, 11);
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
            this.textBox_resistance.Location = new System.Drawing.Point(155, 33);
            this.textBox_resistance.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_resistance.Name = "textBox_resistance";
            this.textBox_resistance.Size = new System.Drawing.Size(52, 22);
            this.textBox_resistance.TabIndex = 23;
            this.textBox_resistance.Text = "0.2";
            this.textBox_resistance.TextChanged += new System.EventHandler(this.textBox_resistance_TextChanged);
            // 
            // label_resistance
            // 
            this.label_resistance.AutoSize = true;
            this.label_resistance.Location = new System.Drawing.Point(10, 36);
            this.label_resistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_resistance.Name = "label_resistance";
            this.label_resistance.Size = new System.Drawing.Size(142, 12);
            this.label_resistance.TabIndex = 22;
            this.label_resistance.Text = "Resistance: (Below 512 ohm)";
            // 
            // button_prime2
            // 
            this.button_prime2.Location = new System.Drawing.Point(11, 59);
            this.button_prime2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_prime2.Name = "button_prime2";
            this.button_prime2.Size = new System.Drawing.Size(52, 26);
            this.button_prime2.TabIndex = 24;
            this.button_prime2.Text = "Prime_2";
            this.button_prime2.UseVisualStyleBackColor = true;
            this.button_prime2.Click += new System.EventHandler(this.button_prime2_Click);
            // 
            // button_prime10
            // 
            this.button_prime10.Location = new System.Drawing.Point(67, 59);
            this.button_prime10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_prime10.Name = "button_prime10";
            this.button_prime10.Size = new System.Drawing.Size(65, 26);
            this.button_prime10.TabIndex = 25;
            this.button_prime10.Text = "Prime_10";
            this.button_prime10.UseVisualStyleBackColor = true;
            this.button_prime10.Click += new System.EventHandler(this.button_prime10_Click);
            // 
            // button_port
            // 
            this.button_port.Location = new System.Drawing.Point(136, 5);
            this.button_port.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_port.Name = "button_port";
            this.button_port.Size = new System.Drawing.Size(70, 26);
            this.button_port.TabIndex = 26;
            this.button_port.Text = "Connect";
            this.button_port.UseVisualStyleBackColor = true;
            this.button_port.Click += new System.EventHandler(this.button_port_Click);
            // 
            // button_6b595
            // 
            this.button_6b595.Location = new System.Drawing.Point(12, 88);
            this.button_6b595.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_6b595.Name = "button_6b595";
            this.button_6b595.Size = new System.Drawing.Size(76, 26);
            this.button_6b595.TabIndex = 27;
            this.button_6b595.Text = "6B595";
            this.button_6b595.UseVisualStyleBackColor = true;
            this.button_6b595.Click += new System.EventHandler(this.button_6b595_Click);
            // 
            // button_6b595_result
            // 
            this.button_6b595_result.Location = new System.Drawing.Point(93, 88);
            this.button_6b595_result.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_6b595_result.Name = "button_6b595_result";
            this.button_6b595_result.Size = new System.Drawing.Size(113, 26);
            this.button_6b595_result.TabIndex = 28;
            this.button_6b595_result.Text = "Result";
            this.button_6b595_result.UseVisualStyleBackColor = true;
            this.button_6b595_result.Click += new System.EventHandler(this.button_6b595_result_Click);
            // 
            // Selftest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 190);
            this.Controls.Add(this.button_6b595_result);
            this.Controls.Add(this.button_6b595);
            this.Controls.Add(this.button_port);
            this.Controls.Add(this.button_prime10);
            this.Controls.Add(this.button_prime2);
            this.Controls.Add(this.textBox_resistance);
            this.Controls.Add(this.label_resistance);
            this.Controls.Add(this.checkBox_RC);
            this.Controls.Add(this.checkBox_RB);
            this.Controls.Add(this.checkBox_RA);
            this.Controls.Add(this.button_prime);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Selftest";
            this.Text = "Selftest";
            this.Load += new System.EventHandler(this.Selftest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_prime;
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
        private System.Windows.Forms.Button button_6b595;
        private System.Windows.Forms.Button button_6b595_result;
    }
}