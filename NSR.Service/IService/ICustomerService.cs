using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        int ValidateCustomerAlreadyExist(Customer customer);
        string GetCustomer(int CompanyID);
        string GetAddress(int CustomerID);

    }
}
