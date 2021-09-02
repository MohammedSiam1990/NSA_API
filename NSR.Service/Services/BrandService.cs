using NSR.IService;
using NSR.Entities;
using NSR.IService.Base;

namespace NSR.Service
{
    public class BrandService : BaseService, IBrandService
    {
        public int SaveProcBrands(Brands Brand)
        {
            return PosService.BrandRepository.SaveProcBrand(Brand);
        }

        public string GetProcBrands(int CompanyId, long UserID, string ImageURL)
        {
            return PosService.BrandRepository.GetProcBrand(CompanyId, UserID, ImageURL);
        }
    }
}
