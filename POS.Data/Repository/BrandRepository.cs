﻿
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class BrandRepository : Repository<Brands>, IBrandRepository
    {
        public BrandRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public int SaveProcBrand(Brands Brands)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
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

                    return result;
                }

                catch (Exception e)
                {
                    Exceptions.ExceptionError.SaveException(e);
                }
                return -1;
            }
        }

        [Obsolete]
        public string GetProcBrand(int CompanyID, string ImageURL)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    object CompId;
                    if (CompanyID == 0)
                        CompId = DBNull.Value;
                    else
                        CompId = CompanyID;

                    string Sql = "EXEC GetBrands @CompanyID,@ImageURL";
                    var data= DbContext.JsonData.FromSql(Sql, new SqlParameter("@CompanyID", CompId),
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
