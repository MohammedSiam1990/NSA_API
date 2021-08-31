using Newtonsoft.Json;
using System;

namespace NSR.Core
{
    [Serializable]
    [JsonObject]
    public  class AspNetUsersession : BaseEntity
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public override string TableName
        {
            get { return "AspNetUsersession"; }
        }

        [PrimaryKey] 
        public int AspNetUsersessionID { get; set; }

        
        public long UserID { get; set; }

       
        public string Email { get; set; }

        
        public string SessionID { get; set; }

        
        public bool? IsPasswordReset { get; set; }
        //end
    }
}

