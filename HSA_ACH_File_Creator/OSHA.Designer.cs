namespace Cfs.Custom.Software
{
    partial class OSHA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.employeesPaid_label = new System.Windows.Forms.Label();
            this.locationList = new System.Windows.Forms.ComboBox();
            this.locationList_label = new System.Windows.Forms.Label();
            this.allEmployees = new System.Windows.Forms.TextBox();
            this.payPeriods_label = new System.Windows.Forms.Label();
            this.payPeriods = new System.Windows.Forms.TextBox();
            this.employeesPerPay_label = new System.Windows.Forms.Label();
            this.employeesPerPay = new System.Windows.Forms.TextBox();
            this.averageEmployees_label = new System.Windows.Forms.Label();
            this.averageEmployees = new System.Windows.Forms.TextBox();
            this.fullTimers_label = new System.Windows.Forms.Label();
            this.fullTimers = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fullTimeHours = new System.Windows.Forms.TextBox();
            this.otherHours_label = new System.Windows.Forms.Label();
            this.otherHours = new System.Windows.Forms.TextBox();
            this.totalHours_label = new System.Windows.Forms.Label();
            this.totalHours = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(174, 30);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "OSHA Worksheet";
            // 
            // employeesPaid_label
            // 
            this.employeesPaid_label.AutoSize = true;
            this.employeesPaid_label.Location = new System.Drawing.Point(14, 194);
            this.employeesPaid_label.Name = "employeesPaid_label";
            this.employeesPaid_label.Size = new System.Drawing.Size(267, 15);
            this.employeesPaid_label.TabIndex = 1;
            this.employeesPaid_label.Text = "The number of employees paid in all pay periods:";
            // 
            // locationList
            // 
            this.locationList.FormattingEnabled = true;
            this.locationList.Items.AddRange(new object[] {
            "All CFS",
            "All SGF",
            "330 Delaware",
            "31 Rossler"});
            this.locationList.Location = new System.Drawing.Point(76, 69);
            this.locationList.Name = "locationList";
            this.locationList.Size = new System.Drawing.Size(121, 23);
            this.locationList.TabIndex = 2;
            this.locationList.SelectedIndexChanged += new System.EventHandler(this.locationList_SelectedIndexChanged);
            // 
            // locationList_label
            // 
            this.locationList_label.AutoSize = true;
            this.locationList_label.Location = new System.Drawing.Point(14, 72);
            this.locationList_label.Name = "locationList_label";
            this.locationList_label.Size = new System.Drawing.Size(56, 15);
            this.locationList_label.TabIndex = 3;
            this.locationList_label.Text = "Location:";
            // 
            // allEmployees
            // 
            this.allEmployees.Enabled = false;
            this.allEmployees.Location = new System.Drawing.Point(288, 191);
            this.allEmployees.Name = "allEmployees";
            this.allEmployees.Size = new System.Drawing.Size(100, 23);
            this.allEmployees.TabIndex = 4;
            // 
            // payPeriods_label
            // 
            this.payPeriods_label.AutoSize = true;
            this.payPeriods_label.Location = new System.Drawing.Point(14, 233);
            this.payPeriods_label.Name = "payPeriods_label";
            this.payPeriods_label.Size = new System.Drawing.Size(236, 15);
            this.payPeriods_label.TabIndex = 5;
            this.payPeriods_label.Text = "The number of pay periods during the year:";
            // 
            // payPeriods
            // 
            this.payPeriods.Enabled = false;
            this.payPeriods.Location = new System.Drawing.Point(288, 230);
            this.payPeriods.Name = "payPeriods";
            this.payPeriods.Size = new System.Drawing.Size(100, 23);
            this.payPeriods.TabIndex = 6;
            // 
            // employeesPerPay_label
            // 
            this.employeesPerPay_label.AutoSize = true;
            this.employeesPerPay_label.Location = new System.Drawing.Point(14, 272);
            this.employeesPerPay_label.Name = "employeesPerPay_label";
            this.employeesPerPay_label.Size = new System.Drawing.Size(146, 15);
            this.employeesPerPay_label.TabIndex = 7;
            this.employeesPerPay_label.Text = "Employees per pay period:";
            // 
            // employeesPerPay
            // 
            this.employeesPerPay.Enabled = false;
            this.employeesPerPay.Location = new System.Drawing.Point(288, 269);
            this.employeesPerPay.Name = "employeesPerPay";
            this.employeesPerPay.Size = new System.Drawing.Size(100, 23);
            this.employeesPerPay.TabIndex = 8;
            // 
            // averageEmployees_label
            // 
            this.averageEmployees_label.AutoSize = true;
            this.averageEmployees_label.Location = new System.Drawing.Point(14, 311);
            this.averageEmployees_label.Name = "averageEmployees_label";
            this.averageEmployees_label.Size = new System.Drawing.Size(211, 15);
            this.averageEmployees_label.TabIndex = 9;
            this.averageEmployees_label.Text = "Annual average number of employees:";
            // 
            // averageEmployees
            // 
            this.averageEmployees.Enabled = false;
            this.averageEmployees.Location = new System.Drawing.Point(288, 308);
            this.averageEmployees.Name = "averageEmployees";
            this.averageEmployees.Size = new System.Drawing.Size(100, 23);
            this.averageEmployees.TabIndex = 10;
            // 
            // fullTimers_label
            // 
            this.fullTimers_label.AutoSize = true;
            this.fullTimers_label.Location = new System.Drawing.Point(516, 194);
            this.fullTimers_label.Name = "fullTimers_label";
            this.fullTimers_label.Size = new System.Drawing.Size(196, 15);
            this.fullTimers_label.TabIndex = 11;
            this.fullTimers_label.Text = "The number of full time employees:";
            // 
            // fullTimers
            // 
            this.fullTimers.Enabled = false;
            this.fullTimers.Location = new System.Drawing.Point(732, 191);
            this.fullTimers.Name = "fullTimers";
            this.fullTimers.Size = new System.Drawing.Size(100, 23);
            this.fullTimers.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(516, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Hours worked by full time employees:";
            // 
            // fullTimeHours
            // 
            this.fullTimeHours.Enabled = false;
            this.fullTimeHours.Location = new System.Drawing.Point(732, 230);
            this.fullTimeHours.Name = "fullTimeHours";
            this.fullTimeHours.Size = new System.Drawing.Size(100, 23);
            this.fullTimeHours.TabIndex = 14;
            // 
            // otherHours_label
            // 
            this.otherHours_label.AutoSize = true;
            this.otherHours_label.Location = new System.Drawing.Point(516, 272);
            this.otherHours_label.Name = "otherHours_label";
            this.otherHours_label.Size = new System.Drawing.Size(115, 15);
            this.otherHours_label.TabIndex = 15;
            this.otherHours_label.Text = "Other hours worked:";
            // 
            // otherHours
            // 
            this.otherHours.Enabled = false;
            this.otherHours.Location = new System.Drawing.Point(732, 269);
            this.otherHours.Name = "otherHours";
            this.otherHours.Size = new System.Drawing.Size(100, 23);
            this.otherHours.TabIndex = 16;
            // 
            // totalHours_label
            // 
            this.totalHours_label.AutoSize = true;
            this.totalHours_label.Location = new System.Drawing.Point(516, 311);
            this.totalHours_label.Name = "totalHours_label";
            this.totalHours_label.Size = new System.Drawing.Size(112, 15);
            this.totalHours_label.TabIndex = 17;
            this.totalHours_label.Text = "Total hours worked:";
            // 
            // totalHours
            // 
            this.totalHours.Enabled = false;
            this.totalHours.Location = new System.Drawing.Point(732, 308);
            this.totalHours.Name = "totalHours";
            this.totalHours.Size = new System.Drawing.Size(100, 23);
            this.totalHours.TabIndex = 18;
            // 
            // OSHA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 479);
            this.Controls.Add(this.totalHours);
            this.Controls.Add(this.totalHours_label);
            this.Controls.Add(this.otherHours);
            this.Controls.Add(this.otherHours_label);
            this.Controls.Add(this.fullTimeHours);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fullTimers);
            this.Controls.Add(this.fullTimers_label);
            this.Controls.Add(this.averageEmployees);
            this.Controls.Add(this.averageEmployees_label);
            this.Controls.Add(this.employeesPerPay);
            this.Controls.Add(this.employeesPerPay_label);
            this.Controls.Add(this.payPeriods);
            this.Controls.Add(this.payPeriods_label);
            this.Controls.Add(this.allEmployees);
            this.Controls.Add(this.locationList_label);
            this.Controls.Add(this.locationList);
            this.Controls.Add(this.employeesPaid_label);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OSHA";
            this.Text = "OSHA Worksheet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label employeesPaid_label;
        private System.Windows.Forms.ComboBox locationList;
        private System.Windows.Forms.Label locationList_label;
        private System.Windows.Forms.TextBox allEmployees;
        private System.Windows.Forms.Label payPeriods_label;
        private System.Windows.Forms.TextBox payPeriods;
        private System.Windows.Forms.Label employeesPerPay_label;
        private System.Windows.Forms.TextBox employeesPerPay;
        private System.Windows.Forms.Label averageEmployees_label;
        private System.Windows.Forms.TextBox averageEmployees;
        private System.Windows.Forms.Label fullTimers_label;
        private System.Windows.Forms.TextBox fullTimers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fullTimeHours;
        private System.Windows.Forms.Label otherHours_label;
        private System.Windows.Forms.TextBox otherHours;
        private System.Windows.Forms.Label totalHours_label;
        private System.Windows.Forms.TextBox totalHours;
    }
}