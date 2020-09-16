using Newtonsoft.Json;
using System;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class FeesType
    {
        public short FeesTypeID { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public int DefaultFeesAmount { get; set; }
        public short Sequence { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string FeesTypeCode { get; set; }

    }
}
