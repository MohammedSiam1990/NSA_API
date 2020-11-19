using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class Customer
    {
        [Key]
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
        public string GPS { get; set; }
        public int? StatusID { get; set; }
        public bool? BlackListed { get; set; }
        public string Email { get; set; }
        public string ImageName { get; set; }
        public decimal? DeliveryFee { get; set; }
        public bool? FreeDelivery { get; set; }
        public decimal? DiscountPrcnt { get; set; }
        public decimal? Points { get; set; }
        public decimal? PointsOpenBalance { get; set; }

    }
}
