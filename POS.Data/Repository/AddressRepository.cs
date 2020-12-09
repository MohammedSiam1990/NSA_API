using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;

namespace POS.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void AddAddress(Address address)
        {
            Add(address);
            PosDbContext.SaveChanges();

        }

        public void UpdateAddress(Address address)
        {
            Update(address);
        }
    }
}
