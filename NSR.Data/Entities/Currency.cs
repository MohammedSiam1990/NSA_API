using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSR.Entities
{
    public partial class Currency
    {
        public Currency()
        {
            Country = new HashSet<Country>();
        }
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencySign { get; set; }
        public string CurrencySignAr { get; set; }

        public virtual ICollection<Country> Country { get; set; }
    }
}
