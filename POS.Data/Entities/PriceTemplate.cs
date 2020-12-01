using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class PriceTemplate
    {
        [Key]
        public int PriceTemplateID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public bool? DateEffect { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? InActive { get; set; }
        public int? BrandID { get; set; }
    }
}
