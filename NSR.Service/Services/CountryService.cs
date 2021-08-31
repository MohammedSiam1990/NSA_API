using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;

namespace NSR.Service.Services
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
