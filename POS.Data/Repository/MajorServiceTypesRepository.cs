using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class MajorServiceTypesRepository : Repository<MajorServiceTypes>, IMajorServiceTypesRepository
    {
        public MajorServiceTypesRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
  
        public MajorServiceTypes GetMajorServiceTypes(int ServiceId)
        {
            try
            {
                var MajorServiceTypes = base.Table()
                   .Where(e => e.MajorServiceId == ServiceId && e.StatusId!=3)
                   .Include(e => e.MajorService).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return MajorServiceTypes;

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {
            try
            {
                var MajorServiceTypes = base.Table().Include(e => e.StatusId!=3).ToList(); 
                base.DbContext.Dispose();
                base.DbContext = null;
                return MajorServiceTypes;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            try
            {
                //MajorServiceTypes.CreationDate = DateTime.Now;
                Add(MajorServiceTypes);
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
    }
}
