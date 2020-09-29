using Pos.IService;
using POS.Entities;
using POS.IService.Base;
using System.Collections.Generic;

namespace Pos.Service
{
    public class BranchService : BaseService, IBranchService
    {

        public int SaveProcBranch(Branches Branch)
        {
            return PosService.BranchRepository.SaveProcBranch(Branch);
        }

        public List<GetBranches> GetProcBranches(int BrandID, string ImageURL)
        {
            return PosService.BranchRepository.GetProcBranches(BrandID, ImageURL);
        }
    }
}
