using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class EmailNotification
    {
        /// <summary>
        /// Gets or sets the email notification identifier.
        /// </summary>
        /// <value>
        /// The email notification identifier.
        /// </value>
        [PrimaryKey]       
        public long EmailNotificationID { get; set; }

        /// <summary>
        /// Gets or sets the tech notification identifier.
        /// </summary>
        /// <value>
        /// The tech notification identifier.
        /// </value>            
        public int? TechNotificationID { get; set; }

        /// <summary>
        /// Gets or sets the email body.
        /// </summary>
        /// <value>
        /// The email body.
        /// </value>             
        public string EmailBody { get; set; }

        /// <summary>
        /// Gets or sets to email.
        /// </summary>
        /// <value>
        /// To email.
        /// </value>       
        public string ToEmail { get; set; }

        /// <summary>
        /// Gets or sets the cc email.
        /// </summary>
        /// <value>
        /// The cc email.
        /// </value>       
        public string CcEmail { get; set; }

        /// <summary>
        /// Gets or sets the email subject.
        /// </summary>
        /// <value>
        /// The email subject.
        /// </value>
              
        public string EmailSubject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is attachment.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is attachment; otherwise, <c>false</c>.
        /// </value>       
        public Boolean? IsAttachment { get; set; }

        /// <summary>
        /// Gets or sets the attached file.
        /// </summary>
        /// <value>
        /// The attached file.
        /// </value>        
        public string AttachedFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is sent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is sent; otherwise, <c>false</c>.
        /// </value>       
        public bool? isSent { get; set; }

        /// <summary>
        /// Gets or sets the email sent date.
        /// </summary>
        /// <value>
        /// The email sent date.
        /// </value>
          
        public DateTime? EmailSentDate { get; set; }

        /// <summary>
        /// Gets or sets the attempt count.
        /// </summary>
        /// <value>
        /// The attempt count.
        /// </value>          
        public int? AttemptCount { get; set; }


        /// <summary>
        /// Gets or sets the SMTP configuration identifier.
        /// </summary>
        /// <value>
        /// The SMTP configuration identifier.
        /// </value>       
        public int? SMTPConfigurationID { get; set; }

        public int? EmailSourceID { get; set; }
    }

    /// <summary>
    /// Class SystemNotificationParameter.
    /// </summary>
    public class SystemNotificationParameter
    {
        /// <summary>
        /// Gets or sets the parameter list.
        /// </summary>
        /// <value>
        /// The parameter list.
        /// </value>
        public Dictionary<string, string> parameterList { get; set; }

        /// <summary>
        /// Gets or sets to address.
        /// </summary>
        /// <value>
        /// To address.
        /// </value>
        public string toAddress { get; set; }

        /// <summary>
        /// Gets or sets the cc address.
        /// </summary>
        /// <value>
        /// The cc address.
        /// </value>
        public string ccAddress { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public string body { get; set; }
    }
}
