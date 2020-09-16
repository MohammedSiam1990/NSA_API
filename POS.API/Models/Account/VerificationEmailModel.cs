using System.ComponentModel.DataAnnotations;

namespace POS.Account
{
    public class VerificationEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}