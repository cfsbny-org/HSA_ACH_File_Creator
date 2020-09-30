using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cfs.Custom.Software
{
    public partial class ValicResponseReader : Form
    {
        public ValicResponseReader()
        {
            InitializeComponent();
        }

        private void ValicResponseReader_Load(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                List<Data.ValicResponseFile> responeLines = new List<Data.ValicResponseFile>();


                Stream fileStream = this.openFileDialog1.OpenFile();


                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null)
                    {

                        responeLines.Add(new Data.ValicResponseFile()
                        {
                            payGroupId = line.Substring(0, 12),
                            locationCode = line.Substring(12, 4),
                            locationName = line.Substring(16, 35),
                            socSecNum = line.Substring(51, 9),
                            employeeId = line.Substring(60, 20),
                            loanNumber = line.Substring(80, 5),
                            amountFinanced = decimal.Parse(line.Substring(85, 12)),
                            paymentFreq = line.Substring(97, 1),
                            loanInterestRate = decimal.Parse(line.Substring(98, 5)),
                            paymentsRemaining = decimal.Parse(line.Substring(103, 4)),
                            firstDueDate = ParseDateMMDDYYYY(line.Substring(107, 8)),
                            repaymentAmount = decimal.Parse(line.Substring(115, 12)),
                            paymentMethod = line.Substring(127, 1),
                            totalLoanRepayment  = decimal.Parse(line.Substring(128, 12)),
                            loanFinanceCharge = decimal.Parse(line.Substring(140, 12)),
                            lastPaymentAmount = decimal.Parse(line.Substring(152, 12)),
                            lastPaymentDate = ParseDateMMDDYYYY(line.Substring(167, 8))
                        }); 
                    }
                }

                fileStream.Close();
                fileStream.Dispose();

                this.dataGridView1.DataSource = responeLines;
                
                //Reports.ValicResponseFile report = new Reports.ValicResponseFile();
                //report.SetDataSource(responeLines);

                //this.crystalReportViewer1.ReportSource = report;
                //this.crystalReportViewer1.
            }


        }


        private DateTime ParseDateMMDDYYYY(string dateString)
        {
            if (dateString.Trim() == string.Empty)
            {
                return DateTime.MinValue;
            }
            else
            {
                int month = int.Parse(dateString.Substring(0, 2));
                int day = int.Parse(dateString.Substring(2, 2));
                int year = int.Parse(dateString.Substring(4, 4));

                return new DateTime(year, month, day);
            }
        }
    }
}
