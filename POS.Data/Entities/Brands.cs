using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class Brands
    {
        public Brands()
        {
            Branches = new HashSet<Branches>();
            ItemGroup = new HashSet<ItemGroup>();
        }
        [Key]

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandNameAr { get; set; }
        public int? StatusId { get; set; }
        public int? MajorServiceId { get; set; }
        public int? CountryId { get; set; }
        public int? CityId { get; set; }
        public int? CurrencyId { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string ModifiedBy { get; set; }
        public string TaxNo { get; set; }
        public string ImageName { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsDefault { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual City City { get; set; }
        public virtual Companies Company { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual MajorService MajorService { get; set; }
        public virtual ICollection<Branches> Branches { get; set; }
        public virtual ICollection<ItemGroup> ItemGroup { get; set; }
    }
}
