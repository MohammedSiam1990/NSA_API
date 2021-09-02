using System.ComponentModel.DataAnnotations;

namespace NSR.Account
{
    public class SendMailModel
    {
        [Required]
        [EmailAddress]
        public string ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}