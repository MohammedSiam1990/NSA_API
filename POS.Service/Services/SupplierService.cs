using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        public string GetSupplier(int CompanyID)
        {
            return PosService.SupplierRepository.GetSupplier(CompanyID);
        }

        public void SaveSupplier(Supplier model)
        {
            PosService.SupplierRepository.SaveSupplier(model);
        }

        public int ValidateNameAlreadyExist(Supplier model)
        {
            return PosService.SupplierRepository.ValidateNameAlreadyExist(model);
        }
    }
}
