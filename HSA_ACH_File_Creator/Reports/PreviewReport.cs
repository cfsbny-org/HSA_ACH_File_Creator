using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace Cfs.Custom.Software.Reports
{
    public partial class PreviewReport : Form
    {
        public PreviewReport()
        {
            InitializeComponent();
        }



        private ReportDocument _report;


        public ReportDocument Report
        {
            get
            {
                return this._report;
            }
            set
            {
                this._report = value;
            }
        }


        private void PreviewReport_Load(object sender, EventArgs e)
        {

            this.reportViewer.ReportSource = this._report;
        }
    }
}
