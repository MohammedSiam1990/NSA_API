using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public partial class PriceTemplateModel
    {
        public int PriceTemplateID { get; set; }
        public int TypeID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public bool? DateEffect { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? InActive { get; set; }
        public int? BrandID { get; set; }
        public long? ApprovedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public string TypeName { get; set; }
        public List<PriceTemplateDetailsModel> PriceTemplateDetails { get; set; }
    }
}
