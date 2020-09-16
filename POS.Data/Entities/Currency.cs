using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            Branches = new HashSet<Branches>();
            Brands = new HashSet<Brands>();
            Companies = new HashSet<Companies>();
            Country = new HashSet<Country>();
        }
        [Key]

        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencySign { get; set; }
        public string CurrencySignAr { get; set; }

        public virtual ICollection<Branches> Branches { get; set; }
        public virtual ICollection<Brands> Brands { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        public virtual ICollection<Country> Country { get; set; }
    }
}
