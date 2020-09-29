
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public List<Item> GetItemAll(Expression<Func<Item, bool>> where)
        {
            try
            {
                var QueryItem = base.Table().Where(where)
                    .Include(e => e.ItemUoms).ThenInclude(e => e.Skus).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryItem;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

      public  Item GetItem(Expression<Func<Item, bool>> where)
        {
            try
            {
                var QueryItem = base.Table().Where(where)
                    .Include(e => e.ItemUoms).ThenInclude(e => e.Skus).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryItem;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void AddItem(Item Item)
        {
            try
            {

                Add(Item);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateItem(Item Item)
        {
            try
            {
                Update(Item);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }



        public bool ValidateItem(Item Item)
        {
            try
            {
                if (Item.ItemName != "" || Item.ItemNameAr != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public int ValidateNameAlreadyExist(Expression<Func<Item, bool>> where,Item model)
        {
            var item= GetById(where);

            if (item.ItemName == model.ItemName)
                return -1;

                    return 0;
        }
    }
}
