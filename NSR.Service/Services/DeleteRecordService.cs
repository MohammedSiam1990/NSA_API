using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
{
    public class DeleteRecordService : BaseService, IDeleteRecordService
    {
        public int DeleteRecord(string TableNme, string TableKey, int RowID, string DeletedBy)
        {
            return PosService.DeleteRecordRepository.DeleteRecord(TableNme, TableKey, RowID, DeletedBy);
        }
    }
}
