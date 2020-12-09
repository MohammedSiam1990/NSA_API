using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class CountryService : BaseService, ICountryService
    {
        public CountryService()
        {

        }
        public Country GetCountry(int ServiceId)
        {
            return PosService.CountryRepository.GetCountry(ServiceId);
        }

        public List<Country> GetCountries()
        {
            return PosService.CountryRepository.GetCountries();
        }


    }
}
