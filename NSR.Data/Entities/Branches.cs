using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSR.Entities
{
    public partial class Branches
    {
        [Key]

        public int BranchId { get; set; }
        public string BranchNum { get; set; }
        public string BranchName { get; set; }
        public string BranchNameAr { get; set; }
        public int BrandId { get; set; }
        public int? StatusId { get; set; }
        public int? TypeId { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CurrencyId { get; set; }
        public string ImageName { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string ServiceTypeID { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? DistrictID { get; set; }

    }
}
