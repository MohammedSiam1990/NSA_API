using System;
using System.Collections.Generic;

namespace POS.Models
{

    public partial class MajorServicesModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }
        public string FoldersPath { get; set; }
        public virtual List<MajorServiceTypesModel> MajorServiceTypes { get; set; }
      //  public virtual List<MajorServicesIconsModel> MajorServicesIcons { get; set; }
    }
}

