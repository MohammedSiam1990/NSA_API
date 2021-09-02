using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public partial class UomModel
    {
        public int UOMID { get; set; }
        public string UOMName { get; set; }
        public string UOMNameAr { get; set; }
        public string Tag { get; set; }
        public int? StatusID { get; set; }
        public int CompanyID { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
