using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class PaymentMethodsModel
    {
        public long PaymentMethodID { get; set; }
        public int CompanyID { get; set; }
        public int? TypeID { get; set; }
        public string PaymentMethodName { get; set; }
        public string PaymentMethodNameAr { get; set; }
        public double CommissionPrcnt { get; set; }
        public bool CalcCommissionTax { get; set; }
        public bool CommissionOnClient { get; set; }
        public int FreePaymentTypeID { get; set; }
        public bool CalcTaxOnFreePM { get; set; }
        public long? ApprovedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public int StatusID { get; set; }

    }
}
