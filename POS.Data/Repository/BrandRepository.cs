
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Common;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace POS.Data.Repository
{
    public class BrandRepository : Repository<Brands>, IBrandRepository
    {
        public BrandRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<Brands> GetBrandBy(Expression<Func<Brands, bool>> where)
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

        public Brands GetBrand(int BrandId)
        {
            try
            {
                var QueryBrands = base.GetById(e=> e.BrandId == BrandId) ;
                base.DbContext.Dispose();
                base.DbContext = null;
                return QueryBrands;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<Brands> GetBrands()
        {
            // return base.GetAll().ToList();
            var QueryBrands = base.Table().ToList();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QueryBrands;
        }

        public void AddBrand(Brands Brand)
        {
            try
            {

                Add(Brand);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateBrand(Brands Brand)
        {
            try
            {
                Update(Brand);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void DeleteBrand(int BrandId)
        {
            try
            {
                Delete(BrandId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }



        public bool ValidateBrand(Brands Brand)
        {
            try
            {
                if (Brand.BrandName != "" )
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void ResetDefaultBrand(int BrandId ,int CompanyId)
        {
            try
            {
              
                var Brands = GetBrandBy(e=> e.CompanyId == CompanyId).ToList();
              
                   using (var context = new DataContext.PosDbContext())
                   {
                        foreach (var Brand in Brands)
                        {

                            if (Brand.BrandId == BrandId)
                                Brand.IsDefault = true;
                            else
                                Brand.IsDefault = false;

                            context.Brands.Attach(Brand);
                          context.Entry(Brand).Property(e => e.IsDefault).IsModified = true;
                           
                         }

                        context.SaveChanges();
                    }
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public bool ValidateCodeorNameAlreadyExist(Expression<Func<Brands, bool>> where)
        {
            return Exists(where);
        }

        [Obsolete]
        public int SaveProcBrand(Brands Brands)
        {
            using (var DbContext = new PosDbContext())
            {
                try { 
                string Sql = "EXEC SaveBrands @BrandID,@BrandName,@BrandNameAr,@StatusID,@MajorServiceID,@CountryID,@CityID,@CurrencyID,@InsertedBy,@ModifiedBy,@TaxNo,@ImageName,@companyID,@IsDefault";
                    
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql, new object[] {
                                                new SqlParameter("@BrandID", Brands.BrandId),
                                                new SqlParameter("@BrandName"  ,Brands.BrandName),
                                                new SqlParameter("@BrandNameAr" , Brands.BrandNameAr),
                                                new SqlParameter("@StatusId" , Brands.StatusId ?? (object)DBNull.Value),
                                                new SqlParameter("@MajorServiceId" , Brands.MajorServiceId),
                                                new SqlParameter("@CountryId" , Brands.CountryId ?? (object)DBNull.Value),
                                                new SqlParameter("@CityId" , Brands.CityId ?? (object)DBNull.Value),
                                                new SqlParameter("@CurrencyId" , Brands.CurrencyId ?? (object)DBNull.Value),
                                                new SqlParameter("@InsertedBy"  , Brands.InsertedBy ?? (object)DBNull.Value), //  User.Identity.GetUserId(),
                                                new SqlParameter("@ModifiedBy"  , Brands.ModifiedBy ?? (object)DBNull.Value), //  User.Identity.GetUserId(),
                                                new SqlParameter("@TaxNo"   , Brands.TaxNo ?? (object)DBNull.Value),
                                                new SqlParameter("@ImageName"    , Brands.ImageName ?? (object)DBNull.Value),
                                                new SqlParameter("@CompanyId"  , Brands.CompanyId ?? (object)DBNull.Value),
                                                new SqlParameter("@IsDefault"   , Brands.IsDefault ?? (object)DBNull.Value)
                                            }).AsEnumerable().FirstOrDefault().ReturnValue;

                return  result;
                }

                catch(Exception e)
                {
                    Exceptions.ExceptionError.SaveException(e);
                }
                return -1;
            }
        }

        [Obsolete]
        public List<GetBrands> GetProcBrand(int CompanyID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {

                string Sql = "EXEC GetBrands @CompanyID,@ImageURL";
                return DbContext.GetBrands.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID),
                                                              new SqlParameter("@ImageURL", ImageURL)
                                                       ).ToList();
            }
        }

     
    }
}
