using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;

namespace NSR.Data.Repository
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
