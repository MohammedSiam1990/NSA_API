namespace NSR.Service.IService
{
    public interface IDeleteRecordService
    {
        int DeleteRecord(string TableNme, string TableKey, int RowID, string DeletedBy);
    }
}
