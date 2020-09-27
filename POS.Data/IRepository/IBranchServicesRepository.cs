using POS.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IBranchServicesRepository
    {
        int SaveBranchServices(int BranchID,string ServiceTypeID);
        List<GetBranchServices> GetProcBranchServices(int BranchID);

    }
}
