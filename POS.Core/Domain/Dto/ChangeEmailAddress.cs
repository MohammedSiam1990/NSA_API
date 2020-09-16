using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class ChangeEmailAddress
    {
        public int UserID { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string CurrentEmail { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }

        [Required]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
