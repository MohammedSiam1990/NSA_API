using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Account;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class LookUpRepository : Repository<Lookups>, IlookUpRepository
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

                string Sql = "EXEC Get_Json_Lookups @langID";
                var data= DbContext.GetLookups.FromSqlRaw(Sql, new SqlParameter("@langID", Lang)).AsEnumerable().FirstOrDefault().LookupsData;

                return data.ToString();
            }

        }
    }
}
