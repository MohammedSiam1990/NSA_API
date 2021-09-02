using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public class ItemModel
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
        public long? ApprovedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? DeletedBy { get; set; }
        public int? SubTypeID { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<ItemUomModel> ItemUoms { get; set; }
       
    }
}
