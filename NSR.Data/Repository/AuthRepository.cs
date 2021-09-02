using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Dto.Procedure;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Linq;

namespace NSR.Data.Repository
{
    public class AuthRepository : Repository<JsonData>, IAuthRepository
    {
        public AuthRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetAllUsersAsync(int UserType, int? CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetUsers @CompanyID,@UserType";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID ?? (object)DBNull.Value),
                                                             new SqlParameter("@UserType", UserType)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }
    }
}
