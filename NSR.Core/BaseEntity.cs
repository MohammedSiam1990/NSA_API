using Newtonsoft.Json;
using System;

namespace NSR.Core
{/// <summary>
 /// Abstract class BaseEntity
 /// </summary>
 /// <createdby>AhmedMustafa</createdby>
 /// <createdon>29/07/2017</createdon>    
 /// <updates>Add serializable for session state server.</updates>
    [Serializable()]
    [JsonObject]
    public abstract class BaseEntity
    {
        public int StatusID { get; set; }

        public bool? IsDeleted { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public int? OperationType { get; set; }
        public long? CreatedByUserTypeID { get; set; }

        public abstract string TableName { get; }
    }
}
