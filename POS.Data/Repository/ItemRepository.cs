
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class ItemRepository : Repository<Items>, IItemRepository
    {
        public ItemRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public int SaveProcItem(Item Items)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC SaveItems @ItemID,@ItemName,@ItemNameAr,@StatusID,@MajorServiceID,@CountryID,@CityID,@CurrencyID,@InsertedBy,@ModifiedBy,@TaxNo,@ImageName,@companyID,@IsDefault";

                    int result = DbContext.ReturnResult.FromSqlRaw(Sql, new object[] {
                                                new SqlParameter("@ItemID", Items.ItemId),
                                                new SqlParameter("@ItemName"  ,Items.ItemName),
                                                new SqlParameter("@ItemNameAr" , Items.ItemNameAr),
                                                new SqlParameter("@StatusId" , Items.StatusId ?? (object)DBNull.Value),
                                                new SqlParameter("@MajorServiceId" , Items.MajorServiceId),
                                                new SqlParameter("@CountryId" , Items.CountryId ?? (object)DBNull.Value),
                                                new SqlParameter("@CityId" , Items.CityId ?? (object)DBNull.Value),
                                                new SqlParameter("@CurrencyId" , Items.CurrencyId ?? (object)DBNull.Value),
                                                new SqlParameter("@InsertedBy"  , Items.InsertedBy ?? (object)DBNull.Value), //  User.Identity.GetUserId(),
                                                new SqlParameter("@ModifiedBy"  , Items.ModifiedBy ?? (object)DBNull.Value), //  User.Identity.GetUserId(),
                                                new SqlParameter("@TaxNo"   , Items.TaxNo ?? (object)DBNull.Value),
                                                new SqlParameter("@ImageName"    , Items.ImageName ?? (object)DBNull.Value),
                                                new SqlParameter("@CompanyId"  , Items.CompanyId ?? (object)DBNull.Value),
                                                new SqlParameter("@IsDefault"   , Items.IsDefault ?? (object)DBNull.Value)
                                            }).AsEnumerable().FirstOrDefault().ReturnValue;

                    return result;
                }

                catch (Exception e)
                {
                    Exceptions.ExceptionError.SaveException(e);
                }
                return -1;
            }
        }

        [Obsolete]
        public List<GetItems> GetProcItem(int CompanyID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetItems @CompanyID,@ImageURL";
                    return DbContext.GetItems.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID),
                                                       new SqlParameter("@ImageURL", ImageURL)).ToList();
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
