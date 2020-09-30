using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class RemarksTemplateDetails
    {
        public int RemarksTemplateDetailsD { get; set; }
        public int RemarksTemplateId { get; set; }
        public string RemarkName1 { get; set; }
        public string RemarkName2 { get; set; }
        public int TypeId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Calories { get; set; }
    }
}
