using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface ICountryService
    {
        Country GetCountry(int ServiceId);
        List<Country> GetCountries();
    }
}
