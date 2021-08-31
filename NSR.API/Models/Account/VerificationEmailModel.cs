using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class VerificationEmailModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}