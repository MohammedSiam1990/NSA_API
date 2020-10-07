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
    public class ItemDataRepository : Repository<JsonData>, IItemDataRepository
    {
        public ItemDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetProcItemData(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetItems @BrandID,@ImageURL";
                    var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                        new SqlParameter("@ImageURL", ImageURL ?? (object)DBNull.Value)).AsEnumerable().FirstOrDefault().Data;

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
