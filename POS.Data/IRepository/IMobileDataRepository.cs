using POS.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IMobileDataRepository
    {
        string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL, string ItemImageURL);
    }
}
