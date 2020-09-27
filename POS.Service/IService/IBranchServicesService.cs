using POS.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IBranchServicesService
    {
        int SaveBranchServices(int BranchID, string ServiceTypeID);
        List<GetBranchServices> GetProcBranchServices(int BranchID);

    }
}
