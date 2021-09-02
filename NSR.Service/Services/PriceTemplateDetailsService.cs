using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class PriceTemplateDetailsService : BaseService, IPriceTemplateDetailsService
    {
        public void SavePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model)
        {
            PosService.PriceTemplateDetailsRepository.DeletePriceTemplateDetails(PriceTemplateID, model);
        }
    }
}
