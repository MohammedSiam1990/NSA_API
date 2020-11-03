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
