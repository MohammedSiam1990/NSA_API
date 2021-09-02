using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface ISupplierService
    {
        void SaveSupplier(Supplier model);
        string GetSupplier(int CompanyID);
        int ValidateNameAlreadyExist(Supplier model);
    }
}
