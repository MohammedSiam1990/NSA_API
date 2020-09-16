using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Entities
{
    public partial class Users
    {
        public Users()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaims>();
            //AspNetUserLogins = new HashSet<AspNetUserLogins>();
            //AspNetUserRoles = new HashSet<AspNetUserRoles>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool? LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int? UserTypeId { get; set; }
        public int? CompanyId { get; set; }
        public int? GroupSecId { get; set; }
        public int? LngId { get; set; }
        public bool? Gender { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? BrandId { get; set; }
        public long? BranchId { get; set; }
        public int? ProductId { get; set; }
        public long? CustomerId { get; set; }
        public string VerificationCode { get; set; }
        public string FirebaseTokenId { get; set; }

        public virtual Branches Branch { get; set; }
        public virtual Brands Brand { get; set; }
        public virtual Companies Company { get; set; }
       
        //public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
