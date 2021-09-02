using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class UserProfileModel
    {
        [Required]
        public long UserId { get; set; }
        public string Email { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int languageId { get; set; }
    }
  }