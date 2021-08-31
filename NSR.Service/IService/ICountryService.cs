using NSR.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface ICountryService
    {
        Country GetCountry(int ServiceId);
        List<Country> GetCountries();
    }
}
