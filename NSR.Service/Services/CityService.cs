using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class CityService : BaseService, ICityService
    {
        public CityService()
        {

        }

        public void AddCity(City City)
        {
            PosService.CityRepository.AddCity(City);
        }

        public void DeleteCity(int CityId)
        {
            PosService.CityRepository.DeleteCity(CityId);
        }

        public List<City> GetCities()
        {
            return PosService.CityRepository.GetCities();
        }
        public List<City> GetCities(int CountryId)
        {
            return PosService.CityRepository.GetCities(CountryId);
        }
        public City GetCity(int CityId)
        {
            return PosService.CityRepository.GetCity(CityId);
        }

        public int SaveCity(City City)
        {
            return PosService.CityRepository.SaveCity(City);
        }

        public void UpdateCity(City City)
        {
            PosService.CityRepository.UpdateCity(City);
        }

        public City ValidateAlreadyExist(City model)
        {
            return PosService.CityRepository.ValidateAlreadyExist(model);
        }
    }
}
