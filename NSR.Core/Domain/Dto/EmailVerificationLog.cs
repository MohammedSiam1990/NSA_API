using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    [Serializable()]
    [JsonObject]
    public class EmailVerificationLog
    {
        public long EmailVerificationID { get; set; }

        public int UserID { get; set; }

        public string VerificationCode { get; set; }

        public DateTime EmailSentOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerifiedLink { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
