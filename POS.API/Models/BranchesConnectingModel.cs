using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.API.Models
{
    public partial class BranchesConnectingModel
    {
        public long BranchConnectingID { get; set; }
        public int BranchID { get; set; }
        public int ConnectingID { get; set; }
        public int TypeID { get; set; }
        public string TypeName { get; set; }
    }
}
