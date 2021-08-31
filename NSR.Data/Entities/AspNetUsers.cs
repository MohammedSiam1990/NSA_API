using System;
using System.Collections.Generic;

namespace NSR.Entities
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaims>();
            //AspNetUserLogins = new HashSet<AspNetUserLogins>();
            //AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }

        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
       
        public DateTime? CreateDate { get; set; }
        public long? InsertedBy { get; set; }
        public bool? IsSuperAdmin { get; set; }
        public int? CompanyId { get; set; }
        public int? UserType { get; set; }
        public int? StatusId { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }

        public long UserID { get; set; }

        public virtual Companies Company { get; set; }
        //public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
