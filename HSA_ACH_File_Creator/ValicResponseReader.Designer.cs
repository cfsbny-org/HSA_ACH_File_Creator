namespace Cfs.Custom.Software
{
    partial class ValicResponseReader
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.valicResponseFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.payGroupIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.socSecNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountFinancedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentFreqDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanInterestRateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentsRemainingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstDueDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repaymentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalLoanRepaymentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loanFinanceChargeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPaymentAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastPaymentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valicResponseFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            this.openFileDialog1.InitialDirectory = "\\\\cfs-filestorage\\hr\\Valic\\Remittance Files";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.payGroupIdDataGridViewTextBoxColumn,
            this.locationCodeDataGridViewTextBoxColumn,
            this.locationNameDataGridViewTextBoxColumn,
            this.socSecNumDataGridViewTextBoxColumn,
            this.employeeIdDataGridViewTextBoxColumn,
            this.loanNumberDataGridViewTextBoxColumn,
            this.amountFinancedDataGridViewTextBoxColumn,
            this.paymentFreqDataGridViewTextBoxColumn,
            this.loanInterestRateDataGridViewTextBoxColumn,
            this.paymentsRemainingDataGridViewTextBoxColumn,
            this.firstDueDateDataGridViewTextBoxColumn,
            this.repaymentAmountDataGridViewTextBoxColumn,
            this.paymentMethodDataGridViewTextBoxColumn,
            this.totalLoanRepaymentDataGridViewTextBoxColumn,
            this.loanFinanceChargeDataGridViewTextBoxColumn,
            this.lastPaymentAmountDataGridViewTextBoxColumn,
            this.lastPaymentDateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.valicResponseFileBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(27, 181);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(733, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // valicResponseFileBindingSource
            // 
            this.valicResponseFileBindingSource.DataSource = typeof(Cfs.Custom.Software.Data.ValicResponseFile);
            // 
            // payGroupIdDataGridViewTextBoxColumn
            // 
            this.payGroupIdDataGridViewTextBoxColumn.DataPropertyName = "payGroupId";
            this.payGroupIdDataGridViewTextBoxColumn.HeaderText = "payGroupId";
            this.payGroupIdDataGridViewTextBoxColumn.Name = "payGroupIdDataGridViewTextBoxColumn";
            // 
            // locationCodeDataGridViewTextBoxColumn
            // 
            this.locationCodeDataGridViewTextBoxColumn.DataPropertyName = "locationCode";
            this.locationCodeDataGridViewTextBoxColumn.HeaderText = "locationCode";
            this.locationCodeDataGridViewTextBoxColumn.Name = "locationCodeDataGridViewTextBoxColumn";
            // 
            // locationNameDataGridViewTextBoxColumn
            // 
            this.locationNameDataGridViewTextBoxColumn.DataPropertyName = "locationName";
            this.locationNameDataGridViewTextBoxColumn.HeaderText = "locationName";
            this.locationNameDataGridViewTextBoxColumn.Name = "locationNameDataGridViewTextBoxColumn";
            // 
            // socSecNumDataGridViewTextBoxColumn
            // 
            this.socSecNumDataGridViewTextBoxColumn.DataPropertyName = "socSecNum";
            this.socSecNumDataGridViewTextBoxColumn.HeaderText = "socSecNum";
            this.socSecNumDataGridViewTextBoxColumn.Name = "socSecNumDataGridViewTextBoxColumn";
            // 
            // employeeIdDataGridViewTextBoxColumn
            // 
            this.employeeIdDataGridViewTextBoxColumn.DataPropertyName = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.HeaderText = "employeeId";
            this.employeeIdDataGridViewTextBoxColumn.Name = "employeeIdDataGridViewTextBoxColumn";
            // 
            // loanNumberDataGridViewTextBoxColumn
            // 
            this.loanNumberDataGridViewTextBoxColumn.DataPropertyName = "loanNumber";
            this.loanNumberDataGridViewTextBoxColumn.HeaderText = "loanNumber";
            this.loanNumberDataGridViewTextBoxColumn.Name = "loanNumberDataGridViewTextBoxColumn";
            // 
            // amountFinancedDataGridViewTextBoxColumn
            // 
            this.amountFinancedDataGridViewTextBoxColumn.DataPropertyName = "amountFinanced";
            this.amountFinancedDataGridViewTextBoxColumn.HeaderText = "amountFinanced";
            this.amountFinancedDataGridViewTextBoxColumn.Name = "amountFinancedDataGridViewTextBoxColumn";
            // 
            // paymentFreqDataGridViewTextBoxColumn
            // 
            this.paymentFreqDataGridViewTextBoxColumn.DataPropertyName = "paymentFreq";
            this.paymentFreqDataGridViewTextBoxColumn.HeaderText = "paymentFreq";
            this.paymentFreqDataGridViewTextBoxColumn.Name = "paymentFreqDataGridViewTextBoxColumn";
            // 
            // loanInterestRateDataGridViewTextBoxColumn
            // 
            this.loanInterestRateDataGridViewTextBoxColumn.DataPropertyName = "loanInterestRate";
            this.loanInterestRateDataGridViewTextBoxColumn.HeaderText = "loanInterestRate";
            this.loanInterestRateDataGridViewTextBoxColumn.Name = "loanInterestRateDataGridViewTextBoxColumn";
            // 
            // paymentsRemainingDataGridViewTextBoxColumn
            // 
            this.paymentsRemainingDataGridViewTextBoxColumn.DataPropertyName = "paymentsRemaining";
            this.paymentsRemainingDataGridViewTextBoxColumn.HeaderText = "paymentsRemaining";
            this.paymentsRemainingDataGridViewTextBoxColumn.Name = "paymentsRemainingDataGridViewTextBoxColumn";
            // 
            // firstDueDateDataGridViewTextBoxColumn
            // 
            this.firstDueDateDataGridViewTextBoxColumn.DataPropertyName = "firstDueDate";
            this.firstDueDateDataGridViewTextBoxColumn.HeaderText = "firstDueDate";
            this.firstDueDateDataGridViewTextBoxColumn.Name = "firstDueDateDataGridViewTextBoxColumn";
            // 
            // repaymentAmountDataGridViewTextBoxColumn
            // 
            this.repaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "repaymentAmount";
            this.repaymentAmountDataGridViewTextBoxColumn.HeaderText = "repaymentAmount";
            this.repaymentAmountDataGridViewTextBoxColumn.Name = "repaymentAmountDataGridViewTextBoxColumn";
            // 
            // paymentMethodDataGridViewTextBoxColumn
            // 
            this.paymentMethodDataGridViewTextBoxColumn.DataPropertyName = "paymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.HeaderText = "paymentMethod";
            this.paymentMethodDataGridViewTextBoxColumn.Name = "paymentMethodDataGridViewTextBoxColumn";
            // 
            // totalLoanRepaymentDataGridViewTextBoxColumn
            // 
            this.totalLoanRepaymentDataGridViewTextBoxColumn.DataPropertyName = "totalLoanRepayment";
            this.totalLoanRepaymentDataGridViewTextBoxColumn.HeaderText = "totalLoanRepayment";
            this.totalLoanRepaymentDataGridViewTextBoxColumn.Name = "totalLoanRepaymentDataGridViewTextBoxColumn";
            // 
            // loanFinanceChargeDataGridViewTextBoxColumn
            // 
            this.loanFinanceChargeDataGridViewTextBoxColumn.DataPropertyName = "loanFinanceCharge";
            this.loanFinanceChargeDataGridViewTextBoxColumn.HeaderText = "loanFinanceCharge";
            this.loanFinanceChargeDataGridViewTextBoxColumn.Name = "loanFinanceChargeDataGridViewTextBoxColumn";
            // 
            // lastPaymentAmountDataGridViewTextBoxColumn
            // 
            this.lastPaymentAmountDataGridViewTextBoxColumn.DataPropertyName = "lastPaymentAmount";
            this.lastPaymentAmountDataGridViewTextBoxColumn.HeaderText = "lastPaymentAmount";
            this.lastPaymentAmountDataGridViewTextBoxColumn.Name = "lastPaymentAmountDataGridViewTextBoxColumn";
            // 
            // lastPaymentDateDataGridViewTextBoxColumn
            // 
            this.lastPaymentDateDataGridViewTextBoxColumn.DataPropertyName = "lastPaymentDate";
            this.lastPaymentDateDataGridViewTextBoxColumn.HeaderText = "lastPaymentDate";
            this.lastPaymentDateDataGridViewTextBoxColumn.Name = "lastPaymentDateDataGridViewTextBoxColumn";
            // 
            // ValicResponseReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 520);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ValicResponseReader";
            this.Text = "Valic Response File Reader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ValicResponseReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valicResponseFileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn payGroupIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn socSecNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountFinancedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentFreqDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanInterestRateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentsRemainingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstDueDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repaymentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalLoanRepaymentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loanFinanceChargeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPaymentAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPaymentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource valicResponseFileBindingSource;
    }
}