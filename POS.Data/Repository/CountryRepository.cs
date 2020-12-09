using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public List<Country> GetCountries()
        {
            return base.GetMany().ToList();
        }
        public Country GetCountry(int CountryId)
        {
            return base.GetById(CountryId);
        }
    }
}
