using POS.IService.Base;
using POS.Service.IService;

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
