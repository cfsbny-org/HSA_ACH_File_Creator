using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cfs.Custom.Software.Data
{

    public class ValicRemittanceParameters
    {
        public string companyId { get; set; }
        public DateTime payDate { get; set; }
        public string fileName { get; set; }
    }


    public class ValicFileLineModel
    {
        public string employeeId { get; set; }
        public string payGroupId { get; set; }
        public string employeeSsn { get; set; }
        public string firstName { get; set; }
        public string middleInit { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressZip { get; set; }
        public string payrollFrequency { get; set; }
        public string payrollDate { get; set; }
        public decimal employeeContrib { get; set; }
        public decimal employeeRoth { get; set; }
        public decimal employerContrib { get; set; }
        public decimal loanRepayment { get; set; }
        public string loanId { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public string homePhone { get; set; }
        public string address3 { get; set; }
        public string genderId { get; set; }
        public string maritalStatus { get; set; }
        public string activeStatus { get; set; }
        public DateTime? statusChange { get; set; }
        public string locationCode { get; set; }
        public string payrollStatus { get; set; }
        public decimal annualSalary { get; set; }
        public decimal ytdHours { get; set; }
        public int sortOrder { get; set; }

    }



    public class ValicDemographicsModel
    {
        public string employeeId { get; set; }
        public string employeeSsn { get; set; }
        public string firstName { get; set; }
        public string middleInit { get; set; }
        public string lastName { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string addressCity { get; set; }
        public string addressState { get; set; }
        public string addressZip { get; set; }
        public string payrollFrequency { get; set; }
        public DateTime payrollDate { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public string homePhone { get; set; }
        public string address3 { get; set; }
        public string genderId { get; set; }
        public string maritalStatus { get; set; }
        public string activeStatus { get; set; }
        public DateTime? statusChange { get; set; }
        public string locationCode { get; set; }
        public string payrollStatus { get; set; }
        public decimal annualSalary { get; set; }
        public string addressCountry { get; set; }
    }


    public class ValicDeductionsModel
    {
        public string employeeId { get; set; }
        public string deductionCode { get; set; }
        public decimal employeeAmount { get; set; }
        public decimal employerAmount { get; set; }
        public string loanId { get; set; }
    }


    public class ValicRemittanceAmountsModel
    {
        public string employeeId { get; set; }
        public decimal employeeAmount { get; set; }
        public decimal employeeRoth { get; set; }
        public decimal employerAmount { get; set; }
        public decimal loanRepayment { get; set; }
        public string loanId { get; set; }
        public int sortOrder { get; set; }
    }


    public class ValicYtdHoursModel
    {
        public string employeeId { get; set; }
        public decimal hoursWorked { get; set; }
    }


    public class ValicFileSummary
    {
        public string remittanceFilePath { get; set; }
        public int employeeCount { get; set; }
        public int employeesContributing { get; set; }
        public decimal? totalEmployee { get; set; }
        public decimal? totalRoth { get; set; }
        public decimal? totalEmployer { get; set; }
        public decimal? totalLoans { get; set; }

    }



    public class ValicResponseFile
    {
        public string payGroupId { get; set; }
        public string locationCode { get; set; }
        public string locationName { get; set; }
        public string socSecNum { get; set; }
        public string employeeId { get; set; }
        public string loanNumber { get; set; }
        public decimal amountFinanced { get; set; }
        public string paymentFreq { get; set; }
        public decimal loanInterestRate { get; set; }
        public decimal paymentsRemaining { get; set; }
        public DateTime firstDueDate { get; set; }
        public decimal repaymentAmount { get; set; }
        public string paymentMethod { get; set; }
        public decimal totalLoanRepayment { get; set; }
        public decimal loanFinanceCharge { get; set; }
        public decimal lastPaymentAmount { get; set; }
        public DateTime lastPaymentDate { get; set; }
    }
}
