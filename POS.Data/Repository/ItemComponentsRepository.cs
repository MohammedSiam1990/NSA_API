using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class ItemComponentsRepository : Repository<ItemComponents>, IItemComponentsRepository
    {

        public ItemComponentsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var ItemComponent = GetMany(e => e.MainItemID == MainItemID && e.MainItemUOMID == MainItemUOMID).ToList();
                    base.DeleteRange(ItemComponent);
                    base.AddRange(model);
                    context.SaveChanges();
                    transaction.Commit();
                }
            }


        }
    }
}
