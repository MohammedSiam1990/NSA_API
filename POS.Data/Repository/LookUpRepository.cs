using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Linq;

namespace POS.Data.Repository
{
    public class LookUpRepository : Repository<GetLookUp>, IlookUpRepository
    {
        public LookUpRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetProcLookUp(string Lang)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC Get_Json_Lookups @langID";
                    var data = DbContext.GetLookups.FromSqlRaw(Sql, new SqlParameter("@langID", Lang)).AsEnumerable().FirstOrDefault().LookupsData;

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
