using System;
using Newtonsoft.Json;

namespace NSR.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class Invoice
    {
        public long InvoiceID { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? InsuranceCompanyID { get; set; }
        public string ICTaxNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public int? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UpdatedOn { get; set; }
        public bool IsConsolidated { get; set; }
    }
}
