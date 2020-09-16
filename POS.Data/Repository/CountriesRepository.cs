
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddCountry(Country Country)
        {
            try
            {

                Add(Country);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateCountry(Country Country)
        {
            try
            {
                Update(Country);
                // PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteCountry(int CountryId)
        {
            try
            {
                Delete(CountryId);
                // PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }



        public bool ValidateCountry(Country Country)
        {
            try
            {
                if (Country.CountryName != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }



        public List<Country> GetCountry()
        {
            try
            {
               return  base.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }


        public Country GetCountryById(int CountryId)
        {

            try
            {
                return base.GetById(CountryId);

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
