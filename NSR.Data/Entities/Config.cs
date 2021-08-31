using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NSR.Data.Entities
{
    public class Config
    {
        [Key]
        public long ConfigID { get; set; }
        public int ConfigKeyID { get; set; }
        public int? BranchID { get; set; }
        public int? BrandID { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public long? ModifiedBy { get; set; }

    }
}
