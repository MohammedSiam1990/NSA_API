using Newtonsoft.Json;
using System;

namespace NSR.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NSR.Core.BaseEntity" />
    /// <createdby>AhmedMustafa</createdby>
    /// <createdon>29/07/2017</createdon>
    [Serializable()]
    [JsonObject]
    public class CultureMasterDDL : BaseEntity
    {
        public override string TableName
        {
            get { return "CultureMaster"; }
        }

        [DbColumn("CultureID")]
        public int CultureID { get; set; }

        [DbColumn("Name")]
        public string Name { get; set; }
    }
}

