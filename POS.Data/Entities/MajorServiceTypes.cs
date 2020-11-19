using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class MajorServiceTypes
    {
        [Key]
        public int MajorServiceTypeId { get; set; }
        public int? MajorServiceId { get; set; }
        public string TypeName { get; set; }
        public string TypeNameAr { get; set; }
        public int? StatusId { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual MajorServices MajorService { get; set; }
    }
}
