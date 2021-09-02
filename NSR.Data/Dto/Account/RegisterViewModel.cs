using System.ComponentModel.DataAnnotations;

namespace NSR.Data.Dto
{
    public class RegisterViewModel
    {
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
    }
}