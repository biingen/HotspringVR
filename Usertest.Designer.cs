namespace Hotspring
{
    partial class Usertest
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
            this.textBox_startValue = new System.Windows.Forms.TextBox();
            this.textBox_endValue = new System.Windows.Forms.TextBox();
            this.textBox_delaytime = new System.Windows.Forms.TextBox();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.label_startValue = new System.Windows.Forms.Label();
            this.label_endValue = new System.Windows.Forms.Label();
            this.label_delay = new System.Windows.Forms.Label();
            this.label_step = new System.Windows.Forms.Label();
            this.checkBox_RA = new System.Windows.Forms.CheckBox();
            this.checkBox_RB = new System.Windows.Forms.CheckBox();
            this.checkBox_RC = new System.Windows.Forms.CheckBox();
            this.button_start = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.label_basis = new System.Windows.Forms.Label();
            this.textBox_basis = new System.Windows.Forms.TextBox();
            this.textBox_resistance = new System.Windows.Forms.TextBox();
            this.label_resistance = new System.Windows.Forms.Label();
            this.label_sendValue = new System.Windows.Forms.Label();
            this.label_receiveValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_startValue
            // 
            this.textBox_startValue.Location = new System.Drawing.Point(164, 38);
            this.textBox_startValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_startValue.Name = "textBox_startValue";
            this.textBox_startValue.Size = new System.Drawing.Size(76, 22);
            this.textBox_startValue.TabIndex = 0;
            this.textBox_startValue.Text = "2";
            this.textBox_startValue.TextChanged += new System.EventHandler(this.textBox_startValue_TextChanged);
            // 
            // textBox_endValue
            // 
            this.textBox_endValue.Location = new System.Drawing.Point(164, 62);
            this.textBox_endValue.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_endValue.Name = "textBox_endValue";
            this.textBox_endValue.Size = new System.Drawing.Size(76, 22);
            this.textBox_endValue.TabIndex = 1;
            this.textBox_endValue.Text = "1048575";
            this.textBox_endValue.TextChanged += new System.EventHandler(this.textBox_endValue_TextChanged);
            // 
            // textBox_delaytime
            // 
            this.textBox_delaytime.Location = new System.Drawing.Point(164, 110);
            this.textBox_delaytime.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_delaytime.Name = "textBox_delaytime";
            this.textBox_delaytime.Size = new System.Drawing.Size(76, 22);
            this.textBox_delaytime.TabIndex = 2;
            this.textBox_delaytime.Text = "2000";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(164, 158);
            this.textBox_step.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(76, 22);
            this.textBox_step.TabIndex = 3;
            this.textBox_step.Text = "0";
            this.textBox_step.TextChanged += new System.EventHandler(this.textBox_step_TextChanged);
            // 
            // label_startValue
            // 
            this.label_startValue.AutoSize = true;
            this.label_startValue.Location = new System.Drawing.Point(18, 38);
            this.label_startValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_startValue.Name = "label_startValue";
            this.label_startValue.Size = new System.Drawing.Size(32, 12);
            this.label_startValue.TabIndex = 4;
            this.label_startValue.Text = "Start: ";
            // 
            // label_endValue
            // 
            this.label_endValue.AutoSize = true;
            this.label_endValue.Location = new System.Drawing.Point(18, 61);
            this.label_endValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_endValue.Name = "label_endValue";
            this.label_endValue.Size = new System.Drawing.Size(30, 12);
            this.label_endValue.TabIndex = 5;
            this.label_endValue.Text = "End: ";
            // 
            // label_delay
            // 
            this.label_delay.AutoSize = true;
            this.label_delay.Location = new System.Drawing.Point(18, 111);
            this.label_delay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_delay.Name = "label_delay";
            this.label_delay.Size = new System.Drawing.Size(62, 12);
            this.label_delay.TabIndex = 6;
            this.label_delay.Text = "Delay (ms): ";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(19, 158);
            this.label_step.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(31, 12);
            this.label_step.TabIndex = 7;
            this.label_step.Text = "Step: ";
            // 
            // checkBox_RA
            // 
            this.checkBox_RA.AutoSize = true;
            this.checkBox_RA.Checked = true;
            this.checkBox_RA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RA.Location = new System.Drawing.Point(21, 9);
            this.checkBox_RA.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RA.Name = "checkBox_RA";
            this.checkBox_RA.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RA.TabIndex = 8;
            this.checkBox_RA.Text = "RA";
            this.checkBox_RA.UseVisualStyleBackColor = true;
            this.checkBox_RA.CheckedChanged += new System.EventHandler(this.checkBox_RA_CheckedChanged);
            // 
            // checkBox_RB
            // 
            this.checkBox_RB.AutoSize = true;
            this.checkBox_RB.Location = new System.Drawing.Point(62, 9);
            this.checkBox_RB.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RB.Name = "checkBox_RB";
            this.checkBox_RB.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RB.TabIndex = 9;
            this.checkBox_RB.Text = "RB";
            this.checkBox_RB.UseVisualStyleBackColor = true;
            this.checkBox_RB.CheckedChanged += new System.EventHandler(this.checkBox_RB_CheckedChanged);
            // 
            // checkBox_RC
            // 
            this.checkBox_RC.AutoSize = true;
            this.checkBox_RC.Location = new System.Drawing.Point(101, 9);
            this.checkBox_RC.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RC.Name = "checkBox_RC";
            this.checkBox_RC.Size = new System.Drawing.Size(40, 16);
            this.checkBox_RC.TabIndex = 10;
            this.checkBox_RC.Text = "RC";
            this.checkBox_RC.UseVisualStyleBackColor = true;
            this.checkBox_RC.CheckedChanged += new System.EventHandler(this.checkBox_RC_CheckedChanged);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(21, 184);
            this.button_start.Margin = new System.Windows.Forms.Padding(2);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(219, 30);
            this.button_start.TabIndex = 11;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label_basis
            // 
            this.label_basis.AutoSize = true;
            this.label_basis.Location = new System.Drawing.Point(19, 88);
            this.label_basis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_basis.Name = "label_basis";
            this.label_basis.Size = new System.Drawing.Size(35, 12);
            this.label_basis.TabIndex = 14;
            this.label_basis.Text = "Basis: ";
            // 
            // textBox_basis
            // 
            this.textBox_basis.Location = new System.Drawing.Point(164, 86);
            this.textBox_basis.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_basis.Name = "textBox_basis";
            this.textBox_basis.Size = new System.Drawing.Size(76, 22);
            this.textBox_basis.TabIndex = 15;
            this.textBox_basis.Text = "2";
            this.textBox_basis.TextChanged += new System.EventHandler(this.textBox_basis_TextChanged);
            // 
            // textBox_resistance
            // 
            this.textBox_resistance.Location = new System.Drawing.Point(164, 134);
            this.textBox_resistance.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_resistance.Name = "textBox_resistance";
            this.textBox_resistance.Size = new System.Drawing.Size(76, 22);
            this.textBox_resistance.TabIndex = 21;
            this.textBox_resistance.Text = "0.2";
            this.textBox_resistance.TextChanged += new System.EventHandler(this.textBox_resistance_TextChanged);
            // 
            // label_resistance
            // 
            this.label_resistance.AutoSize = true;
            this.label_resistance.Location = new System.Drawing.Point(19, 137);
            this.label_resistance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_resistance.Name = "label_resistance";
            this.label_resistance.Size = new System.Drawing.Size(142, 12);
            this.label_resistance.TabIndex = 20;
            this.label_resistance.Text = "Resistance: (Below 512 ohm)";
            // 
            // label_sendValue
            // 
            this.label_sendValue.AutoSize = true;
            this.label_sendValue.Location = new System.Drawing.Point(19, 225);
            this.label_sendValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_sendValue.Name = "label_sendValue";
            this.label_sendValue.Size = new System.Drawing.Size(53, 12);
            this.label_sendValue.TabIndex = 18;
            this.label_sendValue.Text = "00000000";
            this.label_sendValue.Visible = false;
            // 
            // label_receiveValue
            // 
            this.label_receiveValue.AutoSize = true;
            this.label_receiveValue.Location = new System.Drawing.Point(19, 247);
            this.label_receiveValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_receiveValue.Name = "label_receiveValue";
            this.label_receiveValue.Size = new System.Drawing.Size(53, 12);
            this.label_receiveValue.TabIndex = 19;
            this.label_receiveValue.Text = "00000000";
            this.label_receiveValue.Visible = false;
            // 
            // Usertest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 286);
            this.Controls.Add(this.textBox_resistance);
            this.Controls.Add(this.label_resistance);
            this.Controls.Add(this.label_receiveValue);
            this.Controls.Add(this.label_sendValue);
            this.Controls.Add(this.textBox_basis);
            this.Controls.Add(this.label_basis);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.checkBox_RC);
            this.Controls.Add(this.checkBox_RB);
            this.Controls.Add(this.checkBox_RA);
            this.Controls.Add(this.label_step);
            this.Controls.Add(this.label_delay);
            this.Controls.Add(this.label_endValue);
            this.Controls.Add(this.label_startValue);
            this.Controls.Add(this.textBox_step);
            this.Controls.Add(this.textBox_delaytime);
            this.Controls.Add(this.textBox_endValue);
            this.Controls.Add(this.textBox_startValue);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Usertest";
            this.Text = "Usertest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_startValue;
        private System.Windows.Forms.TextBox textBox_endValue;
        private System.Windows.Forms.TextBox textBox_delaytime;
        private System.Windows.Forms.TextBox textBox_step;
        private System.Windows.Forms.Label label_startValue;
        private System.Windows.Forms.Label label_endValue;
        private System.Windows.Forms.Label label_delay;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.CheckBox checkBox_RA;
        private System.Windows.Forms.CheckBox checkBox_RB;
        private System.Windows.Forms.CheckBox checkBox_RC;
        private System.Windows.Forms.Button button_start;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Label label_basis;
        private System.Windows.Forms.TextBox textBox_basis;
        private System.Windows.Forms.TextBox textBox_resistance;
        private System.Windows.Forms.Label label_resistance;
        private System.Windows.Forms.Label label_sendValue;
        private System.Windows.Forms.Label label_receiveValue;
    }
}

