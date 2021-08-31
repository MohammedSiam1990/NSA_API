using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    /// <summary>
    /// <returns></returns>
    /// <createdBy> AhmedMustafa </createdBy>
    /// <createdDate>12-OCT-2017 </createdDate>
    /// </summary>
    /// 
    [Serializable]
    [JsonObject]
    public class Notification
    {
        public int PendingPaymentCount { get; set; }
    }
}
