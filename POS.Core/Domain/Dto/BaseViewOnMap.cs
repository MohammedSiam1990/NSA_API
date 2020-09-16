using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace POS.Core.Domain
{
    [JsonObject]
    [Serializable]
    public class BaseViewOnMap
    {
        public string CityName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}
