using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            PosService.CustomerRepository.AddCustomer(customer);
        }

        public string GetAddress(int CustomerID)
        {
            return PosService.CustomerRepository.GetAddress(CustomerID);
        }

        public string GetCustomer(int CompanyID)
        {
            return PosService.CustomerRepository.GetCustomer(CompanyID);
        }

        public void UpdateCustomer(Customer customer)
        {
            PosService.CustomerRepository.UpdateCustomer(customer);
        }

        public int ValidateCustomerAlreadyExist(Customer customer)
        {
            return PosService.CustomerRepository.ValidateCustomerAlreadyExist(customer);
        }
    }
}
