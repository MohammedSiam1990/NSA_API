using NSR.Entities;

namespace NSR.IService
{
    public interface IBranchService
    {
        int SaveProcBranch(Branches Branch);
        string GetProcBranches(int BrandID, string ImageURL);
    }
}
