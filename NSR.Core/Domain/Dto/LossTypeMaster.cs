using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class LossTypeMaster
    {
        /// <summary>
        /// Gets or sets the LossTypeID identifier.
        /// </summary>
        /// <value>
        /// The LossTypeID identifier.
        /// </value>       
        public byte LossTypeID { get; set; }
        /// <summary>
        /// Gets or sets the English Name for Loss Type.
        /// </summary>
        /// <value>
        /// The English Name for Loss Type.
        /// </value>        
        public string EnglishName { get; set; }

        /// <summary>
        /// Gets or sets the Arabic Name for Loss Type.
        /// </summary>
        /// <value>
        /// The Arabic Name for Loss Type.
        /// </value>        
        public string ArabicName { get; set; }
    }
}
