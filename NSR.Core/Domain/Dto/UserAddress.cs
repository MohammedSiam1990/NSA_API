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
    public class UserAddress : BaseEntity
    {
        public override string TableName
        {
            get { return "UserAddress"; }
        }

        public int UserID { get; set; }

        public int UserAddressID { get; set; }

        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string BuldingNumber { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string District { get; set; }

        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string AdditionalNumber { get; set; }

        [RegularExpression("^[1-8]{1}[2-9]{1}[2-9]{1}[1-9]{1}[1-9]{1}$")]
        [Required]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(200)]
        public string ForeignAddress { get; set; }
        public short CountryID { get; set; }
        public string Country { get; set; }
    }
}
