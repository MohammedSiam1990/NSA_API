using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class Branches
    {
        public Branches()
        {
            BranchServices = new HashSet<BranchServices>();
        }
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
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Brands Brand { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual ICollection<BranchServices> BranchServices { get; set; }
    }
}
