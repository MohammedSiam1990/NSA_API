using System.ComponentModel.DataAnnotations;

namespace NSR.API.Models.Account
{
    public class LoginMobileModel
    {
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FirebaseTokenId { get; set; }

        public int languageId { get; set; }
    }
}