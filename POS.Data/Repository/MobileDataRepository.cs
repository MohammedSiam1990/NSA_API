using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class MobileDataRepository : Repository<GetMobileData>, IMobileDataRepository
    {

        public MobileDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL,string ItemImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    
                    string Sql = "EXEC Get_all_data_json @CompanyID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL,@ItemImageURL";
                    DbContext.Database.SetCommandTimeout(0);
                     var data = DbContext.GetMobileData.FromSqlRaw(Sql,
                        new SqlParameter("@CompanyID", CompanyID),
                        new SqlParameter("@BrandImageURL", BrandImageURL),
                        new SqlParameter("@BranchImageURL", BranchImageURL),
                        new SqlParameter("@ItemGroupImageURL", ItemGroupImageURL),
                        new SqlParameter("@ItemImageURL", ItemImageURL)).AsEnumerable().FirstOrDefault().Data;

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
