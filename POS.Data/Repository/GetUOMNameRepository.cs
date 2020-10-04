using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class GetUOMNameRepository : Repository<GetUOMName>, IGetUOMNameRepository
    {
        public GetUOMNameRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetUOMName(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC Get_UOM_Name @BrandID";
                    DbContext.Database.SetCommandTimeout(0);
                    var data = DbContext.GetUOMName.FromSqlRaw(Sql,
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
    }
}
