using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
{
    public class PriceTemplateService : BaseService, IPriceTemplateService
    {
        public string GetPriceTemlate(int BrandID)
        {
            return PosService.PriceTemplateRepository.GetPriceTemlate(BrandID);
        }

        public void SavePriceTemplate(PriceTemplate model)
        {
            PosService.PriceTemplateDetailsRepository.DeletePriceTemplateDetails(model.PriceTemplateID, model.PriceTemplateDetails);
            PosService.PriceTemplateRepository.SavePriceTemplate(model);
        }

        public int ValidateNameAlreadyExist(PriceTemplate model)
        {
            return PosService.PriceTemplateRepository.ValidateNameAlreadyExist(model);
        }
    }
}
