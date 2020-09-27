using POS.Entities;
using System.Collections.Generic;

namespace Pos.IService
{
    public interface IBrandService
    {
        int SaveProcBrands(Brands Branch);
        List<GetBrands> GetProcBrands(int CompanyId, string ImageURL);
    }
}
