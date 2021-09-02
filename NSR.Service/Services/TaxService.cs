using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
{
    public class TaxService : BaseService, ITaxService
    {
        public int SaveProcTax(Tax tax)
        {
            return PosService.taxRepository.SaveProcTax(tax);
        }

        public string GetProcTaxes(int CompanyID)
        {
            return PosService.taxRepository.GetProcTaxes(CompanyID);
        }
    }

}
