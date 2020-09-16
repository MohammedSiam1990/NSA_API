using POS.API.Helpers;
using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static POS.Common.Enums;

namespace Pos.IService
{
  public  interface IBrandService
    {
        Brands GetBrand(int BrandId);
       List<Brands> GetBrandsByCompany(int CompanyId);
        List<Brands> GetBrands();
        bool ValidateBrand(Brands Brand);
        void AddBrand(Brands Brand);
        void UpdateBrand(Brands Brand);
        void DeleteBrand(int BrandId);
        void ResetDefaultBrand( int CompanyId,string UserId,int BrandId);
        bool ValidateCodeorNameAlreadyExist(int BrandId, int CompanyId, string BrandCode, string BrandName);
        PagedList<Brands> GetBrandsByCompany(List<Brands> Brands, PagedListModel model);

        void SaveProcBrands(Brands Branch);
        List<GetBrands> GetProcBrands(int CompanyId, string ImageURL);
    }
}
