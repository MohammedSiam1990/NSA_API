using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public class BranchWorkStationsModel
    {
        public int BranchWorkstationID { get; set; }
        public int BranchID { get; set; }
        public int CompanyID { get; set; }
        public string WorkstationName { get; set; }
        public string Serial { get; set; }
        public string Mac { get; set; }
        public int StatusID { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public long? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastModifyDate { get; set; }
    }
}
