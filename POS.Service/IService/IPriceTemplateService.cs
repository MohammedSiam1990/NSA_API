using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface IPriceTemplateService
    {
        void SavePriceTemplate(PriceTemplate model);
        int ValidateNameAlreadyExist(PriceTemplate model);
        string GetPriceTemlate(int BrandID);

    }
}
