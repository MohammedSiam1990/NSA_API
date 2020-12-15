using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Entities
{
    public class UserDefinedObjects
    {
        [Key]
        public int UserDefinedObjectsID { get; set; }
        public int? TypeID { get; set; }
        public string JsonValues { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public int? BrandID { get; set; }
        public long? InsertedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }

    }
}
