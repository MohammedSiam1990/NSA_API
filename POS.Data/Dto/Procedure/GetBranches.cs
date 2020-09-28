using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class GetBranches
    {
        public GetBranches()
        {
        }
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
        // public int CompanyId { get; set; }

        //  public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }

        //  public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }

        //   public string DeletedBy { get; set; }
        //   public DateTime? DeletedDate { get; set; }
        public string StatusName { get; set; }
        public string StatusNameAr { get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public string TaxNo { get; set; }
        public string ServiceTypeID { get; set; }

    }
}
