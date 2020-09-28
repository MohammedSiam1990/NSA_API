using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class ItemUom
    {
        public long ItemUomid { get; set; }
      
        public int Uomid { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Price { get; set; }
        public bool? Sell { get; set; }
        public bool? Transfer { get; set; }
        public bool? Adjust { get; set; }
        public bool? Component { get; set; }
        public bool? Purchase { get; set; }
        public decimal? Equivalent { get; set; }
        public long ItemId { get; set; }
        public Item item { get; set; }
        public ICollection<Sku> Skus { get; set; }
    }
}
