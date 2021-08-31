using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSR.Entities
{
    public partial class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string DistrictNameAr { get; set; }
        public int? CityId { get; set; }
        public bool? InActive { get; set; }
        public virtual City City { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
