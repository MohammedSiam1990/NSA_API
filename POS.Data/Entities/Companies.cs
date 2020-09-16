using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Entities
{
    public partial class Companies
    {
        public Companies()
        {
            //AspNetUsers = new HashSet<AspNetUsers>();
            Brands = new HashSet<Brands>();
        }
        [Key]
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

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual Currency Currency { get; set; }
        //public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
        public virtual ICollection<Brands> Brands { get; set; }
    }
}
