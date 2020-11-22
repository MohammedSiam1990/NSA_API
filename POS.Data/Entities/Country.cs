using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameAr { get; set; }
        public int? CurrencyId { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
