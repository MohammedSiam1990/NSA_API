﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Linq;

namespace POS.Data.Repository
{
    public class LookUpRepository : Repository<JsonData>, IlookUpRepository
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
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@langID", Lang)).
                    AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }

        }
    }
}
