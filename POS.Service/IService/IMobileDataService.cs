using POS.Data.Dto;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IMobileDataService
    {
        string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL, string ItemImageURL);
        int UpdateSerialNumber(int CompanyID, string Serial, string Mac);
        int CheckSerialNumber(int CompanyID, string Serial);

    }
}
