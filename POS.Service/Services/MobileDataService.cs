using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class MobileDataService : BaseService, IMobileDataService
    {
        public List<MobileData> GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            return PosService.MobileDataRepository.GetMobileData(CompanyID, BrandImageURL, BranchImageURL, ItemGroupImageURL);
        }
    }
}
