using NSR.Entities;

namespace NSR.IService
{
    public interface IBrandService
    {
        int SaveProcBrands(Brands Branch);
        string GetProcBrands(int CompanyId, long UserID, string ImageURL);
    }
}
