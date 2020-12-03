using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
{
    public class RemarksTemplateService : BaseService, IRemarksTemplateService
    {
        public int AddRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            return PosService.RemarksTemplateRepository.AddRemarksTemplate(remarksTemplate);
        }

        public string GetRemarksTemplate(int BrandID)
        {
            return PosService.RemarksTemplateRepository.GetProcRemarksTemplate(BrandID);
        }

        public void UpdateRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            var DeletRemarksTemplateDetails = PosService.RemarksTemplateDetailsRepository.GetRemarksTemplateDetails(remarksTemplate.RemarksTemplateId);
            PosService.RemarksTemplateRepository.UpdateRemarksTemplate(remarksTemplate, DeletRemarksTemplateDetails);
        }


        public int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate)
        {
            return PosService.RemarksTemplateRepository.ValidateNameAlreadyExist(remarksTemplate);
        }

        public bool ValidateRemarksTemplate(RemarksTemplate remarksTemplate)
        {
            return PosService.RemarksTemplateRepository.ValidateRemarkTemplate(remarksTemplate);
        }
    }
}
