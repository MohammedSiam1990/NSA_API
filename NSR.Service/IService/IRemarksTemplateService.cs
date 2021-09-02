using NSR.Entities;

namespace NSR.Service.IService
{
    public interface IRemarksTemplateService
    {
        string GetRemarksTemplate(int BrandID);
        bool ValidateRemarksTemplate(RemarksTemplate remarksTemplate);
        int AddRemarksTemplate(RemarksTemplate remarksTemplate);
        void UpdateRemarksTemplate(RemarksTemplate remarksTemplate);
        int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate);
    }
}
