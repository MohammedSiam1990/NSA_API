using NSR.Entities;

namespace NSR.Data.IRepository
{
    public interface IBrandRepository
    {
        int SaveProcBrand(Brands Branch);
        string GetProcBrand(int CompanyId, long UserID, string ImageURL);
    }
}