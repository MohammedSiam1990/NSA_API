using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string BrandName { get; set; }
        public int MajorServiceId { get; set; }
        public int  CountryId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password And Confirm password must match")]
        public string ConfirmPassword { get; set; }

    }
    public class RegisterCustormerModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirebaseTokenId { get; set; }

        public int languageId { get; set; }

    }
}