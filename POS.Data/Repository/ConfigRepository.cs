using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        public ConfigRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetConfig(int? BranchID, int? BrandID, int TypeID)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC Get_Config @BranchID,@BrandID,@TypeID";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@BranchID", BranchID ?? (object)DBNull.Value),
                                                   new SqlParameter("@BrandID", BrandID),
                                                   new SqlParameter("@TypeID", TypeID)
                                                   ).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();

            }

        }

        public int SaveConfig(List<Config> Added, List<Config> Updated)
        {

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (Updated.Count > 0) context.UpdateRange(Updated);
                    if (Added.Count > 0) context.AddRange(Added);
                    context.SaveChanges();
                    transaction.Commit();
                    return 1;
                }
            }

        }
    }
}
