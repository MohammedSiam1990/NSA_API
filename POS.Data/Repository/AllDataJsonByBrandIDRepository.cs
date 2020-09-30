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
    public class AllDataJsonByBrandIDRepository : Repository<GetAllDataJsonByBrandID>, IAllDataJsonByBrandIDRepository
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
                try
                {
                    string Sql = "EXEC Get_all_data_json_by_brandID @BrandID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL";
                    var data = DbContext.GetAllDataJsonByBrandID.FromSqlRaw(Sql,
                        new SqlParameter("@BrandID", BrandID),
                        new SqlParameter("@BrandImageURL", BrandImageURL),
                        new SqlParameter("@BranchImageURL", BranchImageURL),
                        new SqlParameter("@ItemGroupImageURL", ItemGroupImageURL)).AsEnumerable().FirstOrDefault().Data;

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
