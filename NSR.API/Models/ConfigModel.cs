using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public partial class ConfigModel
    {
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
