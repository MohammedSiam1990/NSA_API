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

        public void AddItemComponents(ItemComponents itemComponents)
        {
            try
            {
                itemComponents.ItemComponentID = 0;
                itemComponents.CreateDate = DateTime.Now;
                Add(itemComponents);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteItemComponents(long ItemComponentID)
        {
            try
            {
                var ItemComponent = GetMany(e => e.ItemComponentID == ItemComponentID).ToList();
                base.DeleteRange(ItemComponent);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
