using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class MobileDataRepository : Repository<JsonData>, IMobileDataRepository
    {

        public MobileDataRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public int CheckSerialNumber(int CompanyID, string Serial)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC CheckSerialNumber @CompanyID , @Serial";
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                       new object[] {
                                      new SqlParameter("@CompanyID", CompanyID ),
                                      new SqlParameter("@Serial", Serial )}).AsEnumerable().FirstOrDefault().ReturnValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return -1;
            }

        }

        [Obsolete]
        public string GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL, string ItemImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {

                    string Sql = "EXEC Get_all_data_json @CompanyID,@BrandImageURL,@BranchImageURL,@ItemGroupImageURL,@ItemImageURL";
                    DbContext.Database.SetCommandTimeout(0);
                    var data = DbContext.JsonData.FromSqlRaw(Sql,
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

        [Obsolete]
        public int UpdateSerialNumber(int CompanyID, string Serial, string Mac)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC UpdateSerialNumber @CompanyID , @Serial,@Mac";
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                       new object[] {
                                      new SqlParameter("@CompanyID", CompanyID ),
                                      new SqlParameter("@Mac", Mac ),
                                      new SqlParameter("@Serial", Serial )}).AsEnumerable().FirstOrDefault().ReturnValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return -1;
            }
        }
    }
}
