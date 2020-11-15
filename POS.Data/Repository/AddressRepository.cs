using POS.API.Helpers;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void AddAddress(Address address)
        {
            try
            {
                Add(address);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }

        public void UpdateAddress(Address address)
        {
            try
            {
                Update(address);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
