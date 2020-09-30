using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cfs.Custom.Software
{
    public partial class AddStaffLine : Form
    {
        public AddStaffLine()
        {
            InitializeComponent();
        }


        private long _batchId = 0;


        public long BatchId
        {
            get
            {
                return this._batchId;
            }
            set
            {
                this._batchId = value;
            }
        }




        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            using (Data.BenefitsDbDataContext db = new Cfs.Custom.Software.Data.BenefitsDbDataContext())
            {

                try
                {
                    decimal emAmount = Convert.ToDecimal(this.emAmount.Text.Replace("$", string.Empty));
                    decimal erAmount = Convert.ToDecimal(this.erAmount.Text.Replace("$", string.Empty));

                    int accountTypeId = 32;

                    if (this.accountTypeList.SelectedIndex != -1)
                    {
                        accountTypeId = ((Data.AccountType)this.accountTypeList.SelectedItem).accountTypeId;
                    }

                    if (erAmount != 0)
                    {
                        Data.ACHDetail erDetail = new Cfs.Custom.Software.Data.ACHDetail();

                        erDetail.achBatchId = this._batchId;
                        erDetail.employeeId = this.employeeId.Text;
                        erDetail.lastName = this.lastName.Text.Trim();
                        erDetail.firstName = this.firstName.Text.Trim();
                        erDetail.middleInitial = this.middleInit.Text.Trim();
                        erDetail.erAmount = erAmount;
                        erDetail.emAmount = 0;
                        erDetail.routingNumber = this.routingNumber.Text.Trim();
                        erDetail.accountNumber = this.accountNumber.Text.Trim();
                        erDetail.includeInFile = true;
                        erDetail.accountType = accountTypeId.ToString();

                        db.ACHDetails.InsertOnSubmit(erDetail);
                        db.SubmitChanges();
                    }


                    if (emAmount != 0)
                    {
                        Data.ACHDetail emDetail = new Cfs.Custom.Software.Data.ACHDetail();

                        emDetail.achBatchId = this._batchId;
                        emDetail.employeeId = this.employeeId.Text;
                        emDetail.lastName = this.lastName.Text.Trim();
                        emDetail.firstName = this.firstName.Text.Trim();
                        emDetail.middleInitial = this.middleInit.Text.Trim();
                        emDetail.erAmount = 0;
                        emDetail.emAmount = emAmount;
                        emDetail.routingNumber = this.routingNumber.Text.Trim();
                        emDetail.accountNumber = this.accountNumber.Text.Trim();
                        emDetail.includeInFile = true;
                        emDetail.accountType = accountTypeId.ToString();

                        db.ACHDetails.InsertOnSubmit(emDetail);
                        db.SubmitChanges();
                    }


                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    string errorMessage = ex.Message;

                    if (ex.InnerException != null)
                    {
                        errorMessage += Environment.NewLine + ex.InnerException.Message;
                    }

                    MessageBox.Show(errorMessage, "Error Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddStaffLine_Load(object sender, EventArgs e)
        {
            using (Data.BenefitsDbDataContext db = new Cfs.Custom.Software.Data.BenefitsDbDataContext())
            {

                this.accountTypeList.DataSource = db.AccountTypes;
                this.accountTypeList.DisplayMember = "accountTypeDetail";
                this.accountTypeList.ValueMember = "accountTypeId";

            }
        }
    }
}
