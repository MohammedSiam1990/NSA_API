using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Dto;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;

namespace POS.Data.Repository
{
    public class DeleteRecordRepository : Repository<DeleteRecord>, IDeleteRecordRepository
    {
        public DeleteRecordRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public int DeleteRecord(string TableNme, string TableKey, int RowID, string DeletedBy)
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC DeleteRecords @TableNme,@TableKey,@RowID,@DeletedBy";

                    int result = DbContext.Database.ExecuteSqlCommand(Sql, new object[] {
                                                new SqlParameter("@TableNme", TableNme),
                                                new SqlParameter("@TableKey"  ,TableKey),
                                                new SqlParameter("@RowID" ,RowID ),
                                                new SqlParameter("@DeletedBy" ,DeletedBy ),
                                            });

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
