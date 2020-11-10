using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class MajorServices
    {
        public MajorServices()
        {
        //    MajorServiceTypes = new HashSet<MajorServiceTypes>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }
        public string FoldersPath { get; set; }

      //  public virtual ICollection<MajorServiceTypes> MajorServiceTypes { get; set; }
    }
}
