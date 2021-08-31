using NSR.IService;
using NSR.Entities;
using NSR.IService.Base;

namespace NSR.Service
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
