using System;
using Newtonsoft.Json;

namespace NSR.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class MetaData
    {
        public int MetaDataID { get; set; }
        public int ScreenID { get; set; }
        public string ScreenNameEnglish { get; set; }
        public string ScreenNameArabic { get; set; }
        public string ScreenAlias { get; set; }
        public string TitleEnglish { get; set; }
        public string TitleArabic { get; set; }
        public string KeywordEnglish { get; set; }
        public string KeywordArabic { get; set; }
        public string DescriptionEnglish { get; set; }
        public string DescriptionArabic { get; set; }
        public bool IsSeoIndexingEnable { get; set; }
    }
}
