// ---------------------------------------------------------
// <copyright file="CDNMaster.cs" company="">
// All right reserved.
// </copyright>
// <author>AhmedMustafa</author>
// ------------------------------------------------------------ 


using Newtonsoft.Json;
using System;


namespace POS.Core.Domain.CDN
{

    /// <summary>
    /// CDN master domain model.
    /// </summary>
    /// 
    [Serializable]
    [JsonObject]
    public class CDNMaster
    {

        /// <summary>
        /// Gets or sets CDNStaticResourceID number.
        /// </summary>
        public Int16 CDNStaticResourceID { get; set; }

        /// <summary>
        /// Gets or sets VersionNo number.
        /// </summary>
        public Decimal VersionNo { get; set; }

        /// <summary>
        /// Gets or sets RootURL text.
        /// </summary>
        public string RootURL { get; set; }

        /// <summary>
        /// Gets or sets EnCssURL text .
        /// </summary>
        public string EnCssURL { get; set; }

        /// <summary>
        /// Gets or sets ArCssURL text .
        /// </summary>
        public string ArCssURL { get; set; }

        /// <summary>
        /// Gets or sets EnJsURL text.
        /// </summary>
        public string EnJsURL { get; set; }

        /// <summary>
        /// Gets or sets ArJsURL text.
        /// </summary>
        public string ArJsURL { get; set; }

        /// <summary>
        /// Gets or sets a value IsAlive is visible.
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// Gets or sets a value IsAlive is visible.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets a value OperationType.
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value OperationType.
        /// </summary>
        public System.Int16 OperationType { get; set; }

    }
}
