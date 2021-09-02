using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NSR.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NSR.Core.BaseEntity" />
    /// <createdby>AhmedMustafa</createdby>
    /// <createdon>29/07/2017</createdon>
    [Serializable()]
    [JsonObject]
    public class UserDetail : BaseEntity
    {
        public override string TableName
        {
            get { return "UserAddress"; }
        }

        /// <summary>
        /// Gets or sets the user detail identifier.
        /// </summary>
        /// <value>
        /// The user detail identifier.
        /// </value>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>29/07/2017</createdon>
        [PrimaryKey]
        [DbColumnAttribute("UserAddressID")]
        public long UserAddressID { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [InsertColumnAttribute("UserID")]
        [DbColumnAttribute("UserID")]
        public int UserID { get; set; }

        [Required]
        [InsertColumnAttribute("CultureID")]
        [DbColumnAttribute("CultureID")]
        public int CultureID { get; set; }

        public List<CultureMasterDDL> CultureList { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [InsertColumnAttribute("Name")]
        [DbColumnAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [DbColumnAttribute("Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>29/07/2017</createdon>
        [DbColumnAttribute("MobileNumber")]
        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$")]
        public long MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the current screen identifier.
        /// </summary>
        /// <value>
        /// The current screen identifier.
        /// </value>
        public int CurrentScreenID { get; set; }

        /// <summary>
        /// Gets or sets the bulding number.
        /// </summary>
        /// <value>
        /// The bulding number.
        /// </value>
        [InsertColumnAttribute("BuldingNumber")]
        [DbColumnAttribute("BuldingNumber")]
        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string BuldingNumber { get; set; }

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        /// <value>
        /// The district.
        /// </value>
        [InsertColumnAttribute("District")]
        [DbColumnAttribute("District")]
        [MaxLength(50)]
        [Required]
        public string District { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [InsertColumnAttribute("ZipCode")]
        [DbColumnAttribute("ZipCode")]
        [RegularExpression("^[0-9]{5}$")]
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [InsertColumnAttribute("Street")]
        [DbColumnAttribute("Street")]
        [MaxLength(50)]
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [DbColumnAttribute("City")]
        [InsertColumnAttribute("City")]
        [MaxLength(50)]
        [Required]
        public string City { get; set; }



        /// <summary>
        /// Gets or sets the additional number.
        /// </summary>
        /// <value>
        /// The additional number.
        /// </value>
        [InsertColumnAttribute("AdditionalNumber")]
        [DbColumnAttribute("AdditionalNumber")]
        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string AdditionalNumber { get; set; }

        /// <summary>
        /// UserIdHidden
        /// </summary>
        /// <value>
        /// Store Encrypted Value
        /// </value>
        public string UserIdHidden { get; set; }


    }

    [Serializable()]
    [JsonObject]
    public class ProfileAddressDetail : BaseEntity
    {


        public override string TableName
        {
            get { return "UserAddress"; }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        [InsertColumnAttribute("UserID")]
        [DbColumnAttribute("UserID")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the bulding number.
        /// </summary>
        /// <value>
        /// The bulding number.
        /// </value>
        [InsertColumnAttribute("BuldingNumber")]
        [DbColumnAttribute("BuldingNumber")]
        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string BuldingNumber { get; set; }

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        /// <value>
        /// The district.
        /// </value>
        [InsertColumnAttribute("District")]
        [DbColumnAttribute("District")]
        [MaxLength(50)]
        [Required]
        public string District { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        /// <value>
        /// The zip code.
        /// </value>
        [InsertColumnAttribute("ZipCode")]
        [DbColumnAttribute("ZipCode")]
        [RegularExpression("^[0-9]{5}$")]
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        [InsertColumnAttribute("Street")]
        [DbColumnAttribute("Street")]
        [MaxLength(50)]
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [DbColumnAttribute("City")]
        [InsertColumnAttribute("City")]
        [MaxLength(50)]
        [Required]
        public string City { get; set; }


        /// <summary>
        /// Gets or sets the additional number.
        /// </summary>
        /// <value>
        /// The additional number.
        /// </value>
        [InsertColumnAttribute("AdditionalNumber")]
        [DbColumnAttribute("AdditionalNumber")]
        [RegularExpression("^[0-9]{4}$")]
        [Required]
        public string AdditionalNumber { get; set; }
    }
    [Serializable]
    [JsonObject]
    public class ChangePassword
    {
        /// <summary>
        /// UserID Entity
        /// </summary>
        [Required]
        public int UserID { get; set; }

        public string UserIDEN { get; set; }

        /// <summary>
        /// CurrentPassword Entity
        /// </summary>
        [DbColumnAttribute("CurrentPassword")]
        [Required]
        public string CurrentPassword { get; set; }

        /// <summary>
        /// NewPassword Entity
        /// </summary>
        [DbColumnAttribute("NewPassword")]
        [Required]
        public string NewPassword { get; set; }

        /// <summary>
        /// ConfirmPassword Entity
        /// </summary>
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// CurrentScreenID Entity
        /// </summary>
        public int CurrentScreenID { get; set; }

        /// <summary>
        /// VerificationCode Entity
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// UserIDReset
        /// </summary>
        public string UserIDReset { get; set; }
    }
}

