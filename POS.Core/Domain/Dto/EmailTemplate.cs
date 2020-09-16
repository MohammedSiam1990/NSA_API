using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class EmailTemplate
    {
       
        public int EmailTemplateID { get; set; }

       
        public string EmailTemplateName { get; set; }

       
        public string EmailSubjectLineEnglish { get; set; }

        
        public string EmailSubjectLineArabic { get; set; }

        
        public string EmailTemplateHTMLEnglish { get; set; }

        
        public string EmailTemplateHTMLArabic { get; set; }

        
        public int? SMTPConfigurationID { get; set; }

       
        public Boolean IsActive { get; set; }

        
    }

    /// <summary>
    /// Class SharePurchasePolicy
    /// </summary>
    public class SharePurchasePolicy
    {
        /// <summary>
        /// Gets or sets the current screen identifier.
        /// </summary>
        /// <value>
        /// The current screen identifier.
        /// </value>
        public int CurrentScreenID { get; set; }


        /// <summary>
        /// Gets or sets the sharing mode.
        /// </summary>
        /// <value>
        /// The sharing mode.
        /// </value>
        [Required]
        public string SharingMode { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [Required]
        [AllowHtml]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>        
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>11/05/2016</updatedon>
        /// <updates>string to long.</updates>
        [Required]
        [RegularExpression("^05[0-9]{8}$")]
        public long? MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the mobile URL.
        /// </summary>
        /// <value>
        /// The mobile URL.
        /// </value>
        public string MobileUrl { get; set; }

        /// <summary>
        /// Gets or sets the policy detail identifier.
        /// </summary>
        /// <value>
        /// The policy detail identifier.
        /// </value>
        [Required]
        public int PolicyDetailID { get; set; }


        /// <summary>
        /// Gets or sets the policy detail iden.
        /// </summary>
        /// <value>
        /// The policy detail iden.
        /// </value>
        public string PolicyDetailIDEN { get; set; }

        /// <summary>
        /// Gets or sets the current screen encypted id.
        /// </summary>
        /// <value>
        /// The current screen encypted id.
        /// </value>
        public string CurrentScreenIDEN { get; set; }

        /// <summary>
        /// PolicyDetailIdHidden
        /// </summary>
        /// <value>
        /// Strore Encrypted Values
        /// </value>
        public string PolicyDetailIdHidden { get; set; }

        /// <summary>
        /// CarIdHidden
        /// </summary>
        /// <value>
        /// Strore Encrypted Values 
        /// </value>
        public string CarIdHidden { get; set; }

        /// <summary>
        /// Gets or sets the policy holder identifier.
        /// </summary>
        /// <value>
        /// The policy holder identifier.
        /// </value>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>19/02/2016</updatedon>
        /// <updates>string to long</updates>
        public long PolicyHolderID { get; set; }

        /// <summary>
        /// PolicyHolderIDEN
        /// </summary>
        public string PolicyHolderIDEN { get; set; }

        /// <summary>
        /// Gets or sets the name of the policy holder.
        /// </summary>
        /// <value>
        /// The name of the policy holder.
        /// </value>
        public string PolicyHolderName { get; set; }

        /// <summary>
        /// Gets or sets the car identifier.
        /// </summary>
        /// <value>
        /// The car identifier.
        /// </value>
        public string CarID { get; set; }

        /// <summary>
        /// Gets or sets the car iden.
        /// </summary>
        /// <value>
        /// The car iden.
        /// </value>
        public string CarIDEN { get; set; }

        /// <summary>
        /// Gets or sets the insurance company.
        /// </summary>
        /// <value>
        /// The insurance company.
        /// </value>
        public string InsuranceCompany { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the ret string.
        /// </summary>
        /// <value>
        /// The ret string.
        /// </value>
        public string RetString { get; set; }

        ///// <summary>
        ///// Gets or sets the ret id.
        ///// </summary>
        ///// <value>
        ///// The ret id.
        ///// </value>
        //public int SMSSenderTypeID { get; set; }

        //Add to manage SMTP Configuration ID
        public int? SMTPConfigurationID { get; set; }
    }
}
