using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory)
       : base(databaseFactory)
        {

        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                Add(customer);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        [Obsolete]
        public string GetAddress(int CustomerID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetAddress @CustomerID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CustomerID", CustomerID)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        [Obsolete]
        public string GetCustomer(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetCustomers @CompanyID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                customer.LastModifyDate = DateTime.Now;
                Update(customer);
                // PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public int ValidateCustomerAlreadyExist(Customer customer)
        {
            var CustomerModel = new Customer();

            CustomerModel = GetById(e => e.CustomerID != customer.CustomerID && (e.CustomerNum == customer.CustomerNum || e.Mobile == customer.Mobile));
            if(CustomerModel==null) return 1;
            if (CustomerModel.CustomerNum == customer.CustomerNum)
                return -2;
            else if (CustomerModel.Mobile == customer.Mobile)
                return -3;

            return 1;
        }
    }
}
