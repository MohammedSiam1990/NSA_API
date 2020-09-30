using POS.Data.Dto.Procedure;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class AllDataJsonByBrandIDService : BaseService, IAllDataJsonByBrandIDService
    {
        public string GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            return PosService.AllDataJsonByBrandIDRepository.GetAllDataJsonByBrandID(BrandID, BrandImageURL, BrandImageURL, ItemGroupImageURL);
        }
    }
}
