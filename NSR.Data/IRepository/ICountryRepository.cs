
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NSR.Data.IRepository
{
    public interface ICountryRepository
    {
        Country GetCountry(int CountryId);
        List<Country> GetCountries();

    }
}