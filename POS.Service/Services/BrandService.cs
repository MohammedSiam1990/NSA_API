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
        public void AddBrand(Brands Brand)
        {
            PosService.BrandRepository.AddBrand(Brand);
        }

        public void DeleteBrand(int BrandId)
        {
            PosService.BrandRepository.DeleteBrand(BrandId);
        }

        public Brands GetBrand(int BrandId)
        {
            return PosService.BrandRepository.GetBrand(BrandId);
        }

        public List<Brands> GetBrandsByCompany(int CompanyId)
        {
            return PosService.BrandRepository.GetBrandBy(e => e.CompanyId == CompanyId);
        }

        public List<Brands> GetBrands()
        {
            return PosService.BrandRepository.GetBrands();
        }



        public void UpdateBrand(Brands Brand)
        {
            PosService.BrandRepository.UpdateBrand(Brand);
        }



        public bool ValidateBrand(Brands Brand)
        {
            return PosService.BrandRepository.ValidateBrand(Brand);
        }

        public void ResetDefaultBrand(int CompanyId, string UserId, int BrandId)
        {
            //PosService.BrandRepository.ResetDefaultBrand(BrandId, CompanyId);
            //PosService.AccountRepository.ResetUserBarndDefault(UserId, BrandId);
        }
        public bool ValidateCodeorNameAlreadyExist(int BrandId, int CompanyId, string BrandCode, string BrandName)
        {
            return PosService.BrandRepository.ValidateCodeorNameAlreadyExist(e => e.CompanyId == CompanyId &&( e.BrandName == BrandName) && e.BrandId != BrandId);

        }

        public PagedList<Brands> GetBrandsByCompany(List<Brands> Brands, PagedListModel model)
        {
            return new PagedList<Brands>(Brands, model.PageIndex, model.PageSize);
        }

        public void SaveProcBrands(Brands Brand)
        {
            PosService.BrandRepository.SaveProcBrand(Brand);
        }

        public List<GetBrands> GetProcBrands(int CompanyId, string ImageURL)
        {
            return PosService.BrandRepository.GetProcBrand(CompanyId,  ImageURL);
        }
    }
}
