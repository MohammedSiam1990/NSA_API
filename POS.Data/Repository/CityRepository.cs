using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
  
        public List<City> GetCities(int CountryId)
        {
            try
            {
                var City = base.Table()
                   .Where(e => e.CountryId == CountryId )
                   .Include(e => e.Country).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return City;

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public City GetCity(int CityId)
        {
            try
            {
                var City = base.Table().Where(e => e.CityId == CityId)
                   .Include(e => e.Country).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return City;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
   
        public void AddCity(City City)
        {
            try
            {
                //City.CreationDate = DateTime.Now;
                Add(City);
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
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public int SaveCity(City City)
        {
            
                using (var context = new PosDbContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (City.CityId == 0) context.Add(City);
                            if (City.CityId > 0) context.Update(City);
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new AppException(ex.Message);
                        }
                        return 1;
                    }

                }
         }

        public void DeleteCity(int CityId)
        {
            try
            {
                Delete(CityId);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }

        public City ValidateAlreadyExist(City model)
        {
           return GetById(e =>   e.CityId != model.CityId && (e.CityName == model.CityName || e.CityNameAr == model.CityNameAr) );
        }
    }
}
