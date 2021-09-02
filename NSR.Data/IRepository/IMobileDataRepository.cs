using NSR.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IMobileDataRepository
    {
        string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL, string ItemImageURL);
        int UpdateSerialNumber(int CompanyID, string Serial, string Mac);
        int CheckSerialNumber(int CompanyID, string Serial);
    }
}
