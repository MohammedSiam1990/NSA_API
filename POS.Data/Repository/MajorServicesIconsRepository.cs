using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class MajorServicesIconsRepository : Repository<MajorServicesIcons>, IMajorServicesIconsRepository
    {
        public MajorServicesIconsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            try
            {
               // MajorServicesIcons.CreationDate = DateTime.Now;
                Add(MajorServicesIcons);
           
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {

            try
            {
               // MajorServicesIcons.ModificationDate = DateTime.Now;
                Update(MajorServicesIcons);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            try
            {
                if (MajorServicesIcons.IconId == 0)
                    Add(MajorServicesIcons);
                else
                    Update(MajorServicesIcons);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void DeleteMajorServicesIcons(int MajorServicesIconsId)
        {
            try
            {
                Delete(MajorServicesIconsId);
            //    PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
        public MajorServicesIcons GetMajorServicesIcons(int IconId)
        {

            try
            {
                return base.GetById(IconId);

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }



     

    [Obsolete]
    public string GetMajorServicesByIcons(int? ServiceId)
    {
      using (var DbContext = new PosDbContext())
      {
        try
        {
          string Sql = "EXEC GetMajorServicesIcons @ServiceId";
          var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@ServiceId", ServiceId)).AsEnumerable().FirstOrDefault().Data;
          return data.ToString();
        }
        catch (Exception ex)
        {
          Exceptions.ExceptionError.SaveException(ex);
        }
        return null;

      }
    }
  }
}
