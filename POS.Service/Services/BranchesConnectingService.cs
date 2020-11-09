using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class BranchesConnectingService : BaseService, IBranchesConnectingService
    {
        public void SaveBranchesConnecting(List<BranchesConnecting> model)
        {
            PosService.BranchesConnectingRepository.SaveBranchesConnecting(model);
        }
    }
}
