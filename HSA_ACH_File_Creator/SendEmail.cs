using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;


namespace Cfs.Custom.Software
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }


        private Data.BenefitsDbDataContext context = new Cfs.Custom.Software.Data.BenefitsDbDataContext();
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



        private void sendEmailToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application outlook = new Microsoft.Office.Interop.Outlook.Application();
                MailItem email = (MailItem)(outlook.CreateItem(OlItemType.olMailItem));

                email.To = "sbarden@cfsbny.org";
                //email.CC = "jbowen@cfsbny.org";
                email.CC = "tborelli@cfsbny.org";

                email.Subject = "HSA ACH File: Ready to Process";
                email.Importance = OlImportance.olImportanceHigh;

                email.Body = this.emailBody.Text;

                ((Microsoft.Office.Interop.Outlook._MailItem)email).Send();

                this.Dispose();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Sending Message", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }

            


        }

        private void SendEmail_Load(object sender, EventArgs e)
        {
            Data.ACHFile file = (from achFiles in context.ACHFiles
                                 where achFiles.achBatchId == this._batchId
                                 select achFiles).Single();

            StringBuilder emailBodyText = new StringBuilder();
            emailBodyText.Append("ACH File Details" + Environment.NewLine + Environment.NewLine);
            emailBodyText.Append("Batch #: " + this._batchId.ToString() + Environment.NewLine);
            emailBodyText.Append("Pay Date: " + file.achCheckDate.ToShortDateString() + Environment.NewLine);
            emailBodyText.Append("Company: " + file.achCompany + Environment.NewLine);

            this.emailBody.Text = emailBodyText.ToString();

        }
    }
}
