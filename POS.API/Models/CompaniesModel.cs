using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Models
{
    public partial class CompaniesModel
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }
        public string CompanyNameAr { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string ImagePath { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        // public DbGeography Location { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int? CountryId { get; set; }

        public int? CityId { get; set; }

        public int? RegionId { get; set; }

        public int? CurrencyId { get; set; }

        public int? DefaultLngId { get; set; }

        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? CreationDate { get; set; }


        [StringLength(100)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModificationDate { get; set; }


        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public string CompanyNameF { get; set; }
        public string CompanyNameArF { get; set; }
        public string ImagePathF { get; set; }
        public byte? IsConfirmed { get; set; }


    }
}