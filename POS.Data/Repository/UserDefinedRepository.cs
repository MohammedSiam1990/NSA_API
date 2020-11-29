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
    public class UserDefinedRepository : Repository<UserDefinedObjects>, IUserDefinedRepository
    {
        public UserDefinedRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        [Obsolete]
        public string GetUserDefined(int? CompanyID, int? TypeID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetUserDefinedObjects @CompanyID,@TypeID";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID),
                         new SqlParameter("@TypeID", TypeID)).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }

        [Obsolete]
        public int SaveUserDefined(UserDefinedObjects model)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC SaveUserDefinedObjects @UserDefinedObjectsID,@TypeID,@JsonValues" +
                        ",@StatusID,@CompanyID,@BrandID,@InsertedBy,@ModifiedBy";

                    int result = DbContext.ReturnResult.FromSqlRaw(Sql, new object[] {
                                                new SqlParameter("@UserDefinedObjectsID", model.UserDefinedObjectsID),
                                                new SqlParameter("@TypeID"  ,model.TypeID ?? (object)DBNull.Value),
                                                new SqlParameter("@JsonValues" , model.JsonValues ?? (object)DBNull.Value),
                                                new SqlParameter("@StatusID" , model.StatusID ?? (object)DBNull.Value),
                                                new SqlParameter("@CompanyID" , model.CompanyID ?? (object)DBNull.Value),
                                                new SqlParameter("@BrandID" , model.BrandID ?? (object)DBNull.Value),
                                                new SqlParameter("@InsertedBy" , model.InsertedBy ?? (object)DBNull.Value),
                                                new SqlParameter("@ModifiedBy"  , model.ModifiedBy ?? (object)DBNull.Value), //  User.Identity.GetUserId(),
                                            }).AsEnumerable().FirstOrDefault().ReturnValue;
                    return result;
                }

                catch (Exception e)
                {
                    Exceptions.ExceptionError.SaveException(e);
                }
                return -1;
            }

        }
    }
}
