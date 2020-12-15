using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class City
    {
       
        public City()
        {
            Districts = new HashSet<District>();
        } 
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameAr { get; set; }
        public int CountryId { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public virtual Country Country { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
