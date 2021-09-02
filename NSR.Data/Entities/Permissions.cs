using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NSR.Data.Entities
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
        public DateTime? CreateDate { get; set; }

    }
}
