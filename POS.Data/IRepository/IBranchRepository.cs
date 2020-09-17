
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace POS.Data.IRepository
{
    public interface IBranchRepository
    {

        Branches GetBranch(long BranchId);
        List<Branches> GetBranch(Expression<Func<Branches, bool>> where);
        List<Branches> GetBranches();
        bool ValidateBranch(Branches Branch);
        void AddBranch(Branches Branch);
        void UpdateBranch(Branches Branch);
        void DeleteBranch(long BranchId);
        bool ValidateCodeorNameAlreadyExist(Expression<Func<Branches, bool>> where);
        int SaveProcBranch(Branches Branch);
        List<GetBranches> GetProcBranches( int BrandID,string ImageURL );


    }
}