using Pos.IService;
using POS.Entities;
using POS.IService.Base;

namespace Pos.Service
{
    public class BranchService : BaseService, IBranchService
    {
        public int SaveProcBranch(Branches Branch)
        {
            return PosService.BranchRepository.SaveProcBranch(Branch);
        }

        public string GetProcBranches(int BrandID, string ImageURL)
        {
            return PosService.BranchRepository.GetProcBranches(BrandID, ImageURL);
        }
    }
}
