using POS.Entities;

namespace POS.Data.IRepository
{
    public interface IBrandRepository
    {
        int SaveProcBrand(Brands Branch);
        string GetProcBrand(int CompanyId, string ImageURL);
    }
}