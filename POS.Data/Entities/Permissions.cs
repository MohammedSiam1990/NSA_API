using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class Permissions
    {
        [Key]
        public long PermissionID { get; set; }
        public int MenuID { get; set; }
        public int RoleID { get; set; }
        public string JsonData { get; set; }
        public int? BrandID { get; set; }
        public int? MenuType { get; set; }
        public long? InsertedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? datetime { get; set; }

    }
}
