using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class AllDataRepository : Repository<AllData>, IAllDataRepository
    {

        public AllDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetAllData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC Get_all_data_json @CompanyID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL";
                var data = DbContext.GetAllData.FromSqlRaw(Sql,
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@BrandImageURL", BrandImageURL),
                    new SqlParameter("@BranchImageURL", BranchImageURL),
                    new SqlParameter("@ItemGroupImageURL", ItemGroupImageURL)).ToList();

                return data.ToString();
            }
        }
    }
}
