using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class SalesGroupsItemsRepository : Repository<SalesGroupsItems>, ISalesGroupsItemsRepository
    {
        public SalesGroupsItemsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }


        public void SaveSalesGroupsItems(List<SalesGroupsItems> model, int SalesGroupID)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var SalesGroupItems = GetMany(e => e.SalesGroupID == SalesGroupID).ToList();
                    base.DeleteRange(SalesGroupItems);
                    base.AddRange(model);
                    context.SaveChanges();
                    transaction.Commit();
                }
            }
        }
    }
}
