using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface ICustomerRepository
    {        
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        int ValidateCustomerAlreadyExist(Customer customer);
        string GetCustomer(int CustomerID);
        string GetAddress(int CustomerID);

    }
}
