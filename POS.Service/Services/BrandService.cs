using Pos.IService;
using POS.Entities;
using POS.IService.Base;
using System.Collections.Generic;

namespace Pos.Service
{
    public class BrandService : BaseService, IBrandService
    {

        public int SaveProcBrands(Brands Brand)
        {
            return PosService.BrandRepository.SaveProcBrand(Brand);
        }

        public string GetProcBrands(int CompanyId, string ImageURL)
        {
            return PosService.BrandRepository.GetProcBrand(CompanyId, ImageURL);
        }
    }
}
