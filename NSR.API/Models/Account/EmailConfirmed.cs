using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class EmailConfirmedModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ConfirmCode { get; set; }
      
    }
}