using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class PriceTemplateDetails
    {
        [Key]
        public int PriceTemplateDetailsID { get; set; }
        public int? PriceTemplateID { get; set; }
        public long? ItemID { get; set; }
        public long? ItemUOMID { get; set; }
        public long? SalesGroupID { get; set; }
        public decimal? value { get; set; }
        public decimal? InvType1Val { get; set; }
        public decimal? InvType2Val { get; set; }
        public decimal? InvType3Val { get; set; }
        public decimal? InvType4Val { get; set; }
        public decimal? InvType5Val { get; set; }

    }
}
