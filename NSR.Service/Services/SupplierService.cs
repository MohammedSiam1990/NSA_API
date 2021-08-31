using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
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
