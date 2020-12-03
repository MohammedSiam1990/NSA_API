﻿using POS.Data.Entities;
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
        public string GetPriceTemlate(int BrandID)
        {
            return PosService.PriceTemplateRepository.GetPriceTemlate(BrandID);
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
