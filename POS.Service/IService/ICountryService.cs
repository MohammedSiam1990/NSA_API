using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ICountryService
    {
        Country GetCountry(int ServiceId);
        List<Country> GetCountries();
    }
}
