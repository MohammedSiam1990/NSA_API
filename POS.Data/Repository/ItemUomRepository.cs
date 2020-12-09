using Microsoft.EntityFrameworkCore;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class ItemUomRepository : Repository<ItemUom>, IItemUomRepository
    {
        public ItemUomRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void AddItemUom(ItemUom itemUom)
        {
            Add(itemUom);
            PosDbContext.SaveChanges();
        }

        public void DeleteItemUom(long itemUomId)
        {
            Delete(itemUomId);
            PosDbContext.SaveChanges();
        }

        public ItemUom GetItemUom(long itemUomId)
        {
            var QueryitemUom = base.Table().Where(e => e.ItemUomid == itemUomId).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QueryitemUom;
        }

        public List<ItemUom> GetItemUoms(Expression<Func<ItemUom, bool>> where)
        {
            return base.GetMany(where).ToList();

        }

        public List<ItemUom> GetItemUoms()
        {
            var ItemUom = base.Table().Include(e => e.Item).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return ItemUom;
        }
        public void UpdateItemUom(ItemUom itemUom)
        {
            Update(itemUom);
            PosDbContext.SaveChanges();
        }

        public bool ValidateCodeorNameAlreadyExist(Expression<Func<ItemUom, bool>> where)
        {
            return Exists(where);
        }
        public bool ValidateCodeorNameArAlreadyExist(Expression<Func<ItemUom, bool>> where)
        {
            return Exists(where);
        }

        public bool ValidateitemUom(ItemUom itemUom)
        {
            if (itemUom.Name != "")
                return true;
            else
                return false;
        }
    }
}
