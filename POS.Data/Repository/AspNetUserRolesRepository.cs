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
  //  public class AspNetUserRolesRepository : Repository<AspNetUserRoles>, IAspNetUserRolesRepository
  //  {

  //      public AspNetUserRolesRepository(IDatabaseFactory databaseFactory)
  //: base(databaseFactory)
  //      {

  //      }
  //      public void AddAspNetUserRoles(AspNetUserRoles AspNetUserRoles)
  //      {
  //          try
  //          {
  //              Add(AspNetUserRoles);
  //              PosDbContext.SaveChanges();
  //          }
  //          catch (Exception ex)
  //          {
  //              throw new AppException(ex.Message);
  //          }
  //      }

  //      public void DeleteAspNetUserRoles(int AspNetUserRolesId)
  //      {
  //          try
  //          {
  //              Delete(AspNetUserRolesId);
  //              PosDbContext.SaveChanges();
  //          }
  //          catch (Exception ex)
  //          {
  //              throw new AppException(ex.Message);
  //          }
  //      }

  //      public List<AspNetUserRoles> GetAspNetUserRoles()
  //      {

  //          return base.GetAll().ToList();
  //      }

   
  //      public List<AspNetUserRoles> GetAspNetUserRoles(Expression<Func<AspNetUserRoles, bool>> where)
  //      {
  //          try
  //          {
  //              var QueryCity = base.Table().Where(where).Include(e => e.User).ToList();
                    
  //              base.DbContext.Dispose();
  //              base.DbContext = null;
  //              return QueryCity;
  //          }
  //          catch (Exception ex)
  //          {
  //              throw new AppException(ex.Message);
  //          }
  //      }

  //      public AspNetUserRoles GetAspNetUserRoles(int AspNetUserRolesId)
  //      {
  //          try
  //          {
  //              return base.GetById(AspNetUserRolesId);

  //          }
  //          catch (Exception ex)
  //          {
  //              throw new AppException(ex.Message);
  //          }
  //      }

       

  //      public void UpdateAspNetUserRoles(AspNetUserRoles AspNetUserRoles)
  //      {
  //          try
  //          {
  //              Update(AspNetUserRoles);
  //              PosDbContext.SaveChanges();
  //          }
  //          catch (Exception ex)
  //          {
  //              throw new AppException(ex.Message);
  //          };
  //      }

      
  //  }

}
