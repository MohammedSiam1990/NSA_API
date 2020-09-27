using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class BranchServicesRepository : Repository<GetBranchServices>, IBranchServicesRepository
    {
        public BranchServicesRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public List<GetBranchServices> GetProcBranchServices(int BranchID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetBranchServices @BranchID";
                    return DbContext.GetBranchServices.FromSql(Sql, new SqlParameter("@BranchID", BranchID)).ToList();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        [Obsolete]
        public int SaveBranchServices(int BranchID, string ServiceTypeID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC SaveBranchServices @BranchID , @ServiceTypeID ";
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                       new object[] {
                                      new SqlParameter("@BranchID", BranchID ),
                                      new SqlParameter("@ServiceTypeID", ServiceTypeID )   ,
                                       }).AsEnumerable().FirstOrDefault().ReturnValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return -1;
            }

        }
    }
}
