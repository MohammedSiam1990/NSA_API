using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class ItemUomModel
    {
        public long ItemUomid { get; set; }
         public string Name { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public bool? Sell { get; set; }
        public bool? Transfer { get; set; }
        public bool? Adjust { get; set; }
        public bool? Component { get; set; }
        public bool? Purchase { get; set; }
        public decimal? Equivalent { get; set; }
        public long ItemId { get; set; }
        
        public  List<SkuModel> Skus { get; set; }
    }
}
