using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cfs.Custom.Software
{
    public partial class PrintTimesheets : Form
    {
        public PrintTimesheets()
        {
            InitializeComponent();


        }



        private Data.CfsMasterDbDataContext _context = new Data.CfsMasterDbDataContext();




        private void PrintTimesheets_Load(object sender, EventArgs e)
        {
            //List<Data.GeneralObjects.UsersModel> users = new List<Data.GeneralObjects.UsersModel>();

            var users = from u in this._context.Users
                        orderby u.lastName, u.firstName
                        select new Data.GeneralObjects.UsersModel
                        {
                            userId = u.userId,
                            userName = u.lastName.Trim() + ", " + u.firstName.Trim(),
                            isActive = u.activeFlag
                        };


            this.usersList.DataSource = users;
            this.usersList.DisplayMember = "userName";
            this.usersList.ValueMember = "userId";


        }




        private void PrintTimesheetReport(long payPeriodId)
        {


            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-intranet\Abra Reports\Misc\Timesheets.rpt");

            ConnectionInfo ci = new ConnectionInfo();

            ci.ServerName = "cfs-intranet";
            ci.DatabaseName = "CFS_Master";
            ci.IntegratedSecurity = true;

            Tables tables = report.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogOn = table.LogOnInfo;
                tableLogOn.ConnectionInfo = ci;
                table.ApplyLogOnInfo(tableLogOn);
            }


            Sections sections = report.ReportDefinition.Sections;

            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;

                foreach (ReportObject reportObject in reportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);

                        Tables subreportTables = subReportDocument.Database.Tables;

                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreportTables)
                        {
                            TableLogOnInfo tableLogOn = table.LogOnInfo;
                            tableLogOn.ConnectionInfo = ci;
                            table.ApplyLogOnInfo(tableLogOn);
                        }
                    }
                }
            }

            //report.VerifyDatabase();
            report.Refresh();


            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["payPeriodId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = payPeriodId;

            ParameterValues values = new ParameterValues();
            values = parameter.CurrentValues;
            values.Clear();
            values.Add(parameterValue);
            parameter.ApplyCurrentValues(values);

            report.SetParameterValue("@payPeriodId", payPeriodId, "PtoSummarySubreport");
            report.SetParameterValue("@payPeriodId", payPeriodId, "BucketsSubreport");



            this.crystalReportViewer1.ReportSource = report;
            this.crystalReportViewer1.Visible = true;

            this.buttonPrinted.Enabled = true;
            this.btnReset.Enabled = true;
        }



        private void runTimesheets_Click(object sender, EventArgs e)
        {

            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            this.PrintTimesheetReport(payPeriod.payPeriodId);
        }

        private void buttonPrinted_Click(object sender, EventArgs e)
        {

            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            var timesheets = from t in this._context.Timesheets
                             join a in this._context.Approvals
                                on t.timesheetId equals a.approvalObjectId
                             where a.approvalTypeId == 3 && a.approvalStatusId == 3 && t.payPeriodId == payPeriod.payPeriodId
                             select t;

            foreach (var timesheet in timesheets.ToList())
            {
                timesheet.isProcessed = true;
                this._context.SubmitChanges();
            }

            MessageBox.Show("Timesheets for this period have been marked as printed.");
        }

        private void crystalReportViewer1_ReportRefresh(object source, CrystalDecisions.Windows.Forms.ViewerEventArgs e)
        {
            e.Handled = true;

            ReportDocument report = (ReportDocument)this.crystalReportViewer1.ReportSource;
            report.Refresh();

            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            report.SetParameterValue("payPeriodid", payPeriod.payPeriodId);
            report.SetParameterValue("@payPeriodId", payPeriod.payPeriodId, "PtoSummarySubreport");
            report.SetParameterValue("@payPeriodId", payPeriod.payPeriodId, "BucketsSubreport");



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            var timesheets = from t in this._context.Timesheets
                             join a in this._context.Approvals
                                on t.timesheetId equals a.approvalObjectId
                             where a.approvalTypeId == 3 && a.approvalStatusId == 3 && t.payPeriodId == payPeriod.payPeriodId
                             select t;

            foreach (var timesheet in timesheets.ToList())
            {
                timesheet.isProcessed = false;
                this._context.SubmitChanges();
            }

            MessageBox.Show("Timesheets for this period have been marked as printed.");
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.usersList.SelectedIndex != -1)
            {

                long userId = (long)this.usersList.SelectedValue;

                DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

                Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                            where p.payDate == payDate
                                            select p).SingleOrDefault();

                int payPeriodId = payPeriod.payPeriodId;

                ReportDocument report = new ReportDocument();
                report.Load(@"\\cfs-intranet\Abra Reports\Misc\TimesheetsByUser.rpt");

                ConnectionInfo ci = new ConnectionInfo();

                ci.ServerName = "cfs-intranet";
                ci.DatabaseName = "CFS_Master";
                ci.IntegratedSecurity = true;

                Tables tables = report.Database.Tables;

                foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
                {
                    TableLogOnInfo tableLogOn = table.LogOnInfo;
                    tableLogOn.ConnectionInfo = ci;
                    table.ApplyLogOnInfo(tableLogOn);
                }


                Sections sections = report.ReportDefinition.Sections;

                foreach (Section section in sections)
                {
                    ReportObjects reportObjects = section.ReportObjects;

                    foreach (ReportObject reportObject in reportObjects)
                    {
                        if (reportObject.Kind == ReportObjectKind.SubreportObject)
                        {
                            SubreportObject subreportObject = (SubreportObject)reportObject;
                            ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);

                            Tables subreportTables = subReportDocument.Database.Tables;

                            foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreportTables)
                            {
                                TableLogOnInfo tableLogOn = table.LogOnInfo;
                                tableLogOn.ConnectionInfo = ci;
                                table.ApplyLogOnInfo(tableLogOn);
                            }
                        }
                    }
                }

                //report.VerifyDatabase();
                report.Refresh();


                ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
                ParameterFieldDefinition parameter = parameters["payPeriodId"];


                ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
                parameterValue.Value = payPeriodId;

                ParameterValues values = new ParameterValues();
                values = parameter.CurrentValues;
                values.Clear();
                values.Add(parameterValue);
                parameter.ApplyCurrentValues(values);


                ParameterFieldDefinition userParameter = parameters["userId"];


                ParameterDiscreteValue userParameterValue = new ParameterDiscreteValue();
                userParameterValue.Value = userId;

                ParameterValues userValues = new ParameterValues();
                userValues = userParameter.CurrentValues;
                userValues.Clear();
                userValues.Add(userParameterValue);
                userParameter.ApplyCurrentValues(userValues);



                report.SetParameterValue("@payPeriodId", payPeriodId, "PtoSummarySubreport");
                report.SetParameterValue("@payPeriodId", payPeriodId, "BucketsSubreport");



                this.crystalReportViewer1.ReportSource = report;
                this.crystalReportViewer1.Visible = true;

                this.buttonPrinted.Enabled = true;
                this.btnReset.Enabled = true;
            }
        }

        private void missingTimesheetsButton_Click(object sender, EventArgs e)
        {
            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            int payPeriodId = payPeriod.payPeriodId;

            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-intranet\Abra Reports\Misc\Missing Timesheets.rpt");

            ConnectionInfo ci = new ConnectionInfo();

            ci.ServerName = "cfs-intranet";
            ci.DatabaseName = "CFS_Master";
            ci.IntegratedSecurity = true;

            Tables tables = report.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogOn = table.LogOnInfo;
                tableLogOn.ConnectionInfo = ci;
                table.ApplyLogOnInfo(tableLogOn);
            }


            report.Refresh();


            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["@payPeriodId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = payPeriodId;

            ParameterValues values = new ParameterValues();
            values = parameter.CurrentValues;
            values.Clear();
            values.Add(parameterValue);
            parameter.ApplyCurrentValues(values);




            this.crystalReportViewer1.ReportSource = report;
            this.crystalReportViewer1.Visible = true;

        }

        private void exemptPtoButton_Click(object sender, EventArgs e)
        {
            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            int payPeriodId = payPeriod.payPeriodId;

            ReportDocument report = new ReportDocument();
            report.Load(@"\\cfs-intranet\Abra Reports\Misc\Exempt Staff PTO.rpt");

            ConnectionInfo ci = new ConnectionInfo();

            ci.ServerName = "cfs-intranet";
            ci.DatabaseName = "CFS_Master";
            ci.IntegratedSecurity = true;

            Tables tables = report.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo tableLogOn = table.LogOnInfo;
                tableLogOn.ConnectionInfo = ci;
                table.ApplyLogOnInfo(tableLogOn);
            }


            Sections sections = report.ReportDefinition.Sections;

            foreach (Section section in sections)
            {
                ReportObjects reportObjects = section.ReportObjects;

                foreach (ReportObject reportObject in reportObjects)
                {
                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
                    {
                        SubreportObject subreportObject = (SubreportObject)reportObject;
                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);

                        Tables subreportTables = subReportDocument.Database.Tables;

                        foreach (CrystalDecisions.CrystalReports.Engine.Table table in subreportTables)
                        {
                            TableLogOnInfo tableLogOn = table.LogOnInfo;
                            tableLogOn.ConnectionInfo = ci;
                            table.ApplyLogOnInfo(tableLogOn);
                        }
                    }
                }
            }

            report.Refresh();

            //MessageBox.Show(payPeriodId.ToString(), "PayPeriodId", MessageBoxButtons.OK, MessageBoxIcon.Information);


            ParameterFieldDefinitions parameters = report.DataDefinition.ParameterFields;
            ParameterFieldDefinition parameter = parameters["PayPeriodId"];


            ParameterDiscreteValue parameterValue = new ParameterDiscreteValue();
            parameterValue.Value = payPeriodId;

            ParameterValues values = new ParameterValues();
            values = parameter.CurrentValues;
            values.Clear();
            values.Add(parameterValue);
            parameter.ApplyCurrentValues(values);


            report.SetParameterValue("@payPeriodId", payPeriodId, "TimeOffRequestsSubreport");


            this.crystalReportViewer1.ReportSource = report;
            this.crystalReportViewer1.Visible = true;
        }



        // CREATE FILE FOR ULTIPRO IMPORT 
        private void createUltiProFile_Click(object sender, EventArgs e)
        {
            DateTime payDate = DateTime.Parse(this.payDatePicker.Text);

            Data.PayPeriod payPeriod = (from p in this._context.PayPeriods
                                        where p.payDate == payDate
                                        select p).SingleOrDefault();

            if (payPeriod == null)
            {
                MessageBox.Show("Please select a valid pay date.", "Pay Date Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int payPeriodId = payPeriod.payPeriodId;

            DateTime payPeriodStart = payPeriod.payPeriodBeginDate;
            DateTime payPeriodEnd = payPeriod.payPeriodEndDate;


            // GET BEGINNING OF WEEKS
            DateTime weekOneStart = payPeriodStart;
            DateTime weekTwoStart = payPeriodStart;

            for (var d = payPeriodStart.Date; d.Date < payPeriodEnd.Date; d = d.AddDays(1))
            {
                if (d.DayOfWeek == DayOfWeek.Monday)
                {
                    weekTwoStart = d;
                }
            }





            var holidays = (from h in this._context.Holidays
                            where h.holidayDate >= payPeriodStart && h.holidayDate <= payPeriodEnd
                            select h).ToList();



            var employees = (from u in this._context.Users
                             where u.activeFlag == true 
                                && u.essUser == true
                                && u.lastHireDate <= payPeriodEnd
                                //&& (u.termDate == null || u.termDate >= payPeriodStart)
                             orderby u.flsaStatus, u.lastName, u.firstName
                             select new
                             {
                                 u.userId,
                                 u.employeeId,
                                 u.lastName,
                                 u.firstName,
                                 u.abraHours,
                                 u.flsaStatus,
                                 u.holidayHours,
                                 u.employType
                             }).ToList();


            var exemptPtoRequests = (from p in this._context.PtoRequests
                                     join u in this._context.Users
                                         on p.userId equals u.userId
                                     where p.ptoRequestDate >= payPeriodStart && p.ptoRequestDate <= payPeriodEnd
                                        && p.approvalStatusId == 3
                                        && u.flsaStatus == 'Y'
                                        && u.lastHireDate <= payPeriodEnd
                                     group new { p, u } by new { u.userId, u.employeeId, u.lastName, u.firstName, u.abraHours, p.ptoCodeId } into g
                                     select new UP_PayrollExport
                                     {
                                         userId = g.Key.userId,
                                         employeeId = g.Key.employeeId,
                                         lastName = g.Key.lastName,
                                         firstName = g.Key.firstName,
                                         abraHours = g.Key.abraHours,
                                         ptoCodeId = g.Key.ptoCodeId,
                                         ptoHours = g.Sum(x => x.p.ptoRequestHours)
                                     }).ToList();




            var nonexemptTimesheets = (from t in this._context.Timesheets
                                       join d in this._context.TimesheetDetails
                                            on t.timesheetId equals d.timesheetId
                                       join u in this._context.Users
                                           on t.userId equals u.userId
                                       join a in this._context.Approvals
                                           on t.timesheetId equals a.approvalObjectId
                                       where t.payPeriodId == payPeriodId
                                           && a.approvalTypeId == 3
                                           && a.approvalStatusId == 3
                                           && t.timesheetTypeId != 4
                                           && t.timesheetTypeId != 3
                                       //group new { d, u } by new { d.timesheetId, d.ptoCodeId, u.userId, u.employeeId, u.lastName, u.firstName, u.abraHours } into g
                                       select new UP_PayrollExport
                                       {
                                           //userId = g.Key.userId,
                                           //employeeId = g.Key.employeeId,
                                           //lastName = g.Key.lastName,
                                           //firstName = g.Key.firstName,
                                           //abraHours = g.Key.abraHours,
                                           //ptoCodeId = g.Key.ptoCodeId,
                                           //workHours = g.Sum(x => x.d.workHours),
                                           //ptoHours = g.Sum(x => x.d.ptoHours)
                                           timesheetId = t.timesheetId,
                                           userId = t.userId,
                                           employeeId = u.employeeId,
                                           lastName = u.lastName,
                                           firstName = u.firstName,
                                           abraHours = u.abraHours,
                                           workDate = d.timesheetDetailDate,
                                           ptoCodeId = d.ptoCodeId,
                                           workHours = d.workHours,
                                           ptoHours = d.ptoHours
                                       }).ToList();



            //var ptoBuckets = this._context.PtoBuckets(payPeriodId).ToList();


            Excel.Application xl;
            Excel._Workbook workbook;
            Excel._Worksheet sheet;
            //Excel.Range range;

            xl = new Excel.Application();
            xl.Visible = false;

            workbook = (Excel._Workbook)(xl.Workbooks.Add(Missing.Value));
            sheet = (Excel._Worksheet)workbook.ActiveSheet;


            sheet.Cells[1, 1] = "Company";
            sheet.Cells[1, 2] = "Employee Number";
            sheet.Cells[1, 3] = "Employee Name";
            sheet.Cells[1, 4] = "Pay Period Hours";
            sheet.Cells[1, 5] = "Exempt?";
            sheet.Cells[1, 6] = "Earn Code";
            sheet.Cells[1, 7] = "Earn Hours";
            sheet.Cells[1, 8] = "Earn Code";
            sheet.Cells[1, 9] = "Earn Hours";
            sheet.Cells[1, 10] = "Earn Code";
            sheet.Cells[1, 11] = "Earn Hours";
            sheet.Cells[1, 12] = "Earn Code";
            sheet.Cells[1, 13] = "Earn Hours";
            sheet.Cells[1, 14] = "Earn Code";
            sheet.Cells[1, 15] = "Earn Hours";
            sheet.Cells[1, 16] = "Earn Code";
            sheet.Cells[1, 17] = "Earn Hours";
            sheet.Cells[1, 18] = "Earn Code";
            sheet.Cells[1, 19] = "Earn Hours";
            sheet.Cells[1, 20] = "Earn Code";
            sheet.Cells[1, 21] = "Earn Hours";
            sheet.Cells[1, 22] = "Earn Code";
            sheet.Cells[1, 23] = "Earn Hours";
            sheet.Cells[1, 24] = "Earn Code";
            sheet.Cells[1, 25] = "Earn Hours";
            sheet.Cells[1, 26] = "Notes";
            

            //sheet.Cells[2, 6] = "REG";
            //sheet.Cells[2, 8] = "OT";
            //sheet.Cells[2, 10] = "PTO";
            //sheet.Cells[2, 12] = "HOL";
            //sheet.Cells[2, 14] = "OTHER";
            //sheet.Cells[2, 16] = "HRB";
            //sheet.Cells[2, 18] = "BEREV";
            //sheet.Cells[2, 20] = "JURY";
            //sheet.Cells[2, 22] = "MIL";
            //sheet.Cells[2, 24] = "NOPAY";
            //sheet.Cells[2, 26] = "Delete column before import!";

            int row = 2;

            foreach (var employee in employees)
            {

                

                double regularHours = employee.abraHours == null ? 0 : (double)employee.abraHours;
                double ptoHours = 0;
                double hrbHours = 0;
                double holidayHours = 0;
                double otherHours = 0;
                double overtimeHours = 0;
                double brvHours = 0, juryHours = 0, milHours = 0, timeOffHours = 0;

                string employeeNotes = string.Empty;


                int holidayCount = holidays.Count;

                if (employee.flsaStatus == null || employee.flsaStatus == ' ')
                {

                }
                else if (employee.flsaStatus == 'Y')
                {
                    double totalPtoHours = exemptPtoRequests.Where(r => r.userId == employee.userId).Sum(r => r.ptoHours).Value;
                    ptoHours = exemptPtoRequests.Where(r => r.userId == employee.userId && r.ptoCodeId == 11).Sum(r => r.ptoHours).Value;
                    hrbHours = exemptPtoRequests.Where(r => r.userId == employee.userId && r.ptoCodeId == 12).Sum(r => r.ptoHours).Value;
                    brvHours = exemptPtoRequests.Where(n => n.userId == employee.userId && n.ptoCodeId == 5).Sum(n => n.ptoHours).Value;
                    juryHours = exemptPtoRequests.Where(n => n.userId == employee.userId && n.ptoCodeId == 6).Sum(n => n.ptoHours).Value;
                    milHours = exemptPtoRequests.Where(n => n.userId == employee.userId && n.ptoCodeId == 7).Sum(n => n.ptoHours).Value;
                    timeOffHours = exemptPtoRequests.Where(n => n.userId == employee.userId && n.ptoCodeId == 8).Sum(n => n.ptoHours).Value;

                    holidayHours = holidayCount * employee.holidayHours;

                    regularHours = regularHours - totalPtoHours - holidayHours;
                }
                else if (employee.flsaStatus == 'N')
                {

                    

                    var employeeTimesheet = nonexemptTimesheets.Where(n => n.userId == employee.userId).Select(t => t.timesheetId).Distinct().ToList();

                    if (employeeTimesheet.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        if (employeeTimesheet.Count > 1)
                        {
                            employeeNotes = "More than one approved timesheet exists for this employee!";
                        }
                    }

                    double totalWorkHours = nonexemptTimesheets.Where(n => n.userId == employee.userId).Sum(n => n.workHours).Value;
                    ptoHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 11).Sum(n => n.ptoHours).Value;
                    hrbHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 12).Sum(n => n.ptoHours).Value;
                    brvHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 5).Sum(n => n.ptoHours).Value;
                    juryHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 6).Sum(n => n.ptoHours).Value;
                    milHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 7).Sum(n => n.ptoHours).Value;
                    timeOffHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 8).Sum(n => n.ptoHours).Value;

                    holidayHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.ptoCodeId == 9).Sum(n => n.ptoHours).Value;

                    double weekOneWorkHours = 0, weekTwoWorkHours = 0, weekOneOtherHours = 0, weekTwoOtherHours = 0, weekOneOvertime = 0, weekTwoOvertime = 0;


                    // OTHER HOURS AND OVERTIME HOURS CALCULATIONS

                    weekOneWorkHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.workDate >= payPeriodStart && n.workDate < weekTwoStart).Sum(n => n.workHours).Value;
                    weekTwoWorkHours = nonexemptTimesheets.Where(n => n.userId == employee.userId && n.workDate >= weekTwoStart && n.workDate <= payPeriodEnd).Sum(n => n.workHours).Value;

                    double weeklySchedHours = (employee.abraHours == null ? 0 : (double)employee.abraHours) / 2;

                    weekOneOvertime = weekOneWorkHours - 40;

                    if (weekOneOvertime < 0)
                    {
                        weekOneOvertime = 0;
                    }

                    if (weekOneWorkHours > 35)
                    {
                        if (weekOneWorkHours > weeklySchedHours && weeklySchedHours > 0.5)
                        {
                            weekOneOtherHours += weekOneWorkHours - weeklySchedHours - weekOneOvertime;
                        }
                        //if (weekOneWorkHours > 40)
                        //{
                        //    weekOneOvertime += weekOneWorkHours - 40 - weekOneOtherHours;
                        //    if (weekOneOvertime < 0)
                        //    {
                        //        weekOneOvertime = 0;
                        //    }

                        //}
                    }

                    if (weekOneOtherHours < 0)
                    {
                        weekOneOtherHours = 0;
                    }


                    weekTwoOvertime = weekTwoWorkHours - 40;

                    if (weekTwoOvertime < 0)
                    {
                        weekTwoOvertime = 0;
                    }

                    if (weekTwoWorkHours > 35)
                    {
                        if (weekTwoWorkHours > weeklySchedHours && weeklySchedHours > 0.5)
                        {
                            weekTwoOtherHours += weekTwoWorkHours - weeklySchedHours - weekTwoOvertime;
                        }
                        //if (weekTwoWorkHours > 40)
                        //{
                        //    weekTwoOvertime += weekTwoWorkHours - 40 - weekTwoOtherHours;
                        //    if (weekTwoOvertime < 0)
                        //    {
                        //        weekTwoOvertime = 0;
                        //    }
                        //}
                    }

                    if (weekTwoOtherHours < 0)
                    {
                        weekTwoOtherHours = 0;
                    }

                    otherHours = weekOneOtherHours + weekTwoOtherHours;
                    overtimeHours = weekOneOvertime + weekTwoOvertime;

                    regularHours = totalWorkHours - otherHours - overtimeHours;
                }


                //    //double regularHours = employee.abraHours == null ? 0 : (double)employee.abraHours;



                sheet.Cells[row, 1] = "CFSEC";
                sheet.Cells[row, 2] = employee.employeeId.ToString();
                sheet.Cells[row, 3] = string.Format("{0}, {1}", employee.lastName, employee.firstName);
                sheet.Cells[row, 4] = employee.abraHours;
                sheet.Cells[row, 5] = employee.flsaStatus.ToString();
                sheet.Cells[row, 6] = "REG";
                sheet.Cells[row, 7] = regularHours;
                sheet.Cells[row, 8] = "OT";
                sheet.Cells[row, 9] = overtimeHours;
                sheet.Cells[row, 10] = "PTO";
                sheet.Cells[row, 11] = ptoHours;
                sheet.Cells[row, 12] = "HOL";
                sheet.Cells[row, 13] = holidayHours;
                sheet.Cells[row, 14] = "OTHER";
                sheet.Cells[row, 15] = otherHours;
                sheet.Cells[row, 16] = "HRB";
                sheet.Cells[row, 17] = hrbHours;
                sheet.Cells[row, 18] = "BEREV";
                sheet.Cells[row, 19] = brvHours;
                sheet.Cells[row, 20] = "JURY";
                sheet.Cells[row, 21] = juryHours;
                sheet.Cells[row, 22] = "MIL";
                sheet.Cells[row, 23] = milHours;
                sheet.Cells[row, 24] = "NOPAY";
                sheet.Cells[row, 25] = timeOffHours;
                sheet.Cells[row, 26] = employeeNotes;


                row++;
            }


            xl.Visible = true;




        }



        private class UP_PayrollExport
        {
            public long timesheetId { get; set; }
            public long userId { get; set; }
            public int employeeId { get; set; }
            public string lastName { get; set; }
            public string firstName { get; set; }
            public double? abraHours { get; set; }
            public int? ptoCodeId { get; set; }
            public double? workHours { get; set; }
            public double? ptoHours { get; set; }
            public DateTime workDate { get; set; }
        }


    }
}
