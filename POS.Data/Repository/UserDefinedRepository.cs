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

        public void SaveUserDefined(UserDefinedObjects model)
        {
            try
            {
                if (model.UserDefinedObjectsID == 0)
                {
                    model.CreateDate = DateTime.Now;
                    Add(model);
                }
                else
                {
                    model.LastModifyDate= DateTime.Now;
                    Update(model);
                }
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
