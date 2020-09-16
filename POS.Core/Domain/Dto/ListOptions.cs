// ---------------------------------------------------------
// <copyright file="ListOptions.cs" company="Rasan">
// All right reserved.
// </copyright>
// <author>Tameeni</author>
// ------------------------------------------------------------ 

using Newtonsoft.Json;
using System;

namespace POS.Core.Domain
{
    /// <summary>
    /// List options model class.
    /// </summary>
    /// 
    [Serializable]
    [JsonObject]
    public class ListOptions
    {
        /// <summary>
        /// Gets or sets text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public string Value { get; set; }
    }
}
