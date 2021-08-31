using System.ComponentModel.DataAnnotations;

namespace NSR.API.Models.Account
{
    public class AuthenticateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}