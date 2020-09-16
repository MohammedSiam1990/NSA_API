using System;
using Newtonsoft.Json;

namespace POS.Core
{ /// <summary>
  /// 
  /// </summary>
  /// <seealso cref="POS.Core" />
  /// <createdby>AhmedMustafa</createdby>
  /// <createdon>29/07/2017</createdon>  
    [Serializable()]
    [JsonObject]
    public class ScreenAction : BaseEntity
    {
        [DbColumn("ScreenID")]
        public int ScreenID { get; set; }

        [DbColumn("Actions")]
        public string Actions { get; set; }

        public override string TableName
        {
            get { return "Action"; }
        }        
    }
}
