using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Linq;

namespace POS.Data.Repository
{
    public class BranchRepository : Repository<Branches>, IBranchRepository
    {
        public BranchRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public int SaveProcBranch(Branches Branch)
        {

            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC SaveBranches @BranchID , @BranchNum, @BranchName, @BranchNameAr, @BrandID, @StatusID, @TypeID, @Address," +
                    "  @CountryID, @CityID, @CurrencyID,  @ImageName, @InsertedBy, @ModifiedBy, " +
                    "@Latitude, @Longitude,@ServiceTypeID,@ApprovedBy,@ApprovedDate,@DistrictID ";
                int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                   new object[] {
                                      new SqlParameter("@BranchId", Branch.BranchId ),
                                      new SqlParameter("@BranchNum", Branch.BranchNum )   ,
                                      new SqlParameter("@BranchName",Branch.BranchName )   ,
                                      new SqlParameter("@BranchNameAr",Branch.BranchNameAr )    ,
                                      new SqlParameter("@BrandId", Branch.BrandId )    ,
                                      new SqlParameter("@StatusId",Branch.StatusId ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@TypeId",  Branch.TypeId )  ,
                                      new SqlParameter("@Address",Branch.Address ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@CountryId", Branch.CountryId ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@CityId",  Branch.CityId ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@CurrencyId",  Branch.CurrencyId ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@ImageName", Branch.ImageName ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@InsertedBy",  Branch.InsertedBy ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@ModifiedBy", Branch.ModifiedBy ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@Latitude",Branch.Latitude ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@Longitude",Branch.Longitude  ?? (object)DBNull.Value),
                                      new SqlParameter("@ServiceTypeID",Branch.ServiceTypeID  ?? (object)DBNull.Value),
                                      new SqlParameter("@ApprovedBy",Branch.ApprovedBy  ?? (object)DBNull.Value),
                                      new SqlParameter("@ApprovedDate",Branch.ApprovedDate  ?? (object)DBNull.Value),
                                      new SqlParameter("@DistrictID",Branch.DistrictID  ?? (object)DBNull.Value)
                                   }).AsEnumerable().FirstOrDefault().ReturnValue;
                return result;
            }


        }
        [Obsolete]
        public string GetProcBranches(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    object brandId;
                    if (BrandID == 0)
                        brandId = DBNull.Value;
                    else
                        brandId = BrandID;

                    string Sql = "EXEC GetBranches @BrandID,@ImageURL";
                    var data = DbContext.JsonData.FromSql(Sql, new SqlParameter("@BrandID", brandId),
                                                             new SqlParameter("@ImageURL", ImageURL)).AsEnumerable().FirstOrDefault().Data;
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
