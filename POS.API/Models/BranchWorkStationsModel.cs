using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public class BranchWorkStationsModel
    {
        public int BranchWorkstationID { get; set; }
        public int BranchID { get; set; }
        public string WorkstationName { get; set; }
        public string Serial { get; set; }
        public string Mac { get; set; }
        public int StatusID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }
    }
}
