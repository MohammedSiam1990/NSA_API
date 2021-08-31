using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Linq;

namespace NSR.Data.Repository
{
    public class MajorServicesIconsRepository : Repository<MajorServicesIcons>, IMajorServicesIconsRepository
    {
        public MajorServicesIconsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            MajorServicesIcons.OrderId = GetMaxOrderIdByService(MajorServicesIcons.ServiceId);
            Add(MajorServicesIcons);

        }


        public void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {

            MajorServicesIcons.OrderId = GetMaxOrderIdByService(MajorServicesIcons.ServiceId);
            Update(MajorServicesIcons);
        }
        public int GetMaxOrderIdByService(int ServiceId)
        {
            var OrderId = base.GetMany(e => e.ServiceId == ServiceId).Max(e => e.OrderId) + 1;

            return OrderId;
        }
        public void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            MajorServicesIcons.OrderId = GetMaxOrderIdByService(MajorServicesIcons.ServiceId);

            if (MajorServicesIcons.IconId == 0)

                Add(MajorServicesIcons);
            else
                Update(MajorServicesIcons);
        }
        public void DeleteMajorServicesIcons(int MajorServicesIconsId)
        {
            Delete(MajorServicesIconsId);

        }
        public MajorServicesIcons GetMajorServicesIcons(int IconId)
        {
            return base.GetById(IconId);
        }





        [Obsolete]
        public string GetMajorServicesByIcons(int? ServiceId)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetMajorServicesIcons @ServiceId";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@ServiceId", ServiceId)).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();

            }
        }
    }
}
