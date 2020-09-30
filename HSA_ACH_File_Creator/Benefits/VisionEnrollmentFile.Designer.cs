namespace Cfs.Custom.Software.Benefits
{
    partial class VisionEnrollmentFile
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
            this.batchesList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // batchesList
            // 
            this.batchesList.DisplayMember = "batchTitle";
            this.batchesList.FormattingEnabled = true;
            this.batchesList.Location = new System.Drawing.Point(345, 40);
            this.batchesList.Name = "batchesList";
            this.batchesList.Size = new System.Drawing.Size(197, 23);
            this.batchesList.TabIndex = 0;
            this.batchesList.ValueMember = "batchId";
            // 
            // VisionEnrollmentFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 601);
            this.Controls.Add(this.batchesList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VisionEnrollmentFile";
            this.Text = "Vision Enrollment File";
            this.Load += new System.EventHandler(this.VisionEnrollmentFile_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox batchesList;
    }
}