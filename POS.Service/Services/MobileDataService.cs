
using POS.Data.Dto;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class MobileDataService : BaseService, IMobileDataService
    {
        public string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            return PosService.MobileDataRepository.GetMobileData(CompanyID, BrandImageURL, BranchImageURL, ItemGroupImageURL);
        }


    }
}
