using System;

namespace POS.API.Models
{
    public partial class UserDefinedObjectsModel
    {
        public int UserDefinedObjectsID { get; set; }
        public int? TypeID { get; set; }
        public string JsonValues { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public int? BrandID { get; set; }
        public long? InsertedBy { get; set; }
        public long? ModifiedBy { get; set; }
    }

}
