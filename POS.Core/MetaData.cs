using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS.Core
{
    /// <summary>
    /// Class MetaData.
    /// </summary>
    /// <seealso cref="POS.Core" />
    /// 
    [Serializable]
    [JsonObject]
    public class MetaData : BaseEntity
    {
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public override string TableName
        {
            get { return "MetaData"; }
        }

        /// <summary>
        /// Gets or sets the Meta Data identifier.
        /// </summary>
        /// <value>
        /// The Meta Data identifier.
        /// </value>
        [PrimaryKey]
        [DbColumnAttribute("MetaDataID")]
        public int MetaDataID { get; set; }

        /// <summary>
        /// Gets or sets the meta data iden.
        /// </summary>
        /// <value>
        /// The meta data iden.
        /// </value>
        public string MetaDataIDEN { get; set; }

        /// <summary>
        /// Gets or sets the ScreenID
        /// </summary>
        /// <value>
        /// The ScreenID
        /// </value>
        [DbColumnAttribute("ScreenID")]
        [InsertColumnAttribute("ScreenID")]
        public int ScreenID { get; set; }

        /// <summary>
        /// Gets or sets the TitleEnglish
        /// </summary>
        /// <value>
        /// The TitleEnglish
        /// </value>
        [DbColumnAttribute("TitleEnglish")]
        [InsertColumnAttribute("TitleEnglish")]
        [Required]
        public string TitleEnglish { get; set; }

        /// <summary>
        /// Gets or sets the TitleArabic
        /// </summary>
        /// <value>
        /// The TitleArabic
        /// </value>
        [DbColumnAttribute("TitleArabic")]
        [InsertColumnAttribute("TitleArabic")]
        public string TitleArabic { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        /// <value>
        /// The Description
        /// </value>
        [DbColumnAttribute("Description")]
        [InsertColumnAttribute("Description")]
        [Required]
        public string Description { get; set; }

        [DbColumnAttribute("ScreenNameEnglish")]
        public string ScreenNameEnglish { get; set; }

        [DbColumnAttribute("ScreenNameArabic")]
        public string ScreenNameArabic { get; set; }

        [DbColumnAttribute("TotalRows")]
        public int TotalRows { get; set; }



    }

    public class MetaDataDataModel
    {
        public List<MetaData> MetaData { get; set; }

        /// <summary>
        /// Gets or sets the action list.
        /// </summary>
        /// <value>
        /// The action list.
        /// </value>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>29/07/2017</createdon>
        public ScreenAction ActionList { get; set; }

        public int PageSize { get; set; }
        public string SearchText { get; set; }
        public int TotalRecord { get; set; }
        public int NoOfPages { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

}
