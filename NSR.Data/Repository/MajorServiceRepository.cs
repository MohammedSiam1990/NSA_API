using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class MajorServiceRepository : Repository<MajorServices>, IMajorServiceRepository
    {
        public MajorServiceRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public MajorServices GetMajorService(int ServiceId)
        {
            var MajorServices = base.Table()
               .Where(e => e.ServiceId == ServiceId).FirstOrDefault();
            MajorServices.MajorServiceTypes = DbContext.MajorServiceTypes.
            Where(e => e.MajorServiceId == ServiceId && e.StatusId != 3).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return MajorServices;
        }

        public List<MajorServices> GetMajorServices()
        {
            var MajorServices = base.Table().ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return MajorServices;
        }

        public void AddMajorServices(MajorServices MajorServices)
        {
            MajorServices.CreationDate = DateTime.Now;
            Add(MajorServices);
        }
        public void UpdateMajorServices(MajorServices MajorServices)
        {
            Update(MajorServices);
        }
        public void SaveMajorServices(MajorServices MajorServices)
        {
            if (MajorServices.ServiceId == 0)
                Add(MajorServices);
            else
                Update(MajorServices);

            PosDbContext.SaveChanges();
        }
        public void DeleteMajorServices(int MajorServicesId)
        {

            Delete(MajorServicesId);
            PosDbContext.SaveChanges();
        }
    }
}
