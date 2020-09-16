using Pos.IService;
using POS.Entities;
using POS.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pos.Service
{
    public class CountryService : BaseService, ICountryService
    {
        public void AddCountry( Country Country)
        {
            PosService.CountryRepository.AddCountry(Country);
        }

        public void DeleteCountry(int CountryId)
        {
            PosService.CountryRepository.DeleteCountry(CountryId);
        }

      




        public Country GetCountryById(int CountryId)
        {
            return PosService.CountryRepository.GetCountryById(CountryId);
        }
        public List<Country> GetCountry()
        {
            return PosService.CountryRepository.GetCountry();
        }



        public void UpdateCountry(Country Country)
        {
            PosService.CountryRepository.UpdateCountry(Country);
        }

        public bool ValidateCountry(Country Country)
        {
            return PosService.CountryRepository.ValidateCountry(Country);
        }

    }
}
