using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace POS.Core.Domain
{
    [Serializable()]
    [JsonObject]
    public class ForgotPassword
    {
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string ForgetEmailAddress { get; set; }
    }
}
