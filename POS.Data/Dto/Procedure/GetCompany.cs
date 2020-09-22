using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class GetCompany
    {
        public GetCompany()
        {
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameAr { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyEmail { get; set; }
        public string ImageName { get; set; }
        public string Phone { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusNameAr { get; set; }
    }
}
