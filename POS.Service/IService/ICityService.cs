﻿using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ICityService
    {
        City GetCity(int CityId);
        List<City> GetCities(int CountryId);
        void AddCity(City City);
        void UpdateCity(City City);
        int SaveCity(City City);
        void DeleteCity(int CityId);
        City ValidateAlreadyExist(City model);
    }
}
