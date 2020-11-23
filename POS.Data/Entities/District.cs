using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
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
    }
}
