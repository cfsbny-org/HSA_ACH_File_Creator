namespace Cfs.Custom.Software
{
    partial class PrintTimesheets
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exemptPtoButton = new System.Windows.Forms.Button();
            this.missingTimesheetsButton = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.usersList = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.buttonPrinted = new System.Windows.Forms.Button();
            this.runTimesheets = new System.Windows.Forms.Button();
            this.payDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.createUltiProFile = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.createUltiProFile);
            this.panel1.Controls.Add(this.exemptPtoButton);
            this.panel1.Controls.Add(this.missingTimesheetsButton);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.usersList);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.buttonPrinted);
            this.panel1.Controls.Add(this.runTimesheets);
            this.panel1.Controls.Add(this.payDatePicker);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1038, 133);
            this.panel1.TabIndex = 0;
            // 
            // exemptPtoButton
            // 
            this.exemptPtoButton.Location = new System.Drawing.Point(198, 68);
            this.exemptPtoButton.Name = "exemptPtoButton";
            this.exemptPtoButton.Size = new System.Drawing.Size(124, 23);
            this.exemptPtoButton.TabIndex = 11;
            this.exemptPtoButton.Text = "exempt pto";
            this.exemptPtoButton.UseVisualStyleBackColor = true;
            this.exemptPtoButton.Click += new System.EventHandler(this.exemptPtoButton_Click);
            // 
            // missingTimesheetsButton
            // 
            this.missingTimesheetsButton.Location = new System.Drawing.Point(330, 68);
            this.missingTimesheetsButton.Name = "missingTimesheetsButton";
            this.missingTimesheetsButton.Size = new System.Drawing.Size(135, 23);
            this.missingTimesheetsButton.TabIndex = 10;
            this.missingTimesheetsButton.Text = "missing timesheets";
            this.missingTimesheetsButton.UseVisualStyleBackColor = true;
            this.missingTimesheetsButton.Click += new System.EventHandler(this.missingTimesheetsButton_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(913, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(590, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search by User:";
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(685, 38);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(217, 22);
            this.usersList.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(453, 39);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(46, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // buttonPrinted
            // 
            this.buttonPrinted.Enabled = false;
            this.buttonPrinted.Location = new System.Drawing.Point(330, 39);
            this.buttonPrinted.Name = "buttonPrinted";
            this.buttonPrinted.Size = new System.Drawing.Size(117, 23);
            this.buttonPrinted.TabIndex = 5;
            this.buttonPrinted.Text = "mark as printed";
            this.buttonPrinted.UseVisualStyleBackColor = true;
            this.buttonPrinted.Click += new System.EventHandler(this.buttonPrinted_Click);
            // 
            // runTimesheets
            // 
            this.runTimesheets.Location = new System.Drawing.Point(198, 39);
            this.runTimesheets.Name = "runTimesheets";
            this.runTimesheets.Size = new System.Drawing.Size(124, 23);
            this.runTimesheets.TabIndex = 4;
            this.runTimesheets.Text = "view timesheets";
            this.runTimesheets.UseVisualStyleBackColor = true;
            this.runTimesheets.Click += new System.EventHandler(this.runTimesheets_Click);
            // 
            // payDatePicker
            // 
            this.payDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.payDatePicker.Location = new System.Drawing.Point(77, 40);
            this.payDatePicker.Name = "payDatePicker";
            this.payDatePicker.Size = new System.Drawing.Size(106, 22);
            this.payDatePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pay Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Print Timesheets";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 133);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReuseParameterValuesOnRefresh = true;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1038, 510);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.Visible = false;
            this.crystalReportViewer1.ReportRefresh += new CrystalDecisions.Windows.Forms.RefreshEventHandler(this.crystalReportViewer1_ReportRefresh);
            // 
            // createUltiProFile
            // 
            this.createUltiProFile.Location = new System.Drawing.Point(472, 67);
            this.createUltiProFile.Name = "createUltiProFile";
            this.createUltiProFile.Size = new System.Drawing.Size(160, 23);
            this.createUltiProFile.TabIndex = 12;
            this.createUltiProFile.Text = "create ultipro import file";
            this.createUltiProFile.UseVisualStyleBackColor = true;
            this.createUltiProFile.Click += new System.EventHandler(this.createUltiProFile_Click);
            // 
            // PrintTimesheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 643);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PrintTimesheets";
            this.Text = "Print Timesheets";
            this.Load += new System.EventHandler(this.PrintTimesheets_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button runTimesheets;
        private System.Windows.Forms.DateTimePicker payDatePicker;
        private System.Windows.Forms.Button buttonPrinted;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ComboBox usersList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button missingTimesheetsButton;
        private System.Windows.Forms.Button exemptPtoButton;
        private System.Windows.Forms.Button createUltiProFile;
    }
}