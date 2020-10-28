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

        public void AddItemComponents(List<ItemComponents>itemComponents)
        {
            try
            {
                //itemComponents.ItemComponentID = 0;
                //itemComponents.CreateDate = DateTime.Now;
                //Add(itemComponents);
                for (int i = 0; i < itemComponents.Count; ++i)
                {
                    itemComponents[i].CreateDate = DateTime.Now;
                }
                base.AddRange(itemComponents);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteItemComponents(long MainItemID, long MainItemUOMID)
        {
            try
            {
                var ItemComponent = GetMany(e => e.MainItemID == MainItemID && e.MainItemUOMID==MainItemUOMID).ToList();
                base.DeleteRange(ItemComponent);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
