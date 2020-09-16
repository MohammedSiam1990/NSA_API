using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface ICountryRepository
    {
        Country GetCountryById(int CountryId);
        List<Country> GetCountry(); 
        bool ValidateCountry(Country Country);

        void AddCountry(Country Country);
        void UpdateCountry(Country Country);
        void DeleteCountry(int CountryId);

    }
}