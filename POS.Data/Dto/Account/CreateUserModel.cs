using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Dto.Account
{
    public class CreateUserModel
    {
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
        public int CountryId { get; set; }
        public int UserType { get; set; }
        public string InsertedBy { get; set; }
        public string AppUrl { get; set; }

    }
}
