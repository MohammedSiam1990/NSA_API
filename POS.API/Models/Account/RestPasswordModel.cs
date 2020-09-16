using POS.Common;
using System.ComponentModel.DataAnnotations;

namespace POS.Account
{
    public class RestPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType( DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password And Confirm password must match")]
        public string ConfirmPassword { get; set; }


        public string ConfirmCode { get; set; }
    }
    public class CustomerRestPasswordModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int LanguageId  { get; set; }
    }
    public class UserChangePasswordModel
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        public int LanguageId { get; set; }
    }
}