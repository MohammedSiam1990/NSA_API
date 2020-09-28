using POS.Data.Entities;
using POS.Entities;
using System.Collections.Generic;

namespace POS.Data.Repository
{
    internal interface IItemRepository
    {
        int SaveProcBrand(Item Branch);
        List<GetBrands> GetProcBrand(int CompanyId, string ImageURL);
    }
}