using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
            try
            {

                Add(itemUom);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteItemUom(long itemUomId)
        {
            try
            {
                Delete(itemUomId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public ItemUom GetItemUom(long itemUomId)
        {
            try
            {
                var QueryitemUom = base.Table().Where(e => e.ItemUomid == itemUomId).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryitemUom;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<ItemUom> GetItemUoms(Expression<Func<ItemUom, bool>> where)
        {
            try
            {
                return base.GetMany(where).ToList();

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<ItemUom> GetItemUoms()
        {
            try
            {
                var ItemUom = base.Table().Include(e => e.Item).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return ItemUom;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateItemUom(ItemUom itemUom)
        {
            try
            {
                Update(itemUom);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
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
            try
            {
                if (itemUom.Name != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
