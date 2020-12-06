using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System.Collections.Generic;
using System.Linq;

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
            var MajorServiceTypes = base.Table()
               .Where(e => e.MajorServiceId == ServiceId && e.StatusId != 3)
               .Include(e => e.MajorService).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return MajorServiceTypes;
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {
            var MajorServiceTypes = base.Table().Include(e => e.MajorService).Where(e => e.StatusId != 3).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return MajorServiceTypes;
        }

        public void AddMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            AddRange(MajorServiceTypes);
        }
        public void UpdateMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            UpdateRange(MajorServiceTypes);
        }
        public int SaveMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {

            List<MajorServiceTypes> AddedServiceTypes = MajorServiceTypes.Where(e => e.MajorServiceTypeId == 0).ToList();
            List<MajorServiceTypes> UpdatedServiceTypes = MajorServiceTypes.Where(e => e.MajorServiceTypeId > 0).ToList();

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (AddedServiceTypes.Count == 0) context.AddRange(AddedServiceTypes);
                    if (UpdatedServiceTypes.Count > 0) context.UpdateRange(UpdatedServiceTypes);
                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }

            }
        }

        public void DeleteMajorServiceTypes(int MajorServiceId)
        {
            var MajorServiceTypes = GetMajorServiceTypes(MajorServiceId);
            DeleteRange(MajorServiceTypes);

        }

        public MajorServiceTypes ValidateAlreadyExist(MajorServiceTypes model)
        {
            return GetById(e => e.MajorServiceTypeId != model.MajorServiceTypeId && (e.TypeName == model.TypeName || e.TypeNameAr == model.TypeNameAr) && e.StatusId != 3);
        }
    }
}
