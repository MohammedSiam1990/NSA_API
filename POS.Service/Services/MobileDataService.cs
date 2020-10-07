using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
{
    public class MobileDataService : BaseService, IMobileDataService
    {
        public int CheckSerialNumber(int CompanyID, string Serial)
        {
            return PosService.MobileDataRepository.CheckSerialNumber(CompanyID, Serial);
        }

        public string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL, string ItemImageURL)
        {
            return PosService.MobileDataRepository.GetMobileData(CompanyID, BrandImageURL, BranchImageURL, ItemGroupImageURL, ItemImageURL);
        }

        public int UpdateSerialNumber(int CompanyID, string Serial, string Mac)
        {
            return PosService.MobileDataRepository.UpdateSerialNumber(CompanyID, Serial, Mac);
        }
    }
}
