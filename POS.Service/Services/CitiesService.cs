using Pos.IService;
using POS.Entities;
using POS.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pos.Service
{
    public class CityService : BaseService, ICityService
    {
        public void AddCity(City City)
        {
            PosService.CityRepository.AddCity(City);
        }

        public void DeleteCity(int CityId)
        {
            PosService.CityRepository.DeleteCity(CityId);
        }




        public List<City> GetCity(int CountryId)
        {
            return PosService.CityRepository.GetCity(e => e.CityCountryId == CountryId);
        }

        public City GetCityById(int CityId)
        {
            return PosService.CityRepository.GetCityById(CityId);
        }
        public List<City> GetCity()
        {
            return PosService.CityRepository.GetCity();
        }



        public void UpdateCity(City City)
        {
            PosService.CityRepository.UpdateCity(City);
        }

        public bool ValidateCity(City City)
        {
            return PosService.CityRepository.ValidateCity(City);
        }

    }
}
