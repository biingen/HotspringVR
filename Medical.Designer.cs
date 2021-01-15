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
            this.hScrollBar_setvalue = new System.Windows.Forms.HScrollBar();
            this.label_getvalue = new System.Windows.Forms.Label();
            this.button_getvalue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hScrollBar_setvalue
            // 
            this.hScrollBar_setvalue.Location = new System.Drawing.Point(14, 18);
            this.hScrollBar_setvalue.Maximum = 150;
            this.hScrollBar_setvalue.Minimum = -50;
            this.hScrollBar_setvalue.Name = "hScrollBar_setvalue";
            this.hScrollBar_setvalue.Size = new System.Drawing.Size(173, 17);
            this.hScrollBar_setvalue.TabIndex = 1;
            this.hScrollBar_setvalue.Value = 50;
            this.hScrollBar_setvalue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_setvalue_Scroll);
            // 
            // label_getvalue
            // 
            this.label_getvalue.AutoSize = true;
            this.label_getvalue.Location = new System.Drawing.Point(21, 55);
            this.label_getvalue.Name = "label_getvalue";
            this.label_getvalue.Size = new System.Drawing.Size(11, 12);
            this.label_getvalue.TabIndex = 2;
            this.label_getvalue.Text = "0";
            // 
            // button_getvalue
            // 
            this.button_getvalue.Location = new System.Drawing.Point(112, 50);
            this.button_getvalue.Name = "button_getvalue";
            this.button_getvalue.Size = new System.Drawing.Size(75, 23);
            this.button_getvalue.TabIndex = 3;
            this.button_getvalue.Text = "Get value";
            this.button_getvalue.UseVisualStyleBackColor = true;
            this.button_getvalue.Click += new System.EventHandler(this.button_getvalue_Click);
            // 
            // Medical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 286);
            this.Controls.Add(this.button_getvalue);
            this.Controls.Add(this.label_getvalue);
            this.Controls.Add(this.hScrollBar_setvalue);
            this.Name = "Medical";
            this.Text = "Medical";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.HScrollBar hScrollBar_setvalue;
        private System.Windows.Forms.Label label_getvalue;
        private System.Windows.Forms.Button button_getvalue;
    }
}