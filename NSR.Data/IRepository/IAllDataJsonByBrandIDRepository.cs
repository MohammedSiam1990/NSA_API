using NSR.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IAllDataJsonByBrandIDRepository
    {
        string GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);

    }
}
