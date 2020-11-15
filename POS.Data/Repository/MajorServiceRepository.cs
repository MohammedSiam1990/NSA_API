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
    public class MajorServiceRepository : Repository<MajorServices>, IMajorServiceRepository
    {
        public MajorServiceRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
  
        public MajorServices GetMajorService(int ServiceId)
        {
            try
            {
                var MajorServices = base.Table()
                   .Where(e => e.ServiceId == ServiceId).FirstOrDefault();
                MajorServices.MajorServiceTypes = DbContext.MajorServiceTypes.Where(e => e.MajorServiceId==ServiceId  && e.StatusId != 3).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return MajorServices;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<MajorServices> GetMajorServices()
        {
            try
            {
                var MajorServices = base.Table().ToList(); 
                base.DbContext.Dispose();
                base.DbContext = null;
                return MajorServices;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void AddMajorServices(MajorServices MajorServices)
        {
            try
            {
                MajorServices.CreationDate = DateTime.Now;
                Add(MajorServices);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void UpdateMajorServices(MajorServices MajorServices)
        {

            try
            {
                Update(MajorServices);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void SaveMajorServices(MajorServices MajorServices)
        {
            try
            {
                if (MajorServices.ServiceId == 0)
                    Add(MajorServices);
                else
                    Update(MajorServices);

                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void DeleteMajorServices(int MajorServicesId)
        {
            try
            {
                Delete(MajorServicesId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
