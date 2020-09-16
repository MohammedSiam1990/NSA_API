using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class MajorServiceTypes
    {
        public MajorServiceTypes()
        {
            BranchServices = new HashSet<BranchServices>();
        }
        [Key]

        public int MajorServiceTypeId { get; set; }
        public int? MajorServiceId { get; set; }
        public string TypeName { get; set; }
        public string TypeNameAr { get; set; }
        public int? StatusId { get; set; }

        public virtual MajorService MajorService { get; set; }
        public virtual ICollection<BranchServices> BranchServices { get; set; }
    }
}
