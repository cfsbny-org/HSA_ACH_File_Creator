using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cfs.Custom.Software.Benefits
{
    public partial class VisionEnrollmentFile : Form
    {
        public VisionEnrollmentFile()
        {
            InitializeComponent();
        }

        private void VisionEnrollmentFile_Load(object sender, EventArgs e)
        {

            Data.CfsMasterDbDataContext context = new Data.CfsMasterDbDataContext();

            List<Data.GetVisionSubscribersResult> subscribers = context.GetVisionSubscribers(100100).ToList();
            List<Data.GetVisionDependentsResult> dependents = context.GetVisionDependents(100100).ToList();


            Excel.Application xl;
            Excel._Workbook workbook;
            Excel._Worksheet sheet;
            Excel.Range range;

            xl = new Excel.Application();
            xl.Visible = false;


            try
            {
                workbook = (Excel._Workbook)(xl.Workbooks.Add(System.Reflection.Missing.Value));
                sheet = (Excel._Worksheet)workbook.ActiveSheet;

                var lineNumber = 2;
                int depNum;

                foreach (Data.GetVisionSubscribersResult subscriber in subscribers)
                {
                    sheet.Cells[lineNumber, 1] = subscriber.Group_Code;
                    sheet.Cells[lineNumber, 2] = subscriber.Benefit_Option;
                    sheet.Cells[lineNumber, 3] = subscriber.Relationship_Code;
                    sheet.Cells[lineNumber, 4] = subscriber.Coverage_Effective_Date;
                    sheet.Cells[lineNumber, 5] = subscriber.Termination_Date;
                    sheet.Cells[lineNumber, 6] = "'" + subscriber.Member_ID;
                    sheet.Cells[lineNumber, 7] = "'" + subscriber.Social_Security_Number;
                    sheet.Cells[lineNumber, 8] = subscriber.Member_First_Name;
                    sheet.Cells[lineNumber, 9] = subscriber.Member_Last_Name;
                    sheet.Cells[lineNumber, 10] = subscriber.Date_of_Birth;
                    sheet.Cells[lineNumber, 11] = subscriber.Gender;
                    sheet.Cells[lineNumber, 12] = subscriber.Address_Line_1;
                    sheet.Cells[lineNumber, 13] = subscriber.Address_Line_2;
                    sheet.Cells[lineNumber, 14] = subscriber.City;
                    sheet.Cells[lineNumber, 15] = subscriber.State;
                    sheet.Cells[lineNumber, 16] = subscriber.Zip;
                    sheet.Cells[lineNumber, 17] = subscriber.Division_Code;
                    sheet.Cells[lineNumber, 18] = subscriber.Location_Code;

                    lineNumber++;


                    List<Data.GetVisionDependentsResult> subDependents = dependents.Where(d => d.visionEnrollmentId == subscriber.visionEnrollmentId).ToList();

                    if (subDependents != null && subDependents.Count > 0)
                    {
                        depNum = 1;

                        foreach (Data.GetVisionDependentsResult dependent in subDependents)
                        {

                            sheet.Cells[lineNumber, 1] = dependent.Group_Code;
                            sheet.Cells[lineNumber, 2] = dependent.Benefit_Option;
                            sheet.Cells[lineNumber, 3] = dependent.Relationship_Code.ToString();
                            sheet.Cells[lineNumber, 4] = dependent.Coverage_Effective_Date;
                            sheet.Cells[lineNumber, 5] = dependent.Termination_Date;
                            sheet.Cells[lineNumber, 6] = "'" + subscriber.Member_ID + depNum.ToString().PadLeft(2, '0');
                            sheet.Cells[lineNumber, 7] = "'" + dependent.Social_Security_Number;
                            sheet.Cells[lineNumber, 8] = dependent.Member_First_Name;
                            sheet.Cells[lineNumber, 9] = dependent.Member_Last_Name;
                            sheet.Cells[lineNumber, 10] = dependent.Date_of_Birth;
                            sheet.Cells[lineNumber, 11] = dependent.Gender.ToString();
                            sheet.Cells[lineNumber, 12] = dependent.Address_Line_1;
                            sheet.Cells[lineNumber, 13] = dependent.Address_Line_2;
                            sheet.Cells[lineNumber, 14] = dependent.City;
                            sheet.Cells[lineNumber, 15] = dependent.State;
                            sheet.Cells[lineNumber, 16] = dependent.Zip;
                            sheet.Cells[lineNumber, 17] = dependent.Division_Code;
                            sheet.Cells[lineNumber, 18] = dependent.Location_Code;

                            lineNumber++;
                            depNum++;
                        }

                    }
                }

                xl.Visible = true;
                xl.UserControl = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //xl.Quit();
                context.Dispose();
            }
        }
    }
}
