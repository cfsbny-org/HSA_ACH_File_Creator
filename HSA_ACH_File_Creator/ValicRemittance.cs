using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using OfficeOpenXml;

namespace Cfs.Custom.Software
{
    public partial class ValicRemittance : Form
    {

        private BackgroundWorker dataWorker;


        public ValicRemittance()
        {
            InitializeComponent();

            this.dataWorker = new BackgroundWorker();
            this.dataWorker.WorkerReportsProgress = true;
            this.dataWorker.DoWork += new DoWorkEventHandler(dataWorker_DoWork);
            this.dataWorker.ProgressChanged += new ProgressChangedEventHandler(dataWorker_ProgressChanged);
            this.dataWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(dataWorker_RunWorkerCompleted);
        }

        private void btnGenerateRemittanceFile_Click(object sender, EventArgs e)
        {
            if (this.companySelect.SelectedItem != null)
            {
                string selectedCompany = this.companySelect.SelectedItem.ToString();
                DateTime payDate = DateTime.Parse(this.payDatePicker.Text);
                this.saveFileDialog.FileName = string.Format("{0} {1}", selectedCompany, payDate.ToString("yyyy-MM-dd"));

                if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Data.ValicRemittanceParameters parameters = new Data.ValicRemittanceParameters();

                    parameters.companyId = selectedCompany;
                    parameters.payDate = payDate;
                    parameters.fileName = this.saveFileDialog.FileName;

                    this.btnGenerateRemittanceFile.Enabled = false;
                    //this.progressLabel.Text = "Generating file.  Please wait.";

                    //this.workerProgressBar.Visible = true;

                    //this.dataWorker.RunWorkerAsync(parameters);


                    List<Data.ValicDemographicsModel> demographics = new List<Data.ValicDemographicsModel>();
                    List<Data.ValicDeductionsModel> deductions = new List<Data.ValicDeductionsModel>();
                    List<Data.ValicRemittanceAmountsModel> remittances = new List<Data.ValicRemittanceAmountsModel>();


                    List<Data.ValicFileLineModel> fileLines = new List<Data.ValicFileLineModel>();


                    string payGroupId = string.Empty;
                    const string comma = ",";


                    switch (parameters.companyId)
                    {
                        case "CFS":
                            payGroupId = "GA71730001";
                            break;
                        case "SGF":
                            payGroupId = "GA71730002";
                            break;
                        /////////////////////////////////////////////////////////////////////////////////////////
                        /// SYB: Say Yes Buffalo
                        case "SYB": /////////////////////////////////////////////////////////////////////////////////
                            payGroupId = "GA71730003";
                            break;
                    }



                    //string filePath = @"\\844dc2\jbowen\UltiPro\Valic\Demographics.xlsx";



                    #region OPEN/READ DEMOGRAPHICS EXCEL FILE

                    if (this.openDemoFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string filePath = this.openDemoFileDialog.FileName;

                        ExcelPackage package = new ExcelPackage(new FileInfo(filePath));
                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                        //ExcelWorksheet demoSheet = package.Workbook.Worksheets[0];
                        
                        var demosheetList = package.Workbook.Worksheets.ToList();
                        ExcelWorksheet demoSheet = demosheetList.First();

                        string currentSsn = string.Empty;

                        for (int row = 2; row <= demoSheet.Dimension.End.Row; row++)
                        {
                            currentSsn = ProcessReaderString(demoSheet.Cells[row, 3].Value);

                            var employee = new Data.ValicDemographicsModel();

                            //demographics.Add(new Data.ValicDemographicsModel()
                            //{
                            employee.employeeId = demoSheet.Cells[row, 2].Value.ToString().Trim();
                            employee.employeeSsn = ProcessReaderString(demoSheet.Cells[row, 3].Value);
                            employee.firstName = ProcessReaderString(demoSheet.Cells[row, 4].Value);
                            employee.middleInit = ProcessReaderString(demoSheet.Cells[row, 5].Value);
                            employee.lastName = ProcessReaderString(demoSheet.Cells[row, 6].Value);
                            employee.address1 = ProcessReaderString(demoSheet.Cells[row, 7].Value);
                            employee.address2 = ProcessReaderString(demoSheet.Cells[row, 8].Value);
                            employee.addressCity = ProcessReaderString(demoSheet.Cells[row, 9].Value);
                            employee.addressState = ProcessReaderString(demoSheet.Cells[row, 10].Value);
                            employee.addressZip = ProcessReaderString(demoSheet.Cells[row, 11].Value);
                            employee.addressCountry = ProcessReaderString(demoSheet.Cells[row, 12].Value);
                            employee.birthDate = ConvertExcelSerialDate(int.Parse(demoSheet.Cells[row, 13].Value.ToString()));
                            employee.hireDate = ConvertExcelSerialDate(int.Parse(demoSheet.Cells[row, 14].Value.ToString()));
                            employee.homePhone = ProcessReaderString(demoSheet.Cells[row, 15].Value);
                            employee.genderId = ProcessReaderString(demoSheet.Cells[row, 16].Value);
                            employee.maritalStatus = ProcessReaderString(demoSheet.Cells[row, 17].Value);
                            employee.activeStatus = ProcessReaderString(demoSheet.Cells[row, 18].Value);
                            string termDate = demoSheet.Cells[row, 19].Value == null ? "NULL TERM DATE" : demoSheet.Cells[row, 19].Value.ToString();
                            employee.statusChange = demoSheet.Cells[row, 19].Value == null ? DateTime.MinValue : ConvertExcelSerialDate(int.Parse(demoSheet.Cells[row, 19].Value.ToString()));
                            employee.payrollStatus = ProcessReaderString(demoSheet.Cells[row, 20].Value);
                            employee.annualSalary = decimal.Parse(demoSheet.Cells[row, 21].Value.ToString());
                            employee.payrollDate = parameters.payDate;
                            //});

                            demographics.Add(employee);


                        }


                        demographics = demographics.Where(d => d.activeStatus == "A" || d.activeStatus == "L" || d.activeStatus == "S" || (d.activeStatus == "T" && d.statusChange >= DateTime.Today.AddDays(-30))).ToList();

                        package.Dispose();

                    }  //  if (this.openDemoFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)


                    #endregion




                    #region OPEN/READ DEDUCTIONS EXCEL FILE

                    if (this.openDeductionsFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        string filePath = this.openDeductionsFileDialog.FileName;

                        ExcelPackage package = new ExcelPackage(new FileInfo(filePath));

                        //ExcelWorksheet deductSheet = package.Workbook.Worksheets[0];
                        
                        var deductsheetList = package.Workbook.Worksheets.ToList();
                        ExcelWorksheet deductSheet = deductsheetList.First();
                        string currentEmployeeId = string.Empty;
                        string currentEmployeeName = string.Empty;

                        for (int row = 2; row <= deductSheet.Dimension.End.Row; row++)
                        {
                            currentEmployeeId = deductSheet.Cells[row, 2].Value.ToString();
                            currentEmployeeName = deductSheet.Cells[row, 4].Value.ToString();

                            //deductions.Add(new Data.ValicDeductionsModel()
                            //{
                            //    employeeId = deductSheet.Cells[row, 2].Value.ToString().Trim(),
                            //    deductionCode = deductSheet.Cells[row, 5].Value.ToString(),
                            //    employeeAmount = deductSheet.Cells[row, 6].Value == null ? 0 : decimal.Parse(deductSheet.Cells[row, 6].Value.ToString()),
                            //    employerAmount = deductSheet.Cells[row, 7].Value == null ? 0 : decimal.Parse(deductSheet.Cells[row, 7].Value.ToString()),
                            //    loanId = deductSheet.Cells[row, 8].Value == null ? string.Empty : deductSheet.Cells[row, 8].Value.ToString()
                            //});

                            Data.ValicDeductionsModel deductLine = new Data.ValicDeductionsModel();

                            deductLine.employeeId = deductSheet.Cells[row, 2].Value.ToString().Trim();
                            deductLine.deductionCode = deductSheet.Cells[row, 5].Value.ToString();
                            deductLine.employeeAmount = deductSheet.Cells[row, 6].Value == null ? 0 : decimal.Parse(deductSheet.Cells[row, 6].Value.ToString());
                            deductLine.employerAmount = deductSheet.Cells[row, 7].Value == null ? 0 : decimal.Parse(deductSheet.Cells[row, 7].Value.ToString());
                            deductLine.loanId = deductSheet.Cells[row, 8].Value == null ? string.Empty : deductSheet.Cells[row, 8].Value.ToString();

                            deductions.Add(deductLine);
                        }

                        package.Dispose();

                    } //  if (this.openDeductionsFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)

                    #endregion




                    #region BUILD REMITTANCE FILE DATA



                    List<string> employeeIds = deductions.Select(d => d.employeeId).Distinct().ToList();

                    foreach (string employeeId in employeeIds)
                    {
                        var employeeDeductions = deductions.Where(d => d.employeeId == employeeId).ToList();

                        var employeeTotal = employeeDeductions.Where(d => d.deductionCode == "403BC" || d.deductionCode == "403BF" || d.deductionCode == "403BP").
                                                        Select(d => d.employeeAmount).Sum();

                        var rothTotal = employeeDeductions.Where(d => d.deductionCode.Contains("ROT")).Select(d => d.employeeAmount).Sum();

                        var employerTotal = employeeDeductions.Where(d => d.deductionCode == "403ER").Select(d => d.employerAmount).Sum()+
                            employeeDeductions.Where(d => d.deductionCode.Substring(0,4) == "HSAS").Select(d => d.employerAmount).Sum();

                        var employeeLoans = employeeDeductions.Where(d => d.deductionCode.Contains("403L")).ToList();

                        if (employeeLoans == null || employeeLoans.Count == 0)
                        {
                            remittances.Add(new Data.ValicRemittanceAmountsModel()
                            {
                                employeeId = employeeId,
                                employeeAmount = employeeTotal,
                                employeeRoth = rothTotal,
                                employerAmount = employerTotal,
                                loanRepayment = 0,
                                loanId = string.Empty,
                                sortOrder = 1
                            });
                        }
                        else
                        {
                            int lineCount = 1;
                            foreach (var loan in employeeLoans)
                            {
                                if (lineCount == 1)
                                {
                                    remittances.Add(new Data.ValicRemittanceAmountsModel()
                                    {
                                        employeeId = employeeId,
                                        employeeAmount = employeeTotal,
                                        employeeRoth = rothTotal,
                                        employerAmount = employerTotal,
                                        loanRepayment = loan.employeeAmount,
                                        loanId = loan.loanId,
                                        sortOrder = 1
                                    });
                                }
                                else
                                {
                                    remittances.Add(new Data.ValicRemittanceAmountsModel()
                                    {
                                        employeeId = employeeId,
                                        employeeAmount = 0,
                                        employeeRoth = 0,
                                        employerAmount = 0,
                                        loanRepayment = loan.employeeAmount,
                                        loanId = loan.loanId,
                                        sortOrder = lineCount
                                    });
                                }
                                lineCount++;
                            }
                        }

                    }  // foreach

                    #endregion



                    #region WRITE DATA TO FILE

                    using (StreamWriter writer = File.CreateText(parameters.fileName))
                    {


                        StringBuilder lineText = new StringBuilder();


                        // HEADER ROW
                        lineText.Append("Format Code").Append(comma);
                        lineText.Append("Paygroup ID").Append(comma);
                        lineText.Append("SSN").Append(comma);
                        lineText.Append("Employee ID").Append(comma);
                        lineText.Append("Participant First Name").Append(comma);
                        lineText.Append("Participant Middle Name").Append(comma);
                        lineText.Append("Participant Last Name").Append(comma);
                        lineText.Append("Address 1").Append(comma);
                        lineText.Append("Address 2").Append(comma);
                        lineText.Append("City").Append(comma);
                        lineText.Append("State/Country Code").Append(comma);
                        lineText.Append("Zip").Append(comma);
                        lineText.Append("Payroll Frequency Code").Append(comma);
                        lineText.Append("Payroll Date").Append(comma);
                        lineText.Append("Employee Pre Tax Deferrals").Append(comma);
                        lineText.Append("Employee After Tax Roth").Append(comma);
                        lineText.Append("Employer Non Elective").Append(comma);
                        lineText.Append("Loan Repays").Append(comma);
                        lineText.Append("Contribution Slot 5").Append(comma);
                        lineText.Append("Loan ID").Append(comma);
                        lineText.Append("Birth Date").Append(comma);
                        lineText.Append("Hire Date").Append(comma);
                        lineText.Append("Phone").Append(comma);
                        lineText.Append("Address 3").Append(comma);
                        lineText.Append("Gender ID").Append(comma);
                        lineText.Append("Marital Status").Append(comma);
                        lineText.Append("Participant Status").Append(comma);
                        lineText.Append("Participant Status Change Date").Append(comma);
                        lineText.Append("Location Code/HR Area").Append(comma);
                        lineText.Append("HR Sub Area").Append(comma);
                        lineText.Append("Payroll Status Code").Append(comma);
                        lineText.Append("Annual Salary").Append(comma);
                        lineText.Append("Hours").Append(comma);
                        lineText.Append("Email Address").Append(comma);
                        lineText.Append("Employee Plan Eligibility Group Code/Payroll Code").Append(comma);
                        lineText.Append("Plan 1 Eligibility Date").Append(comma);
                        lineText.Append("Plan 2 Eligibility Date").Append(comma);
                        lineText.Append("Plan 1 Vesting Date").Append(comma);
                        lineText.Append("Plan 2 Vesting Date").Append(comma);
                        lineText.Append("Prior Employee ID").Append(comma);


                        writer.WriteLine(lineText.ToString());



                        foreach (var line in demographics.OrderBy(f => f.lastName).ThenBy(f => f.firstName))
                        {

                            DateTime today = DateTime.Today;
                            int employeeAge = today.Year - line.birthDate.Year;

                            if (line.birthDate.Date > today.Date.AddYears(-employeeAge))
                            {
                                employeeAge--;
                            }

                            //if (employeeAge < 21)
                            //{
                            //    continue;
                            //}

                            string payrollDate = parameters.payDate.ToString("MMddyyyy");

                            string payrollFrequency = string.Empty;
                            string payrollStatus = string.Empty;
                            string locationCode = string.Empty;

                            switch (parameters.companyId)
                            {
                                case "CFS":
                                    payrollFrequency = "BW";
                                    locationCode = "0001";
                                    break;
                                case "SGF":
                                    payrollFrequency = "SM";
                                    locationCode = "0002";
                                    break;
                                case "SYB":
                                    payrollFrequency = "BW";
                                    locationCode = "0003";
                                    break;
                            }


                            switch (line.payrollStatus)
                            {
                                case "F":
                                    payrollStatus = "FT";
                                    break;
                                case "P":
                                    payrollStatus = "PT";
                                    break;
                                default:
                                    payrollStatus = "HO";
                                    break;
                            }


                            // CANADIAN ADDRESS (ONTARIO ONLY)
                            if (line.addressCountry.Trim() == "Canada")
                            {
                                line.address3 = string.Format("{0}, {1}, {2}", line.addressCity, line.addressState, line.addressZip);
                                line.addressCity = "Canada";
                                line.addressState = "ZZ";
                                line.addressZip = "000000000";
                            }


                            var employeeRemittances = remittances.Where(r => r.employeeId.Trim() == line.employeeId.Trim()).ToList();

                            if (employeeRemittances.Count == 0)
                            {
                                lineText = new StringBuilder();

                                lineText.Append(CsvStringify("CR")).Append(comma);
                                lineText.Append(CsvStringify(payGroupId)).Append(comma);
                                lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                                lineText.Append(comma); // EMPLOYEE ID - NOT USING
                                lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                                lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                                lineText.Append(CsvStringify(line.addressState)).Append(comma);
                                lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                                lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                                lineText.Append(CsvStringify(payrollDate)).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                                lineText.Append(CsvStringify("00")).Append(comma);
                                lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                                lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                                lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address3)).Append(comma);
                                lineText.Append(CsvStringify(line.genderId)).Append(comma);
                                lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                                lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                                if (line.activeStatus == "T")
                                {
                                    lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                                }
                                else
                                {
                                    lineText.Append(comma);
                                }

                                lineText.Append(CsvStringify(locationCode)).Append(comma);
                                lineText.Append(comma); // HR Sub Area
                                lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                                lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                                lineText.Append(comma); // Hours
                                lineText.Append(comma); // Email
                                lineText.Append(comma); // Employee Plan
                                lineText.Append(comma); // Eligibility Date
                                lineText.Append(comma); // Eligibility Date
                                lineText.Append(comma); // Vesting Date
                                lineText.Append(comma); // Vesting Date
                                lineText.Append(comma); // Prior Employee ID


                                writer.WriteLine(lineText.ToString());

                            }
                            else
                            {

                                if (employeeRemittances.Count == 1)
                                {

                                    var remittance = employeeRemittances.FirstOrDefault();

                                    lineText = new StringBuilder();

                                    lineText.Append(CsvStringify("CR")).Append(comma);
                                    lineText.Append(CsvStringify(payGroupId)).Append(comma);
                                    lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                                    lineText.Append(comma); // EMPLOYEE ID - NOT USING
                                    lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                                    lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                                    lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                                    lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                                    lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                                    lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                                    lineText.Append(CsvStringify(line.addressState)).Append(comma);
                                    lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                                    lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                                    lineText.Append(CsvStringify(payrollDate)).Append(comma);
                                    lineText.Append(FormatDecimalAmount(remittance.employeeAmount, 7)).Append(comma);
                                    lineText.Append(FormatDecimalAmount(remittance.employeeRoth, 7)).Append(comma);
                                    lineText.Append(FormatDecimalAmount(remittance.employerAmount, 7)).Append(comma);
                                    lineText.Append(FormatDecimalAmount(remittance.loanRepayment, 7)).Append(comma);
                                    lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                                    lineText.Append(CsvStringify(remittance.loanId == null ? string.Empty : remittance.loanId.Trim().PadLeft(2, '0'))).Append(comma);
                                    lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                                    lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                                    lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                                    lineText.Append(CsvStringify(line.address3)).Append(comma);
                                    lineText.Append(CsvStringify(line.genderId)).Append(comma);
                                    lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                                    lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                                    if (line.activeStatus == "T")
                                    {
                                        lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                                    }
                                    else
                                    {
                                        lineText.Append(comma);
                                    }

                                    lineText.Append(CsvStringify(locationCode)).Append(comma);
                                    lineText.Append(comma); // HR Sub Area
                                    lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                                    lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                                    lineText.Append(comma); // Hours
                                    lineText.Append(comma); // Email
                                    lineText.Append(comma); // Employee Plan
                                    lineText.Append(comma); // Eligibility Date
                                    lineText.Append(comma); // Eligibility Date
                                    lineText.Append(comma); // Vesting Date
                                    lineText.Append(comma); // Vesting Date
                                    lineText.Append(comma); // Prior Employee ID


                                    writer.WriteLine(lineText.ToString());

                                }
                                else
                                {
                                    foreach (var remittance in employeeRemittances.OrderBy(r => r.sortOrder).ToList())
                                    {

                                        lineText = new StringBuilder();

                                        lineText.Append(CsvStringify("CR")).Append(comma);
                                        lineText.Append(CsvStringify(payGroupId)).Append(comma);
                                        lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                                        lineText.Append(comma); // EMPLOYEE ID - NOT USING
                                        lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                                        lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                                        lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                                        lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                                        lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                                        lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                                        lineText.Append(CsvStringify(line.addressState)).Append(comma);
                                        lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                                        lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                                        lineText.Append(CsvStringify(payrollDate)).Append(comma);
                                        lineText.Append(FormatDecimalAmount(remittance.employeeAmount, 7)).Append(comma);
                                        lineText.Append(FormatDecimalAmount(remittance.employeeRoth, 7)).Append(comma);
                                        lineText.Append(FormatDecimalAmount(remittance.employerAmount, 7)).Append(comma);
                                        lineText.Append(FormatDecimalAmount(remittance.loanRepayment, 7)).Append(comma);
                                        lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                                        lineText.Append(CsvStringify(remittance.loanId == null ? string.Empty : remittance.loanId.Trim().PadLeft(2, '0'))).Append(comma);
                                        lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                                        lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                                        lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                                        lineText.Append(CsvStringify(line.address3)).Append(comma);
                                        lineText.Append(CsvStringify(line.genderId)).Append(comma);
                                        lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                                        lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                                        if (line.activeStatus == "T")
                                        {
                                            lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                                        }
                                        else
                                        {
                                            lineText.Append(comma);
                                        }

                                        lineText.Append(CsvStringify(locationCode)).Append(comma);
                                        lineText.Append(comma); // HR Sub Area
                                        lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                                        lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                                        lineText.Append(comma); // Hours
                                        lineText.Append(comma); // Email
                                        lineText.Append(comma); // Employee Plan
                                        lineText.Append(comma); // Eligibility Date
                                        lineText.Append(comma); // Eligibility Date
                                        lineText.Append(comma); // Vesting Date
                                        lineText.Append(comma); // Vesting Date
                                        lineText.Append(comma); // Prior Employee ID


                                        writer.WriteLine(lineText.ToString());
                                    }


                                }
                            }



                        }

                    }

                    #endregion



                    Data.ValicFileSummary summary = new Data.ValicFileSummary()
                    {
                        remittanceFilePath = parameters.fileName,
                        employeeCount = demographics.Select(f => f.employeeId).Distinct().Count(),
                        totalEmployee = remittances.Select(f => f.employeeAmount).Sum(),
                        totalRoth = remittances.Select(f => f.employeeRoth).Sum(),
                        totalEmployer = remittances.Select(f => f.employerAmount).Sum(),
                        totalLoans = remittances.Select(f => f.loanRepayment).Sum()
                    };


                    string path = Path.GetDirectoryName(summary.remittanceFilePath);
                    System.Diagnostics.Process.Start(path);

                    this.employeeCountLabel.Text = summary.employeeCount.ToString();
                    this.employeeContribLabel.Text = summary.totalEmployee == null ? "$0.00" : ((decimal)summary.totalEmployee).ToString("c");
                    this.employeeRothLabel.Text = summary.totalRoth == null ? "$0.00" : ((decimal)summary.totalRoth).ToString("c");
                    this.employerTotalLabel.Text = summary.totalEmployer == null ? "$0.00" : ((decimal)summary.totalEmployer).ToString("c");
                    this.loansTotalLabel.Text = summary.totalLoans == null ? "$0.00" : ((decimal)summary.totalLoans).ToString("c");


                }
            }

        }



        private void dataWorker_DoWork(object sender, DoWorkEventArgs args)
        {
            Data.ValicRemittanceParameters parameters = (Data.ValicRemittanceParameters)args.Argument; 

            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\data;Collating Sequence=general;";
            //string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\sample;Collating Sequence=general;";


            List<Data.ValicDemographicsModel> demographics = new List<Data.ValicDemographicsModel>();
            List<Data.ValicDeductionsModel> deductions = new List<Data.ValicDeductionsModel>();
            List<Data.ValicRemittanceAmountsModel> remittances = new List<Data.ValicRemittanceAmountsModel>();


            List<Data.ValicFileLineModel> fileLines = new List<Data.ValicFileLineModel>();


            string payGroupId = string.Empty;
            const string comma = ",";


            switch (parameters.companyId)
            {
                case "CFS":
                    payGroupId = "GA71730001";
                    break;
                case "SGF":
                    payGroupId = "GA71730002";
                    break;
                case "SYB":
                    payGroupId = "GA71730003";
                    break;
            }


            this.dataWorker.ReportProgress(0, "Starting process...");




            OleDbConnection conn = new OleDbConnection(connString);
            StringBuilder query = new StringBuilder();

            query.Append("SELECT h.p_empno, h.p_lname, h.p_fname, h.p_mi, h.p_ssn, h.p_hstreet1, h.p_hstreet2, h.p_hcity, ");
            query.Append("h.p_hstate, h.p_hzip, h.p_birth, h.p_sendate, h.p_hphone, h.p_sex, h.p_married, h.p_employ, ");
            query.Append("h.p_annual, h.p_active, h.p_employ, h.p_salhour, h.p_termdate ");
            query.Append("FROM hrpersnl h ");
            //query.Append("ON h.p_company = c.company AND h.p_empno = c.empno ");
            query.Append("WHERE h.p_company = '" + parameters.companyId + "' ");
            query.Append("AND (h.p_active IN ('A','L','S') ");
            //query.Append("AND h.p_level2 <> '609' AND h.p_level2 <> '340' ");
            query.Append("OR (h.p_active = 'T' AND h.p_termdate > {" + parameters.payDate.AddDays(-30).ToShortDateString() + "}) );");
            //query.Append("AND c.chkdate = {" + parameters.payDate.ToShortDateString() + "} ");
            //query.Append("AND c.chkstatus <> 'V';");

            OleDbCommand comm = new OleDbCommand(query.ToString(), conn);
            comm.CommandType = CommandType.Text;

            try
            {
                conn.Open();
                OleDbDataReader reader = comm.ExecuteReader();

                this.dataWorker.ReportProgress(20, "Dempgraphics query executed.");

                while (reader.Read())
                {
                    demographics.Add(new Data.ValicDemographicsModel()
                    {
                        employeeId = reader["p_empno"].ToString(),
                        employeeSsn = reader["p_ssn"].ToString(),
                        firstName = reader["p_fname"].ToString(),
                        middleInit = ProcessReaderString(reader["p_mi"]),
                        lastName = reader["p_lname"].ToString(),
                        address1 = reader["p_hstreet1"].ToString(),
                        address2 = ProcessReaderString(reader["p_hstreet2"]),
                        addressCity = ProcessReaderString(reader["p_hcity"]),
                        addressState = ProcessReaderString(reader["p_hstate"]),
                        addressZip = ProcessReaderString(reader["p_hzip"]),
                        payrollDate = parameters.payDate,
                        birthDate = DateTime.Parse(reader["p_birth"].ToString()),
                        hireDate = DateTime.Parse(reader["p_sendate"].ToString()),
                        homePhone = ProcessReaderString(reader["p_hphone"]),
                        genderId = reader["p_sex"].ToString(),
                        maritalStatus = ProcessReaderString(reader["p_married"]),
                        activeStatus = reader["p_active"].ToString(),
                        statusChange = DateTime.Parse(reader["p_termdate"].ToString()),
                        payrollStatus = reader["p_employ"].ToString(),
                        annualSalary = decimal.Parse(reader["p_annual"].ToString())
                    });
                }

                reader.Close();
                reader.Dispose();

                this.dataWorker.ReportProgress(40, "Dempgraphics data compiled.");

                //comm.Dispose();
            }
            catch (Exception ex)
            {

                comm.Dispose();

                conn.Close();
                conn.Dispose();

                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += Environment.NewLine + Environment.NewLine + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage);

                return;
            }
            finally
            {
                //conn.Close();
                //conn.Dispose();
            }


            query = new StringBuilder();


            query.Append("SELECT d.empno, d.amount, d.erliab, d.code, p.member ");
            query.Append("FROM prckhist c INNER JOIN prdehist d ON c.company = d.company AND c.empno = d.empno AND c.chknumber = d.chknumber ");
            query.Append("INNER JOIN prdeds p ON d.company = p.company AND d.empno = p.empno AND d.code = p.dedcode ");
            query.Append("WHERE c.company = '" + parameters.companyId + "' ");
            query.Append("AND (d.code LIKE 'MUT%' OR d.code LIKE 'ROT%' OR d.code LIKE 'VAL%') ");  // CHANGE BACK!!!!  LOOK BELOW TOO!!!
            //query.Append("AND (d.code LIKE 'MUT%' OR d.code LIKE 'ROT%' OR d.code LIKE 'VAC%') ");
            query.Append("AND c.chkdate = {" + parameters.payDate.ToShortDateString() + "} ");
            query.Append("AND c.chkstatus <> 'V';");

            comm = new OleDbCommand(query.ToString(), conn);
            comm.CommandType = CommandType.Text;

            try
            {
                OleDbDataReader dedReader = comm.ExecuteReader();

                this.dataWorker.ReportProgress(60, "Deductions query executed.");

                while (dedReader.Read())
                {
                    deductions.Add(new Data.ValicDeductionsModel()
                    {
                        employeeId = dedReader["empno"].ToString(),
                        deductionCode = dedReader["code"].ToString(),
                        employeeAmount = decimal.Parse(dedReader["amount"].ToString()),
                        employerAmount = decimal.Parse(dedReader["erliab"].ToString()),
                        loanId = ProcessReaderString(dedReader["member"])
                    });
                }

                this.dataWorker.ReportProgress(80, "Deductions data compiled.");

                dedReader.Close();
                dedReader.Dispose();
            }
            catch (Exception ex)
            {
                comm.Dispose();

                conn.Close();
                conn.Dispose();

                string errorMessage = ex.Message;

                if (ex.InnerException != null)
                {
                    errorMessage += Environment.NewLine + Environment.NewLine + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage);

                return;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
                conn.Dispose();
            }


            if (conn.State == ConnectionState.Open)
            {
                comm.Dispose();
                conn.Close();
                conn.Dispose();
            }



            List<string> employeeIds = deductions.Select(d => d.employeeId).Distinct().ToList();

            foreach (string employeeId in employeeIds)
            {
                var employeeDeductions = deductions.Where(d => d.employeeId == employeeId).ToList();

                var employeeTotal = employeeDeductions.Where(d => d.deductionCode == "MUT$" || d.deductionCode == "MUT%" || d.deductionCode == "MUTN").
                                                Select(d => d.employeeAmount).Sum();

                var rothTotal = employeeDeductions.Where(d => d.deductionCode.Contains("ROT")).Select(d => d.employeeAmount).Sum();

                var employerTotal = employeeDeductions.Where(d => d.deductionCode == "MUTR").Select(d => d.employerAmount).Sum();

                var employeeLoans = employeeDeductions.Where(d => d.deductionCode.Contains("VAL")).ToList();

                if (employeeLoans == null || employeeLoans.Count == 0)
                {
                    remittances.Add(new Data.ValicRemittanceAmountsModel()
                    {
                        employeeId = employeeId,
                        employeeAmount = employeeTotal,
                        employeeRoth = rothTotal,
                        employerAmount = employerTotal,
                        loanRepayment = 0,
                        loanId = string.Empty,
                        sortOrder = 1
                    });
                }
                else
                {
                    int lineCount = 1;
                    foreach (var loan in employeeLoans)
                    {
                        if (lineCount == 1)
                        {
                            remittances.Add(new Data.ValicRemittanceAmountsModel()
                            {
                                employeeId = employeeId,
                                employeeAmount = employeeTotal,
                                employeeRoth = rothTotal,
                                employerAmount = employerTotal,
                                loanRepayment = loan.employeeAmount,
                                loanId = loan.loanId,
                                sortOrder = 1
                            });
                        }
                        else
                        {
                            remittances.Add(new Data.ValicRemittanceAmountsModel()
                            {
                                employeeId = employeeId,
                                employeeAmount = 0,
                                employeeRoth = 0,
                                employerAmount = 0,
                                loanRepayment = loan.employeeAmount,
                                loanId = loan.loanId,
                                sortOrder = lineCount
                            });
                        }
                        lineCount++;
                    }
                }

            }



            //try
            //{
            //fileLines = (from e in demographics
            //             //from r in remittances.Where(r => r.employeeId == e.employeeId).DefaultIfEmpty()
            //             orderby e.lastName, e.firstName
            //             select new Data.ValicFileLineModel
            //             {
            //                 employeeId = e.employeeId,
            //                 employeeSsn = e.employeeSsn,
            //                 firstName = e.firstName,
            //                 middleInit = e.middleInit,
            //                 lastName = e.lastName,
            //                 address1 = e.address1,
            //                 address2 = e.address2,
            //                 addressCity = e.addressCity,
            //                 addressState = e.addressState,
            //                 addressZip = e.addressZip,
            //                 payrollDate = e.payrollDate.ToString("MMddyyyy"),
            //                 //employeeContrib = r == null ? 0 : r.employeeAmount,
            //                 //employeeRoth = r == null ? 0 : r.employeeRoth,
            //                 //employerContrib = r == null ? 0 : r.employerAmount,
            //                 //loanRepayment = r == null ? 0 : r.loanRepayment,
            //                 //loanId = r.loanId,
            //                 birthDate = e.birthDate,
            //                 hireDate = e.hireDate,
            //                 homePhone = e.homePhone,
            //                 genderId = e.genderId,
            //                 maritalStatus = e.maritalStatus,
            //                 activeStatus = e.activeStatus,
            //                 statusChange = e.statusChange,
            //                 payrollStatus = e.payrollStatus,
            //                 annualSalary = e.annualSalary
            //                 //sortOrder = r == null ? 1 : r.sortOrder
            //             }).ToList();

            this.dataWorker.ReportProgress(90, "Compiling remittance file...");

            //Excel.Application xl;
            //Excel._Workbook workbook;
            //Excel._Worksheet sheet;
            ////Excel.Range range;

            //xl = new Excel.Application();
            //xl.Visible = false;

            //workbook = (Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
            //sheet = (Excel._Worksheet)workbook.ActiveSheet;


            using (StreamWriter writer = File.CreateText(parameters.fileName))
            {


                StringBuilder lineText = new StringBuilder();


                // HEADER ROW
                lineText.Append("Format Code").Append(comma);
                lineText.Append("Paygroup ID").Append(comma);
                lineText.Append("SSN").Append(comma);
                lineText.Append("Employee ID").Append(comma);
                lineText.Append("Participant First Name").Append(comma);
                lineText.Append("Participant Middle Name").Append(comma);
                lineText.Append("Participant Last Name").Append(comma);
                lineText.Append("Address 1").Append(comma);
                lineText.Append("Address 2").Append(comma);
                lineText.Append("City").Append(comma);
                lineText.Append("State/Country Code").Append(comma);
                lineText.Append("Zip").Append(comma);
                lineText.Append("Payroll Frequency Code").Append(comma);
                lineText.Append("Payroll Date").Append(comma);
                lineText.Append("Employee Pre Tax Deferrals").Append(comma);
                lineText.Append("Employee After Tax Roth").Append(comma);
                lineText.Append("Employer Non Elective").Append(comma);
                lineText.Append("Loan Repays").Append(comma);
                lineText.Append("Contribution Slot 5").Append(comma);
                lineText.Append("Loan ID").Append(comma);
                lineText.Append("Birth Date").Append(comma);
                lineText.Append("Hire Date").Append(comma);
                lineText.Append("Phone").Append(comma);
                lineText.Append("Address 3").Append(comma);
                lineText.Append("Gender ID").Append(comma);
                lineText.Append("Marital Status").Append(comma);
                lineText.Append("Participant Status").Append(comma);
                lineText.Append("Participant Status Change Date").Append(comma);
                lineText.Append("Location Code/HR Area").Append(comma);
                lineText.Append("HR Sub Area").Append(comma);
                lineText.Append("Payroll Status Code").Append(comma);
                lineText.Append("Annual Salary").Append(comma);
                lineText.Append("Hours").Append(comma);
                lineText.Append("Email Address").Append(comma);
                lineText.Append("Employee Plan Eligibility Group Code/Payroll Code").Append(comma);
                lineText.Append("Plan 1 Eligibility Date").Append(comma);
                lineText.Append("Plan 2 Eligibility Date").Append(comma);
                lineText.Append("Plan 1 Vesting Date").Append(comma);
                lineText.Append("Plan 2 Vesting Date").Append(comma);
                lineText.Append("Prior Employee ID").Append(comma);


                writer.WriteLine(lineText.ToString());



                foreach (var line in demographics.OrderBy(f => f.lastName).ThenBy(f => f.firstName))
                {

                    DateTime today = DateTime.Today;
                    int employeeAge = today.Year - line.birthDate.Year;

                    if (line.birthDate.Date > today.Date.AddYears(-employeeAge))
                    {
                        employeeAge--;
                    }

                    if (employeeAge < 21)
                    {
                        continue;
                    }

                    string payrollDate = parameters.payDate.ToString("MMddyyyy");

                    string payrollFrequency = string.Empty;
                    string payrollStatus = string.Empty;
                    string locationCode = string.Empty;

                    switch (parameters.companyId)
                    {
                        case "CFS":
                            payrollFrequency = "BW";
                            locationCode = "0001";
                            break;
                        case "SGF":
                            payrollFrequency = "SM";
                            locationCode = "0002";
                            break;
                        case "SYB":
                            payrollFrequency = "BW";
                            locationCode = "0003";
                            break;
                    }


                    switch (line.payrollStatus)
                    {
                        case "RFT":
                            payrollStatus = "FT";
                            break;
                        case "RPT":
                            payrollStatus = "PT";
                            break;
                        default:
                            payrollStatus = "HO";
                            break;
                    }


                    // CANADIAN ADDRESS (ONTARIO ONLY)
                    if (line.addressState.Trim() == "ON")
                    {
                        line.address3 = string.Format("{0}, {1}, {2}", line.addressCity, line.addressState, line.addressZip);
                        line.addressCity = "Canada";
                        line.addressState = "ZZ";
                        line.addressZip = "000000000";
                    }


                    var employeeRemittances = remittances.Where(r => r.employeeId.Trim() == line.employeeId.Trim()).ToList();

                    if (employeeRemittances.Count == 0)
                    {
                        lineText = new StringBuilder();

                        lineText.Append(CsvStringify("CR")).Append(comma);
                        lineText.Append(CsvStringify(payGroupId)).Append(comma);
                        lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                        lineText.Append(comma); // EMPLOYEE ID - NOT USING
                        lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                        lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                        lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                        lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                        lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                        lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                        lineText.Append(CsvStringify(line.addressState)).Append(comma);
                        lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                        lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                        lineText.Append(CsvStringify(payrollDate)).Append(comma);
                        lineText.Append(CsvStringify("0000000")).Append(comma);
                        lineText.Append(CsvStringify("0000000")).Append(comma);
                        lineText.Append(CsvStringify("0000000")).Append(comma);
                        lineText.Append(CsvStringify("0000000")).Append(comma);
                        lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                        lineText.Append(CsvStringify("00")).Append(comma);
                        lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                        lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                        lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                        lineText.Append(CsvStringify(line.address3)).Append(comma);
                        lineText.Append(CsvStringify(line.genderId)).Append(comma);
                        lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                        lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                        if (line.activeStatus == "T")
                        {
                            lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                        }
                        else
                        {
                            lineText.Append(comma);
                        }

                        lineText.Append(CsvStringify(locationCode)).Append(comma);
                        lineText.Append(comma); // HR Sub Area
                        lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                        lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                        lineText.Append(comma); // Hours
                        lineText.Append(comma); // Email
                        lineText.Append(comma); // Employee Plan
                        lineText.Append(comma); // Eligibility Date
                        lineText.Append(comma); // Eligibility Date
                        lineText.Append(comma); // Vesting Date
                        lineText.Append(comma); // Vesting Date
                        lineText.Append(comma); // Prior Employee ID


                        writer.WriteLine(lineText.ToString());

                    }
                    else
                    {

                        if (employeeRemittances.Count == 1)
                        {

                            var remittance = employeeRemittances.FirstOrDefault();

                            lineText = new StringBuilder();

                            lineText.Append(CsvStringify("CR")).Append(comma);
                            lineText.Append(CsvStringify(payGroupId)).Append(comma);
                            lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                            lineText.Append(comma); // EMPLOYEE ID - NOT USING
                            lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                            lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                            lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                            lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                            lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                            lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                            lineText.Append(CsvStringify(line.addressState)).Append(comma);
                            lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                            lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                            lineText.Append(CsvStringify(payrollDate)).Append(comma);
                            lineText.Append(FormatDecimalAmount(remittance.employeeAmount, 7)).Append(comma);
                            lineText.Append(FormatDecimalAmount(remittance.employeeRoth, 7)).Append(comma);
                            lineText.Append(FormatDecimalAmount(remittance.employerAmount, 7)).Append(comma);
                            lineText.Append(FormatDecimalAmount(remittance.loanRepayment, 7)).Append(comma);
                            lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                            lineText.Append(CsvStringify(remittance.loanId == null ? string.Empty : remittance.loanId.Trim().PadLeft(2, '0'))).Append(comma);
                            lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                            lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                            lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                            lineText.Append(CsvStringify(line.address3)).Append(comma);
                            lineText.Append(CsvStringify(line.genderId)).Append(comma);
                            lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                            lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                            if (line.activeStatus == "T")
                            {
                                lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                            }
                            else
                            {
                                lineText.Append(comma);
                            }

                            lineText.Append(CsvStringify(locationCode)).Append(comma);
                            lineText.Append(comma); // HR Sub Area
                            lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                            lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                            lineText.Append(comma); // Hours
                            lineText.Append(comma); // Email
                            lineText.Append(comma); // Employee Plan
                            lineText.Append(comma); // Eligibility Date
                            lineText.Append(comma); // Eligibility Date
                            lineText.Append(comma); // Vesting Date
                            lineText.Append(comma); // Vesting Date
                            lineText.Append(comma); // Prior Employee ID


                            writer.WriteLine(lineText.ToString());

                        }
                        else
                        {
                            foreach (var remittance in employeeRemittances.OrderBy(r => r.sortOrder).ToList())
                            {

                                lineText = new StringBuilder();

                                lineText.Append(CsvStringify("CR")).Append(comma);
                                lineText.Append(CsvStringify(payGroupId)).Append(comma);
                                lineText.Append(CsvStringify(line.employeeSsn.Replace("-", string.Empty).Trim())).Append(comma);
                                lineText.Append(comma); // EMPLOYEE ID - NOT USING
                                lineText.Append(CsvStringify(line.firstName.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.middleInit)).Append(comma);
                                lineText.Append(CsvStringify(line.lastName.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address1.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address2.Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.addressCity)).Append(comma);
                                lineText.Append(CsvStringify(line.addressState)).Append(comma);
                                lineText.Append(CsvStringify(line.addressZip.Replace("-", string.Empty))).Append(comma);
                                lineText.Append(CsvStringify(payrollFrequency)).Append(comma);
                                lineText.Append(CsvStringify(payrollDate)).Append(comma);
                                lineText.Append(FormatDecimalAmount(remittance.employeeAmount, 7)).Append(comma);
                                lineText.Append(FormatDecimalAmount(remittance.employeeRoth, 7)).Append(comma);
                                lineText.Append(FormatDecimalAmount(remittance.employerAmount, 7)).Append(comma);
                                lineText.Append(FormatDecimalAmount(remittance.loanRepayment, 7)).Append(comma);
                                lineText.Append(CsvStringify("0000000")).Append(comma); // Contribution Slot 5 - NOT USING
                                lineText.Append(CsvStringify(remittance.loanId == null ? string.Empty : remittance.loanId.Trim().PadLeft(2, '0'))).Append(comma);
                                lineText.Append(CsvStringify(line.birthDate.ToString("MMddyyyy"))).Append(comma);
                                lineText.Append(CsvStringify(line.hireDate.ToString("MMddyyyy"))).Append(comma);
                                lineText.Append(CsvStringify(line.homePhone.Trim().Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Trim())).Append(comma);
                                lineText.Append(CsvStringify(line.address3)).Append(comma);
                                lineText.Append(CsvStringify(line.genderId)).Append(comma);
                                lineText.Append(CsvStringify(line.maritalStatus)).Append(comma);
                                lineText.Append(CsvStringify(line.activeStatus)).Append(comma);

                                if (line.activeStatus == "T")
                                {
                                    lineText.Append(CsvStringify(((DateTime)line.statusChange).ToString("MMddyyyy"))).Append(comma);
                                }
                                else
                                {
                                    lineText.Append(comma);
                                }

                                lineText.Append(CsvStringify(locationCode)).Append(comma);
                                lineText.Append(comma); // HR Sub Area
                                lineText.Append(CsvStringify(payrollStatus)).Append(comma);
                                lineText.Append(FormatDecimalAmount(line.annualSalary, 10)).Append(comma);
                                lineText.Append(comma); // Hours
                                lineText.Append(comma); // Email
                                lineText.Append(comma); // Employee Plan
                                lineText.Append(comma); // Eligibility Date
                                lineText.Append(comma); // Eligibility Date
                                lineText.Append(comma); // Vesting Date
                                lineText.Append(comma); // Vesting Date
                                lineText.Append(comma); // Prior Employee ID


                                writer.WriteLine(lineText.ToString());
                            }


                        }
                    }






                }
            }
            //}
            //catch (Exception ex)
            //{

            //    string errorMessage = ex.Message;

            //    if (ex.InnerException != null)
            //    {
            //        errorMessage += Environment.NewLine + Environment.NewLine + ex.InnerException.Message;
            //    }

            //    errorMessage += Environment.NewLine + Environment.NewLine + ex.StackTrace;

            //    MessageBox.Show(errorMessage);

            //}

            this.dataWorker.ReportProgress(100, "Remittance file created.");




            Data.ValicFileSummary summary = new Data.ValicFileSummary()
            {
                remittanceFilePath = parameters.fileName,
                employeeCount = demographics.Select(f => f.employeeId).Distinct().Count(),
                totalEmployee = remittances.Select(f => f.employeeAmount).Sum(),
                totalRoth = remittances.Select(f => f.employeeRoth).Sum(),
                totalEmployer = remittances.Select(f => f.employerAmount).Sum(),
                totalLoans = remittances.Select(f => f.loanRepayment).Sum()
            };


            //Reports.ValicFile report = new Reports.ValicFile();

            //report.SetDataSource(fileLines);

            //report.ParameterFields["companyId"].CurrentValues.AddValue(parameters.companyId);
            //report.ParameterFields["payDate"].CurrentValues.AddValue(parameters.payDate);

            //report.ExportToDisk(ExportFormatType.PortableDocFormat, parameters.fileName.Replace(".csv", ".pdf"));

            //report.Close();
            //report.Dispose();


            args.Result = summary;

        }


        private void dataWorker_ProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            this.workerProgressBar.Value = args.ProgressPercentage;
            this.progressLabel.Text = args.UserState.ToString();
        }


        private void dataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                this.btnGenerateRemittanceFile.Enabled = true;
                //this.progressLabel.Text = "File generated.";




                if (e.Result == null)
                {
                    System.Diagnostics.Debug.WriteLine("Result is null.");
                }
                else
                {
                    Data.ValicFileSummary summary = (Data.ValicFileSummary)e.Result;

                    string path = Path.GetDirectoryName(summary.remittanceFilePath);
                    System.Diagnostics.Process.Start(path);

                    this.employeeCountLabel.Text = summary.employeeCount.ToString();
                    this.employeeContribLabel.Text = summary.totalEmployee == null ? "$0.00" : ((decimal)summary.totalEmployee).ToString("c");
                    this.employeeRothLabel.Text = summary.totalRoth == null ? "$0.00" : ((decimal)summary.totalRoth).ToString("c");
                    this.employerTotalLabel.Text = summary.totalEmployer == null ? "$0.00" : ((decimal)summary.totalEmployer).ToString("c");
                    this.loansTotalLabel.Text = summary.totalLoans == null ? "$0.00" : ((decimal)summary.totalLoans).ToString("c");
                }
            }
        }





        private string ProcessReaderString(object readerValue)
        {
            if (readerValue == null)
            {
                return string.Empty;
            }
            else
            {
                return readerValue.ToString().Trim();
            }
        }



        private string CsvStringify(object objectToStringify)
        {
            if (objectToStringify == null)
            {
                return string.Format("{0}", string.Empty);
            }
            else
            {
                return string.Format("{0}", objectToStringify.ToString().Replace(",", " "));
            }
        }



        private string FormatDecimalAmount(decimal? decimalAmount, int padWidth)
        {
            string decimalFormatted = string.Empty;

            if (decimalAmount == null)
            {
                decimalFormatted = CsvStringify(string.Empty.PadLeft(padWidth, '0'));
            }
            else
            {
                decimalFormatted = CsvStringify(((decimal)decimalAmount).ToString("F").Replace(".", string.Empty).PadLeft(padWidth, '0'));
            }

            return decimalFormatted;
        }




        private DateTime ConvertExcelSerialDate(int SerialDate)
        {
            if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(SerialDate);
        }


    }
}
