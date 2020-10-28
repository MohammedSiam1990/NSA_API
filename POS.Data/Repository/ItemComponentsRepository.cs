using POS.API.Helpers;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class ItemComponentsRepository : Repository<ItemComponents>, IItemComponentsRepository
    {

        public ItemComponentsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void SaveItemComponents(List<ItemComponents> model)
        {
            try
            {
                long MainItemID = model.First().MainItemID;
                long MainItemUOMID = model.First().MainItemUOMID;


                DbContext.Database.BeginTransaction();
                var ItemComponent = GetMany(e => e.MainItemID == MainItemID && e.MainItemUOMID == MainItemUOMID).ToList();
                base.DeleteRange(ItemComponent);
                base.AddRange(model);
                DbContext.Database.CommitTransaction();
            }
            catch (Exception ex)
            {
                DbContext.Database.RollbackTransaction();
                throw new AppException(ex.Message);
            }

        }
    }
}
