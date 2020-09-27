using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto.Procedure
{
    public partial class GetUoms
    {
        public GetUoms()
        {
        }
        public int UOMID { get; set; }
        public string UOMName { get; set; }
        public string UOMNameAr { get; set; }
        public string Tag { get; set; }
        public int? StatusID { get; set; }
        public int? CompanyID { get; set; }
        public string InsertedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string StatusName { get; set; }
        public string StatusNameAr { get; set; }

    }
}
