
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using POS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Drawing;
using static POS.Common.Enums;
using POS.Data.DataContext;
using Microsoft.Data.SqlClient;

namespace POS.Data.Repository
{
    public class BranchRepository : Repository<Branches>, IBranchRepository
    {
        public BranchRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<Branches> GetBranch(Expression<Func<Branches, bool>> where)
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
        public Branches GetBranch(long BranchId)
        {
            try
            {
                var QueryBranch = base.Table().Where(e=>e.BranchId==BranchId).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryBranch;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<Branches> GetBranches()
        {
            try
            {
                var QueryCity = base.Table().Include(e => e.City).ToList();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryCity;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void AddBranch(Branches Branch)
        {
            try
            {

                Add(Branch);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateBranch(Branches Branch)
        {
            try
            {
                Update(Branch);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteBranch(long BranchId)
        {
            try
            {
                Delete(BranchId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public bool ValidateBranch(Branches Branch)
        {
            try
            {
                if (Branch.BranchName != ""  )
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public bool ValidateCodeorNameAlreadyExist(Expression<Func<Branches, bool>> where)
        {
            return Exists(where);
        }

        [Obsolete]
        public int SaveProcBranch(Branches Branch)
        {

            using (var DbContext = new PosDbContext())
            {
                
                    string Sql = "EXEC SaveBranches @BranchID , @BranchNum, @BranchName, @BranchNameAr, @BrandID, @StatusID, @TypeID, @Address,  @CountryID, @CityID, @CurrencyID,  @ImageName, @InsertedBy, @ModifiedBy, @Latitude, @Longitude ";
                   int result = DbContext.Database.ExecuteSqlCommand(Sql ,
                                      new object[] {
                                      new SqlParameter("@BranchId", Branch.BranchId ),
                                      new SqlParameter("@BranchNum", Branch.BranchNum )   ,
                                      new SqlParameter("@BranchName",Branch.BranchName )   ,
                                      new SqlParameter("@BranchNameAr",Branch.BranchNameAr )    ,
                                      new SqlParameter("@BrandId", Branch.BrandId)    ,
                                      new SqlParameter("@StatusId",Branch.StatusId )    ,
                                      new SqlParameter("@TypeId",  Branch.TypeId )  ,
                                      new SqlParameter("@Address",Branch.Address )    ,
                                      new SqlParameter("@CountryId", Branch.CountryId )   ,
                                      new SqlParameter("@CityId",  Branch.CityId)   ,
                                      new SqlParameter("@CurrencyId",  Branch.CurrencyId)   ,
                                      new SqlParameter("@ImageName", Branch.ImageName)    ,
                                      new SqlParameter("@InsertedBy",  Branch.InsertedBy)   , 
                                      new SqlParameter("@ModifiedBy", Branch.ModifiedBy)    , 
                                      new SqlParameter("@Latitude",Branch.Latitude )    ,
                                      new SqlParameter("@Longitude",Branch.Longitude  )    });
                return result;
            }
         
        }
        [Obsolete]
        public List<GetBranches> GetProcBranches(int BrandID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC GetBranches @BrandID,@ImageURL";
                return DbContext.GetBranches.FromSql(Sql,  new SqlParameter("@BrandID", BrandID),
                                                              new SqlParameter("@ImageURL", ImageURL)
                                                       ).ToList();
            }
        }
    }
}
