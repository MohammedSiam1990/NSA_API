using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class Sku
    {
        public long? Skuid { get; set; }
        public string Code { get; set; }
        public long? ItemUomid { get; set; }
        public ItemUom ItemUom { get; set; }
    }
}
