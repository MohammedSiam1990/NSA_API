using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class ItemGroupsModel
    {

        public int ItemGroupId { get; set; }
        public string ItemGroupNum { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupNameAr { get; set; }
        public string ItemGroupMobileName { get; set; }
        public string ItemGroupMobileNameAr { get; set; }
        public int? BrandId { get; set; }
        public int? StatusId { get; set; }
        public byte? TypeId { get; set; }
        public string ImageName { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string GroupColor { get; set; }

    }
}
