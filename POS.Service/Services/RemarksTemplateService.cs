using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class RemarksTemplateService : BaseService, IRemarksTemplateService
    {
        public string GetRemarksTemplate(int BrandID)
        {
            return PosService.RemarksTemplateRepository.GetProcRemarksTemplate(BrandID);
        }
    }
}
