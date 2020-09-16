using System;
using Newtonsoft.Json;

namespace POS.Core.Domain
{
    /// <summary>
    /// Merchant Prefix Master
    /// </summary>
    /// <version>1.0    13th June 18     AhmedMustafa</version>
    [Serializable]
    [JsonObject]
    public class MerchantPrefixMaster
    {
        public int MerchantPrefixID { get; set; }
        public int InsuranceTypeID { get; set; }
        public string ReferencePrefix { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
