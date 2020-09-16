using System;
using Newtonsoft.Json;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class NationalityMaster
    {
        public short NationalityID { get; set; }
        public string NameEnglish { get; set; }
        public string NameArabic { get; set; }
        public int NationalityCode { get; set; }
    }
}
