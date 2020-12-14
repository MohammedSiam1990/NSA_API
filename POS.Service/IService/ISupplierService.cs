using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface ISupplierService
    {
        void SaveSupplier(Supplier model);
        string GetSupplier(int CompanyID);
        int ValidateNameAlreadyExist(Supplier model);
    }
}
