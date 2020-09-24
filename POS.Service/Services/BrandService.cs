using Pos.IService;
using POS.API.Helpers;
using POS.Common;
using POS.Entities;
using POS.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace Pos.Service
{
    public class BrandService : BaseService, IBrandService
    {

        public int SaveProcBrands(Brands Brand)
        {
         return   PosService.BrandRepository.SaveProcBrand(Brand);
        }

        public List<GetBrands> GetProcBrands(int CompanyId, string ImageURL)
        {
            return PosService.BrandRepository.GetProcBrand(CompanyId,  ImageURL);
        }
    }
}
