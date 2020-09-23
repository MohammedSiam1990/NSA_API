using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class DeleteRecordService : BaseService, IDeleteRecordService
    {
        public int DeleteRecord(string TableNme, string TableKey, int RowID, string DeletedBy)
        {
            return PosService.DeleteRecordRepository.DeleteRecord(TableNme, TableKey, RowID, DeletedBy);
        }
    }
}
