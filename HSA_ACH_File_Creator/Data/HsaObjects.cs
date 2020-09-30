using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cfs.Custom.Software.Data
{
    public class HsaObjects
    {



        public class BatchParameters
        {
            public string company { get; set; }
            public DateTime checkDate { get; set; }
        }
    }



    public class GeneralObjects
    {
        public class PayPeriodsModel
        {
            
            public long payPeriodId { get; set; }
        }


        public class UsersModel
        {
            public long userId { get; set; }
            public string userName { get; set; }
            public bool isActive { get; set; }
        }
    }

    public class PayStubObjects
    {

        public enum CheckStubSection
        {
            DirectDeposits,
            Earnings,
            Taxes,
            Deductions,
            YtdDetail
        }

        public class ExportFileDetail
        {
            public string codeKey { get; set; }
            public string createdBy { get; set; }
            public DateTime createdStamp { get; set; }
            public string uploadedIp { get; set; }
            public DateTime checkDate { get; set; }
            public List<Data.CheckStubHeader> checkHeader { get; set; }
            public List<Data.CheckStubDetail> checkDetail { get; set; }
            public List<Data.CheckStubYtd> checkSummary { get; set; }
        }


        public class CheckStubHeader
        {
            public int abraId { get; set; }
            public DateTime checkDate { get; set; }
            public string checkNumber { get; set; }
            public decimal grossPay { get; set; }
            public decimal netPay { get; set; }
            public DateTime payPeriodStartDate { get; set; }
            public DateTime payPeriodEndDate { get; set; }
            public string payToOrder { get; set; }
            public string payAddress { get; set; }
            public decimal salaryRate { get; set; }
            
        }


        public class CheckStubDetail
        {
            public int abraId { get; set; }
            public string checkNumber { get; set; }
            public DateTime checkDate { get; set; }
            public int checkSectionId { get; set; }
            public string itemCode { get; set; }
            public string itemDescription { get; set; }
            public decimal itemAmount { get; set; }
            public decimal itemRate { get; set; }
            public decimal itemQuantity { get; set; }
        }


        public class YtdDetail
        {
            public int abraId { get; set; }
            public string checkNumber { get; set; }
            public DateTime checkDate { get; set; }
            public int checkSectionId { get; set; }
            public string codeType { get; set; }
            public string itemCode { get; set; }
            public decimal ytdAmount { get; set; }
        }




    }
}
