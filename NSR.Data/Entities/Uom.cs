using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.Entities
{
    public class Uom
    {
        public int UOMID { get; set; }
        public string UOMName { get; set; }
        public string UOMNameAr { get; set; }
        public string Tag { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public long? InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string StatusName { get; set; }
        public string StatusNameAr { get; set; }

    }
}