using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    [Serializable()]
    [JsonObject]
    public class ContactUS
    {
        [Required]
        [MaxLength(150)]
        [RegularExpression("^[a-zA-Z0-9. -]*$")]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^05[0-9]{8}$")]
        public long MobileNumber { get; set; }

        [Required]
        [RegularExpression("^[1-9][0-9]*$")]
        public int QueryType { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Comment { get; set; }

        public int UserID { get; set; }
    }
}
