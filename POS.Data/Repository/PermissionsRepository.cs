using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class PermissionsRepository : Repository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetPermissionsLookUps(int MenuType,int RoldID, int? BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetPermissionsLookups @MenuType,@RoldID,@BrandID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@RoldID", RoldID),
                    new SqlParameter("@MenuType", MenuType), new SqlParameter("@BrandID", BrandID ?? (object)DBNull.Value))
                    .AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        public void SavePermissions(List<Permissions> model,int RoleID)
        {
            var Permission = GetMany(e => e.RoleID == RoleID).ToList();
            DeleteRange(Permission);
            AddRange(model);
        }
    }
}
