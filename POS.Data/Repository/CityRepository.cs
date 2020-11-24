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
   
        public void AddCity(List<City> City)
        {
            try
            {
                //City.CreationDate = DateTime.Now;
                AddRange(City);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void UpdateCity(List<City> City)
        {

            try
            {
                UpdateRange(City);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public int SaveCity(List<City> City)
        {
            
                List<City> AddedServiceTypes = City.Where(e => e.CityId == 0).ToList();
                List<City> UpdatedServiceTypes = City.Where(e => e.CityId > 0).ToList();

                using (var context = new PosDbContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            if (AddedServiceTypes.Count > 0) context.AddRange(AddedServiceTypes);
                            if (UpdatedServiceTypes.Count > 0) context.UpdateRange(UpdatedServiceTypes);
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
