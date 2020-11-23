
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface ICountryRepository
    {
        Country GetCountry(int CountryId);
        List<Country> GetCountries();

    }
}