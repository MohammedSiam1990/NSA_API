using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Dto.Account
{
    public class UserModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Lang { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameAr { get; set; }
        public string ImageName { get; set; }
        public int CountryId { get; set; }
        public string AppUrl { get; set; }
        public int UserType { get; set; }
        public long? InsertedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public int CompanyId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool StatusID { get; set; }
        public long? UesrID { get; set; }
        public int? RoleID { get; set; }
    }
}
