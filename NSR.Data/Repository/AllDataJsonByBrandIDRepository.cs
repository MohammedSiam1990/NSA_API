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
    public class AllDataJsonByBrandIDRepository : Repository<JsonData>, IAllDataJsonByBrandIDRepository
    {
        public AllDataJsonByBrandIDRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {

            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC Get_all_data_json_by_brandID @BrandID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL";
                var data = DbContext.JsonData.FromSqlRaw(Sql,
                    new SqlParameter("@BrandID", BrandID),
                    new SqlParameter("@BrandImageURL", BrandImageURL),
                    new SqlParameter("@BranchImageURL", BranchImageURL),
                    new SqlParameter("@ItemGroupImageURL", ItemGroupImageURL)).AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }

        }
    }
}
