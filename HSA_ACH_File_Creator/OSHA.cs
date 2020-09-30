using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cfs.Custom.Software
{
    public partial class OSHA : Form
    {
        public OSHA()
        {
            InitializeComponent();
        }

        private void locationList_SelectedIndexChanged(object sender, EventArgs e)
        {

            string connString = @"Provider=vfpoledb;Data Source=\\cfs-hrms\Abra\Data;Collating Sequence=general;";
            OleDbConnection conn = new OleDbConnection(connString);


            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += Environment.NewLine + Environment.NewLine + ex.InnerException.Message;
                }

                MessageBox.Show(errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

       
    }
}
