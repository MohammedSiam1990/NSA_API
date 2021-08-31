using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Linq;

namespace NSR.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseFactory databaseFactory)
       : base(databaseFactory)
        {

        }
        public void AddCustomer(Customer customer)
        {
            Add(customer);
        }

        [Obsolete]
        public string GetAddress(int CustomerID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetAddress @CustomerID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CustomerID", CustomerID)).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        [Obsolete]
        public string GetCustomer(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetCustomers @CompanyID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID)).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();

            }
        }

        public void UpdateCustomer(Customer customer)
        {
            customer.LastModifyDate = DateTime.Now;
            Update(customer);
        }

        public int ValidateCustomerAlreadyExist(Customer customer)
        {
            var CustomerModel = new Customer();

            CustomerModel = GetById(e => e.CustomerID != customer.CustomerID && (e.CustomerNum == customer.CustomerNum || (e.Mobile == customer.Mobile && e.CountryID == customer.CountryID)) && e.CompanyID == customer.CompanyID && e.CustTypeID == customer.CustTypeID && e.StatusID != 3);
            if (CustomerModel == null) return 1;
            if (CustomerModel.CustomerNum == customer.CustomerNum)
                return -2;
            else if (CustomerModel.Mobile == customer.Mobile && CustomerModel.CountryID == customer.CountryID)
                return -3;

            return 1;
        }
    }
}
