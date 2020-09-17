using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static POS.Common.Enums;

namespace Pos.IService
{
  public  interface IBranchService
    {
        Branches GetBranch(long BranchId);
        List<Branches> GetBranchesByCompany(int CompanyId);
        List<Branches> GetBranchesByBrand(int BrandId);
        List<Branches> GetBranches();
        bool ValidateBranch(Branches Branch);
        void AddBranch(Branches Branch);
        void UpdateBranch(Branches Branch);
        void DeleteBranch(long BranchId);
        bool ValidateCodeorNameAlreadyExist(long BranchId, int CompanyId, string BranchCode, string BranchName);

        int SaveProcBranch(Branches Branch);
       List<GetBranches>  GetProcBranches(int BrandID, string ImageURL);
    }
}
