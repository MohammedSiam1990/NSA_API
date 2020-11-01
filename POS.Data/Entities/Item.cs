using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class Item
    {
        public long ItemId { get; set; }
        public string ItemNum { get; set; }
        public string ItemName { get; set; }
        public string ItemNameAr { get; set; }
        public string MobileName { get; set; }
        public string MobileNameAr { get; set; }
        public int ItemTypeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? GroupId { get; set; }
        public int? GnrlTaxId { get; set; }
        public int? SpclTaxId { get; set; }
        public int? RemarksTemplateId { get; set; }
        public decimal? InsuranceVal { get; set; }
        public bool? NoDisc { get; set; }
        public bool? PriceChange { get; set; }
        public bool? Weighable { get; set; }
        public string PosColor { get; set; }
        public string ImageName { get; set; }
        public int? StatusId { get; set; }
        public int? BrandId { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public ICollection<ItemUom> ItemUoms { get; set; }
    }
}
