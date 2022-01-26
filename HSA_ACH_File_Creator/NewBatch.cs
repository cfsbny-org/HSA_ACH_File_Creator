using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using OfficeOpenXml;

namespace Cfs.Custom.Software
{
    public partial class NewBatch : Form
    {

        private Data.BenefitsDbDataContext context = new Cfs.Custom.Software.Data.BenefitsDbDataContext();
        private long _batchId = 0;


        private BackgroundWorker abraWorker;


        public NewBatch()
        {
            InitializeComponent();

            this.abraWorker = new BackgroundWorker();
            this.abraWorker.DoWork += new DoWorkEventHandler(abraWorker_DoWork);
            this.abraWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(abraWorker_RunWorkerCompleted);
        }




        private void NewBatch_Load(object sender, EventArgs e)
        {
            var accountTypes = (from types in this.context.BankAccountTypes
                                select types).ToList();

            this.bankAccountTypesBindingSource.DataSource = accountTypes;
        }




        private void getData_button_Click(object sender, EventArgs e)
        {

            string company = this.company.SelectedItem.ToString();
            DateTime checkDate = DateTime.Parse(this.achCheckDateDateTimePicker.Text);

            //ThreadStart starter = delegate { getHsaDataFromAbra(company, checkDate); };
            //new Thread(starter).Start();

            //this.getHsaDataFromAbra(company, checkDate);

            Data.HsaObjects.BatchParameters parameters = new Data.HsaObjects.BatchParameters();
            parameters.company = company;
            parameters.checkDate = checkDate;

            this.statusImageBox.Image = Properties.Resources.running_img;

            this.abraWorker.RunWorkerAsync(parameters);

        }


        private void btnImportUltiProData_Click(object sender, EventArgs e)
        {

            if (this.company.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Company.", "Company", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string company = this.company.SelectedItem.ToString();
            DateTime checkDate = DateTime.Parse(this.achCheckDateDateTimePicker.Text);

            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string filePath = this.openFileDialog1.FileName;
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(new FileInfo(filePath));

                //ExcelWorksheet sheet = package.Workbook.Worksheets[1];
                var sheetList = package.Workbook.Worksheets.ToList();
                ExcelWorksheet sheet = sheetList.First();

                Data.ACHFile newFile = new Cfs.Custom.Software.Data.ACHFile();

                newFile.achBatchCreated = DateTime.Now;
                newFile.achBatchCreatedBy = Environment.UserName;
                newFile.achCheckDate = checkDate;
                newFile.achCompany = company;
                newFile.achFileStatus = 'N';
                newFile.achTotalAmount = 0;

                context.ACHFiles.InsertOnSubmit(newFile);
                context.SubmitChanges();

                System.Diagnostics.Debug.WriteLine("Batch record created.");

                this._batchId = newFile.achBatchId;


                for (int row = 2; row <= sheet.Dimension.End.Row; row++)
                {

                    string accountType = "32";

                    string accountTypeString = sheet.Cells[row, 14].Value.ToString().Trim();
                    switch (accountTypeString)
                    {
                        case "Checking":
                            accountType = "22";
                            break;
                    }


                    decimal erAmount = 0;
                    decimal emAmount = 0;

                    string deductionCode = sheet.Cells[row, 8].Value.ToString().Trim();

                    switch (deductionCode)
                    {
                        case "HSAFM":
                        case "HSAS":
                            erAmount = decimal.Parse(sheet.Cells[row, 9].Value.ToString());
                            break;
                        default:
                            emAmount = decimal.Parse(sheet.Cells[row, 9].Value.ToString());
                            break;
                    }


                    Data.ACHDetail detail = new Cfs.Custom.Software.Data.ACHDetail();

                    detail.achBatchId = this._batchId;
                    detail.employeeId = sheet.Cells[row, 1].Value.ToString();
                    detail.lastName = sheet.Cells[row, 2].Value.ToString();
                    detail.firstName = sheet.Cells[row, 3].Value.ToString();
                    detail.middleInitial = sheet.Cells[row, 4].Value == null ? string.Empty : sheet.Cells[row, 4].Value.ToString();
                    detail.erAmount = erAmount;
                    detail.emAmount = emAmount;
                    detail.accountType = accountType;
                    detail.routingNumber = sheet.Cells[row, 11].Value == null ? string.Empty : sheet.Cells[row, 11].Value.ToString();
                    detail.accountNumber = sheet.Cells[row, 12].Value == null ? string.Empty : sheet.Cells[row, 12].Value.ToString();
                    detail.includeInFile = true;


                    context.ACHDetails.InsertOnSubmit(detail);
                }

                context.SubmitChanges();

                // CLOSE EXCEL SPREADSHEET
                package.Dispose();


                


                var achDetail = from details in context.ACHDetails
                                where details.achBatchId == this._batchId
                                select details;

                this.aCHDetailsBindingSource.DataSource = achDetail;



                this.updateBalances();

            }

            
            
            

            //string company = this.company.SelectedItem.ToString();
            //DateTime checkDate = DateTime.Parse(this.achCheckDateDateTimePicker.Text);

            ////ThreadStart starter = delegate { getHsaDataFromAbra(company, checkDate); };
            ////new Thread(starter).Start();

            ////this.getHsaDataFromAbra(company, checkDate);

            //Data.HsaObjects.BatchParameters parameters = new Data.HsaObjects.BatchParameters();
            //parameters.company = company;
            //parameters.checkDate = checkDate;

            

        }


        private void getHsaDataFromAbra(string company, string checkDate)
        {
            DataSet ds = new DataSet();
            DataTable employee = new DataTable("Employee");

            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\data;Collating Sequence=general;";

            OleDbConnection conn = new OleDbConnection(connString);
            StringBuilder query = new StringBuilder();

            query.Append("SELECT h.p_empno, h.p_lname, h.p_fname, h.p_mi, h.p_ssn, d.amount, d.erliab, t.u_abanum, t.u_acctnum, t.u_accttype ");
            //query.Append("TRIM(h.p_lname) + ', ' + TRIM(h.p_fname) + ' ' + TRIM(h.p_mi) AS FullName ");
            query.Append("FROM prdehist d INNER JOIN prckhist c ");
            query.Append("ON (d.company = c.company AND d.empno = c.empno AND d.chknumber = c.chknumber) ");
            query.Append("INNER JOIN hrpersnl h ON (d.company = h.p_company AND d.empno = h.p_empno) ");
            query.Append("INNER JOIN hrtkpers t ON (h.p_company = t.u_company AND h.p_empno = t.u_empno) ");
            query.Append("WHERE d.company = '" + company + "' AND ");
            query.Append("d.code IN ('HSAS','HSAF','HSAE','HSA','HSP1','HSAN') AND c.chkdate = {" + checkDate + "} ");
            query.Append("ORDER BY h.p_lname, h.p_fname, d.erliab;");
            //query.Append("AND (NOT (t.u_acctnum IS NULL) OR t.u_acctnum <> '');");



            OleDbCommand comm = new OleDbCommand(query.ToString(), conn);
            comm.CommandType = System.Data.CommandType.Text;


            try
            {
                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
                adapter.Fill(employee);

                ds.Tables.Add(employee);

                adapter.Dispose();

                conn.Close();
                conn.Dispose();

                // MessageBox.Show(employee.Rows.Count.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            Data.ACHFile newFile = new Cfs.Custom.Software.Data.ACHFile();

            newFile.achBatchCreated = DateTime.Now;
            newFile.achBatchCreatedBy = Environment.UserName;
            newFile.achCheckDate = DateTime.Parse(checkDate);
            newFile.achCompany = company;
            newFile.achFileStatus = 'N';
            newFile.achTotalAmount = 0;

            context.ACHFiles.InsertOnSubmit(newFile);
            context.SubmitChanges();

            this._batchId = newFile.achBatchId;
            decimal totalErAmount = 0;
            decimal totalEmAmount = 0;

            foreach (DataRow row in employee.Rows)
            {

                Data.ACHDetail detail = new Cfs.Custom.Software.Data.ACHDetail();

                detail.achBatchId = this._batchId;
                detail.employeeId = row["p_empno"].ToString();
                detail.lastName = row["p_lname"].ToString();
                detail.firstName = row["p_fname"].ToString();
                detail.middleInitial = row["p_mi"].ToString();
                detail.erAmount = decimal.Parse(row["erliab"].ToString());
                detail.emAmount = decimal.Parse(row["amount"].ToString());
                detail.accountType = row["u_accttype"] == null ? "32" : row["u_accttype"].ToString();
                detail.routingNumber = row["u_abanum"].ToString();
                detail.accountNumber = row["u_acctnum"].ToString();
                detail.includeInFile = true;

                totalErAmount += decimal.Parse(row["erliab"].ToString());
                totalEmAmount += decimal.Parse(row["amount"].ToString());

                context.ACHDetails.InsertOnSubmit(detail);
            }

            this.totalErAmount_label.Text = totalErAmount.ToString("$#.00");
            this.totalEmAmount_label.Text = totalEmAmount.ToString("$#.00");

            context.SubmitChanges();

            var detailsQuery = from details in context.ACHDetails
                               where details.achBatchId == this._batchId
                               select details;

            this.aCHDetailsBindingSource.DataSource = detailsQuery;
        }



        private void abraWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            Data.HsaObjects.BatchParameters parameters = (Data.HsaObjects.BatchParameters)e.Argument;
            string company = parameters.company;
            string checkDate = parameters.checkDate.ToShortDateString();

            DataSet ds = new DataSet();
            DataTable employee = new DataTable("Employee");

            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\data;Collating Sequence=general;";

            OleDbConnection conn = new OleDbConnection(connString);
            StringBuilder query = new StringBuilder();

            query.Append("SELECT h.p_empno, h.p_lname, h.p_fname, h.p_mi, h.p_ssn, d.amount, d.erliab, t.u_abanum, t.u_acctnum, t.u_accttype ");
            //query.Append("TRIM(h.p_lname) + ', ' + TRIM(h.p_fname) + ' ' + TRIM(h.p_mi) AS FullName ");
            query.Append("FROM prdehist d INNER JOIN prckhist c ");
            query.Append("ON (d.company = c.company AND d.empno = c.empno AND d.chknumber = c.chknumber) ");
            query.Append("INNER JOIN hrpersnl h ON (d.company = h.p_company AND d.empno = h.p_empno) ");
            query.Append("INNER JOIN hrtkpers t ON (h.p_company = t.u_company AND h.p_empno = t.u_empno) ");
            query.Append("WHERE d.company = '" + company + "' AND ");
            query.Append("d.code IN ('HSAS','HSAF','HSAE','HSA','HSP1','HSAN') AND c.chkdate = {" + checkDate + "} ");
            query.Append("ORDER BY h.p_lname, h.p_fname, d.erliab;");
            //query.Append("AND (NOT (t.u_acctnum IS NULL) OR t.u_acctnum <> '');");



            OleDbCommand comm = new OleDbCommand(query.ToString(), conn);
            comm.CommandType = System.Data.CommandType.Text;



            conn.Open();

            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            adapter.Fill(employee);

            ds.Tables.Add(employee);

            adapter.Dispose();

            conn.Close();
            conn.Dispose();

            // MessageBox.Show(employee.Rows.Count.ToString(), "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            System.Diagnostics.Debug.WriteLine("Abra Query Completed.");

            Data.ACHFile newFile = new Cfs.Custom.Software.Data.ACHFile();

            newFile.achBatchCreated = DateTime.Now;
            newFile.achBatchCreatedBy = Environment.UserName;
            newFile.achCheckDate = DateTime.Parse(checkDate);
            newFile.achCompany = company;
            newFile.achFileStatus = 'N';
            newFile.achTotalAmount = 0;

            context.ACHFiles.InsertOnSubmit(newFile);
            context.SubmitChanges();

            System.Diagnostics.Debug.WriteLine("Batch record created.");

            this._batchId = newFile.achBatchId;

            System.Diagnostics.Debug.WriteLine("Batch ID: " + this._batchId.ToString());
            System.Diagnostics.Debug.WriteLine("Employee Rows: " + employee.Rows.Count.ToString());

            foreach (DataRow row in employee.Rows)
            {

                Data.ACHDetail detail = new Cfs.Custom.Software.Data.ACHDetail();

                detail.achBatchId = this._batchId;
                detail.employeeId = row["p_empno"].ToString();
                detail.lastName = row["p_lname"].ToString();
                detail.firstName = row["p_fname"].ToString();
                detail.middleInitial = row["p_mi"].ToString();
                detail.erAmount = decimal.Parse(row["erliab"].ToString());
                detail.emAmount = decimal.Parse(row["amount"].ToString());
                detail.accountType = row["u_accttype"] == null ? "32" : row["u_accttype"].ToString();
                detail.routingNumber = row["u_abanum"].ToString();
                detail.accountNumber = row["u_acctnum"].ToString();
                detail.includeInFile = true;


                context.ACHDetails.InsertOnSubmit(detail);
            }



            context.SubmitChanges();

            System.Diagnostics.Debug.WriteLine("Batch details saved.");

            var detailsQuery = from details in context.ACHDetails
                               where details.achBatchId == this._batchId
                               select details;

            //this.aCHDetailsBindingSource.DataSource = detailsQuery;

            e.Result = detailsQuery;

            System.Diagnostics.Debug.WriteLine("Worker Completed.");
        }


        private void abraWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                System.Diagnostics.Debug.WriteLine("Worker cancelled.");
            }
            else if (e.Error != null)
            {
                Exception ex = (Exception)e.Error;
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += Environment.NewLine + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Error Getting Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Worker completed successfully.");

                if (e.Result == null)
                {
                    System.Diagnostics.Debug.WriteLine("Result is null.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Result is not null");

                    IQueryable<Data.ACHDetail> achDetail = (IQueryable<Data.ACHDetail>)e.Result;
                    this.aCHDetailsBindingSource.DataSource = achDetail;


                    
                    this.updateBalances();
                    this.statusImageBox.Image = null;
                }
            }
        }



        private void saveBatch_toolstripButton_Click(object sender, EventArgs e)
        {
            context.SubmitChanges();
        }


        private void printReportToolStripButton_Click(object sender, EventArgs e)
        {

            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-intranet\Abra Reports\Misc\ACH Batch Details.rpt");

            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["BatchId"];
       

            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = this._batchId;

            ParameterValues values = new ParameterValues();
            values = parameter.CurrentValues;
            values.Clear();
            values.Add(parameterValue);
            parameter.ApplyCurrentValues(values);

           

            if (this.printDialog.ShowDialog() == DialogResult.OK)
            {
                report.PrintOptions.PrinterName = this.printDialog.PrinterSettings.PrinterName;
                report.PrintToPrinter(1, false, 0, 0);

            }



        }

        private void previewBatchToolStripButton1_Click(object sender, EventArgs e)
        {
            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-fileserv01\ACHReports\ACH Batch Details.rpt");

            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["BatchId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = this._batchId;

            ParameterValues values = new ParameterValues();
            values = parameter.CurrentValues;
            values.Clear();
            values.Add(parameterValue);
            parameter.ApplyCurrentValues(values);


            Reports.PreviewReport preview = new Cfs.Custom.Software.Reports.PreviewReport();
            preview.Report = report;
            preview.MdiParent = this.ParentForm;
            preview.Show();
        }


        private void emailToolStripButton_Click(object sender, EventArgs e)
        {

            SendEmail email = new SendEmail();
            email.BatchId = this._batchId;
            email.MdiParent = this.ParentForm;
            email.Show();

            

        }

        


        private void updateBalances()
        {

            

            decimal totalErAmount = 0;
            decimal totalEmAmount = 0;

            try
            {

                System.Diagnostics.Debug.WriteLine("Updating Balances..." + DateTime.Now.ToString());

                IQueryable<Data.ACHDetail> achDetail = (IQueryable<Data.ACHDetail>)this.aCHDetailsBindingSource.DataSource;

                totalErAmount = achDetail.Sum(d => d.erAmount);
                totalEmAmount = achDetail.Sum(d => d.emAmount);

                this.totalErAmount_label.Text = totalErAmount.ToString("C");
                this.totalEmAmount_label.Text = totalEmAmount.ToString("C");
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += Environment.NewLine + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Error Updating Totals", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //foreach (DataGridViewRow row in this.aCHDetailsDataGridView.Rows)
            //{
                
            //    decimal erAmount = (decimal)row.Cells["erAmountColumn"].Value;
            //    decimal emAmount = (decimal)row.Cells["emAmountColumn"].Value;

            //    totalErAmount += erAmount;
            //    totalEmAmount += emAmount;
            //}

            //this.totalErAmount_label.Text = totalErAmount.ToString("C");
            //this.totalEmAmount_label.Text = totalEmAmount.ToString("C");
        }



        private void aCHDetailsDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (this.aCHDetailsDataGridView.CurrentRow != null &&
            //        this.aCHDetailsDataGridView.CurrentRow.Index >= 0)
            //{
            //    //this.updateBalances();
            //}

            //System.Diagnostics.Debug.WriteLine("Current Cell Changed.");

            //DataRow thisRow = ((DataRowView)((BindingSource)sender).Current).Row;
            //if (thisRow.RowState == DataRowState.Modified)
            //{
            //    context.SubmitChanges();
            //    this.updateBalances();
            //}
        }

        private void addEmployeeToolStripButton_Click(object sender, EventArgs e)
        {
            AddStaffLine addStaff = new AddStaffLine();
            addStaff.BatchId = this._batchId;

            if (addStaff.ShowDialog() == DialogResult.OK)
            {
                var detailsQuery = from details in context.ACHDetails
                                   where details.achBatchId == this._batchId
                                   select details;

                this.aCHDetailsBindingSource.DataSource = detailsQuery;
            }
        }

        private void aCHDetailsDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            context.SubmitChanges();
            this.updateBalances();
        }

        

    }
}
