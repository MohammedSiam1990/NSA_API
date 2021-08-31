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
    public class ItemDataRepository : Repository<JsonData>, IItemDataRepository
    {
        public ItemDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetProcActiveItemData(int BrandID, string ImageURL, string Lang)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetActiveItems @BrandID,@ImageURL,@lang";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                    new SqlParameter("@ImageURL", ImageURL ?? (object)DBNull.Value)
                    , new SqlParameter("@lang", Lang ?? (object)DBNull.Value)).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        [Obsolete]
        public string GetProcItemData(int BrandID, string ImageURL, string Lang)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetItems @BrandID,@ImageURL,@lang";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                    new SqlParameter("@ImageURL", ImageURL ?? (object)DBNull.Value)
                    , new SqlParameter("@lang", Lang ?? (object)DBNull.Value)).AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }

        }
    }
}
