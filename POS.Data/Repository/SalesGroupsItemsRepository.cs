using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
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
    public class SalesGroupsItemsRepository : Repository<SalesGroupsItems>, ISalesGroupsItemsRepository
    {
        public SalesGroupsItemsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetItemsSalesGroups(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetItemsSalesGroups @BrandID,@ImageURL";
                    var data = DbContext.JsonData.FromSqlRaw(Sql,
                        new SqlParameter("@BrandID", BrandID),
                        new SqlParameter("@ImageURL", ImageURL) ).AsEnumerable().FirstOrDefault().Data;

                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }

                return null;

            }
        }

        public void SaveSalesGroupsItems(List<SalesGroupsItems> model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        long SalesGroupID = model.First().SalesGroupID;

                        var SalesGroupItems = GetMany(e => e.SalesGroupID== SalesGroupID).ToList();
                        base.DeleteRange(SalesGroupItems);
                        base.AddRange(model);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new AppException(ex.Message);
                    }
                }
            }
        }
    }
}
