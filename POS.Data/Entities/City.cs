using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class City
    {
        public City()
        {
            Branches = new HashSet<Branches>();
            Brands = new HashSet<Brands>();
            Companies = new HashSet<Companies>();
        }
        [Key]

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string CityNameAr { get; set; }
        public int CityCountryId { get; set; }

        public virtual Country CityCountry { get; set; }
        public virtual ICollection<Branches> Branches { get; set; }
        public virtual ICollection<Brands> Brands { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
    }
}
