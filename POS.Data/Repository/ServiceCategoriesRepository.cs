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
    public class MajorServiceTypesRepository : Repository<MajorServiceTypes>, IMajorServiceTypesRepository
    {

        public MajorServiceTypesRepository(IDatabaseFactory databaseFactory)
  : base(databaseFactory)
        {

        }
        public void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            try
            {
                Add(MajorServiceTypes);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteMajorServiceTypes(int MajorServiceTypesId)
        {
            try
            {
                Delete(MajorServiceTypesId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {

            return base.GetAll().ToList();
        }

   
        public List<MajorServiceTypes> GetMajorServiceTypesByMajorService(Expression<Func<MajorServiceTypes, bool>> where)
        {
            try
            {
                var QueryCity = base.Table().Where(where).Include(e => e.MajorService).ToList();

                    
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryCity;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public MajorServiceTypes GetMajorServiceTypes(int MajorServiceTypesId)
        {
            try
            {
                return base.GetById(MajorServiceTypesId);

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            try
            {
                if (MajorServiceTypes.MajorServiceTypeId == 0)
                    Add(MajorServiceTypes);
                else
                    Update(MajorServiceTypes);

                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            try
            {
                Update(MajorServiceTypes);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            };
        }

        public bool ValidateMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            try
            {
                if (MajorServiceTypes.TypeName != "" && MajorServiceTypes.TypeNameAr != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }

}
