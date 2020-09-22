using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto;

using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class MobileDataRepository : Repository<GetMobileData>, IMobileDataRepository
    {

        public MobileDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public List<GetMobileData> GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC Get_all_data_json @CompanyID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL";
                var data = DbContext.GetMobileData.FromSqlRaw(Sql,
                    new SqlParameter("@CompanyID", CompanyID),
                    new SqlParameter("@BrandImageURL", BrandImageURL),
                    new SqlParameter("@BranchImageURL", BranchImageURL),
                    new SqlParameter("@ItemGroupImageURL", ItemGroupImageURL)).ToList();

                return data;
            }
        }
    }
}
