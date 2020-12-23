using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class PermissionsModel
    {
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
