using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
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
    public class ConfigRepository : Repository<Config>, IConfigRepository
    {
        public ConfigRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetConfig(int BranchID,int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {

                    string Sql = "EXEC Get_Config @BranchID,@BrandID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@BranchID", BranchID),
                                                       new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        public int SaveConfig(List<Config> Added, List<Config> Updated)
        {
            
                using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                     if (Updated.Count>0)context.UpdateRange(Updated);
                     if (Added.Count>0)context.AddRange(Added);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        if (ex.InnerException.Message.Contains("duplicate key"))
                        {
                            return -2;
                        }

                        throw new AppException(ex.Message);
                    }
                    return 1;
                }
            }

        }
    }
}
