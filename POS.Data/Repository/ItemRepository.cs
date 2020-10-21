
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

        [Obsolete]
        public string GetProcItemData(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetItems @BrandID,@ImageURL";
                    var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                        new SqlParameter("@ImageURL", ImageURL ?? (object)DBNull.Value)).AsEnumerable().FirstOrDefault().Data;

                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }
        public void AddItem(Item Item)
        {
            try
            {
                Item.CreateDate = DateTime.Now;
                Add(Item);
              //  PosDbContext.SaveChanges();
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
                Item.LastModifyDate = DateTime.Now;
                Update(Item);
               // PosDbContext.SaveChanges();
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

        public int ValidateNameAlreadyExist(Item model)
        {
            var item = new Item();
            if (model.MobileNameAr == "" && model.MobileName=="")
            {
                 item = GetById(e => e.ItemId != model.ItemId && e.StatusId != 3 && e.BrandId == model.BrandId && (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemName  || e.ItemNum == model.ItemNum));
            }
            else if(model.MobileNameAr == "")
            {
                item = GetById(e => e.ItemId != model.ItemId && e.StatusId != 3 && e.BrandId == model.BrandId && (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemName || e.MobileName == model.MobileName ||  e.ItemNum == model.ItemNum));

            }
            else if(model.MobileName == "")
            {
                item = GetById(e => e.ItemId != model.ItemId && e.StatusId != 3 && e.BrandId == model.BrandId && (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemName || e.ItemNum == model.ItemNum));

            }
            else
            {
                item = GetById(e => e.ItemId != model.ItemId && e.StatusId != 3 && e.BrandId == model.BrandId && (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemName || e.MobileName == model.MobileName || e.MobileNameAr == model.MobileNameAr || e.ItemNum == model.ItemNum));
            }

            if (item == null) return 1;

            if (item.ItemName == model.ItemName )
             return -2;
            else if (item.ItemNameAr == model.ItemNameAr )
             return -3;
            else if(item.MobileName == model.MobileName)
             return -4;
            else if(item.MobileNameAr == model.MobileNameAr)
            return -5;
            else if(item.ItemNum == model.ItemNum)
            return -6;

            return 1;
                    
        }

        [Obsolete]
        public string GetUOMName(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC Get_UOM_Name @BrandID";
                    DbContext.Database.SetCommandTimeout(0);
                    var data = DbContext.JsonData.FromSqlRaw(Sql,
                       new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().Data;

                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }

        }
    }
}
