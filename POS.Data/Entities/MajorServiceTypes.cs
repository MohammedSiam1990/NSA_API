using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class MajorServiceTypes
    {
        public int MajorServiceTypeId { get; set; }
        public int? MajorServiceId { get; set; }
        public string TypeName { get; set; }
        public string TypeNameAr { get; set; }
        public int? StatusId { get; set; }

        public virtual MajorServices MajorService { get; set; }
    }
}
