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
    public class UserTypeMaster : BaseEntity
    {
        public override string TableName
        {
            get { return "UserTypeMaster"; }
        }


        [PrimaryKey]
        [DbColumnAttribute("UserTypeID")]
        public int UserTypeID { get; set; }

        [DbColumnAttribute("UserTypeEnglishName")]
        [InsertColumnAttribute("UserTypeEnglishName")]
        public string UserTypeEnglishName { get; set; }

        [DbColumnAttribute("UserTypeArabicName")]
        [InsertColumnAttribute("UserTypeArabicName")]
        public string UserTypeArabicName { get; set; }

        [DbColumnAttribute("Sequence")]
        [InsertColumnAttribute("Sequence")]
        public int Sequence { get; set; }

        [DbColumnAttribute("IsActive")]
        [InsertColumnAttribute("IsActive")]
        public bool IsActive { get; set; }
    }
}
