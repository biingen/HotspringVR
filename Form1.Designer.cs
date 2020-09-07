namespace Hotspring
{
    partial class Form_hotspring
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_user = new System.Windows.Forms.TabPage();
            this.tabPage_self = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_user);
            this.tabControl1.Controls.Add(this.tabPage_self);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(326, 305);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage_user
            // 
            this.tabPage_user.Location = new System.Drawing.Point(4, 22);
            this.tabPage_user.Name = "tabPage_user";
            this.tabPage_user.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage_user.Size = new System.Drawing.Size(318, 279);
            this.tabPage_user.TabIndex = 0;
            this.tabPage_user.Text = "User";
            this.tabPage_user.UseVisualStyleBackColor = true;
            // 
            // tabPage_self
            // 
            this.tabPage_self.Location = new System.Drawing.Point(4, 22);
            this.tabPage_self.Name = "tabPage_self";
            this.tabPage_self.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage_self.Size = new System.Drawing.Size(318, 279);
            this.tabPage_self.TabIndex = 1;
            this.tabPage_self.Text = "Self";
            this.tabPage_self.UseVisualStyleBackColor = true;
            // 
            // Form_hotspring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 307);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_hotspring";
            this.Text = "Hotspring_v1.0.0.1";
            this.Load += new System.EventHandler(this.Form_hotspring_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_user;
        private System.Windows.Forms.TabPage tabPage_self;
    }
}