namespace Hotspring
{
    partial class Medical
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
            this.hScrollBar_backlight_set = new System.Windows.Forms.HScrollBar();
            this.label_backlight_show = new System.Windows.Forms.Label();
            this.button_backlight_get = new System.Windows.Forms.Button();
            this.hScrollBar_rgbgain_set = new System.Windows.Forms.HScrollBar();
            this.label_rgbgain_show = new System.Windows.Forms.Label();
            this.button_rgbgain_get = new System.Windows.Forms.Button();
            this.numericUpDown_rgbgain_set = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_maininput = new System.Windows.Forms.NumericUpDown();
            this.button_maininput_get = new System.Windows.Forms.Button();
            this.label_maininput_show = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgbgain_set)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maininput)).BeginInit();
            this.SuspendLayout();
            // 
            // hScrollBar_backlight_set
            // 
            this.hScrollBar_backlight_set.LargeChange = 1;
            this.hScrollBar_backlight_set.Location = new System.Drawing.Point(11, 20);
            this.hScrollBar_backlight_set.Maximum = 150;
            this.hScrollBar_backlight_set.Minimum = -50;
            this.hScrollBar_backlight_set.Name = "hScrollBar_backlight_set";
            this.hScrollBar_backlight_set.Size = new System.Drawing.Size(173, 17);
            this.hScrollBar_backlight_set.TabIndex = 1;
            this.hScrollBar_backlight_set.Value = 50;
            this.hScrollBar_backlight_set.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_backlight_set_Scroll);
            // 
            // label_backlight_show
            // 
            this.label_backlight_show.AutoSize = true;
            this.label_backlight_show.Location = new System.Drawing.Point(204, 23);
            this.label_backlight_show.Name = "label_backlight_show";
            this.label_backlight_show.Size = new System.Drawing.Size(11, 12);
            this.label_backlight_show.TabIndex = 2;
            this.label_backlight_show.Text = "0";
            // 
            // button_backlight_get
            // 
            this.button_backlight_get.Location = new System.Drawing.Point(269, 19);
            this.button_backlight_get.Name = "button_backlight_get";
            this.button_backlight_get.Size = new System.Drawing.Size(38, 23);
            this.button_backlight_get.TabIndex = 3;
            this.button_backlight_get.Text = "Get";
            this.button_backlight_get.UseVisualStyleBackColor = true;
            this.button_backlight_get.Click += new System.EventHandler(this.button_backlight_get_Click);
            // 
            // hScrollBar_rgbgain_set
            // 
            this.hScrollBar_rgbgain_set.LargeChange = 1;
            this.hScrollBar_rgbgain_set.Location = new System.Drawing.Point(52, 54);
            this.hScrollBar_rgbgain_set.Maximum = 255;
            this.hScrollBar_rgbgain_set.Name = "hScrollBar_rgbgain_set";
            this.hScrollBar_rgbgain_set.Size = new System.Drawing.Size(132, 17);
            this.hScrollBar_rgbgain_set.TabIndex = 1;
            this.hScrollBar_rgbgain_set.Value = 100;
            this.hScrollBar_rgbgain_set.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_rgbgain_set_Scroll);
            // 
            // label_rgbgain_show
            // 
            this.label_rgbgain_show.AutoSize = true;
            this.label_rgbgain_show.Location = new System.Drawing.Point(203, 55);
            this.label_rgbgain_show.Name = "label_rgbgain_show";
            this.label_rgbgain_show.Size = new System.Drawing.Size(11, 12);
            this.label_rgbgain_show.TabIndex = 6;
            this.label_rgbgain_show.Text = "0";
            // 
            // button_rgbgain_get
            // 
            this.button_rgbgain_get.Location = new System.Drawing.Point(269, 52);
            this.button_rgbgain_get.Name = "button_rgbgain_get";
            this.button_rgbgain_get.Size = new System.Drawing.Size(38, 23);
            this.button_rgbgain_get.TabIndex = 7;
            this.button_rgbgain_get.Text = "Get";
            this.button_rgbgain_get.UseVisualStyleBackColor = true;
            this.button_rgbgain_get.Click += new System.EventHandler(this.button_rgbgain_get_Click);
            // 
            // numericUpDown_rgbgain_set
            // 
            this.numericUpDown_rgbgain_set.Location = new System.Drawing.Point(11, 52);
            this.numericUpDown_rgbgain_set.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_rgbgain_set.Name = "numericUpDown_rgbgain_set";
            this.numericUpDown_rgbgain_set.Size = new System.Drawing.Size(38, 22);
            this.numericUpDown_rgbgain_set.TabIndex = 2;
            // 
            // numericUpDown_maininput
            // 
            this.numericUpDown_maininput.Location = new System.Drawing.Point(11, 89);
            this.numericUpDown_maininput.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown_maininput.Name = "numericUpDown_maininput";
            this.numericUpDown_maininput.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown_maininput.TabIndex = 8;
            this.numericUpDown_maininput.ValueChanged += new System.EventHandler(this.numericUpDown_maininput_ValueChanged);
            // 
            // button_maininput_get
            // 
            this.button_maininput_get.Location = new System.Drawing.Point(269, 89);
            this.button_maininput_get.Name = "button_maininput_get";
            this.button_maininput_get.Size = new System.Drawing.Size(38, 23);
            this.button_maininput_get.TabIndex = 10;
            this.button_maininput_get.Text = "Get";
            this.button_maininput_get.UseVisualStyleBackColor = true;
            this.button_maininput_get.Click += new System.EventHandler(this.button_maininput_get_Click);
            // 
            // label_maininput_show
            // 
            this.label_maininput_show.AutoSize = true;
            this.label_maininput_show.Location = new System.Drawing.Point(203, 92);
            this.label_maininput_show.Name = "label_maininput_show";
            this.label_maininput_show.Size = new System.Drawing.Size(11, 12);
            this.label_maininput_show.TabIndex = 9;
            this.label_maininput_show.Text = "0";
            // 
            // Medical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 286);
            this.Controls.Add(this.button_maininput_get);
            this.Controls.Add(this.label_maininput_show);
            this.Controls.Add(this.numericUpDown_maininput);
            this.Controls.Add(this.numericUpDown_rgbgain_set);
            this.Controls.Add(this.button_rgbgain_get);
            this.Controls.Add(this.label_rgbgain_show);
            this.Controls.Add(this.hScrollBar_rgbgain_set);
            this.Controls.Add(this.button_backlight_get);
            this.Controls.Add(this.label_backlight_show);
            this.Controls.Add(this.hScrollBar_backlight_set);
            this.Name = "Medical";
            this.Text = "Medical";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_rgbgain_set)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maininput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.HScrollBar hScrollBar_backlight_set;
        private System.Windows.Forms.Label label_backlight_show;
        private System.Windows.Forms.Button button_backlight_get;
        private System.Windows.Forms.HScrollBar hScrollBar_rgbgain_set;
        private System.Windows.Forms.Label label_rgbgain_show;
        private System.Windows.Forms.Button button_rgbgain_get;
        private System.Windows.Forms.NumericUpDown numericUpDown_rgbgain_set;
        private System.Windows.Forms.NumericUpDown numericUpDown_maininput;
        private System.Windows.Forms.Button button_maininput_get;
        private System.Windows.Forms.Label label_maininput_show;
    }
}