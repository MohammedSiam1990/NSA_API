using POS.Entities;
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
        public void AddRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            PosService.RemarksTemplateRepository.AddRemarksTemplate(remarksTemplate);
        }

        public string GetRemarksTemplate(int BrandID)
        {
            return PosService.RemarksTemplateRepository.GetProcRemarksTemplate(BrandID);
        }

        public void UpdateRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            PosService.RemarksTemplateRepository.UpdateRemarksTemplate(remarksTemplate);
        }

        public int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate)
        {
         return  PosService.RemarksTemplateRepository.ValidateNameAlreadyExist(remarksTemplate);
        }

        public bool ValidateRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            return PosService.RemarksTemplateRepository.ValidateRemarkTemplate(remarksTemplate);
        }
    }
}
