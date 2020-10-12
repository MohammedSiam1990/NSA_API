using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class ItemUom
    {
        public ItemUom()
        {
            Skus = new HashSet<Sku>();
        }
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
        public string SkuCode { get; set; }
        public virtual Item Item { get; set; }
        public virtual ICollection<Sku> Skus { get; set; }
    }
}
