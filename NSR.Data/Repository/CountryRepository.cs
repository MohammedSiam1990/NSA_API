using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
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
