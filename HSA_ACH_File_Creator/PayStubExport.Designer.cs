namespace Cfs.Custom.Software
{
    partial class PayStubExport
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.payDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.stubDataView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.payrollYear = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.companyList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkStubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stubBatchIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stubBatchCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stubBatchCreatedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUploadedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.uploadedStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVoidedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.voidedStampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voidedReasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.stubDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStubBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "create file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pay Stub Exporter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "1.  Create Export File";
            // 
            // payDate
            // 
            this.payDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.payDate.Location = new System.Drawing.Point(128, 135);
            this.payDate.Name = "payDate";
            this.payDate.Size = new System.Drawing.Size(103, 23);
            this.payDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pay Date:";
            // 
            // stubDataView
            // 
            this.stubDataView.AllowUserToAddRows = false;
            this.stubDataView.AllowUserToDeleteRows = false;
            this.stubDataView.AutoGenerateColumns = false;
            this.stubDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stubDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.stubBatchIdDataGridViewTextBoxColumn,
            this.stubBatchCreatedDataGridViewTextBoxColumn,
            this.stubBatchCreatedByDataGridViewTextBoxColumn,
            this.checkDateDataGridViewTextBoxColumn,
            this.companyIdDataGridViewTextBoxColumn,
            this.isUploadedDataGridViewCheckBoxColumn,
            this.uploadedStampDataGridViewTextBoxColumn,
            this.isVoidedDataGridViewCheckBoxColumn,
            this.voidedStampDataGridViewTextBoxColumn,
            this.voidedReasonDataGridViewTextBoxColumn});
            this.stubDataView.DataSource = this.checkStubBindingSource;
            this.stubDataView.Location = new System.Drawing.Point(20, 341);
            this.stubDataView.Name = "stubDataView";
            this.stubDataView.ReadOnly = true;
            this.stubDataView.Size = new System.Drawing.Size(574, 211);
            this.stubDataView.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "2. Manage Exported Data";
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(438, 567);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 7;
            this.uploadButton.Text = "upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(519, 567);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "void";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(357, 567);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(75, 23);
            this.viewButton.TabIndex = 9;
            this.viewButton.Text = "view";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Visible = false;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // payrollYear
            // 
            this.payrollYear.FormattingEnabled = true;
            this.payrollYear.Location = new System.Drawing.Point(128, 106);
            this.payrollYear.Name = "payrollYear";
            this.payrollYear.Size = new System.Drawing.Size(121, 23);
            this.payrollYear.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Payroll Year:";
            // 
            // companyList
            // 
            this.companyList.FormattingEnabled = true;
            this.companyList.Items.AddRange(new object[] {
            "CFS",
            "SGF"});
            this.companyList.Location = new System.Drawing.Point(128, 164);
            this.companyList.Name = "companyList";
            this.companyList.Size = new System.Drawing.Size(121, 23);
            this.companyList.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Company:";
            // 
            // checkStubBindingSource
            // 
            this.checkStubBindingSource.DataSource = typeof(Cfs.Custom.Software.Data.CheckStub);
            // 
            // stubBatchIdDataGridViewTextBoxColumn
            // 
            this.stubBatchIdDataGridViewTextBoxColumn.DataPropertyName = "stubBatchId";
            this.stubBatchIdDataGridViewTextBoxColumn.HeaderText = "Batch ID";
            this.stubBatchIdDataGridViewTextBoxColumn.Name = "stubBatchIdDataGridViewTextBoxColumn";
            this.stubBatchIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stubBatchCreatedDataGridViewTextBoxColumn
            // 
            this.stubBatchCreatedDataGridViewTextBoxColumn.DataPropertyName = "stubBatchCreated";
            this.stubBatchCreatedDataGridViewTextBoxColumn.HeaderText = "Created";
            this.stubBatchCreatedDataGridViewTextBoxColumn.Name = "stubBatchCreatedDataGridViewTextBoxColumn";
            this.stubBatchCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stubBatchCreatedByDataGridViewTextBoxColumn
            // 
            this.stubBatchCreatedByDataGridViewTextBoxColumn.DataPropertyName = "stubBatchCreatedBy";
            this.stubBatchCreatedByDataGridViewTextBoxColumn.HeaderText = "Created By";
            this.stubBatchCreatedByDataGridViewTextBoxColumn.Name = "stubBatchCreatedByDataGridViewTextBoxColumn";
            this.stubBatchCreatedByDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // checkDateDataGridViewTextBoxColumn
            // 
            this.checkDateDataGridViewTextBoxColumn.DataPropertyName = "checkDate";
            this.checkDateDataGridViewTextBoxColumn.HeaderText = "Check Date";
            this.checkDateDataGridViewTextBoxColumn.Name = "checkDateDataGridViewTextBoxColumn";
            this.checkDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // companyIdDataGridViewTextBoxColumn
            // 
            this.companyIdDataGridViewTextBoxColumn.DataPropertyName = "companyId";
            this.companyIdDataGridViewTextBoxColumn.HeaderText = "Company";
            this.companyIdDataGridViewTextBoxColumn.Name = "companyIdDataGridViewTextBoxColumn";
            this.companyIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isUploadedDataGridViewCheckBoxColumn
            // 
            this.isUploadedDataGridViewCheckBoxColumn.DataPropertyName = "isUploaded";
            this.isUploadedDataGridViewCheckBoxColumn.HeaderText = "Uploaded?";
            this.isUploadedDataGridViewCheckBoxColumn.Name = "isUploadedDataGridViewCheckBoxColumn";
            this.isUploadedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // uploadedStampDataGridViewTextBoxColumn
            // 
            this.uploadedStampDataGridViewTextBoxColumn.DataPropertyName = "uploadedStamp";
            this.uploadedStampDataGridViewTextBoxColumn.HeaderText = "UploadedStamp";
            this.uploadedStampDataGridViewTextBoxColumn.Name = "uploadedStampDataGridViewTextBoxColumn";
            this.uploadedStampDataGridViewTextBoxColumn.ReadOnly = true;
            this.uploadedStampDataGridViewTextBoxColumn.Visible = false;
            // 
            // isVoidedDataGridViewCheckBoxColumn
            // 
            this.isVoidedDataGridViewCheckBoxColumn.DataPropertyName = "isVoided";
            this.isVoidedDataGridViewCheckBoxColumn.HeaderText = "isVoided";
            this.isVoidedDataGridViewCheckBoxColumn.Name = "isVoidedDataGridViewCheckBoxColumn";
            this.isVoidedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isVoidedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // voidedStampDataGridViewTextBoxColumn
            // 
            this.voidedStampDataGridViewTextBoxColumn.DataPropertyName = "voidedStamp";
            this.voidedStampDataGridViewTextBoxColumn.HeaderText = "voidedStamp";
            this.voidedStampDataGridViewTextBoxColumn.Name = "voidedStampDataGridViewTextBoxColumn";
            this.voidedStampDataGridViewTextBoxColumn.ReadOnly = true;
            this.voidedStampDataGridViewTextBoxColumn.Visible = false;
            // 
            // voidedReasonDataGridViewTextBoxColumn
            // 
            this.voidedReasonDataGridViewTextBoxColumn.DataPropertyName = "voidedReason";
            this.voidedReasonDataGridViewTextBoxColumn.HeaderText = "voidedReason";
            this.voidedReasonDataGridViewTextBoxColumn.Name = "voidedReasonDataGridViewTextBoxColumn";
            this.voidedReasonDataGridViewTextBoxColumn.ReadOnly = true;
            this.voidedReasonDataGridViewTextBoxColumn.Visible = false;
            // 
            // PayStubExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 602);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.companyList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.payrollYear);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stubDataView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.payDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PayStubExport";
            this.Text = "Pay Stub Exporter";
            this.Load += new System.EventHandler(this.PayStubExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stubDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkStubBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker payDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView stubDataView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.ComboBox payrollYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox companyList;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource checkStubBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn stubBatchIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stubBatchCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stubBatchCreatedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUploadedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploadedStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVoidedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voidedStampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn voidedReasonDataGridViewTextBoxColumn;
    }
}