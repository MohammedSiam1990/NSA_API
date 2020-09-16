
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
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddCity(City City)
        {
            try
            {

                Add(City);
                //  PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateCity(City City)
        {
            try
            {
                Update(City);
                // PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteCity(int CityId)
        {
            try
            {
                Delete(CityId);
                // PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }



        public bool ValidateCity(City City)
        {
            try
            {
                if (City.CityName != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<City> GetCity(Expression<Func<City, bool>> where)
        {
            try
            {
                var QueryCity = base.Table().Where(where).Include(e => e.CityCountry).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryCity;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<City> GetCity()
        {
            return base.GetAll().ToList();
        }


        public City GetCityById(int CityId)
        {

            try
            {
                return base.GetById(CityId);

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
