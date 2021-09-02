using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IBranchesConnectingRepository
    {
        void SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID);
    }
}
