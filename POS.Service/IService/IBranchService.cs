using POS.Entities;
using System.Collections.Generic;

namespace Pos.IService
{
    public interface IBranchService
    {
        int SaveProcBranch(Branches Branch);
        List<GetBranches> GetProcBranches(int BrandID, string ImageURL);
    }
}
