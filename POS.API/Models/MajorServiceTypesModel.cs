using System;
using System.Collections.Generic;

namespace POS.Models
{

    public partial class MajorServiceTypesModel
    {
        public int MajorServiceTypeId { get; set; }
        public int? MajorServiceId { get; set; }
        public string TypeName { get; set; }
        public string TypeNameAr { get; set; }
        public int? StatusId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public string  DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        // public virtual MajorServicesModel MajorServices { get; set; }
    }
}

