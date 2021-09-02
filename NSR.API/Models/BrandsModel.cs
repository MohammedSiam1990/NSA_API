    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

namespace NSR.Models
{
    public partial class BrandsModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public int? StatusId { get; set; }
        public int? MajorServiceId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CurrencyId { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string TaxNo { get; set; }
        public string ImageName { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsDefault { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public long? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

    }
}
