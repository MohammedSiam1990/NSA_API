using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IDeleteRecordRepository
    {
        int DeleteRecord(string TableNme,string TableKey,int RowID,string DeletedBy);
    }
}
