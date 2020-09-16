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
  public  interface ICountryService
    {
   

        Country GetCountryById(int CountryId);
        List<Country> GetCountry();

        bool ValidateCountry(Country Country);
        void AddCountry(Country Country);
        void UpdateCountry(Country Country);
        void DeleteCountry(int CountryId);
    }
}
