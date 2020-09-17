using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace POS.Data.IRepository
{
    public interface IBrandRepository
    {
        Brands GetBrand(int BrandId);
        List<Brands> GetBrandBy(Expression<Func<Brands, bool>> where);
        List<Brands> GetBrands();
        bool ValidateBrand(Brands Brand);
        void AddBrand(Brands Brand);
        void UpdateBrand(Brands Brand);
        void DeleteBrand(int BrandId);
        void ResetDefaultBrand(int BrandId, int CompanyId);
        bool ValidateCodeorNameAlreadyExist(Expression<Func<Brands, bool>> where);
        int SaveProcBrand(Brands Branch);
        List<GetBrands> GetProcBrand(int CompanyId, string ImageURL);
    }
}