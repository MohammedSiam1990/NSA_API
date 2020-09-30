using POS.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IAllDataJsonByBrandIDRepository
    {
        string GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);

    }
}
