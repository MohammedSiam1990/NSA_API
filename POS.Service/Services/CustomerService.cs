using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        public void AddCustomer(Customer customer)
        {
            PosService.CustomerRepository.AddCustomer(customer);
        }

        public string GetCustomer(int CustomerID)
        {
            return PosService.CustomerRepository.GetCustomer(CustomerID);
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
