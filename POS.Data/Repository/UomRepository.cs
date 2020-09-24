using Microsoft.Data.SqlClient;
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
    public class UomRepository : Repository<Uom>, IUomRepository
    {
        public UomRepository(IDatabaseFactory databaseFactory)
 : base(databaseFactory)
        {

        }

        [Obsolete]
        public List<GetUoms> GetProcUoms(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetUOM @CompanyID";
                return DbContext.GetUoms.FromSql(Sql, new SqlParameter("@CompanyID", CompanyID)
                                                       ).ToList();
            }
        }

        [Obsolete]
        public int SaveProcUom(Uom uom)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC SaveUOM @UOMID , @UOMName, @UOMNameAr, @Tag, @StatusID" 
                        +", @CompanyID, @InsertedBy, @CreateDate,  @ModifiedBy, @LastModifyDate";
                    int result = DbContext.ReturnResult.FromSqlRaw(Sql,
                                       new object[] {
                                      new SqlParameter("@UOMID", uom.UOMID ),
                                      new SqlParameter("@UOMName", uom.UOMName )   ,
                                      new SqlParameter("@UOMNameAr",uom.UOMNameAr )   ,
                                      new SqlParameter("@Tag",uom.Tag )    ,
                                      new SqlParameter("@StatusID", uom.StatusID )    ,
                                      new SqlParameter("@CompanyID",  uom.CompanyID )  ,
                                      new SqlParameter("@InsertedBy",uom.InsertedBy ?? (object)DBNull.Value)    ,
                                      new SqlParameter("@CreateDate", uom.CreateDate)   ,
                                      new SqlParameter("@ModifiedBy",  uom.ModifiedBy ?? (object)DBNull.Value)   ,
                                      new SqlParameter("@LastModifyDate",  uom.LastModifyDate) }).AsEnumerable().FirstOrDefault().ReturnValue;
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
