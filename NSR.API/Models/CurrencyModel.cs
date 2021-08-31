using NSR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
  public class CurrencyModel
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyNameAr { get; set; }
        public string CurrencySign { get; set; }
        public string CurrencySignAr { get; set; }
    }
}
