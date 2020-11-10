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
                return base.GetById(ServiceId);

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<MajorServices> GetMajorServices()
        {
            return base.GetAll().ToList();
        }

 
    }
}
