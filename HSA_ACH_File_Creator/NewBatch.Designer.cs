namespace Cfs.Custom.Software
{
    partial class NewBatch
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
            System.Windows.Forms.Label achCheckDateLabel;
            System.Windows.Forms.Label achCompanyLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewBatch));
            this.achCheckDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.aCHFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.company = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aCHDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.aCHDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalErAmount_label = new System.Windows.Forms.Label();
            this.totalEmAmount_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.getData_button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.gatData_toolstripButton = new System.Windows.Forms.ToolStripButton();
            this.saveBatch_toolstripButton = new System.Windows.Forms.ToolStripButton();
            this.addEmployeeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printReportToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.previewBatchToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.emailToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.statusImageBox = new System.Windows.Forms.PictureBox();
            this.btnImportUltiProData = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bankAccountTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emAmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            achCheckDateLabel = new System.Windows.Forms.Label();
            achCompanyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHDetailsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHDetailsBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // achCheckDateLabel
            // 
            achCheckDateLabel.AutoSize = true;
            achCheckDateLabel.Location = new System.Drawing.Point(13, 93);
            achCheckDateLabel.Name = "achCheckDateLabel";
            achCheckDateLabel.Size = new System.Drawing.Size(66, 13);
            achCheckDateLabel.TabIndex = 7;
            achCheckDateLabel.Text = "Check Date:";
            // 
            // achCompanyLabel
            // 
            achCompanyLabel.AutoSize = true;
            achCompanyLabel.Location = new System.Drawing.Point(13, 123);
            achCompanyLabel.Name = "achCompanyLabel";
            achCompanyLabel.Size = new System.Drawing.Size(56, 13);
            achCompanyLabel.TabIndex = 9;
            achCompanyLabel.Text = "Company:";
            // 
            // achCheckDateDateTimePicker
            // 
            this.achCheckDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.aCHFileBindingSource, "achCheckDate", true));
            this.achCheckDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.achCheckDateDateTimePicker.Location = new System.Drawing.Point(133, 93);
            this.achCheckDateDateTimePicker.Name = "achCheckDateDateTimePicker";
            this.achCheckDateDateTimePicker.Size = new System.Drawing.Size(121, 21);
            this.achCheckDateDateTimePicker.TabIndex = 8;
            // 
            // aCHFileBindingSource
            // 
            this.aCHFileBindingSource.DataSource = typeof(Cfs.Custom.Software.Data.ACHFile);
            // 
            // company
            // 
            this.company.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.aCHFileBindingSource, "achCompany", true));
            this.company.FormattingEnabled = true;
            this.company.Items.AddRange(new object[] {
            "CFS",
            "SGF",
            "SYB"});
            this.company.Location = new System.Drawing.Point(133, 120);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(121, 21);
            this.company.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 23);
            this.label1.TabIndex = 11;
            this.label1.Text = "Create New Batch";
            // 
            // aCHDetailsDataGridView
            // 
            this.aCHDetailsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aCHDetailsDataGridView.AutoGenerateColumns = false;
            this.aCHDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aCHDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.erAmountColumn,
            this.emAmountColumn,
            this.accountType,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn11});
            this.aCHDetailsDataGridView.DataSource = this.aCHDetailsBindingSource;
            this.aCHDetailsDataGridView.Location = new System.Drawing.Point(12, 157);
            this.aCHDetailsDataGridView.MultiSelect = false;
            this.aCHDetailsDataGridView.Name = "aCHDetailsDataGridView";
            this.aCHDetailsDataGridView.Size = new System.Drawing.Size(878, 429);
            this.aCHDetailsDataGridView.TabIndex = 11;
            this.aCHDetailsDataGridView.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.aCHDetailsDataGridView_RowLeave);
            // 
            // aCHDetailsBindingSource
            // 
            this.aCHDetailsBindingSource.DataMember = "ACHDetails";
            this.aCHDetailsBindingSource.DataSource = this.aCHFileBindingSource;
            // 
            // totalErAmount_label
            // 
            this.totalErAmount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalErAmount_label.AutoSize = true;
            this.totalErAmount_label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalErAmount_label.Location = new System.Drawing.Point(667, 599);
            this.totalErAmount_label.Name = "totalErAmount_label";
            this.totalErAmount_label.Size = new System.Drawing.Size(71, 13);
            this.totalErAmount_label.TabIndex = 12;
            this.totalErAmount_label.Text = "<Total ER>";
            // 
            // totalEmAmount_label
            // 
            this.totalEmAmount_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalEmAmount_label.AutoSize = true;
            this.totalEmAmount_label.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalEmAmount_label.Location = new System.Drawing.Point(666, 629);
            this.totalEmAmount_label.Name = "totalEmAmount_label";
            this.totalEmAmount_label.Size = new System.Drawing.Size(73, 13);
            this.totalEmAmount_label.TabIndex = 13;
            this.totalEmAmount_label.Text = "<Total EM>";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Employer Contribution:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 629);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Total Employee Deductions:";
            // 
            // getData_button
            // 
            this.getData_button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.getData_button.Location = new System.Drawing.Point(274, 91);
            this.getData_button.Name = "getData_button";
            this.getData_button.Size = new System.Drawing.Size(118, 23);
            this.getData_button.TabIndex = 16;
            this.getData_button.Text = "get data";
            this.getData_button.UseVisualStyleBackColor = true;
            this.getData_button.Visible = false;
            this.getData_button.Click += new System.EventHandler(this.getData_button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gatData_toolstripButton,
            this.saveBatch_toolstripButton,
            this.addEmployeeToolStripButton,
            this.toolStripSeparator2,
            this.printReportToolStripButton,
            this.previewBatchToolStripButton1,
            this.toolStripSeparator1,
            this.emailToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(902, 25);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // gatData_toolstripButton
            // 
            this.gatData_toolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.gatData_toolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("gatData_toolstripButton.Image")));
            this.gatData_toolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gatData_toolstripButton.Name = "gatData_toolstripButton";
            this.gatData_toolstripButton.Size = new System.Drawing.Size(23, 22);
            this.gatData_toolstripButton.Text = "Retrieve data from database.";
            this.gatData_toolstripButton.Click += new System.EventHandler(this.getData_button_Click);
            // 
            // saveBatch_toolstripButton
            // 
            this.saveBatch_toolstripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveBatch_toolstripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveBatch_toolstripButton.Image")));
            this.saveBatch_toolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveBatch_toolstripButton.Name = "saveBatch_toolstripButton";
            this.saveBatch_toolstripButton.Size = new System.Drawing.Size(23, 22);
            this.saveBatch_toolstripButton.Text = "Save batch";
            this.saveBatch_toolstripButton.Click += new System.EventHandler(this.saveBatch_toolstripButton_Click);
            // 
            // addEmployeeToolStripButton
            // 
            this.addEmployeeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addEmployeeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addEmployeeToolStripButton.Image")));
            this.addEmployeeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addEmployeeToolStripButton.Name = "addEmployeeToolStripButton";
            this.addEmployeeToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addEmployeeToolStripButton.Text = "Add Employee";
            this.addEmployeeToolStripButton.Click += new System.EventHandler(this.addEmployeeToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // printReportToolStripButton
            // 
            this.printReportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printReportToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printReportToolStripButton.Image")));
            this.printReportToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printReportToolStripButton.Name = "printReportToolStripButton";
            this.printReportToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printReportToolStripButton.Text = "Print Batch";
            this.printReportToolStripButton.Click += new System.EventHandler(this.printReportToolStripButton_Click);
            // 
            // previewBatchToolStripButton1
            // 
            this.previewBatchToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previewBatchToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("previewBatchToolStripButton1.Image")));
            this.previewBatchToolStripButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.previewBatchToolStripButton1.Name = "previewBatchToolStripButton1";
            this.previewBatchToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.previewBatchToolStripButton1.Text = "Preview Batch Details";
            this.previewBatchToolStripButton1.Click += new System.EventHandler(this.previewBatchToolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // emailToolStripButton
            // 
            this.emailToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.emailToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("emailToolStripButton.Image")));
            this.emailToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.emailToolStripButton.Name = "emailToolStripButton";
            this.emailToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.emailToolStripButton.Text = "Send Notification";
            this.emailToolStripButton.Click += new System.EventHandler(this.emailToolStripButton_Click);
            // 
            // printDialog
            // 
            this.printDialog.UseEXDialog = true;
            // 
            // statusImageBox
            // 
            this.statusImageBox.Location = new System.Drawing.Point(400, 92);
            this.statusImageBox.Name = "statusImageBox";
            this.statusImageBox.Size = new System.Drawing.Size(30, 21);
            this.statusImageBox.TabIndex = 18;
            this.statusImageBox.TabStop = false;
            // 
            // btnImportUltiProData
            // 
            this.btnImportUltiProData.Location = new System.Drawing.Point(274, 119);
            this.btnImportUltiProData.Name = "btnImportUltiProData";
            this.btnImportUltiProData.Size = new System.Drawing.Size(156, 23);
            this.btnImportUltiProData.TabIndex = 19;
            this.btnImportUltiProData.Text = "import UltiPro data";
            this.btnImportUltiProData.UseVisualStyleBackColor = true;
            this.btnImportUltiProData.Click += new System.EventHandler(this.btnImportUltiProData_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
            // 
            // bankAccountTypesBindingSource
            // 
            this.bankAccountTypesBindingSource.DataSource = typeof(Cfs.Custom.Software.Data.BankAccountType);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "achDetailId";
            this.dataGridViewTextBoxColumn1.HeaderText = "achDetailId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "achBatchId";
            this.dataGridViewTextBoxColumn2.HeaderText = "achBatchId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "employeeId";
            this.dataGridViewTextBoxColumn3.HeaderText = "Employee ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "lastName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "firstName";
            this.dataGridViewTextBoxColumn5.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "middleInitial";
            this.dataGridViewTextBoxColumn6.HeaderText = "MI";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // erAmountColumn
            // 
            this.erAmountColumn.DataPropertyName = "erAmount";
            this.erAmountColumn.HeaderText = "Employer Contribution";
            this.erAmountColumn.MaxInputLength = 20;
            this.erAmountColumn.Name = "erAmountColumn";
            // 
            // emAmountColumn
            // 
            this.emAmountColumn.DataPropertyName = "emAmount";
            this.emAmountColumn.HeaderText = "Employee Deduction";
            this.emAmountColumn.MaxInputLength = 20;
            this.emAmountColumn.Name = "emAmountColumn";
            // 
            // accountType
            // 
            this.accountType.DataPropertyName = "accountType";
            this.accountType.DataSource = this.bankAccountTypesBindingSource;
            this.accountType.DisplayMember = "accountTypeDetail";
            this.accountType.HeaderText = "Account Type";
            this.accountType.Name = "accountType";
            this.accountType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accountType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.accountType.ValueMember = "accountTypeId";
            this.accountType.Width = 160;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "routingNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "Routing Number";
            this.dataGridViewTextBoxColumn9.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "accountNumber";
            this.dataGridViewTextBoxColumn10.HeaderText = "Account Number";
            this.dataGridViewTextBoxColumn10.MaxInputLength = 20;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "includeInFile";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Include In File?";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ACHFile";
            this.dataGridViewTextBoxColumn11.HeaderText = "ACHFile";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // NewBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 654);
            this.Controls.Add(this.btnImportUltiProData);
            this.Controls.Add(this.statusImageBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.getData_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.totalEmAmount_label);
            this.Controls.Add(this.totalErAmount_label);
            this.Controls.Add(this.aCHDetailsDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.company);
            this.Controls.Add(achCheckDateLabel);
            this.Controls.Add(this.achCheckDateDateTimePicker);
            this.Controls.Add(achCompanyLabel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewBatch";
            this.Text = "New ACH File Batch";
            this.Load += new System.EventHandler(this.NewBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.aCHFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHDetailsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aCHDetailsBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankAccountTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource aCHFileBindingSource;
        private System.Windows.Forms.DateTimePicker achCheckDateDateTimePicker;
        private System.Windows.Forms.ComboBox company;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource aCHDetailsBindingSource;
        private System.Windows.Forms.DataGridView aCHDetailsDataGridView;
        private System.Windows.Forms.Label totalErAmount_label;
        private System.Windows.Forms.Label totalEmAmount_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button getData_button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton gatData_toolstripButton;
        private System.Windows.Forms.ToolStripButton saveBatch_toolstripButton;
        private System.Windows.Forms.ToolStripButton printReportToolStripButton;
        private System.Windows.Forms.ToolStripButton previewBatchToolStripButton1;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton emailToolStripButton;
        private System.Windows.Forms.ToolStripButton addEmployeeToolStripButton;
        private System.Windows.Forms.PictureBox statusImageBox;
        private System.Windows.Forms.Button btnImportUltiProData;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bankAccountTypesBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn erAmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emAmountColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn accountType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
    }
}