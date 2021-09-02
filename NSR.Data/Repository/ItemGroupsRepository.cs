using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Linq;

namespace NSR.Data.Repository
{
    public class ItemGroupsRepository : Repository<ItemGroup>, IItemGroupsRepository
    {
        public ItemGroupsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }


        [Obsolete]
        public int SaveItemGroup(ItemGroup itemGroup)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC SaveItemGroups @ItemGroupID, @ItemGroupNum, @ItemGroupName," +
                    " @ItemGroupNameAr ,@ItemGroupMobileName" + ", @ItemGroupMobileNameAr, @BrandID," +
                    " @StatusID, @TypeID, @InsertedBy" + ",@ModifiedBy, @GroupColor,@ImageName";
                int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                   new object[] {
                                      new SqlParameter("@ItemGroupID", itemGroup.ItemGroupId),
                                      new SqlParameter("@ItemGroupNum", itemGroup.ItemGroupNum )   ,
                                      new SqlParameter("@ItemGroupName", itemGroup.ItemGroupName )   ,
                                      new SqlParameter("@ItemGroupNameAr",itemGroup.ItemGroupNameAr )   ,
                                      new SqlParameter("@ItemGroupMobileName",itemGroup.ItemGroupMobileName )    ,
                                      new SqlParameter("@ItemGroupMobileNameAr", itemGroup.ItemGroupMobileNameAr)    ,
                                      new SqlParameter("@BrandID",itemGroup.BrandId )    ,
                                      new SqlParameter("@StatusID",  itemGroup.StatusId ?? (object)DBNull.Value)  ,
                                      new SqlParameter("@TypeID",itemGroup.TypeId ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@InsertedBy",  itemGroup.InsertedBy ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@LastModifyDate",  itemGroup.LastModifyDate ?? (object)DBNull.Value)  ,
                                      new SqlParameter("@ModifiedBy", itemGroup.ModifiedBy ?? (object)DBNull.Value),
                                      new SqlParameter("@GroupColor", itemGroup.GroupColor ?? (object)DBNull.Value),
                                      new SqlParameter("@ImageName", itemGroup.ImageName ?? (object)DBNull.Value)
                                   }).AsEnumerable().FirstOrDefault().ReturnValue;
                return result;

            }

        }

        [Obsolete]
        public string GetProcItemGroups(int BrandID, string ImageName)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC GetItemGroups @BrandID,@ImageURL";
                var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@BrandID", BrandID),
                                                              new SqlParameter("@ImageURL", ImageName)
                                                       ).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }
    }


}
