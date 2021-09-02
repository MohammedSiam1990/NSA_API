using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NSR.Data.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public List<Item> GetItemAll(Expression<Func<Item, bool>> where)
        {
            var QueryItem = base.Table().Where(where)
                .Include(e => e.ItemUoms).ThenInclude(e => e.Skus).ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QueryItem;
        }

        [Obsolete]
        public string GetProcItemData(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetItems @BrandID,@ImageURL";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                    new SqlParameter("@ImageURL", ImageURL ?? (object)DBNull.Value)).
                    AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }

        }
        public void AddItem(Item Item)
        {
            Item.CreateDate = DateTime.Now;
            Add(Item);
        }

        public void UpdateItem(Item Item)
        {
            Item.LastModifyDate = DateTime.Now;
            Update(Item);
        }



        public bool ValidateItem(Item Item)
        {
            if (Item.ItemName != "" || Item.ItemNameAr != "")
                return true;
            else
                return false;
        }

        public int ValidateNameAlreadyExist(Item model)
        {
            var item = new Item();
            item = GetById(e => e.ItemId != model.ItemId && e.StatusId != 3 && e.BrandId == model.BrandId &&
            (e.ItemName == model.ItemName || e.ItemNameAr == model.ItemNameAr ||
            e.MobileName == model.MobileName || e.MobileNameAr == model.MobileNameAr 
            || e.ItemNum == model.ItemNum));

            if (item == null) return 1;

            if (item.ItemName == model.ItemName)
                return -2;
            else if (item.ItemNameAr == model.ItemNameAr)
                return -3;
            else if (item.MobileName == model.MobileName && model.MobileName != "")
                return -4;
            else if (item.MobileNameAr == model.MobileNameAr && model.MobileNameAr != "")
                return -5;
            else if (item.ItemNum == model.ItemNum)
                return -6;

            return 1;

        }

        [Obsolete]
        public string GetUOMName(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC Get_UOM_Name @BrandID";
                DbContext.Database.SetCommandTimeout(0);
                var data = DbContext.JsonData.FromSqlRaw(Sql,
                   new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().Data;

                return data.ToString();

            }

        }

        //public void SaveSalesGroupsItems(List<SalesGroupsItems> model)
        //{
        //    using (var context = new PosDbContext())
        //    {
        //        using (var transaction = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                long SalesGroupItemsID = model.First().SalesGroupItemsID;

        //                var SalesGroupsItems = GetMany().ToList();
        //                base.DeleteRange(SalesGroupsItems);
        //                base.AddRange(model);
        //                context.SaveChanges();
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw new AppException(ex.Message);
        //            }
        //        }
        //    }

        //}
    }
}
