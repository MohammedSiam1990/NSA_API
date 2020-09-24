﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        public TaxRepository(IDatabaseFactory databaseFactory)
               : base(databaseFactory)
        {

        }

        [Obsolete]
        public List<GetTaxes> GetProcTaxes(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetTax @CompanyID";
                return DbContext.GetTaxes.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID)
                                                       ).ToList();
            }
        }

        [Obsolete]
        public int SaveProcTax(Tax tax)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC SaveTax @TaxID , @TaxName, @TaxNameAr, @TaxVal, @StatusID,@SpecialTax"
                        + ", @CompanyID, @InsertedBy, @CreateDate,  @ModifiedBy, @LastModifyDate";
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                       new object[] {
                                      new SqlParameter("@TaxID", tax.TaxID ),
                                      new SqlParameter("@TaxName", tax.TaxName )   ,
                                      new SqlParameter("@TaxNameAr",tax.TaxNameAr )   ,
                                      new SqlParameter("@TaxVal",tax.TaxVal )    ,
                                      new SqlParameter("@StatusID", tax.StatusID )    ,
                                      new SqlParameter("@SpecialTax", tax.SpecialTax )    ,
                                      new SqlParameter("@CompanyID",  tax.CompanyID )  ,
                                      new SqlParameter("@InsertedBy",tax.InsertedBy ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@CreateDate", tax.CreateDate)   ,
                                      new SqlParameter("@ModifiedBy",  tax.ModifiedBy ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@LastModifyDate",  tax.LastModifyDate) }).AsEnumerable().FirstOrDefault().ReturnValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return -1;
            }

        }

    }
 
}
