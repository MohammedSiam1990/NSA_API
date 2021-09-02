using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSR.Entities
{
    public partial class MajorServices
    {
        public MajorServices()
        {
         MajorServiceTypes = new HashSet<MajorServiceTypes>();
     //    MajorServicesIcons = new HashSet<MajorServicesIcons>();
        }
        [Key]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }
        public string FoldersPath { get; set; }
     // public virtual ICollection<MajorServicesIcons> MajorServicesIcons { get; set; }
       public virtual ICollection<MajorServiceTypes> MajorServiceTypes { get; set; }
    }
}
