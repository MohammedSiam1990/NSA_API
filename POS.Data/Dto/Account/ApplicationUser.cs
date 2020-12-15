using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Steander.Core.Entities
{

    public class ApplicationUser : IdentityUser
    {
        //[DataType("datetime2")]
        public DateTime? CreateDate { get; set; }
         public string Name { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public int? CompanyId { get; set; }
        public int? UserType { get; set; }
        public long? InsertedBy { get; set; }
        public string Password { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public int? StatusID { get; set; }
        public long UserID { get; set; }
    }
}
