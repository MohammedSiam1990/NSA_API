using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public partial class SupplierModel
    {
        public long SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierNameAr { get; set; }
        public string ContactName { get; set; }
        public string ContactMobile { get; set; }
        public bool? AcceptTermSale { get; set; }
        public bool? NoTax { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public long? InsertedBy { get; set; }

        public DateTime? LastModifyDate { get; set; }
        public string TaxNum { get; set; }
        public int? StatusID { get; set; }
        public long? AddressID { get; set; }
        public int? DueDateDays { get; set; }
        public int? DueDateTypeID { get; set; }
        public int? CompanyID { get; set; }
        public string Email { get; set; }
        public int ContactCountryCodeID { get; set; }
        public AddressModel Address { get; set; }
    }
}
