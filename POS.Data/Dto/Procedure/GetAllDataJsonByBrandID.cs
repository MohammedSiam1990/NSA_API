using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto.Procedure
{
    public partial class GetAllDataJsonByBrandID
    {
        public GetAllDataJsonByBrandID()
        {
            
        }
        public string BrandsData { get; set; }
        public string BranchsData { get; set; }
        public string ItemsGroup { get; set; }
        public string Departments { get; set; }
        public string GeneralTax { get; set; }
        public string SpecialTax { get; set; }
        public string RemarksTemplate { get; set; }
    }
}
