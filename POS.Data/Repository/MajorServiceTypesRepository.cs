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
    public class MajorServiceTypesRepository : Repository<MajorServiceTypes>, IMajorServiceTypesRepository
    {
        public MajorServiceTypesRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
  
        public List<MajorServiceTypes> GetMajorServiceTypes(int ServiceId)
        {
            try
            {
                var MajorServiceTypes = base.Table()
                   .Where(e => e.MajorServiceId == ServiceId && e.StatusId!=3)
                   .Include(e => e.MajorService).ToList();
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
                var MajorServiceTypes = base.Table().Where(e => e.StatusId != 3).ToList(); 
                base.DbContext.Dispose();
                base.DbContext = null;
                return MajorServiceTypes;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
   
        public void AddMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            try
            {
                //MajorServiceTypes.CreationDate = DateTime.Now;
                AddRange(MajorServiceTypes);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void UpdateMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {

            try
            {
                UpdateRange(MajorServiceTypes);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public int SaveMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            
                List<MajorServiceTypes> AddedServiceTypes = MajorServiceTypes.Where(e => e.MajorServiceTypeId == 0).ToList();
                List<MajorServiceTypes> UpdatedServiceTypes = MajorServiceTypes.Where(e => e.MajorServiceTypeId > 0).ToList();

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

        public void DeleteMajorServiceTypes(int MajorServiceId)
        {
            try
            {
                var MajorServiceTypes = GetMajorServiceTypes(MajorServiceId);
                DeleteRange(MajorServiceTypes);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
