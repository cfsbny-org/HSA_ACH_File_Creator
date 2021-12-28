using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Cfs.Custom.Software
{
    public partial class Batches : Form
    {

        private Data.BenefitsDbDataContext context = 
                new Cfs.Custom.Software.Data.BenefitsDbDataContext();


        private enum FileType
        {
            Employee,
            Employer
        }


        public Batches()
        {
            InitializeComponent();
        }

        private void Batches_Load(object sender, EventArgs e)
        {
            var batchesQuery = from batches in context.ACHFiles
                               where batches.achFileStatus == 'N' || batches.achFileStatus == 'O'
                               orderby batches.achBatchCreated descending 
                               select batches;

            this.aCHFileBindingSource.DataSource = batchesQuery;


        }

        private void createAchFile_toolstripButton_Click(object sender, EventArgs e)
        {

            long batchId = (long)this.aCHFileDataGridView.SelectedRows[0].Cells[0].Value;

            Data.ACHFile achFile = (from files in context.ACHFiles
                                    where files.achBatchId == batchId
                                    select files).Single();

            this.saveAchFileDialog.Title = "Create Employee ACH File";
            this.saveAchFileDialog.FileName = achFile.achCompany + " EMPLOYEE " + achFile.achCheckDate.ToString("yyyyMMdd");
            this.saveAchFileDialog.InitialDirectory = @"\\quagmire\accounting\HSA ACH Files\";

            if (this.saveAchFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.createAchFile(batchId, FileType.Employee);
            }


            this.saveAchFileDialog.Title = "Create Employer ACH File";
            this.saveAchFileDialog.FileName = achFile.achCompany + " EMPLOYER " + achFile.achCheckDate.ToString("yyyyMMdd");


            if (this.saveAchFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.createAchFile(batchId, FileType.Employer);
            }
            
        }


        private void createAchFile(long batchId, FileType fileType)
        {

            string fileName = this.saveAchFileDialog.FileName;

            int lineCount = 0;
            decimal totalAmount = 0;
            int entryHash = 0;

            string fileTypeDesc = string.Empty;

            switch (fileType)
            {
                case FileType.Employee:
                    fileTypeDesc = "EMPLOYEE";
                    break;
                case FileType.Employer:
                    fileTypeDesc = "ER CONT";
                    break;
            }


            Data.ACHFile achFile = (from files in context.ACHFiles
                                    where files.achBatchId == batchId
                                    select files).Single();

            IQueryable<Data.ACHDetail> achFileDetail = null;

            switch (fileType)
            {
                case FileType.Employee:
                    achFileDetail = from details in context.ACHDetails
                                    where details.achBatchId == batchId &&
                                             details.includeInFile == true &&
                                             details.emAmount != 0
                                    select details;
                    break;

                case FileType.Employer:
                    achFileDetail = from details in context.ACHDetails
                                    where details.achBatchId == batchId &&
                                             details.includeInFile == true &&
                                             details.erAmount != 0
                                    select details;
                    break;
            }

            


            if (achFile == null)
            {
                MessageBox.Show("Error retrieving ACH file batch.");
                return;
            }
            else
            {
                if (achFileDetail == null)
                {
                    MessageBox.Show("No records for batch.");
                    return;
                }

                string taxId = "161004825";
                string company="CHILD & FAMILY SERVICES";

                switch (achFile.achCompany)
                {
                    case "CFS":
                        taxId = "161004825";
                        break;
                    case "SGF":
                        taxId = "161285546";
                        break;
                    case "SYB":
                        taxId = "462867677";
                        company ="SAY YES BUFFALO";
                        break;
                }


                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    // FILE HEADER RECORD
                    sw.Write("1");// 1
                    sw.Write("01");//2-3
                    sw.Write(" 021300077");//4-13
                    sw.Write(" " + taxId);// 14-23
                    sw.Write(DateTime.Today.ToString("yyMMdd"));//24-29
                    sw.Write(DateTime.Now.ToString("hhmm"));//30-33
                    sw.Write("A");//34
                    sw.Write("094");//35-37
                    sw.Write("10");//38-39
                    sw.Write("1");//40
                    sw.Write(this.formatFixedLengthText("KeyBank", 23));//41-63
                    sw.Write(this.formatFixedLengthText(company, 23));//64-86
                    sw.Write(batchId.ToString().PadLeft(8, '0'));  //87-94
                    sw.Write(sw.NewLine);

                    // BATCH HEADER RECORD
                    sw.Write("5");
                    sw.Write("200");
                    sw.Write(this.formatFixedLengthText(@"CHILD & FAMILY", 16));
                    sw.Write(this.formatFixedLengthText("BATCH" + batchId.ToString().PadLeft(10, '0'), 20));
                    sw.Write("1" + taxId);
                    sw.Write("PPD");
                    sw.Write(this.formatFixedLengthText(fileTypeDesc, 10));
                    sw.Write(batchId.ToString().PadLeft(6, '0'));
                    sw.Write(achFile.achCheckDate.ToString("yyMMdd"));
                    sw.Write(this.addEmptyFixedLengthText(3));
                    sw.Write("1");
                    sw.Write("02130007");
                    sw.Write(batchId.ToString().PadLeft(7, '0'));
                    sw.Write(sw.NewLine);


                    foreach (Data.ACHDetail detail in achFileDetail)
                    {
                        lineCount += 1;

                        decimal amount = 0;
 
                        switch(fileType)
                        {
                            case FileType.Employee:
                                amount = detail.emAmount;
                                break;
                            case FileType.Employer:
                                amount = detail.erAmount;
                                break;
                        }

                        int amountRounded = (int)(Math.Round(amount, 2) * 100);
                        totalAmount += amount;


                        string middleInitial = string.Empty;

                        if (detail.middleInitial != null)
                        {
                            if (detail.middleInitial.Length > 0)
                            {
                                middleInitial = detail.middleInitial.Substring(0, 1);
                            }
                        }

                        sw.Write("6");
                        sw.Write(this.formatFixedLengthText(detail.accountType == null ? "32" : detail.accountType.Trim(), 2));
                        sw.Write(this.formatFixedLengthText(detail.routingNumber.Trim(), 9));
                        sw.Write(this.formatFixedLengthText(detail.accountNumber.Trim(), 17));
                        sw.Write(amountRounded.ToString().PadLeft(10, '0'));
                        sw.Write(this.formatFixedLengthText(detail.employeeId.Trim(), 15));
                        sw.Write(this.formatFixedLengthText(detail.lastName.Trim() + ", " 
                                    + detail.firstName.Trim() + " " 
                                    + middleInitial, 22));
                        sw.Write(this.addEmptyFixedLengthText(2));
                        sw.Write("0");
                        sw.Write("02130007");
                        sw.Write(lineCount.ToString().PadLeft(7, '0'));

                        entryHash += int.Parse(detail.routingNumber.Substring(0, 8));

                        sw.Write(sw.NewLine);

                        

                    } // foreach Detail

                    int totalAmountRounded = (int)(Math.Round(totalAmount, 2) * 100);


                    // BATCH CONTROL RECORD
                    sw.Write("8");
                    sw.Write(fileType == FileType.Employee ? "225" : "200");
                    sw.Write(lineCount.ToString().PadLeft(6, '0'));
                    sw.Write(entryHash.ToString().PadLeft(10, '0'));
                    sw.Write("000000000000");
                    sw.Write(totalAmountRounded.ToString().PadLeft(12, '0'));
                    sw.Write("1" + taxId);
                    sw.Write(this.addEmptyFixedLengthText(19));
                    sw.Write(this.addEmptyFixedLengthText(6));
                    sw.Write("02130007");
                    sw.Write(batchId.ToString().PadLeft(7, '0'));
                    sw.Write(sw.NewLine);

                    double lineCountDiv = (lineCount + 4) / 10;
                    int blockLines = 10 - ((lineCount + 4) % 10);
                    int blockCount = (int)(((lineCount + 4) + blockLines) / 10);


                    // FILE CONTROL RECORD
                    sw.Write("9");
                    sw.Write("000001");
                    sw.Write(blockCount.ToString().PadLeft(6, '0'));
                    sw.Write(lineCount.ToString().PadLeft(8, '0'));
                    sw.Write(entryHash.ToString().PadLeft(10, '0'));
                    sw.Write("000000000000");
                    sw.Write(totalAmountRounded.ToString().PadLeft(12, '0'));
                    sw.Write(this.addEmptyFixedLengthText(39));
                    sw.Write(sw.NewLine);



                    for (int j = 0; j < blockLines; j++)
                    {
                        for (int i = 0; i < 94; i++)
                        {
                            sw.Write("9");
                        }
                        if (j == (blockLines - 1))
                        { }
                        else
                        {
                            sw.Write(sw.NewLine);
                        }
                    }

                    

                } // using

            } // if null
        }


        private string formatFixedLengthText(string value, int length)
        {
            string fixedValue = string.Empty;

            if (value == null)
            {
                fixedValue = string.Empty;

                for (int i = 0; i < length; i++)
                {
                    fixedValue += " ";
                }
            }
            else
            {
                if (value.Length == length)
                {
                    fixedValue = value;
                }
                else if (value.Length > length)
                {
                    fixedValue = value.Substring(0, length);
                }
                else if (value.Length < length)
                {
                    int spaceLength = length - value.Length;

                    for (int i = 0; i < spaceLength; i++)
                    {
                        value += " ";
                    }
                    fixedValue = value;
                }
            }
            return fixedValue;
        }



        private string addEmptyFixedLengthText(int length)
        {
            string fixedValue = string.Empty;

            for (int i = 0; i < length; i++)
            {
                fixedValue += " ";
            }

            return fixedValue;
        }



        private int sumOfDigits(int digitsToSum)
        {
            int sum = 0;

            while (digitsToSum != 0)
            {
                sum += digitsToSum % 10;
                digitsToSum /= 10;
            }

            return sum;
        }

        private void printBatchToolStripButton_Click(object sender, EventArgs e)
        {
            long batchId = (long)this.aCHFileDataGridView.SelectedRows[0].Cells[0].Value;
            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-fileserv01\ACHReports\Abra Reports\Misc\ACH Batch Details.rpt");

            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["BatchId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = batchId;

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

        private void previewBatchToolStripButton_Click(object sender, EventArgs e)
        {
            long batchId = (long)this.aCHFileDataGridView.SelectedRows[0].Cells[0].Value;

            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-intranet\Abra Reports\Misc\ACH Batch Details.rpt");

            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["BatchId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = batchId;

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
    }
}
