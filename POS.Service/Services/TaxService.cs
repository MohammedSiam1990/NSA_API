using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
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
