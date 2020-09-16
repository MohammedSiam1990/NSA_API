using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class GetBrands
    {
        public GetBrands()
        {
        }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public int? StatusId { get; set; }
        public int? MajorServiceId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CurrencyId { get; set; }
     //   public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public string TaxNo { get; set; }
     public string ImageName { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsDefault { get; set; }
        public string StatusName { get; set; }
        public string StatusNameAr { get; set; }
    }
}
