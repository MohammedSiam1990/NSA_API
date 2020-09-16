using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class BranchServices
    {
        [Key]
        public int BranchServiceId { get; set; }
        public int BranchId { get; set; }
        public int ServiceTypeId { get; set; }
        public int? StatusId { get; set; }

        public virtual Branches Branch { get; set; }
        public virtual MajorServiceTypes ServiceType { get; set; }
    }
}
