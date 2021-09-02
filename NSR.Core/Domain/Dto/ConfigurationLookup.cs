using System;
using Newtonsoft.Json;

namespace NSR.Core.Domain
{
    /// <summary>
    /// ConfigurationLookup class to hold the key value pair
    /// </summary>
    [Serializable()]
    [JsonObject]
    public class ConfigurationLookup : BaseEntity
    {
        /// <summary>
        /// Table name for configuration lookup values
        /// </summary>
        public override string TableName
        {
            get { return "ConfigurationLookup"; }
        }

        /// <summary>
        /// Gets or sets configuration lookup id
        /// </summary>
        [PrimaryKey]
        [DbColumnAttribute("ID")]
        public int ConfigurationLookupID { get; set; }

        /// <summary>
        /// Gets or sets key field
        /// </summary>
        [DbColumnAttribute("KeyField")]
        public string KeyField { get; set; }

        /// <summary>
        /// Gets or sets value field
        /// </summary>
        [DbColumnAttribute("ValueField")]
        public string ValueField { get; set; }
    }
}