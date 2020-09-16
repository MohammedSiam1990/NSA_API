using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pos.IService
{
    public interface ICityService
    {


        City GetCityById(int CityId);
        List<City> GetCity();
        List<City> GetCity(int CountryId);
        bool ValidateCity(City City);
        void AddCity(City City);
        void UpdateCity(City City);
        void DeleteCity(int CityId);
    }
}
