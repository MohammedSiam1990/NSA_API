using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface ICityService
    {
        City GetCity(int CityId);
        List<City> GetCities();
        List<City> GetCities(int CountryId);
        void AddCity(City City);
        void UpdateCity(City City);
        int SaveCity(City City);
        void DeleteCity(int CityId);
        City ValidateAlreadyExist(City model);
    }
}
