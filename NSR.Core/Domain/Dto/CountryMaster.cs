﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class CountryMaster
    {
        public short CountryID { get; set; }
        public string NameEnglish { get; set; }
        public string NameArabic { get; set; }
        public int DialingCode { get; set; }
    }
}
