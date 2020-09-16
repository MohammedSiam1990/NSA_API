using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class Lookups
    {
        public int LookupId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }
        public int? Sequence { get; set; }
        public bool? IsDefault { get; set; }
        public int? StatusId { get; set; }
    }
}
