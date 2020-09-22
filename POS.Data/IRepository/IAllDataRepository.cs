using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IAllDataRepository
    {
        string GetAllData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);         
        
    }
}
