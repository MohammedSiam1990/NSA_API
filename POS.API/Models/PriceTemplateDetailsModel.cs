using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class PriceTemplateDetailsModel
    {
        public int PriceTemplateDetailsID { get; set; }
        public int PriceTemplateID { get; set; }
        public long ItemUOMID { get; set; }
        public decimal value { get; set; }
        public decimal? InvType1Val { get; set; }
        public decimal? InvType1Va2 { get; set; }
        public decimal? InvType1Va3 { get; set; }
        public decimal? InvType1Va4 { get; set; }
        public decimal? InvType1Va5 { get; set; }
    }
}
