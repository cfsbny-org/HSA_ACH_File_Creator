namespace Cfs.Custom.Software
{
    partial class SendEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEmail));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.sendEmailToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emailBody = new System.Windows.Forms.TextBox();
            this.emailBody_label = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendEmailToolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(513, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // sendEmailToolStripButton1
            // 
            this.sendEmailToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendEmailToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("sendEmailToolStripButton1.Image")));
            this.sendEmailToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendEmailToolStripButton1.Name = "sendEmailToolStripButton1";
            this.sendEmailToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.sendEmailToolStripButton1.Text = "Send E-mail Notification";
            this.sendEmailToolStripButton1.Click += new System.EventHandler(this.sendEmailToolStripButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 335);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(513, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(172, 17);
            this.toolStripStatusLabel1.Text = "Send notification of new batch.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.emailBody_label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 60);
            this.panel1.TabIndex = 2;
            // 
            // emailBody
            // 
            this.emailBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.emailBody.Location = new System.Drawing.Point(0, 85);
            this.emailBody.Multiline = true;
            this.emailBody.Name = "emailBody";
            this.emailBody.Size = new System.Drawing.Size(513, 250);
            this.emailBody.TabIndex = 3;
            // 
            // emailBody_label
            // 
            this.emailBody_label.AutoSize = true;
            this.emailBody_label.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailBody_label.Location = new System.Drawing.Point(3, 42);
            this.emailBody_label.Name = "emailBody_label";
            this.emailBody_label.Size = new System.Drawing.Size(61, 15);
            this.emailBody_label.TabIndex = 0;
            this.emailBody_label.Text = " Message:";
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 357);
            this.Controls.Add(this.emailBody);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SendEmail";
            this.Text = "Send Notification";
            this.Load += new System.EventHandler(this.SendEmail_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox emailBody;
        private System.Windows.Forms.ToolStripButton sendEmailToolStripButton1;
        private System.Windows.Forms.Label emailBody_label;
    }
}