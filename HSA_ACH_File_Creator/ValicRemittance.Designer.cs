namespace Cfs.Custom.Software
{
    partial class ValicRemittance
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
            this.payDatePicker = new System.Windows.Forms.DateTimePicker();
            this.payDatePickerLabel = new System.Windows.Forms.Label();
            this.companySelect = new System.Windows.Forms.ComboBox();
            this.companySelectLabel = new System.Windows.Forms.Label();
            this.btnGenerateRemittanceFile = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.progressLabel = new System.Windows.Forms.Label();
            this.workerProgressBar = new System.Windows.Forms.ProgressBar();
            this.fileSummaryGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.loansTotalLabel = new System.Windows.Forms.Label();
            this.employerTotalLabel = new System.Windows.Forms.Label();
            this.employeeRothLabel = new System.Windows.Forms.Label();
            this.employeeContribLabel = new System.Windows.Forms.Label();
            this.employeeCountLabel = new System.Windows.Forms.Label();
            this.generatingLabel = new System.Windows.Forms.Label();
            this.openDemoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openDeductionsFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSummaryGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // payDatePicker
            // 
            this.payDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.payDatePicker.Location = new System.Drawing.Point(111, 63);
            this.payDatePicker.Name = "payDatePicker";
            this.payDatePicker.Size = new System.Drawing.Size(98, 22);
            this.payDatePicker.TabIndex = 0;
            // 
            // payDatePickerLabel
            // 
            this.payDatePickerLabel.AutoSize = true;
            this.payDatePickerLabel.Location = new System.Drawing.Point(51, 70);
            this.payDatePickerLabel.Name = "payDatePickerLabel";
            this.payDatePickerLabel.Size = new System.Drawing.Size(54, 13);
            this.payDatePickerLabel.TabIndex = 1;
            this.payDatePickerLabel.Text = "Pay Date:";
            // 
            // companySelect
            // 
            this.companySelect.FormattingEnabled = true;
            this.companySelect.Items.AddRange(new object[] {
            "CFS",
            "SGF"});
            this.companySelect.Location = new System.Drawing.Point(111, 23);
            this.companySelect.Name = "companySelect";
            this.companySelect.Size = new System.Drawing.Size(121, 21);
            this.companySelect.TabIndex = 2;
            // 
            // companySelectLabel
            // 
            this.companySelectLabel.AutoSize = true;
            this.companySelectLabel.Location = new System.Drawing.Point(47, 26);
            this.companySelectLabel.Name = "companySelectLabel";
            this.companySelectLabel.Size = new System.Drawing.Size(58, 13);
            this.companySelectLabel.TabIndex = 3;
            this.companySelectLabel.Text = "Company:";
            // 
            // btnGenerateRemittanceFile
            // 
            this.btnGenerateRemittanceFile.Location = new System.Drawing.Point(111, 106);
            this.btnGenerateRemittanceFile.Name = "btnGenerateRemittanceFile";
            this.btnGenerateRemittanceFile.Size = new System.Drawing.Size(98, 23);
            this.btnGenerateRemittanceFile.TabIndex = 4;
            this.btnGenerateRemittanceFile.Text = "generate file";
            this.btnGenerateRemittanceFile.UseVisualStyleBackColor = true;
            this.btnGenerateRemittanceFile.Click += new System.EventHandler(this.btnGenerateRemittanceFile_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV files|*.csv|All files|*.*";
            this.saveFileDialog.InitialDirectory = "\\\\cfs-filestorage\\hr\\Valic\\Remittance Files";
            this.saveFileDialog.Title = "Save Remittance File";
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(108, 201);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 13);
            this.progressLabel.TabIndex = 5;
            // 
            // workerProgressBar
            // 
            this.workerProgressBar.Location = new System.Drawing.Point(111, 175);
            this.workerProgressBar.Name = "workerProgressBar";
            this.workerProgressBar.Size = new System.Drawing.Size(281, 23);
            this.workerProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.workerProgressBar.TabIndex = 6;
            this.workerProgressBar.Visible = false;
            // 
            // fileSummaryGroup
            // 
            this.fileSummaryGroup.Controls.Add(this.label5);
            this.fileSummaryGroup.Controls.Add(this.label4);
            this.fileSummaryGroup.Controls.Add(this.label3);
            this.fileSummaryGroup.Controls.Add(this.label2);
            this.fileSummaryGroup.Controls.Add(this.label1);
            this.fileSummaryGroup.Controls.Add(this.loansTotalLabel);
            this.fileSummaryGroup.Controls.Add(this.employerTotalLabel);
            this.fileSummaryGroup.Controls.Add(this.employeeRothLabel);
            this.fileSummaryGroup.Controls.Add(this.employeeContribLabel);
            this.fileSummaryGroup.Controls.Add(this.employeeCountLabel);
            this.fileSummaryGroup.Location = new System.Drawing.Point(111, 257);
            this.fileSummaryGroup.Name = "fileSummaryGroup";
            this.fileSummaryGroup.Size = new System.Drawing.Size(281, 190);
            this.fileSummaryGroup.TabIndex = 7;
            this.fileSummaryGroup.TabStop = false;
            this.fileSummaryGroup.Text = "File Summary";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Loan Payments:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Employer Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Roth Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Employee Total:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Employee Count:";
            // 
            // loansTotalLabel
            // 
            this.loansTotalLabel.AutoSize = true;
            this.loansTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loansTotalLabel.Location = new System.Drawing.Point(118, 141);
            this.loansTotalLabel.Name = "loansTotalLabel";
            this.loansTotalLabel.Size = new System.Drawing.Size(0, 13);
            this.loansTotalLabel.TabIndex = 4;
            // 
            // employerTotalLabel
            // 
            this.employerTotalLabel.AutoSize = true;
            this.employerTotalLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employerTotalLabel.Location = new System.Drawing.Point(118, 113);
            this.employerTotalLabel.Name = "employerTotalLabel";
            this.employerTotalLabel.Size = new System.Drawing.Size(0, 13);
            this.employerTotalLabel.TabIndex = 3;
            // 
            // employeeRothLabel
            // 
            this.employeeRothLabel.AutoSize = true;
            this.employeeRothLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRothLabel.Location = new System.Drawing.Point(118, 86);
            this.employeeRothLabel.Name = "employeeRothLabel";
            this.employeeRothLabel.Size = new System.Drawing.Size(0, 13);
            this.employeeRothLabel.TabIndex = 2;
            // 
            // employeeContribLabel
            // 
            this.employeeContribLabel.AutoSize = true;
            this.employeeContribLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeContribLabel.Location = new System.Drawing.Point(118, 59);
            this.employeeContribLabel.Name = "employeeContribLabel";
            this.employeeContribLabel.Size = new System.Drawing.Size(0, 13);
            this.employeeContribLabel.TabIndex = 1;
            // 
            // employeeCountLabel
            // 
            this.employeeCountLabel.AutoSize = true;
            this.employeeCountLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCountLabel.Location = new System.Drawing.Point(118, 32);
            this.employeeCountLabel.Name = "employeeCountLabel";
            this.employeeCountLabel.Size = new System.Drawing.Size(0, 13);
            this.employeeCountLabel.TabIndex = 0;
            // 
            // generatingLabel
            // 
            this.generatingLabel.AutoSize = true;
            this.generatingLabel.Location = new System.Drawing.Point(111, 156);
            this.generatingLabel.Name = "generatingLabel";
            this.generatingLabel.Size = new System.Drawing.Size(155, 13);
            this.generatingLabel.TabIndex = 8;
            this.generatingLabel.Text = "Remittance FIle Generating...";
            this.generatingLabel.Visible = false;
            // 
            // openDemoFileDialog
            // 
            this.openDemoFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            this.openDemoFileDialog.Title = "Demographics File";
            // 
            // openDeductionsFileDialog
            // 
            this.openDeductionsFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            this.openDeductionsFileDialog.Title = "Deductions File";
            // 
            // ValicRemittance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 472);
            this.Controls.Add(this.generatingLabel);
            this.Controls.Add(this.fileSummaryGroup);
            this.Controls.Add(this.workerProgressBar);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.btnGenerateRemittanceFile);
            this.Controls.Add(this.companySelectLabel);
            this.Controls.Add(this.companySelect);
            this.Controls.Add(this.payDatePickerLabel);
            this.Controls.Add(this.payDatePicker);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ValicRemittance";
            this.Text = "Create Valic Remittance File";
            this.fileSummaryGroup.ResumeLayout(false);
            this.fileSummaryGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker payDatePicker;
        private System.Windows.Forms.Label payDatePickerLabel;
        private System.Windows.Forms.ComboBox companySelect;
        private System.Windows.Forms.Label companySelectLabel;
        private System.Windows.Forms.Button btnGenerateRemittanceFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar workerProgressBar;
        private System.Windows.Forms.GroupBox fileSummaryGroup;
        private System.Windows.Forms.Label generatingLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label loansTotalLabel;
        private System.Windows.Forms.Label employerTotalLabel;
        private System.Windows.Forms.Label employeeRothLabel;
        private System.Windows.Forms.Label employeeContribLabel;
        private System.Windows.Forms.Label employeeCountLabel;
        private System.Windows.Forms.OpenFileDialog openDemoFileDialog;
        private System.Windows.Forms.OpenFileDialog openDeductionsFileDialog;
    }
}