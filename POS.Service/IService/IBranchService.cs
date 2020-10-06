using POS.Entities;
using System.Collections.Generic;

namespace Pos.IService
{
    public interface IBranchService
    {
        int SaveProcBranch(Branches Branch);
        string GetProcBranches(int BrandID, string ImageURL);
    }
}
