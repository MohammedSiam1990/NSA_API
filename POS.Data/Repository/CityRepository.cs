using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<City> GetCities()
        {
            var City = base.Table()
               .Include(e => e.Country).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return City;
        }
        public List<City> GetCities(int CountryId)
        {
            var City = base.Table()
               .Where(e => e.CountryId == CountryId)
               .Include(e => e.Country).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return City;


        }
        public City GetCity(int CityId)
        {
            var City = base.Table().Where(e => e.CityId == CityId)
               .Include(e => e.Country).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return City;
        }

        public void AddCity(City City)
        {
            City.CreateDate = DateTime.Now;
            Add(City);
        }
        public void UpdateCity(City City)
        {
            City.LastModifyDate = DateTime.Now;
            Update(City);
        }
        public int SaveCity(City City)
        {

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (City.CityId == 0) 
                    {
                        City.CreateDate = DateTime.Now;
                        context.Add(City);
                     }
                    if (City.CityId > 0)
                    {
                        City.LastModifyDate = DateTime.Now;
                        context.Update(City);
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                return 1;

            }
        }

        public void DeleteCity(int CityId)
        {
            Delete(CityId);
        }

        public City ValidateAlreadyExist(City model)
        {
            return GetById(e => e.CityId != model.CityId && e.CountryId == model.CountryId && (e.CityName == model.CityName || e.CityNameAr == model.CityNameAr));
        }
    }
}
