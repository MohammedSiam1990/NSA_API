using System;
using Newtonsoft.Json;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class RegionTowingFeeMaster
    {
        public int RegionTowingFeeID { get; set; }
        public int? RegionID { get; set; }
        public short? VehicleBodyTypeID { get; set; }
        public int? InsuranceCompanyID { get; set; }
        public decimal Amount { get; set; }
        public byte? CurrencyID  { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatedBy { get; set; }
        public int? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public int? UpdatedOn { get; set; }
    }
}
