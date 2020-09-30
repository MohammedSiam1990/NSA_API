using POS.Data.Dto;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IMobileDataService
    {
        string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);
    }
}
