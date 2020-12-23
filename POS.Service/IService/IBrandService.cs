using POS.Entities;

namespace Pos.IService
{
    public interface IBrandService
    {
        int SaveProcBrands(Brands Branch);
        string GetProcBrands(int CompanyId, long UserID, string ImageURL);
    }
}
