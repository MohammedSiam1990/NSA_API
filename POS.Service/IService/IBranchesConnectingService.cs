using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IBranchesConnectingService
    {
        void SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID);

    }
}
