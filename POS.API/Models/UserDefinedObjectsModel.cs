using System;

namespace POS.API.Models
{
    public partial class UserDefinedObjectsModel
    {
        public int UserDefinedObjectsID { get; set; }
        public int? TypeID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public int? OrderID { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public int? BrandID { get; set; }
        public string InsertedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }

}
