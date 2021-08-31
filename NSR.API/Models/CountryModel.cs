using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
  public class CountryModel
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameAr { get; set; }
        public int? CurrencyId { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyNameAr { get; set; }
    }
}
