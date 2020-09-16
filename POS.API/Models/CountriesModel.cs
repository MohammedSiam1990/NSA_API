 
    using System;
    using System.Collections.Generic; 
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{

    public partial class CountriesModel
    {

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryNameAr { get; set; }
        public string Flag { get; set; }
        public bool? IsActive { get; set; }
        public byte CurrencyId { get; set; }
        public string CurrencyCodeEnglish { get; set; }
        public string CurrencyCodeArabic { get; set; }
    }
}

