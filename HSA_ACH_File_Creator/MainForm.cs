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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void aCHBatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewBatch newBatch = new NewBatch();
            newBatch.MdiParent = this;
            newBatch.Show();
        }

        private void aCHBatchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Batches batches = new Batches();
            batches.MdiParent = this;
            batches.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutHSAACHFileCreatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void exportPayStubsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayStubExport stubs = new PayStubExport();
            stubs.MdiParent = this;
            stubs.Show();
        }

        private void printTimesheetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintTimesheets timesheets = new PrintTimesheets();
            timesheets.MdiParent = this;
            timesheets.Show();
        }

        private void createVisionFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Benefits.VisionEnrollmentFile vision = new Benefits.VisionEnrollmentFile();
            vision.MdiParent = this;
            vision.Show();
        }

        private void oSHAWorksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OSHA osha = new OSHA();
            osha.MdiParent = this;
            osha.Show();
        }

        private void valicRemittanceFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValicRemittance valic = new ValicRemittance();
            valic.MdiParent = this;
            valic.Show();
        }

        private void valicResponseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValicResponseReader reader = new ValicResponseReader();
            reader.MdiParent = this;
            reader.Show();
        }

        private void valicPaidOffLoansReportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
