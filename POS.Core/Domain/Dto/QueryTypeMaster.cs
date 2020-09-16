using Newtonsoft.Json;
using System;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class QueryTypeMaster
    {
        public int QueryTypeID { get; set; }
        public string QueryType { get; set; }
    }
}
