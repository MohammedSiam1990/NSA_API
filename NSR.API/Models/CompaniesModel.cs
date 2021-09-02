using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSR.Models
{
    public partial class CompaniesModel
    {
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
        public long? ModifiedBy { get; set; }
        public int? StatusId { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }

    }
}