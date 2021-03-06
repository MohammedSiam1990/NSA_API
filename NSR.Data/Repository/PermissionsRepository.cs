using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSR.Data.Repository
{
    public class PermissionsRepository : Repository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetPermissions(int MenuType,int RoldID, int? BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetPermissions @MenuType,@RoldID,@BrandID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@RoldID", RoldID),
                    new SqlParameter("@MenuType", MenuType), new SqlParameter("@BrandID", BrandID ?? (object)DBNull.Value))
                    .AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        public void SavePermissions(Permissions model,int RoleID,int MenuID)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var Permission = GetMany(e => e.RoleID == RoleID && e.MenuID == MenuID).ToList();
                    base.DeleteRange(Permission);
                    base.Add(model);
                    context.SaveChanges();
                    transaction.Commit();
                    
                }
            }

        }
    }
}
