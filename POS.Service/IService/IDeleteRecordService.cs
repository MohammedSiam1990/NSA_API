using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IDeleteRecordService
    {
        int DeleteRecord(string TableNme, string TableKey, int RowID, string DeletedBy);
    }
}
