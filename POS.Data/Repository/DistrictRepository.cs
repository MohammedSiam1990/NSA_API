using Microsoft.EntityFrameworkCore;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository(IDatabaseFactory databaseFactory)
     : base(databaseFactory)
        {

        }
        public void AddDistrict(District district)
        {
            Add(district);
        }

        public void DeleteDistrict(int DistrictId)
        {
            Delete(DistrictId);
        }

        public District GetDistrict(int DistrictId)
        {
            var QueryDistrict = base.Table().Include(e => e.City).ThenInclude(c => c.Country)
              .Where(e => e.DistrictId == DistrictId).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QueryDistrict;
        }

        public List<District> GetDistricts()
        {
            var ItemDistrict = base.Table().Include(e => e.City).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return ItemDistrict;
        }
        public List<District> GetDistricts(int CityId)
        {
            var ItemDistrict = base.Table().Where(e => e.CityId == CityId).Include(e => e.City).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return ItemDistrict;
        }
        public List<District> GetDistricts(Expression<Func<District, bool>> where)
        {
            return base.GetMany(where).ToList();
        }

        public void SaveDistrict(District district)
        {
            throw new NotImplementedException();
        }

        public void UpdateDistrict(District district)
        {
            Update(district);
        }

        public District ValidateAlreadyExist(District model)
        {
            return GetById(e => e.DistrictId != model.DistrictId && e.CityId == model.CityId && (e.DistrictName == model.DistrictName || e.DistrictNameAr == model.DistrictNameAr));

        }

        public bool ValidateCodeorNameAlreadyExist(Expression<Func<District, bool>> where)
        {
            return Exists(where);
        }
        public bool ValidateCodeorNameArAlreadyExist(Expression<Func<District, bool>> where)
        {
            return Exists(where);
        }


    }
}
