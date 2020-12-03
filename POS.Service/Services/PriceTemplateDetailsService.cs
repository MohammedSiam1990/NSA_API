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
    public class PriceTemplateDetailsService : BaseService, IPriceTemplateDetailsService
    {
        public void SavePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model)
        {
             PosService.PriceTemplateDetailsRepository.DeletePriceTemplateDetails(PriceTemplateID, model);
        }
    }
}
