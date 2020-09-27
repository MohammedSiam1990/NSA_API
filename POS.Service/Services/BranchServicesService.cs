using POS.Data.Dto.Procedure;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class BranchServicesService : BaseService, IBranchServicesService
    {
        public List<GetBranchServices> GetProcBranchServices(int BranchID)
        {
            return PosService.BranchServicesRepository.GetProcBranchServices(BranchID);
        }

        public int SaveBranchServices(int BranchID, string ServiceTypeID)
        {
            return PosService.BranchServicesRepository.SaveBranchServices(BranchID, ServiceTypeID);
        }
    }
}
