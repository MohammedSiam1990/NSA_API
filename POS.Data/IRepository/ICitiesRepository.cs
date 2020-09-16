using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface ICityRepository
    {
        City GetCityById(int CityId);
        List<City> GetCity(); 
        bool ValidateCity(City City);

        void AddCity(City City);
        void UpdateCity(City City);
        void DeleteCity(int CityId);
        List<City> GetCity(Expression<Func<City, bool>> where);
    }
}
