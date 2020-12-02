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
    public class PriceTemplateService : BaseService, IPriceTemplateService
    {
        public string GetPriceTemlate(int PriceTemplateID)
        {
            return PosService.PriceTemplateRepository.GetPriceTemlate(PriceTemplateID);
        }

        public void SavePriceTemplate(PriceTemplate model)
        {
             PosService.PriceTemplateDetailsRepository.DeletePriceTemplateDetails(model.PriceTemplateID,model.PriceTemplateDetails);
             PosService.PriceTemplateRepository.SavePriceTemplate(model);
        }

        public int ValidateNameAlreadyExist(PriceTemplate model)
        {
            return PosService.PriceTemplateRepository.ValidateNameAlreadyExist(model);
        }
    }
}
