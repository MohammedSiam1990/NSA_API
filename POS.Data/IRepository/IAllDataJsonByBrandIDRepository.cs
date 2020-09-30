using POS.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IAllDataJsonByBrandIDRepository
    {
        List<GetAllDataJsonByBrandID> GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);

    }
}
