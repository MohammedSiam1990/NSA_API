using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto
{
    public partial class GetAllData
    {
        public GetAllData()
        {

        }
        public string BrandsData { get; set; }
        public string BranchsData { get; set; }
        public string ItemsGroup { get; set; }

    }
}
