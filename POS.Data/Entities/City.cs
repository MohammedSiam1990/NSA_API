using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class City
    {
       
        public City()
        {
            District = new HashSet<District>();
        } 
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameAr { get; set; }
        public int CityCountryId { get; set; }
        public virtual ICollection<District> District { get; set; }
        public virtual Country Country { get; set; }
    }
}
