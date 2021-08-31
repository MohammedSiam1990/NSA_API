using System;
using System.Collections.Generic;


namespace NSR.Entities
{
    public partial class UsersModel
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PasswordHashKey { get; set; }
        public string PassworSaltkey { get; set; }
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
        public long? CreatedBy { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long? ModifiedBy { get; set; }
        public int? BrandId { get; set; }
        public long? BranchId { get; set; }
        public int? ProductId { get; set; }
        public long? CustomerId { get; set; }

    }
}
