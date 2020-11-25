using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class CustomerModel
    {
        public long CustomerID { get; set; }
        public int CompanyID { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNameAr { get; set; }
        public int? TypeID { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int? GenderID { get; set; }
        public string Remarks { get; set; }
        public int? InsertSourceID { get; set; }
        public bool? AllowTermSale { get; set; }
        public decimal? TermSaleLimit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? CreditOpenBalance { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string TaxNum { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? StatusID { get; set; }
        public bool? BlackListed { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public decimal? DeliveryFee { get; set; }
        public bool? FreeDelivery { get; set; }
        public decimal? DiscountPrcnt { get; set; }
        public decimal? Points { get; set; }
        public decimal? PointsOpenBalance { get; set; }
        public int? CustTypeID { get; set; }
        public bool? IsCreditor { get; set; }

    }
}
