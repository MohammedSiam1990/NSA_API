using NSR.Data.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IBranchesConnectingService
    {
        void SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID);

    }
}
