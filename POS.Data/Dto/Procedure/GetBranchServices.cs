using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto.Procedure
{
    public partial class GetBranchServices
    {
        public GetBranchServices()
        {

        }
        public int BranchServiceID { get; set; }
        public int BranchID { get; set; }
        public int ServiceTypeID { get; set; }
        public int StatusID { get; set; }
    }
}
