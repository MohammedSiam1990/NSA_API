using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Dto.Account
{
    public class CreateUserModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Lang { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameAr { get; set; }
        public string ImageName { get; set; }
        public string AppUrl { get; set; }
        public int UserType { get; set; }
        public string InsertedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime LastModifyDate { get; set; }
        public int CompanyId { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool StatusID { get; set; }
    }
}
