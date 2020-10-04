using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class SkuModel
    {
        public long? Skuid { get; set; }
        public string Code { get; set; }
        public int BrandID { get; set; }
        public long? ItemUomid { get; set; }
    }
}
