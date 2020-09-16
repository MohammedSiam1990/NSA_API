using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class Pagination
    {
        /// <summary>
        /// Gets or sets OrderBy
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets OrderType
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Gets or sets PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets PageIndex
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets TotalRecord
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// Gets or sets NoOfPages
        /// </summary>
        public int NoOfPages { get; set; }
    }
}
