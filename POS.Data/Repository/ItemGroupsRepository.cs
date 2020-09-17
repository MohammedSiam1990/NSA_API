using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Account;
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
   public class ItemGroupsRepository : Repository<ItemGroup>, IItemGroupsRepository
    {
        public ItemGroupsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

     
   
        [Obsolete]
        public GetBranches GetProcBranches(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC GetBranches @BrandID,@ImageURL";
                return DbContext.GetBranches.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID),
                                                              new SqlParameter("@ImageURL", ImageURL)
                                                       ).AsEnumerable().FirstOrDefault();
            }
        }

        [Obsolete]
        public int SaveItemGroup(ItemGroup itemGroup)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC SaveItemGroups @ItemGroupID, @ItemGroupNum, @ItemGroupName," +
                    " @ItemGroupNameAr ,@ItemGroupMobileName" + ", @ItemGroupNameMobileAr, @BrandID," +
                    " @StatusID, @TypeID,  @CreateDate, @InsertedBy" + ", @LastModifyDate,  @ModifiedBy";
                int result = DbContext.Database.ExecuteSqlCommand(Sql,
                                   new object[] {
                                      new SqlParameter("@ItemGroupID", itemGroup.ItemGroupId),
                                      new SqlParameter("@ItemGroupNum", itemGroup.ItemGroupNum )   ,
                                      new SqlParameter("@ItemGroupName", itemGroup.ItemGroupName )   ,
                                      new SqlParameter("@ItemGroupNameAr",itemGroup.ItemGroupNameAr )   ,
                                      new SqlParameter("@ItemGroupMobileName",itemGroup.ItemGroupMobileName )    ,
                                      new SqlParameter("@ItemGroupNameMobileAr", itemGroup.ItemGroupNameMobileAr)    ,
                                      new SqlParameter("@BrandID",itemGroup.BrandId )    ,
                                      new SqlParameter("@StatusID",  itemGroup.StatusId )  ,
                                      new SqlParameter("@TypeID",itemGroup.TypeId )    ,
                                      new SqlParameter("@CreateDate", itemGroup.CreateDate )   ,
                                      new SqlParameter("@InsertedBy",  itemGroup.InsertedBy)   ,
                                      new SqlParameter("@LastModifyDate",  itemGroup.LastModifyDate)  ,
                                      new SqlParameter("@ModifiedBy", itemGroup.ModifiedBy)  });
                return result;
            }
          
        }

        [Obsolete]
        public List<GetProcItemGroups> GetProcItemGroups(int BrandID, string ImageName)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC GetItemGroups @BrandID,@ImageURL";
                return DbContext.GetProcItemGroups.FromSql(Sql, new SqlParameter("@BrandID", BrandID),
                                                              new SqlParameter("@ImageURL", ImageName)
                                                       ).ToList();
            }
        }
    }
    
    
}
