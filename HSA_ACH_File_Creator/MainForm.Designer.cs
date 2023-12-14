namespace Cfs.Custom.Software
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCHBatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valicRemittanceFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCHBatchToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.valicResponseFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valicPaidOffLoansReportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printTimesheetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPayStubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oSHAWorksheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutHSAACHFileCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benefitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createVisionFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.benefitsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(664, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.printTimesheetsToolStripMenuItem,
            this.exportPayStubsToolStripMenuItem,
            this.oSHAWorksheetToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCHBatchToolStripMenuItem,
            this.valicRemittanceFileToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // aCHBatchToolStripMenuItem
            // 
            this.aCHBatchToolStripMenuItem.Name = "aCHBatchToolStripMenuItem";
            this.aCHBatchToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aCHBatchToolStripMenuItem.Text = "ACH &Batch";
            this.aCHBatchToolStripMenuItem.Click += new System.EventHandler(this.aCHBatchToolStripMenuItem_Click);
            // 
            // valicRemittanceFileToolStripMenuItem
            // 
            this.valicRemittanceFileToolStripMenuItem.Name = "valicRemittanceFileToolStripMenuItem";
            this.valicRemittanceFileToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.valicRemittanceFileToolStripMenuItem.Text = "&Valic Remittance File";
            this.valicRemittanceFileToolStripMenuItem.Click += new System.EventHandler(this.valicRemittanceFileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aCHBatchToolStripMenuItem1,
            this.valicResponseFileToolStripMenuItem,
            this.valicPaidOffLoansReportFileToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // aCHBatchToolStripMenuItem1
            // 
            this.aCHBatchToolStripMenuItem1.Name = "aCHBatchToolStripMenuItem1";
            this.aCHBatchToolStripMenuItem1.Size = new System.Drawing.Size(237, 22);
            this.aCHBatchToolStripMenuItem1.Text = "&ACH Batch";
            this.aCHBatchToolStripMenuItem1.Click += new System.EventHandler(this.aCHBatchToolStripMenuItem1_Click);
            // 
            // valicResponseFileToolStripMenuItem
            // 
            this.valicResponseFileToolStripMenuItem.Name = "valicResponseFileToolStripMenuItem";
            this.valicResponseFileToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.valicResponseFileToolStripMenuItem.Text = "Valic Loan Feedback File";
            this.valicResponseFileToolStripMenuItem.Click += new System.EventHandler(this.valicResponseFileToolStripMenuItem_Click);
            // 
            // valicPaidOffLoansReportFileToolStripMenuItem
            // 
            this.valicPaidOffLoansReportFileToolStripMenuItem.Name = "valicPaidOffLoansReportFileToolStripMenuItem";
            this.valicPaidOffLoansReportFileToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.valicPaidOffLoansReportFileToolStripMenuItem.Text = "Valic Paid Off Loans Report File";
            this.valicPaidOffLoansReportFileToolStripMenuItem.Click += new System.EventHandler(this.valicPaidOffLoansReportFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // printTimesheetsToolStripMenuItem
            // 
            this.printTimesheetsToolStripMenuItem.Name = "printTimesheetsToolStripMenuItem";
            this.printTimesheetsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.printTimesheetsToolStripMenuItem.Text = "Print Timesheets";
            this.printTimesheetsToolStripMenuItem.Click += new System.EventHandler(this.printTimesheetsToolStripMenuItem_Click);
            // 
            // exportPayStubsToolStripMenuItem
            // 
            this.exportPayStubsToolStripMenuItem.Name = "exportPayStubsToolStripMenuItem";
            this.exportPayStubsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exportPayStubsToolStripMenuItem.Text = "Export &Pay Stubs";
            this.exportPayStubsToolStripMenuItem.Click += new System.EventHandler(this.exportPayStubsToolStripMenuItem_Click);
            // 
            // oSHAWorksheetToolStripMenuItem
            // 
            this.oSHAWorksheetToolStripMenuItem.Name = "oSHAWorksheetToolStripMenuItem";
            this.oSHAWorksheetToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.oSHAWorksheetToolStripMenuItem.Text = "OSHA &Worksheet";
            this.oSHAWorksheetToolStripMenuItem.Click += new System.EventHandler(this.oSHAWorksheetToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutHSAACHFileCreatorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutHSAACHFileCreatorToolStripMenuItem
            // 
            this.aboutHSAACHFileCreatorToolStripMenuItem.Name = "aboutHSAACHFileCreatorToolStripMenuItem";
            this.aboutHSAACHFileCreatorToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.aboutHSAACHFileCreatorToolStripMenuItem.Text = "&About HSA ACH File Creator";
            this.aboutHSAACHFileCreatorToolStripMenuItem.Click += new System.EventHandler(this.aboutHSAACHFileCreatorToolStripMenuItem_Click);
            // 
            // benefitsToolStripMenuItem
            // 
            this.benefitsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createVisionFileToolStripMenuItem});
            this.benefitsToolStripMenuItem.Name = "benefitsToolStripMenuItem";
            this.benefitsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.benefitsToolStripMenuItem.Text = "&Benefits";
            this.benefitsToolStripMenuItem.Visible = false;
            // 
            // createVisionFileToolStripMenuItem
            // 
            this.createVisionFileToolStripMenuItem.Name = "createVisionFileToolStripMenuItem";
            this.createVisionFileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.createVisionFileToolStripMenuItem.Text = "Create &Vision File";
            this.createVisionFileToolStripMenuItem.Click += new System.EventHandler(this.createVisionFileToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 442);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "HSA ACH File Creator (2023-12-14)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCHBatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCHBatchToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutHSAACHFileCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPayStubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem printTimesheetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benefitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createVisionFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oSHAWorksheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valicRemittanceFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valicResponseFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valicPaidOffLoansReportFileToolStripMenuItem;
    }
}

