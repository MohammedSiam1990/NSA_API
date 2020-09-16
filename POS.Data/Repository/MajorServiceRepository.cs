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
    public class MajorServiceRepository : Repository<MajorService>, IMajorServiceRepository
    {
        public MajorServiceRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddMajorService(MajorService majorService)
        {
            try
            {
                Add(majorService);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteMajorService(int ServiceId)
        {
            try
            {
                Delete(ServiceId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public MajorService GetMajorService(int ServiceId)
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

        public List<MajorService> GetMajorServices()
        {
            return base.GetAll().ToList();
        }

        public void SaveMajorService(MajorService majorService)
        {
            try
            {
                if (majorService.ServiceId == 0)
                    Add(majorService);
                else
                    Update(majorService);

                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateMajorService(MajorService majorService)
        {
            try
            {
                Update(majorService);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            };
        }

        public bool ValidateMajorService(MajorService majorService)
        {
            try
            {
                if (majorService.ServiceName != "" && majorService.ServiceName != "")
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
