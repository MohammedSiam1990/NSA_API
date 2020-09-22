using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class AllDataService : BaseService, IAllDataService
    {
        public string GetAllData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            return PosService.AllDataRepository.GetAllData(CompanyID, BrandImageURL, BranchImageURL, ItemGroupImageURL);
        }
    }
}
