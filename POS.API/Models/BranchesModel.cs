using System;
using System.Collections.Generic;
using static POS.Common.Enums;

namespace POS.Models
{
   
    public partial class BranchesModel
    {

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

    }  
}
