using System;
using System.Collections.Generic;

namespace POS.Models
{

    public partial class MajorServicesModel
    {
        public int MajorServiceTypeId { get; set; }
        public int? MajorServiceId { get; set; }
        public string TypeName { get; set; }
        public string TypeNameAr { get; set; }
        public int? StatusId { get; set; }
        public virtual List<MajorServicesTypesModel> MajorServicesTypes { get; set; }
        public virtual List<MajorServicesIconsModel> MajorServicesIcons { get; set; }
    }
}

