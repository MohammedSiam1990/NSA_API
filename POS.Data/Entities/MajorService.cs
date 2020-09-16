using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class MajorService
    {
        public MajorService()
        {
            Brands = new HashSet<Brands>();
            MajorServiceTypes = new HashSet<MajorServiceTypes>();
        }
        [Key]

        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceNameAr { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Brands> Brands { get; set; }
        public virtual ICollection<MajorServiceTypes> MajorServiceTypes { get; set; }
    }
}
