using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace Cfs.Custom.Software
{
    public partial class PayStubExport : Form
    {

        private BackgroundWorker abraWorker;

        private Data.CfsMasterDbDataContext ObjectContext = new Data.CfsMasterDbDataContext();


        public PayStubExport()
        {
            InitializeComponent();

            this.abraWorker = new BackgroundWorker();
            this.abraWorker.DoWork += new DoWorkEventHandler(abraWorker_DoWork);
            this.abraWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(abraWorker_RunWorkerCompleted);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            string codeKey = guid.ToString();

            codeKey = codeKey.Substring(0, 8);

            

            //List<string> parameters = new List<string>();
            //parameters.Add(codeKey);
            //parameters.Add(this.payDate.Text);

            //this.abraWorker.RunWorkerAsync(parameters);

            string checkDate = DateTime.Parse(this.payDate.Text).ToShortDateString();
            DateTime startDate = new DateTime((int)this.payrollYear.SelectedItem, 1, 1);
            string company = this.companyList.SelectedItem.ToString();



            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\data;Collating Sequence=general;";

            OleDbConnection conn = new OleDbConnection(connString);

            long stubId = 0;

            try
            {

                Data.CheckStub stub = new Data.CheckStub();

                stub.stubBatchCreatedBy = Environment.UserName;
                stub.stubBatchCreated = DateTime.Now;
                stub.checkDate = DateTime.Parse(checkDate);
                stub.companyId = company;
                stub.isUploaded = false;
                stub.isVoided = false;

                this.ObjectContext.CheckStubs.InsertOnSubmit(stub);
                this.ObjectContext.SubmitChanges();

                stubId = stub.stubBatchId;

                StringBuilder query = new StringBuilder();

                query.Append("SELECT c.empno, c.chkdate, c.chknumber, c.chkstatus, c.totalgross, c.amount, c.payperiod, ");
                query.Append("h.p_lname, h.p_fname, h.p_mi, h.p_hstreet1, h.p_hstreet2, h.p_hcity, h.p_hstate, ");
                query.Append("h.p_hzip, h.p_salhour, h.p_salary, h.p_unitrate ");
                query.Append("FROM prckhist c INNER JOIN hrpersnl h ON c.company = h.p_company AND c.empno = h.p_empno ");
                query.Append("WHERE c.company = '" + company + "' AND c.chkdate = {" + checkDate + "};");

                OleDbCommand comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;



                conn.Open();
                OleDbDataReader reader = comm.ExecuteReader();

                

                while (reader.Read())
                {
                    Data.CheckStubHeader item = new Data.CheckStubHeader();

                    item.abraId = int.Parse(reader["empno"].ToString());
                    item.checkDate = DateTime.Parse(reader["chkdate"].ToString());
                    item.checkNumber = reader["chknumber"].ToString();
                    item.checkStatus = char.Parse(reader["chkstatus"].ToString().Trim());
                    item.grossPay = decimal.Parse(reader["totalgross"].ToString());
                    item.netPay = decimal.Parse(reader["amount"].ToString());
                    DateTime payPeriodEndDate = DateTime.Parse(reader["payperiod"].ToString());
                    
                    DateTime payPeriodStartDate;
                    
                    if (company == "SGF")
                    {
                        if (payPeriodEndDate.Day > 15)
                        {
                            payPeriodStartDate = new DateTime(payPeriodEndDate.Year, payPeriodEndDate.Month, 16);
                        }
                        else
                        {
                            payPeriodStartDate = new DateTime(payPeriodEndDate.Year, payPeriodEndDate.Month, 1);
                        }
                    }
                    else
                    {
                        payPeriodStartDate = payPeriodEndDate.AddDays(-13);
                    }

                    item.payPeriodStart = payPeriodStartDate;
                    item.payPeriodEnd = payPeriodEndDate;
                    item.payToOrder = reader["p_fname"].ToString().Trim() + " " + reader["p_mi"].ToString().Trim()  + " " + reader["p_lname"].ToString().Trim();
                    item.payToAddress = reader["p_hstreet1"].ToString().Trim();
                    item.payToAddress += Environment.NewLine;
                    if (reader["p_hstreet2"].ToString().Trim() != string.Empty)
                    {
                        item.payToAddress += reader["p_hstreet2"].ToString().Trim();
                        item.payToAddress += Environment.NewLine;
                    }
                    item.payToAddress += reader["p_hcity"].ToString().Trim() + ", " + reader["p_hstate"].ToString().Trim() + " " + reader["p_hzip"].ToString().Trim();

                    string empType = reader["p_salhour"].ToString().Trim();

                    if (empType == "S")
                    {
                        item.salaryRate = decimal.Parse(reader["p_salary"].ToString());
                    }
                    else
                    {
                        item.salaryRate = decimal.Parse(reader["p_unitrate"].ToString());
                    }
                    item.checkStubBatchId = stubId;

                    this.ObjectContext.CheckStubHeaders.InsertOnSubmit(item);

                    
                }

                reader.Close();
                reader.Dispose();

                query = new StringBuilder();

                query.Append("SELECT p.empno, p.accttype, p.bankacct, p.amount, c.chknumber, p.chkdate ");
                query.Append("FROM prhdirct p INNER JOIN prckhist c ON p.company = c.company AND ");
                query.Append("p.empno = c.empno AND p.chkdate = c.chkdate ");
                query.Append("WHERE p.company = '" + company + "' AND p.chkdate = {" + checkDate + "};");

                comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;

                OleDbDataReader ddReader = comm.ExecuteReader();


                while (ddReader.Read())
                {
                    Data.CheckStubDetail item = new Data.CheckStubDetail();

                    item.abraId = int.Parse(ddReader["empno"].ToString());
                    item.checkNumber = ddReader["chknumber"].ToString();
                    item.checkDate = DateTime.Parse(ddReader["chkdate"].ToString());
                    item.checkSectionId = (int)Data.PayStubObjects.CheckStubSection.DirectDeposits;
                    item.itemCode = ddReader["accttype"].ToString();

                    string accountNumber = ddReader["bankacct"].ToString().Trim();
                    item.itemDescription = accountNumber.Substring(accountNumber.Length - 4).PadLeft(10, 'X');

                    item.itemAmount = double.Parse(ddReader["amount"].ToString());
                    item.itemRate = 0;
                    item.itemQuantity = 0;

                    item.checkStubBatchId = stubId;

                    this.ObjectContext.CheckStubDetails.InsertOnSubmit(item);
                }

                ddReader.Close();
                ddReader.Dispose();


                query = new StringBuilder();

                query.Append("SELECT j.empno, j.earncode, p.stubdesc, j.payrate, j.hours, j.amount, j.chknumber, j.chkdate FROM prjobcst j ");
                query.Append("INNER JOIN prcodes p ON j.earncode = p.code ");
                query.Append("WHERE j.company = '" + company + "' AND p.company = '" + company + "' AND chkdate = {" + checkDate + "};");

                comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;

                OleDbDataReader eeReader = comm.ExecuteReader();

                while (eeReader.Read())
                {
                    Data.CheckStubDetail item = new Data.CheckStubDetail();

                    item.abraId = int.Parse(eeReader["empno"].ToString());
                    item.checkNumber = eeReader["chknumber"].ToString();
                    item.checkDate = DateTime.Parse(eeReader["chkdate"].ToString());
                    item.checkSectionId = (int)Data.PayStubObjects.CheckStubSection.Earnings;
                    item.itemCode = eeReader["earncode"].ToString();
                    item.itemDescription = eeReader["stubdesc"].ToString();
                    item.itemRate = double.Parse(eeReader["payrate"].ToString());
                    item.itemQuantity = double.Parse(eeReader["hours"].ToString());
                    item.itemAmount = double.Parse(eeReader["amount"].ToString());

                    item.checkStubBatchId = stubId;

                    this.ObjectContext.CheckStubDetails.InsertOnSubmit(item);
                }

                eeReader.Close();
                eeReader.Dispose();


                query = new StringBuilder();

                query.Append("SELECT d.empno, d.code, t.taxdesc, d.amount, d.chknumber, c.chkdate ");
                query.Append("FROM prdehist d INNER JOIN prckhist c ON d.chknumber = c.chknumber AND d.empno = c.empno AND d.company = c.company ");
                query.Append("INNER JOIN prtaxcds t ON d.code = t.taxcode WHERE d.company = '" + company + "' AND c.chkdate = {" + checkDate + "} ");
                query.Append("AND d.detailType = 'T' AND d.amount <> 0 AND t.company = '" + company + "';");

                comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;

                OleDbDataReader taxReader = comm.ExecuteReader();

                while (taxReader.Read())
                {
                    Data.CheckStubDetail item = new Data.CheckStubDetail();

                    item.abraId = int.Parse(taxReader["empno"].ToString());
                    item.checkNumber = taxReader["chknumber"].ToString();
                    item.checkDate = DateTime.Parse(taxReader["chkdate"].ToString());
                    item.checkSectionId = (int)Data.PayStubObjects.CheckStubSection.Taxes;
                    item.itemCode = taxReader["code"].ToString();
                    item.itemDescription = taxReader["taxdesc"].ToString();
                    item.itemAmount = double.Parse(taxReader["amount"].ToString());
                    item.itemRate = 0;
                    item.itemQuantity = 0;

                    item.checkStubBatchId = stubId;
                    
                    this.ObjectContext.CheckStubDetails.InsertOnSubmit(item);
                }

                taxReader.Close();
                taxReader.Dispose();


                query = new StringBuilder();

                query.Append("SELECT d.empno, d.code, p.stubdesc, d.amount, d.chknumber, c.chkdate ");
                query.Append("FROM prdehist d INNER JOIN prckhist c ON d.chknumber = c.chknumber AND d.empno = c.empno AND d.company = c.company ");
                query.Append("INNER JOIN prcodes p ON d.code = p.code WHERE p.company = '" + company + "' AND c.company = '" + company + "' AND c.chkdate = {" + checkDate + "} ");
                query.Append("AND d.detailType = 'D' AND d.amount <> 0;");

                comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;

                OleDbDataReader dedReader = comm.ExecuteReader();

                while (dedReader.Read())
                {
                    Data.CheckStubDetail item = new Data.CheckStubDetail();

                    item.abraId = int.Parse(dedReader["empno"].ToString());
                    item.checkNumber = dedReader["chknumber"].ToString();
                    item.checkDate = DateTime.Parse(dedReader["chkdate"].ToString());
                    item.checkSectionId = (int)Data.PayStubObjects.CheckStubSection.Deductions;
                    item.itemCode = dedReader["code"].ToString();
                    item.itemDescription = dedReader["stubdesc"].ToString();
                    item.itemAmount = double.Parse(dedReader["amount"].ToString());
                    item.itemRate = 0;
                    item.itemQuantity = 0;

                    item.checkStubBatchId = stubId;

                    this.ObjectContext.CheckStubDetails.InsertOnSubmit(item);
                }

                dedReader.Close();
                dedReader.Dispose();


                query = new StringBuilder();

                query.Append("SELECT p.empno, p.detailtype, p.code, SUM(p.amount) AS ytdamount ");
                query.Append("FROM prdehist p INNER JOIN prckhist c ");
                query.Append("ON p.chknumber = c.chknumber AND p.empno = c.empno AND p.company = c.company ");
                query.Append("WHERE p.company = '" + company + "' AND c.company = '" + company + "' AND c.chkdate BETWEEN { " + startDate.ToShortDateString() + "} ");
                query.Append("AND {" + checkDate + "} ");
                query.Append("GROUP BY p.empno, p.detailtype, p.code ");
                query.Append("HAVING SUM(p.amount) <> 0;");

                comm = new OleDbCommand(query.ToString(), conn);
                comm.CommandType = System.Data.CommandType.Text;

                OleDbDataReader ytdReader = comm.ExecuteReader();

                while (ytdReader.Read())
                {
                    Data.CheckStubYtd item = new Data.CheckStubYtd();

                    item.checkNumber = string.Empty;
                    item.checkDate = DateTime.Parse(checkDate);
                    //item.checkSectionId = (int)Data.PayStubObjects.CheckStubSection.YtdDetail;
                    item.abraId = int.Parse(ytdReader["empno"].ToString());
                    item.itemCode = ytdReader["code"].ToString();
                    item.codeType = ytdReader["detailtype"].ToString();
                    item.ytdAmount = double.Parse(ytdReader["ytdamount"].ToString());

                    item.checkStubBatchId = stubId;

                    this.ObjectContext.CheckStubYtds.InsertOnSubmit(item);
                }

                ytdReader.Close();
                ytdReader.Dispose();


                if (company == "CFS")
                {

                    query = new StringBuilder();

                    query.Append("SELECT s.t_empno, s.t_id, s.t_carry, s.t_close, s.t_taken ");
                    query.Append("FROM hatsum s INNER JOIN prckhist c ");
                    query.Append("ON s.t_empno = c.empno AND s.t_company = c.company ");
                    query.Append("WHERE s.t_noaccrue = 0 AND s.t_company = '" + company + "' AND c.company = '" + company + "' AND c.chkdate = { " + checkDate + "};");
                    

                    comm = new OleDbCommand(query.ToString(), conn);
                    comm.CommandType = System.Data.CommandType.Text;

                    OleDbDataReader ptoReader = comm.ExecuteReader();

                    while (ptoReader.Read())
                    {
                        Data.CheckStubPtoBalance balance = new Data.CheckStubPtoBalance();

                        balance.checkStubBatchId = stubId;

                        balance.abraId = int.Parse(ptoReader["t_empno"].ToString());
                        balance.ptoCode = ptoReader["t_id"].ToString();
                        balance.ptoCarried = double.Parse(ptoReader["t_carry"].ToString());
                        balance.ptoClose = double.Parse(ptoReader["t_close"].ToString());
                        balance.ptoTaken = double.Parse(ptoReader["t_taken"].ToString());

                        this.ObjectContext.CheckStubPtoBalances.InsertOnSubmit(balance);
                    }

                    ptoReader.Close();
                    ptoReader.Dispose();

                }
                comm.Dispose();


                this.ObjectContext.SubmitChanges();

                //Data.PayStubObjects.ExportFileDetail file = new Data.PayStubObjects.ExportFileDetail();

                

                


                MessageBox.Show("Data export complete.");

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (ex.InnerException != null)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                this.stubDataView.Refresh();
            }
           

           

        }



        private void abraWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> parameters = (List<string>)e.Argument;

            string codeKey = parameters[0];
            string payDateString = parameters[1];


            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\abra\data;Collating Sequence=general;";

            OleDbConnection conn = new OleDbConnection(connString);
            StringBuilder query = new StringBuilder();



        }


        private void abraWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void PayStubExport_Load(object sender, EventArgs e)
        {
            this.stubDataView.DataSource = this.ObjectContext.CheckStubs.Where(s => s.isUploaded == false && s.isVoided == false && s.companyId == "SGF");

            int currentYear = DateTime.Now.Year;
            this.payrollYear.Items.Add(currentYear - 1);
            this.payrollYear.Items.Add(currentYear);
            this.payrollYear.Items.Add(currentYear + 1);
        }




        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.stubDataView.SelectedRows.Count > 0)
            {
                Data.CheckStub selectedStub = (Data.CheckStub)this.stubDataView.CurrentRow.DataBoundItem;

                selectedStub.isVoided = true;
                selectedStub.voidedStamp = DateTime.Now;

                this.ObjectContext.SubmitChanges();

                this.stubDataView.DataSource = this.ObjectContext.CheckStubs.Where(s => s.isUploaded == false && s.isVoided == false);
            }
            else
            {
                MessageBox.Show("No file selected.");
            }
        }



        private void uploadButton_Click(object sender, EventArgs e)
        {
            if (this.stubDataView.SelectedRows.Count > 0)
            {
                Data.CheckStub selectedStub = (Data.CheckStub)this.stubDataView.CurrentRow.DataBoundItem;

                //MessageBox.Show(selectedStub.stubBatchId.ToString());

                var headers = this.ObjectContext.CheckStubHeaders.Where(h => h.checkStubBatchId == selectedStub.stubBatchId);
                var detail = this.ObjectContext.CheckStubDetails.Where(d => d.checkStubBatchId == selectedStub.stubBatchId);
                var summary = this.ObjectContext.CheckStubYtds.Where(s => s.checkStubBatchId == selectedStub.stubBatchId);

                //MessageBox.Show(headers.Count.ToString());
                //MessageBox.Show(detail.Count.ToString());
                //MessageBox.Show(summary.Count.ToString());

                Data.PayStubObjects.ExportFileDetail fileDetail = new Data.PayStubObjects.ExportFileDetail();

                fileDetail.createdBy = Environment.UserName;
                fileDetail.createdStamp = DateTime.Now;
                fileDetail.uploadedIp = Environment.MachineName;
                fileDetail.checkDate = selectedStub.checkDate;
                fileDetail.checkHeader = headers.ToList();
                fileDetail.checkDetail = detail.ToList();
                fileDetail.checkSummary = summary.ToList();


                JavaScriptSerializer js = new JavaScriptSerializer();
                string fileString = js.Serialize(fileDetail);

                string encryptedString = Security.Encryption.EncryptData(fileString, "cfsToSgfChkStbs!4565");


                Sgf.Web.Services.CheckStubImportSoapClient client = new Sgf.Web.Services.CheckStubImportSoapClient();
                try
                {
                    client.ImportCheckStubs(encryptedString);

                    selectedStub.isUploaded = true;
                    selectedStub.uploadedStamp = DateTime.Now;

                    // this.ObjectContext.FalkCheckStubs.Attach(selectedStub, true);
                    this.ObjectContext.SubmitChanges();

                    this.stubDataView.DataSource = this.ObjectContext.CheckStubs.Where(s => s.isUploaded == false && s.isVoided == false);

                    MessageBox.Show("Process completed successfully.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;

                    if (ex.InnerException != null)
                    {
                        message += Environment.NewLine + ex.InnerException.Message;
                    }

                    MessageBox.Show(message);
                }
                finally
                {
                    client.Close();
                    
                }



                
            }
            else
            {
                MessageBox.Show("No file selected.");
            }

        }

        private void viewButton_Click(object sender, EventArgs e)
        {

        }


    }
}
