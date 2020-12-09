using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class PriceTemplateDetailsService : BaseService, IPriceTemplateDetailsService
    {
        public void SavePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model)
        {
            PosService.PriceTemplateDetailsRepository.DeletePriceTemplateDetails(PriceTemplateID, model);
        }
    }
}
