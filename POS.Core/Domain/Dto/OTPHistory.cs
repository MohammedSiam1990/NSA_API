using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [Serializable()]
    [JsonObject]
    public class OTPHistory : BaseEntity
    {

        public override string TableName
        {
            get { return "OTPHistory"; }
        }       

        [PrimaryKey]
        public long OTPHistoryID { get; set; }

        [DbColumn("UserID")]
        [InsertColumnAttribute("UserID")]
        public int UserID { get; set; }

        [DbColumn("Event")]
        [InsertColumnAttribute("Event")]
        public string Event { get; set; }

        [DbColumn("OTPCode")]
        [InsertColumnAttribute("OTPCode")]
        public string OTPCode { get; set; }

        [DbColumn("IsActive")]
        [InsertColumnAttribute("IsActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the user mobile.
        /// </summary>
        /// <value>
        /// The user mobile.
        /// </value>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>11/05/2016</updatedon>
        /// <updates>string to long.</updates>
        public long? UserMobile { get; set; }

    }

    /// <summary>
    /// Class SendOTP.
    /// </summary>
    /// <updatedby>Rujuta Xavier</updatedby>
    /// <updatedon>04/01/2017</updatedon>
    /// <updates>Serializable, JsonObject attributes added.</updates>
    [Serializable()]
    [JsonObject]
    public class SendOTP
    {
        [Required]
        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$")]
        public string SMSCode { get; set; }

        [Required]
        public int UserID { get; set; }

        /// <summary>
        /// UserIDHidden
        /// </summary>
        /// <value>
        /// Store Hidden Field Value 
        /// </value>
        public string UserIDHidden { get; set; }

        [Required]
        public string UserType { get; set; }
    }
}
