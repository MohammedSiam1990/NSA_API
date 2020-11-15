using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface ICustomerRepository
    {        
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        int ValidateCustomerAlreadyExist(Customer customer);
        string GetCustomer(int CustomerID);
    }
}
