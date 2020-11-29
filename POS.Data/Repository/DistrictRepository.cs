using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
      try
      {

        Add(district);
        PosDbContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public void DeleteDistrict(int DistrictId)
    {
      try
      {
        Delete(DistrictId);
        PosDbContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public District GetDistrict(int DistrictId)
    {
      try
      {
        var QueryDistrict = base.Table().Include(e => e.City).ThenInclude(c=>c.Country)
          .Where(e => e.DistrictId == DistrictId).FirstOrDefault();
        base.DbContext.Dispose();
        base.DbContext = null;
        return QueryDistrict;
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public List<District> GetDistricts()
    {
      try
      {
        var ItemDistrict = base.Table().Include(e => e.City).ToList();
        base.DbContext.Dispose();
        base.DbContext = null;
        return ItemDistrict;
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }
    public List<District> GetDistricts(int CityId)
    {
      try
      {
        var ItemDistrict = base.Table().Where(e=>e.CityId==CityId).Include(e => e.City).ToList();
        base.DbContext.Dispose();
        base.DbContext = null;
        return ItemDistrict;
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }
    public List<District> GetDistricts(Expression<Func<District, bool>> where)
    {
      try
      {
        return base.GetMany(where).ToList();

      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public void SaveDistrict(District district)
    {
      throw new NotImplementedException();
    }

    public void UpdateDistrict(District district)
    {
      try
      {
        Update(district);
        PosDbContext.SaveChanges();
      }
      catch (Exception ex)
      {
        throw new AppException(ex.Message);
      }
    }

    public District ValidateAlreadyExist(District model)
    {
      return GetById(e => e.DistrictId != model.DistrictId && e.CityId == model.CityId  && (e.DistrictName == model.DistrictName || e.DistrictNameAr == model.DistrictNameAr));

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
