using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Entities
{
   public class Tax
    {
        public int TaxID { get; set; }
        public string TaxName { get; set; }
        public string TaxNameAr { get; set; }
        public decimal? TaxVal { get; set; }
        public int? StatusID { get; set; }
        public bool? SpecialTax { get; set; }
        public int? CompanyID { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }

}
