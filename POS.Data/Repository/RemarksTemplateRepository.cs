using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class RemarksTemplateRepository: Repository<GetRemarksTemplate>, IRemarksTemplateRepository
    {
        public RemarksTemplateRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetProcRemarksTemplate(int BrandID)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetRemarksTemplateData @BrandID";
                    var data = DbContext.GetRemarksTemplate.FromSqlRaw(Sql, new SqlParameter("@BrandID", BrandID)).AsEnumerable().FirstOrDefault().RemarksTemplateData;

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
