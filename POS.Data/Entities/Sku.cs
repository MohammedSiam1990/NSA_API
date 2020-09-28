using System;
using System.Collections.Generic;

namespace POS.Data.Entities
{
    public partial class Sku
    {
        public long? Skuid { get; set; }
        public long? ItemUomid { get; set; }
        public string Code { get; set; }
    }
}
