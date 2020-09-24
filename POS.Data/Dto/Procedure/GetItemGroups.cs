using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto.Account
{
    public class GetItemGroups
    {
        public int ItemGroupID { get; set; }
        public string ItemGroupNum { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupNameAr { get; set; }
        public string ItemGroupMobileName { get; set; }
        public string ItemGroupNameMobileAr { get; set; }
        public int? BrandID { get; set; }
        public int? StatusID { get; set; }
        public byte? TypeID { get; set; }
        public string ImageName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
